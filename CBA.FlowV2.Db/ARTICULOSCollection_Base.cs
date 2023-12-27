// <fileinfo name="ARTICULOSCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string CODIGO_EMPRESAColumnName = "CODIGO_EMPRESA";
		public const string CODIGO_PROVEEDORColumnName = "CODIGO_PROVEEDOR";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string CODIGO_BARRAS_EMPRESAColumnName = "CODIGO_BARRAS_EMPRESA";
		public const string CODIGO_BARRAS_PROVEEDORColumnName = "CODIGO_BARRAS_PROVEEDOR";
		public const string DESCRIPCION_INTERNAColumnName = "DESCRIPCION_INTERNA";
		public const string DESCRIPCION_IMPRESIONColumnName = "DESCRIPCION_IMPRESION";
		public const string DESCRIPCION_PROVEEDORColumnName = "DESCRIPCION_PROVEEDOR";
		public const string CODIGO_PRESENTACION_IDColumnName = "CODIGO_PRESENTACION_ID";
		public const string CODIGO_EMPAQUE_IDColumnName = "CODIGO_EMPAQUE_ID";
		public const string CODIGO_COLOR_IDColumnName = "CODIGO_COLOR_ID";
		public const string CODIGO_TALLE_IDColumnName = "CODIGO_TALLE_ID";
		public const string CODIGO_CATALOGO_PROVEEDORColumnName = "CODIGO_CATALOGO_PROVEEDOR";
		public const string IMPORTADOColumnName = "IMPORTADO";
		public const string PRODUCCION_INTERNAColumnName = "PRODUCCION_INTERNA";
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
		public const string ES_TRAZABLEColumnName = "ES_TRAZABLE";
		public const string PARA_VENTAColumnName = "PARA_VENTA";
		public const string ES_COMBOColumnName = "ES_COMBO";
		public const string ARTICULO_LINEA_IDColumnName = "ARTICULO_LINEA_ID";
		public const string PROCEDENCIAColumnName = "PROCEDENCIA";
		public const string GENEROColumnName = "GENERO";
		public const string ARTICULO_PADRE_IDColumnName = "ARTICULO_PADRE_ID";
		public const string NO_REPONERColumnName = "NO_REPONER";
		public const string ES_COMBO_ABIERTOColumnName = "ES_COMBO_ABIERTO";
		public const string ES_MODIFICABLEColumnName = "ES_MODIFICABLE";
		public const string ARTICULO_MARCA_IDColumnName = "ARTICULO_MARCA_ID";
		public const string RECARGO_FINANCIEROColumnName = "RECARGO_FINANCIERO";
		public const string NOTA_CREDITO_IDColumnName = "NOTA_CREDITO_ID";
		public const string CONTROLAR_PRECIOColumnName = "CONTROLAR_PRECIO";
		public const string COSTO_BASE_MONTOColumnName = "COSTO_BASE_MONTO";
		public const string COSTO_BASE_MONEDA_IDColumnName = "COSTO_BASE_MONEDA_ID";
		public const string COSTO_BASE_COTIZACIONColumnName = "COSTO_BASE_COTIZACION";
		public const string ES_USADOColumnName = "ES_USADO";
		public const string ES_DANHADOColumnName = "ES_DANHADO";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string ES_OBSOLETOColumnName = "ES_OBSOLETO";
		public const string ES_COMBO_REPRESENTATIVOColumnName = "ES_COMBO_REPRESENTATIVO";
		public const string DESCRIPCION_CATALOGOColumnName = "DESCRIPCION_CATALOGO";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string IMAGEN_PATH_TMPColumnName = "IMAGEN_PATH_TMP";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string RETENCIONColumnName = "RETENCION";
		public const string AUTONUMERACIONES_IDColumnName = "AUTONUMERACIONES_ID";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string CANTIDAD_MAXIMAColumnName = "CANTIDAD_MAXIMA";
		public const string UNIDAD_MEDIDA_CONTROLColumnName = "UNIDAD_MEDIDA_CONTROL";
		public const string CANTIDAD_MAYORISTAColumnName = "CANTIDAD_MAYORISTA";
		public const string PARA_COMPRAColumnName = "PARA_COMPRA";
		public const string ES_FORMULAColumnName = "ES_FORMULA";
		public const string TIPO_FORMULAColumnName = "TIPO_FORMULA";
		public const string CANTIDAD_MINIMA_PRODUCCIONColumnName = "CANTIDAD_MINIMA_PRODUCCION";
		public const string CANTIDAD_MAXIMA_PRODUCCIONColumnName = "CANTIDAD_MAXIMA_PRODUCCION";
		public const string PORCENTAJE_PRECIO_PADREColumnName = "PORCENTAJE_PRECIO_PADRE";
		public const string MONTO_PRECIO_PADREColumnName = "MONTO_PRECIO_PADRE";
		public const string CODIGO_BALANZAColumnName = "CODIGO_BALANZA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOSCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this table belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>ARTICULOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByCOSTO_BASE_MONEDA_ID(decimal costo_base_moneda_id)
		{
			return GetByCOSTO_BASE_MONEDA_ID(costo_base_moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <param name="costo_base_moneda_idNull">true if the method ignores the costo_base_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByCOSTO_BASE_MONEDA_ID(decimal costo_base_moneda_id, bool costo_base_moneda_idNull)
		{
			return MapRecords(CreateGetByCOSTO_BASE_MONEDA_IDCommand(costo_base_moneda_id, costo_base_moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOSTO_BASE_MONEDA_IDAsDataTable(decimal costo_base_moneda_id)
		{
			return GetByCOSTO_BASE_MONEDA_IDAsDataTable(costo_base_moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <param name="costo_base_moneda_idNull">true if the method ignores the costo_base_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTO_BASE_MONEDA_IDAsDataTable(decimal costo_base_moneda_id, bool costo_base_moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOSTO_BASE_MONEDA_IDCommand(costo_base_moneda_id, costo_base_moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <param name="costo_base_moneda_idNull">true if the method ignores the costo_base_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTO_BASE_MONEDA_IDCommand(decimal costo_base_moneda_id, bool costo_base_moneda_idNull)
		{
			string whereSql = "";
			if(costo_base_moneda_idNull)
				whereSql += "COSTO_BASE_MONEDA_ID IS NULL";
			else
				whereSql += "COSTO_BASE_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_BASE_MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!costo_base_moneda_idNull)
				AddParameter(cmd, "COSTO_BASE_MONEDA_ID", costo_base_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_IDAsDataTable(decimal activo_id, bool activo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByARTICULO_PADRE_ID(decimal articulo_padre_id)
		{
			return GetByARTICULO_PADRE_ID(articulo_padre_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <param name="articulo_padre_idNull">true if the method ignores the articulo_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByARTICULO_PADRE_ID(decimal articulo_padre_id, bool articulo_padre_idNull)
		{
			return MapRecords(CreateGetByARTICULO_PADRE_IDCommand(articulo_padre_id, articulo_padre_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_PADRE_IDAsDataTable(decimal articulo_padre_id)
		{
			return GetByARTICULO_PADRE_IDAsDataTable(articulo_padre_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <param name="articulo_padre_idNull">true if the method ignores the articulo_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_PADRE_IDAsDataTable(decimal articulo_padre_id, bool articulo_padre_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_PADRE_IDCommand(articulo_padre_id, articulo_padre_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <param name="articulo_padre_idNull">true if the method ignores the articulo_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_PADRE_IDCommand(decimal articulo_padre_id, bool articulo_padre_idNull)
		{
			string whereSql = "";
			if(articulo_padre_idNull)
				whereSql += "ARTICULO_PADRE_ID IS NULL";
			else
				whereSql += "ARTICULO_PADRE_ID=" + _db.CreateSqlParameterName("ARTICULO_PADRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_padre_idNull)
				AddParameter(cmd, "ARTICULO_PADRE_ID", articulo_padre_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByAUTONUMERACIONES_ID(decimal autonumeraciones_id)
		{
			return GetByAUTONUMERACIONES_ID(autonumeraciones_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <param name="autonumeraciones_idNull">true if the method ignores the autonumeraciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByAUTONUMERACIONES_ID(decimal autonumeraciones_id, bool autonumeraciones_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACIONES_IDCommand(autonumeraciones_id, autonumeraciones_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACIONES_IDAsDataTable(decimal autonumeraciones_id)
		{
			return GetByAUTONUMERACIONES_IDAsDataTable(autonumeraciones_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <param name="autonumeraciones_idNull">true if the method ignores the autonumeraciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACIONES_IDAsDataTable(decimal autonumeraciones_id, bool autonumeraciones_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACIONES_IDCommand(autonumeraciones_id, autonumeraciones_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <param name="autonumeraciones_idNull">true if the method ignores the autonumeraciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACIONES_IDCommand(decimal autonumeraciones_id, bool autonumeraciones_idNull)
		{
			string whereSql = "";
			if(autonumeraciones_idNull)
				whereSql += "AUTONUMERACIONES_ID IS NULL";
			else
				whereSql += "AUTONUMERACIONES_ID=" + _db.CreateSqlParameterName("AUTONUMERACIONES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeraciones_idNull)
				AddParameter(cmd, "AUTONUMERACIONES_ID", autonumeraciones_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByCODIGO_COLOR_ID(decimal codigo_color_id)
		{
			return GetByCODIGO_COLOR_ID(codigo_color_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <param name="codigo_color_idNull">true if the method ignores the codigo_color_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByCODIGO_COLOR_ID(decimal codigo_color_id, bool codigo_color_idNull)
		{
			return MapRecords(CreateGetByCODIGO_COLOR_IDCommand(codigo_color_id, codigo_color_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCODIGO_COLOR_IDAsDataTable(decimal codigo_color_id)
		{
			return GetByCODIGO_COLOR_IDAsDataTable(codigo_color_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <param name="codigo_color_idNull">true if the method ignores the codigo_color_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCODIGO_COLOR_IDAsDataTable(decimal codigo_color_id, bool codigo_color_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCODIGO_COLOR_IDCommand(codigo_color_id, codigo_color_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <param name="codigo_color_idNull">true if the method ignores the codigo_color_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCODIGO_COLOR_IDCommand(decimal codigo_color_id, bool codigo_color_idNull)
		{
			string whereSql = "";
			if(codigo_color_idNull)
				whereSql += "CODIGO_COLOR_ID IS NULL";
			else
				whereSql += "CODIGO_COLOR_ID=" + _db.CreateSqlParameterName("CODIGO_COLOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!codigo_color_idNull)
				AddParameter(cmd, "CODIGO_COLOR_ID", codigo_color_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByCODIGO_EMPAQUE_ID(decimal codigo_empaque_id)
		{
			return GetByCODIGO_EMPAQUE_ID(codigo_empaque_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <param name="codigo_empaque_idNull">true if the method ignores the codigo_empaque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByCODIGO_EMPAQUE_ID(decimal codigo_empaque_id, bool codigo_empaque_idNull)
		{
			return MapRecords(CreateGetByCODIGO_EMPAQUE_IDCommand(codigo_empaque_id, codigo_empaque_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCODIGO_EMPAQUE_IDAsDataTable(decimal codigo_empaque_id)
		{
			return GetByCODIGO_EMPAQUE_IDAsDataTable(codigo_empaque_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <param name="codigo_empaque_idNull">true if the method ignores the codigo_empaque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCODIGO_EMPAQUE_IDAsDataTable(decimal codigo_empaque_id, bool codigo_empaque_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCODIGO_EMPAQUE_IDCommand(codigo_empaque_id, codigo_empaque_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <param name="codigo_empaque_idNull">true if the method ignores the codigo_empaque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCODIGO_EMPAQUE_IDCommand(decimal codigo_empaque_id, bool codigo_empaque_idNull)
		{
			string whereSql = "";
			if(codigo_empaque_idNull)
				whereSql += "CODIGO_EMPAQUE_ID IS NULL";
			else
				whereSql += "CODIGO_EMPAQUE_ID=" + _db.CreateSqlParameterName("CODIGO_EMPAQUE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!codigo_empaque_idNull)
				AddParameter(cmd, "CODIGO_EMPAQUE_ID", codigo_empaque_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByCODIGO_PRESENTACION_ID(decimal codigo_presentacion_id)
		{
			return GetByCODIGO_PRESENTACION_ID(codigo_presentacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <param name="codigo_presentacion_idNull">true if the method ignores the codigo_presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByCODIGO_PRESENTACION_ID(decimal codigo_presentacion_id, bool codigo_presentacion_idNull)
		{
			return MapRecords(CreateGetByCODIGO_PRESENTACION_IDCommand(codigo_presentacion_id, codigo_presentacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCODIGO_PRESENTACION_IDAsDataTable(decimal codigo_presentacion_id)
		{
			return GetByCODIGO_PRESENTACION_IDAsDataTable(codigo_presentacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <param name="codigo_presentacion_idNull">true if the method ignores the codigo_presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCODIGO_PRESENTACION_IDAsDataTable(decimal codigo_presentacion_id, bool codigo_presentacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCODIGO_PRESENTACION_IDCommand(codigo_presentacion_id, codigo_presentacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <param name="codigo_presentacion_idNull">true if the method ignores the codigo_presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCODIGO_PRESENTACION_IDCommand(decimal codigo_presentacion_id, bool codigo_presentacion_idNull)
		{
			string whereSql = "";
			if(codigo_presentacion_idNull)
				whereSql += "CODIGO_PRESENTACION_ID IS NULL";
			else
				whereSql += "CODIGO_PRESENTACION_ID=" + _db.CreateSqlParameterName("CODIGO_PRESENTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!codigo_presentacion_idNull)
				AddParameter(cmd, "CODIGO_PRESENTACION_ID", codigo_presentacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByCODIGO_TALLE_ID(decimal codigo_talle_id)
		{
			return GetByCODIGO_TALLE_ID(codigo_talle_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <param name="codigo_talle_idNull">true if the method ignores the codigo_talle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByCODIGO_TALLE_ID(decimal codigo_talle_id, bool codigo_talle_idNull)
		{
			return MapRecords(CreateGetByCODIGO_TALLE_IDCommand(codigo_talle_id, codigo_talle_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCODIGO_TALLE_IDAsDataTable(decimal codigo_talle_id)
		{
			return GetByCODIGO_TALLE_IDAsDataTable(codigo_talle_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <param name="codigo_talle_idNull">true if the method ignores the codigo_talle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCODIGO_TALLE_IDAsDataTable(decimal codigo_talle_id, bool codigo_talle_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCODIGO_TALLE_IDCommand(codigo_talle_id, codigo_talle_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <param name="codigo_talle_idNull">true if the method ignores the codigo_talle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCODIGO_TALLE_IDCommand(decimal codigo_talle_id, bool codigo_talle_idNull)
		{
			string whereSql = "";
			if(codigo_talle_idNull)
				whereSql += "CODIGO_TALLE_ID IS NULL";
			else
				whereSql += "CODIGO_TALLE_ID=" + _db.CreateSqlParameterName("CODIGO_TALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!codigo_talle_idNull)
				AddParameter(cmd, "CODIGO_TALLE_ID", codigo_talle_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByCOMBO_ID(decimal combo_id)
		{
			return GetByCOMBO_ID(combo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <param name="combo_idNull">true if the method ignores the combo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByCOMBO_ID(decimal combo_id, bool combo_idNull)
		{
			return MapRecords(CreateGetByCOMBO_IDCommand(combo_id, combo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOMBO_IDAsDataTable(decimal combo_id)
		{
			return GetByCOMBO_IDAsDataTable(combo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <param name="combo_idNull">true if the method ignores the combo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOMBO_IDAsDataTable(decimal combo_id, bool combo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOMBO_IDCommand(combo_id, combo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <param name="combo_idNull">true if the method ignores the combo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOMBO_IDCommand(decimal combo_id, bool combo_idNull)
		{
			string whereSql = "";
			if(combo_idNull)
				whereSql += "COMBO_ID IS NULL";
			else
				whereSql += "COMBO_ID=" + _db.CreateSqlParameterName("COMBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!combo_idNull)
				AddParameter(cmd, "COMBO_ID", combo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByFAMILIA_ID(decimal familia_id)
		{
			return GetByFAMILIA_ID(familia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByFAMILIA_ID(decimal familia_id, bool familia_idNull)
		{
			return MapRecords(CreateGetByFAMILIA_IDCommand(familia_id, familia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFAMILIA_IDAsDataTable(decimal familia_id)
		{
			return GetByFAMILIA_IDAsDataTable(familia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFAMILIA_IDAsDataTable(decimal familia_id, bool familia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFAMILIA_IDCommand(familia_id, familia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFAMILIA_IDCommand(decimal familia_id, bool familia_idNull)
		{
			string whereSql = "";
			if(familia_idNull)
				whereSql += "FAMILIA_ID IS NULL";
			else
				whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!familia_idNull)
				AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByGRUPO_ID(decimal grupo_id)
		{
			return GetByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecords(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id)
		{
			return GetByGRUPO_IDAsDataTable(grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPUESTO_IDCommand(decimal impuesto_id)
		{
			string whereSql = "";
			whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByIMPUESTO_COMPRA_ID(decimal impuesto_compra_id)
		{
			return GetByIMPUESTO_COMPRA_ID(impuesto_compra_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <param name="impuesto_compra_idNull">true if the method ignores the impuesto_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByIMPUESTO_COMPRA_ID(decimal impuesto_compra_id, bool impuesto_compra_idNull)
		{
			return MapRecords(CreateGetByIMPUESTO_COMPRA_IDCommand(impuesto_compra_id, impuesto_compra_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPUESTO_COMPRA_IDAsDataTable(decimal impuesto_compra_id)
		{
			return GetByIMPUESTO_COMPRA_IDAsDataTable(impuesto_compra_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <param name="impuesto_compra_idNull">true if the method ignores the impuesto_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_COMPRA_IDAsDataTable(decimal impuesto_compra_id, bool impuesto_compra_idNull)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_COMPRA_IDCommand(impuesto_compra_id, impuesto_compra_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <param name="impuesto_compra_idNull">true if the method ignores the impuesto_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPUESTO_COMPRA_IDCommand(decimal impuesto_compra_id, bool impuesto_compra_idNull)
		{
			string whereSql = "";
			if(impuesto_compra_idNull)
				whereSql += "IMPUESTO_COMPRA_ID IS NULL";
			else
				whereSql += "IMPUESTO_COMPRA_ID=" + _db.CreateSqlParameterName("IMPUESTO_COMPRA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!impuesto_compra_idNull)
				AddParameter(cmd, "IMPUESTO_COMPRA_ID", impuesto_compra_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByARTICULO_LINEA_ID(decimal articulo_linea_id)
		{
			return GetByARTICULO_LINEA_ID(articulo_linea_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <param name="articulo_linea_idNull">true if the method ignores the articulo_linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByARTICULO_LINEA_ID(decimal articulo_linea_id, bool articulo_linea_idNull)
		{
			return MapRecords(CreateGetByARTICULO_LINEA_IDCommand(articulo_linea_id, articulo_linea_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_LINEA_IDAsDataTable(decimal articulo_linea_id)
		{
			return GetByARTICULO_LINEA_IDAsDataTable(articulo_linea_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <param name="articulo_linea_idNull">true if the method ignores the articulo_linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_LINEA_IDAsDataTable(decimal articulo_linea_id, bool articulo_linea_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_LINEA_IDCommand(articulo_linea_id, articulo_linea_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <param name="articulo_linea_idNull">true if the method ignores the articulo_linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_LINEA_IDCommand(decimal articulo_linea_id, bool articulo_linea_idNull)
		{
			string whereSql = "";
			if(articulo_linea_idNull)
				whereSql += "ARTICULO_LINEA_ID IS NULL";
			else
				whereSql += "ARTICULO_LINEA_ID=" + _db.CreateSqlParameterName("ARTICULO_LINEA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_linea_idNull)
				AddParameter(cmd, "ARTICULO_LINEA_ID", articulo_linea_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByARTICULO_MARCA_ID(decimal articulo_marca_id)
		{
			return GetByARTICULO_MARCA_ID(articulo_marca_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <param name="articulo_marca_idNull">true if the method ignores the articulo_marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByARTICULO_MARCA_ID(decimal articulo_marca_id, bool articulo_marca_idNull)
		{
			return MapRecords(CreateGetByARTICULO_MARCA_IDCommand(articulo_marca_id, articulo_marca_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_MARCA_IDAsDataTable(decimal articulo_marca_id)
		{
			return GetByARTICULO_MARCA_IDAsDataTable(articulo_marca_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <param name="articulo_marca_idNull">true if the method ignores the articulo_marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_MARCA_IDAsDataTable(decimal articulo_marca_id, bool articulo_marca_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_MARCA_IDCommand(articulo_marca_id, articulo_marca_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <param name="articulo_marca_idNull">true if the method ignores the articulo_marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_MARCA_IDCommand(decimal articulo_marca_id, bool articulo_marca_idNull)
		{
			string whereSql = "";
			if(articulo_marca_idNull)
				whereSql += "ARTICULO_MARCA_ID IS NULL";
			else
				whereSql += "ARTICULO_MARCA_ID=" + _db.CreateSqlParameterName("ARTICULO_MARCA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_marca_idNull)
				AddParameter(cmd, "ARTICULO_MARCA_ID", articulo_marca_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByNOTA_CREDITO_ID(decimal nota_credito_id)
		{
			return GetByNOTA_CREDITO_ID(nota_credito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByNOTA_CREDITO_ID(decimal nota_credito_id, bool nota_credito_idNull)
		{
			return MapRecords(CreateGetByNOTA_CREDITO_IDCommand(nota_credito_id, nota_credito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNOTA_CREDITO_IDAsDataTable(decimal nota_credito_id)
		{
			return GetByNOTA_CREDITO_IDAsDataTable(nota_credito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNOTA_CREDITO_IDAsDataTable(decimal nota_credito_id, bool nota_credito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNOTA_CREDITO_IDCommand(nota_credito_id, nota_credito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNOTA_CREDITO_IDCommand(decimal nota_credito_id, bool nota_credito_idNull)
		{
			string whereSql = "";
			if(nota_credito_idNull)
				whereSql += "NOTA_CREDITO_ID IS NULL";
			else
				whereSql += "NOTA_CREDITO_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nota_credito_idNull)
				AddParameter(cmd, "NOTA_CREDITO_ID", nota_credito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByPROCEDENCIA(decimal procedencia)
		{
			return GetByPROCEDENCIA(procedencia, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <param name="procedenciaNull">true if the method ignores the procedencia
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByPROCEDENCIA(decimal procedencia, bool procedenciaNull)
		{
			return MapRecords(CreateGetByPROCEDENCIACommand(procedencia, procedenciaNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROCEDENCIAAsDataTable(decimal procedencia)
		{
			return GetByPROCEDENCIAAsDataTable(procedencia, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <param name="procedenciaNull">true if the method ignores the procedencia
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROCEDENCIAAsDataTable(decimal procedencia, bool procedenciaNull)
		{
			return MapRecordsToDataTable(CreateGetByPROCEDENCIACommand(procedencia, procedenciaNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <param name="procedenciaNull">true if the method ignores the procedencia
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROCEDENCIACommand(decimal procedencia, bool procedenciaNull)
		{
			string whereSql = "";
			if(procedenciaNull)
				whereSql += "PROCEDENCIA IS NULL";
			else
				whereSql += "PROCEDENCIA=" + _db.CreateSqlParameterName("PROCEDENCIA");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!procedenciaNull)
				AddParameter(cmd, "PROCEDENCIA", procedencia);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByREGION_ID(decimal region_id)
		{
			return GetByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByREGION_ID(decimal region_id, bool region_idNull)
		{
			return MapRecords(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREGION_IDAsDataTable(decimal region_id)
		{
			return GetByREGION_IDAsDataTable(region_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREGION_IDAsDataTable(decimal region_id, bool region_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecords(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_IDAsDataTable(subgrupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_UNIDAD_MEDIDA</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_UNIDAD_MEDIDA</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_IDAsDataTable(string unidad_medida_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_UNIDAD_MEDIDA</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_IDCommand(string unidad_medida_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", unidad_medida_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public ARTICULOSRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOSRow"/> objects 
		/// by the <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		public virtual ARTICULOSRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_IDAsDataTable(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOSRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS (" +
				"ID, " +
				"ENTIDAD_ID, " +
				"CODIGO_EMPRESA, " +
				"CODIGO_PROVEEDOR, " +
				"FAMILIA_ID, " +
				"GRUPO_ID, " +
				"SUBGRUPO_ID, " +
				"CODIGO_BARRAS_EMPRESA, " +
				"CODIGO_BARRAS_PROVEEDOR, " +
				"DESCRIPCION_INTERNA, " +
				"DESCRIPCION_IMPRESION, " +
				"DESCRIPCION_PROVEEDOR, " +
				"CODIGO_PRESENTACION_ID, " +
				"CODIGO_EMPAQUE_ID, " +
				"CODIGO_COLOR_ID, " +
				"CODIGO_TALLE_ID, " +
				"CODIGO_CATALOGO_PROVEEDOR, " +
				"IMPORTADO, " +
				"PRODUCCION_INTERNA, " +
				"UNIDAD_MEDIDA_ID, " +
				"FACTOR_CONVERSION_KG, " +
				"FACTOR_CONVERSION_M, " +
				"CANTIDAD_POR_CAJA, " +
				"IMPUESTO_ID, " +
				"IMPUESTO_COMPRA_ID, " +
				"SERVICIO, " +
				"COMBO_ID, " +
				"ESTADO, " +
				"INGRESO_APROBADO, " +
				"USUARIO_APROBACION_ID, " +
				"FECHA_APROBACION, " +
				"ES_TRAZABLE, " +
				"PARA_VENTA, " +
				"ES_COMBO, " +
				"ARTICULO_LINEA_ID, " +
				"PROCEDENCIA, " +
				"GENERO, " +
				"ARTICULO_PADRE_ID, " +
				"NO_REPONER, " +
				"ES_COMBO_ABIERTO, " +
				"ES_MODIFICABLE, " +
				"ARTICULO_MARCA_ID, " +
				"RECARGO_FINANCIERO, " +
				"NOTA_CREDITO_ID, " +
				"CONTROLAR_PRECIO, " +
				"COSTO_BASE_MONTO, " +
				"COSTO_BASE_MONEDA_ID, " +
				"COSTO_BASE_COTIZACION, " +
				"ES_USADO, " +
				"ES_DANHADO, " +
				"CENTRO_COSTO_ID, " +
				"ES_OBSOLETO, " +
				"ES_COMBO_REPRESENTATIVO, " +
				"DESCRIPCION_CATALOGO, " +
				"REGION_ID, " +
				"IMAGEN_PATH_TMP, " +
				"ACTIVO_ID, " +
				"RETENCION, " +
				"AUTONUMERACIONES_ID, " +
				"CANTIDAD_MINIMA, " +
				"CANTIDAD_MAXIMA, " +
				"UNIDAD_MEDIDA_CONTROL, " +
				"CANTIDAD_MAYORISTA, " +
				"PARA_COMPRA, " +
				"ES_FORMULA, " +
				"TIPO_FORMULA, " +
				"CANTIDAD_MINIMA_PRODUCCION, " +
				"CANTIDAD_MAXIMA_PRODUCCION, " +
				"PORCENTAJE_PRECIO_PADRE, " +
				"MONTO_PRECIO_PADRE, " +
				"CODIGO_BALANZA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_EMPRESA") + ", " +
				_db.CreateSqlParameterName("CODIGO_PROVEEDOR") + ", " +
				_db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				_db.CreateSqlParameterName("GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_BARRAS_EMPRESA") + ", " +
				_db.CreateSqlParameterName("CODIGO_BARRAS_PROVEEDOR") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION_INTERNA") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION_IMPRESION") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION_PROVEEDOR") + ", " +
				_db.CreateSqlParameterName("CODIGO_PRESENTACION_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_EMPAQUE_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_COLOR_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_TALLE_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_CATALOGO_PROVEEDOR") + ", " +
				_db.CreateSqlParameterName("IMPORTADO") + ", " +
				_db.CreateSqlParameterName("PRODUCCION_INTERNA") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION_KG") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION_M") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_COMPRA_ID") + ", " +
				_db.CreateSqlParameterName("SERVICIO") + ", " +
				_db.CreateSqlParameterName("COMBO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("ES_TRAZABLE") + ", " +
				_db.CreateSqlParameterName("PARA_VENTA") + ", " +
				_db.CreateSqlParameterName("ES_COMBO") + ", " +
				_db.CreateSqlParameterName("ARTICULO_LINEA_ID") + ", " +
				_db.CreateSqlParameterName("PROCEDENCIA") + ", " +
				_db.CreateSqlParameterName("GENERO") + ", " +
				_db.CreateSqlParameterName("ARTICULO_PADRE_ID") + ", " +
				_db.CreateSqlParameterName("NO_REPONER") + ", " +
				_db.CreateSqlParameterName("ES_COMBO_ABIERTO") + ", " +
				_db.CreateSqlParameterName("ES_MODIFICABLE") + ", " +
				_db.CreateSqlParameterName("ARTICULO_MARCA_ID") + ", " +
				_db.CreateSqlParameterName("RECARGO_FINANCIERO") + ", " +
				_db.CreateSqlParameterName("NOTA_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("CONTROLAR_PRECIO") + ", " +
				_db.CreateSqlParameterName("COSTO_BASE_MONTO") + ", " +
				_db.CreateSqlParameterName("COSTO_BASE_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_BASE_COTIZACION") + ", " +
				_db.CreateSqlParameterName("ES_USADO") + ", " +
				_db.CreateSqlParameterName("ES_DANHADO") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("ES_OBSOLETO") + ", " +
				_db.CreateSqlParameterName("ES_COMBO_REPRESENTATIVO") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION_CATALOGO") + ", " +
				_db.CreateSqlParameterName("REGION_ID") + ", " +
				_db.CreateSqlParameterName("IMAGEN_PATH_TMP") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACIONES_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MINIMA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MAXIMA") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_CONTROL") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MAYORISTA") + ", " +
				_db.CreateSqlParameterName("PARA_COMPRA") + ", " +
				_db.CreateSqlParameterName("ES_FORMULA") + ", " +
				_db.CreateSqlParameterName("TIPO_FORMULA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MINIMA_PRODUCCION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MAXIMA_PRODUCCION") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_PRECIO_PADRE") + ", " +
				_db.CreateSqlParameterName("MONTO_PRECIO_PADRE") + ", " +
				_db.CreateSqlParameterName("CODIGO_BALANZA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "CODIGO_EMPRESA", value.CODIGO_EMPRESA);
			AddParameter(cmd, "CODIGO_PROVEEDOR", value.CODIGO_PROVEEDOR);
			AddParameter(cmd, "FAMILIA_ID",
				value.IsFAMILIA_IDNull ? DBNull.Value : (object)value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "CODIGO_BARRAS_EMPRESA", value.CODIGO_BARRAS_EMPRESA);
			AddParameter(cmd, "CODIGO_BARRAS_PROVEEDOR", value.CODIGO_BARRAS_PROVEEDOR);
			AddParameter(cmd, "DESCRIPCION_INTERNA", value.DESCRIPCION_INTERNA);
			AddParameter(cmd, "DESCRIPCION_IMPRESION", value.DESCRIPCION_IMPRESION);
			AddParameter(cmd, "DESCRIPCION_PROVEEDOR", value.DESCRIPCION_PROVEEDOR);
			AddParameter(cmd, "CODIGO_PRESENTACION_ID",
				value.IsCODIGO_PRESENTACION_IDNull ? DBNull.Value : (object)value.CODIGO_PRESENTACION_ID);
			AddParameter(cmd, "CODIGO_EMPAQUE_ID",
				value.IsCODIGO_EMPAQUE_IDNull ? DBNull.Value : (object)value.CODIGO_EMPAQUE_ID);
			AddParameter(cmd, "CODIGO_COLOR_ID",
				value.IsCODIGO_COLOR_IDNull ? DBNull.Value : (object)value.CODIGO_COLOR_ID);
			AddParameter(cmd, "CODIGO_TALLE_ID",
				value.IsCODIGO_TALLE_IDNull ? DBNull.Value : (object)value.CODIGO_TALLE_ID);
			AddParameter(cmd, "CODIGO_CATALOGO_PROVEEDOR", value.CODIGO_CATALOGO_PROVEEDOR);
			AddParameter(cmd, "IMPORTADO", value.IMPORTADO);
			AddParameter(cmd, "PRODUCCION_INTERNA", value.PRODUCCION_INTERNA);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "FACTOR_CONVERSION_KG",
				value.IsFACTOR_CONVERSION_KGNull ? DBNull.Value : (object)value.FACTOR_CONVERSION_KG);
			AddParameter(cmd, "FACTOR_CONVERSION_M",
				value.IsFACTOR_CONVERSION_MNull ? DBNull.Value : (object)value.FACTOR_CONVERSION_M);
			AddParameter(cmd, "CANTIDAD_POR_CAJA", value.CANTIDAD_POR_CAJA);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "IMPUESTO_COMPRA_ID",
				value.IsIMPUESTO_COMPRA_IDNull ? DBNull.Value : (object)value.IMPUESTO_COMPRA_ID);
			AddParameter(cmd, "SERVICIO", value.SERVICIO);
			AddParameter(cmd, "COMBO_ID",
				value.IsCOMBO_IDNull ? DBNull.Value : (object)value.COMBO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "ES_TRAZABLE", value.ES_TRAZABLE);
			AddParameter(cmd, "PARA_VENTA", value.PARA_VENTA);
			AddParameter(cmd, "ES_COMBO", value.ES_COMBO);
			AddParameter(cmd, "ARTICULO_LINEA_ID",
				value.IsARTICULO_LINEA_IDNull ? DBNull.Value : (object)value.ARTICULO_LINEA_ID);
			AddParameter(cmd, "PROCEDENCIA",
				value.IsPROCEDENCIANull ? DBNull.Value : (object)value.PROCEDENCIA);
			AddParameter(cmd, "GENERO", value.GENERO);
			AddParameter(cmd, "ARTICULO_PADRE_ID",
				value.IsARTICULO_PADRE_IDNull ? DBNull.Value : (object)value.ARTICULO_PADRE_ID);
			AddParameter(cmd, "NO_REPONER", value.NO_REPONER);
			AddParameter(cmd, "ES_COMBO_ABIERTO", value.ES_COMBO_ABIERTO);
			AddParameter(cmd, "ES_MODIFICABLE", value.ES_MODIFICABLE);
			AddParameter(cmd, "ARTICULO_MARCA_ID",
				value.IsARTICULO_MARCA_IDNull ? DBNull.Value : (object)value.ARTICULO_MARCA_ID);
			AddParameter(cmd, "RECARGO_FINANCIERO", value.RECARGO_FINANCIERO);
			AddParameter(cmd, "NOTA_CREDITO_ID",
				value.IsNOTA_CREDITO_IDNull ? DBNull.Value : (object)value.NOTA_CREDITO_ID);
			AddParameter(cmd, "CONTROLAR_PRECIO", value.CONTROLAR_PRECIO);
			AddParameter(cmd, "COSTO_BASE_MONTO",
				value.IsCOSTO_BASE_MONTONull ? DBNull.Value : (object)value.COSTO_BASE_MONTO);
			AddParameter(cmd, "COSTO_BASE_MONEDA_ID",
				value.IsCOSTO_BASE_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_BASE_MONEDA_ID);
			AddParameter(cmd, "COSTO_BASE_COTIZACION",
				value.IsCOSTO_BASE_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_BASE_COTIZACION);
			AddParameter(cmd, "ES_USADO", value.ES_USADO);
			AddParameter(cmd, "ES_DANHADO", value.ES_DANHADO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "ES_OBSOLETO", value.ES_OBSOLETO);
			AddParameter(cmd, "ES_COMBO_REPRESENTATIVO", value.ES_COMBO_REPRESENTATIVO);
			AddParameter(cmd, "DESCRIPCION_CATALOGO", value.DESCRIPCION_CATALOGO);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "IMAGEN_PATH_TMP", value.IMAGEN_PATH_TMP);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "RETENCION",
				value.IsRETENCIONNull ? DBNull.Value : (object)value.RETENCION);
			AddParameter(cmd, "AUTONUMERACIONES_ID",
				value.IsAUTONUMERACIONES_IDNull ? DBNull.Value : (object)value.AUTONUMERACIONES_ID);
			AddParameter(cmd, "CANTIDAD_MINIMA",
				value.IsCANTIDAD_MINIMANull ? DBNull.Value : (object)value.CANTIDAD_MINIMA);
			AddParameter(cmd, "CANTIDAD_MAXIMA",
				value.IsCANTIDAD_MAXIMANull ? DBNull.Value : (object)value.CANTIDAD_MAXIMA);
			AddParameter(cmd, "UNIDAD_MEDIDA_CONTROL", value.UNIDAD_MEDIDA_CONTROL);
			AddParameter(cmd, "CANTIDAD_MAYORISTA",
				value.IsCANTIDAD_MAYORISTANull ? DBNull.Value : (object)value.CANTIDAD_MAYORISTA);
			AddParameter(cmd, "PARA_COMPRA", value.PARA_COMPRA);
			AddParameter(cmd, "ES_FORMULA", value.ES_FORMULA);
			AddParameter(cmd, "TIPO_FORMULA", value.TIPO_FORMULA);
			AddParameter(cmd, "CANTIDAD_MINIMA_PRODUCCION",
				value.IsCANTIDAD_MINIMA_PRODUCCIONNull ? DBNull.Value : (object)value.CANTIDAD_MINIMA_PRODUCCION);
			AddParameter(cmd, "CANTIDAD_MAXIMA_PRODUCCION",
				value.IsCANTIDAD_MAXIMA_PRODUCCIONNull ? DBNull.Value : (object)value.CANTIDAD_MAXIMA_PRODUCCION);
			AddParameter(cmd, "PORCENTAJE_PRECIO_PADRE",
				value.IsPORCENTAJE_PRECIO_PADRENull ? DBNull.Value : (object)value.PORCENTAJE_PRECIO_PADRE);
			AddParameter(cmd, "MONTO_PRECIO_PADRE",
				value.IsMONTO_PRECIO_PADRENull ? DBNull.Value : (object)value.MONTO_PRECIO_PADRE);
			AddParameter(cmd, "CODIGO_BALANZA", value.CODIGO_BALANZA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS SET " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"CODIGO_EMPRESA=" + _db.CreateSqlParameterName("CODIGO_EMPRESA") + ", " +
				"CODIGO_PROVEEDOR=" + _db.CreateSqlParameterName("CODIGO_PROVEEDOR") + ", " +
				"FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				"GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID") + ", " +
				"SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				"CODIGO_BARRAS_EMPRESA=" + _db.CreateSqlParameterName("CODIGO_BARRAS_EMPRESA") + ", " +
				"CODIGO_BARRAS_PROVEEDOR=" + _db.CreateSqlParameterName("CODIGO_BARRAS_PROVEEDOR") + ", " +
				"DESCRIPCION_INTERNA=" + _db.CreateSqlParameterName("DESCRIPCION_INTERNA") + ", " +
				"DESCRIPCION_IMPRESION=" + _db.CreateSqlParameterName("DESCRIPCION_IMPRESION") + ", " +
				"DESCRIPCION_PROVEEDOR=" + _db.CreateSqlParameterName("DESCRIPCION_PROVEEDOR") + ", " +
				"CODIGO_PRESENTACION_ID=" + _db.CreateSqlParameterName("CODIGO_PRESENTACION_ID") + ", " +
				"CODIGO_EMPAQUE_ID=" + _db.CreateSqlParameterName("CODIGO_EMPAQUE_ID") + ", " +
				"CODIGO_COLOR_ID=" + _db.CreateSqlParameterName("CODIGO_COLOR_ID") + ", " +
				"CODIGO_TALLE_ID=" + _db.CreateSqlParameterName("CODIGO_TALLE_ID") + ", " +
				"CODIGO_CATALOGO_PROVEEDOR=" + _db.CreateSqlParameterName("CODIGO_CATALOGO_PROVEEDOR") + ", " +
				"IMPORTADO=" + _db.CreateSqlParameterName("IMPORTADO") + ", " +
				"PRODUCCION_INTERNA=" + _db.CreateSqlParameterName("PRODUCCION_INTERNA") + ", " +
				"UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				"FACTOR_CONVERSION_KG=" + _db.CreateSqlParameterName("FACTOR_CONVERSION_KG") + ", " +
				"FACTOR_CONVERSION_M=" + _db.CreateSqlParameterName("FACTOR_CONVERSION_M") + ", " +
				"CANTIDAD_POR_CAJA=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"IMPUESTO_COMPRA_ID=" + _db.CreateSqlParameterName("IMPUESTO_COMPRA_ID") + ", " +
				"SERVICIO=" + _db.CreateSqlParameterName("SERVICIO") + ", " +
				"COMBO_ID=" + _db.CreateSqlParameterName("COMBO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"INGRESO_APROBADO=" + _db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				"USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"ES_TRAZABLE=" + _db.CreateSqlParameterName("ES_TRAZABLE") + ", " +
				"PARA_VENTA=" + _db.CreateSqlParameterName("PARA_VENTA") + ", " +
				"ES_COMBO=" + _db.CreateSqlParameterName("ES_COMBO") + ", " +
				"ARTICULO_LINEA_ID=" + _db.CreateSqlParameterName("ARTICULO_LINEA_ID") + ", " +
				"PROCEDENCIA=" + _db.CreateSqlParameterName("PROCEDENCIA") + ", " +
				"GENERO=" + _db.CreateSqlParameterName("GENERO") + ", " +
				"ARTICULO_PADRE_ID=" + _db.CreateSqlParameterName("ARTICULO_PADRE_ID") + ", " +
				"NO_REPONER=" + _db.CreateSqlParameterName("NO_REPONER") + ", " +
				"ES_COMBO_ABIERTO=" + _db.CreateSqlParameterName("ES_COMBO_ABIERTO") + ", " +
				"ES_MODIFICABLE=" + _db.CreateSqlParameterName("ES_MODIFICABLE") + ", " +
				"ARTICULO_MARCA_ID=" + _db.CreateSqlParameterName("ARTICULO_MARCA_ID") + ", " +
				"RECARGO_FINANCIERO=" + _db.CreateSqlParameterName("RECARGO_FINANCIERO") + ", " +
				"NOTA_CREDITO_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_ID") + ", " +
				"CONTROLAR_PRECIO=" + _db.CreateSqlParameterName("CONTROLAR_PRECIO") + ", " +
				"COSTO_BASE_MONTO=" + _db.CreateSqlParameterName("COSTO_BASE_MONTO") + ", " +
				"COSTO_BASE_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_BASE_MONEDA_ID") + ", " +
				"COSTO_BASE_COTIZACION=" + _db.CreateSqlParameterName("COSTO_BASE_COTIZACION") + ", " +
				"ES_USADO=" + _db.CreateSqlParameterName("ES_USADO") + ", " +
				"ES_DANHADO=" + _db.CreateSqlParameterName("ES_DANHADO") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"ES_OBSOLETO=" + _db.CreateSqlParameterName("ES_OBSOLETO") + ", " +
				"ES_COMBO_REPRESENTATIVO=" + _db.CreateSqlParameterName("ES_COMBO_REPRESENTATIVO") + ", " +
				"DESCRIPCION_CATALOGO=" + _db.CreateSqlParameterName("DESCRIPCION_CATALOGO") + ", " +
				"REGION_ID=" + _db.CreateSqlParameterName("REGION_ID") + ", " +
				"IMAGEN_PATH_TMP=" + _db.CreateSqlParameterName("IMAGEN_PATH_TMP") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"RETENCION=" + _db.CreateSqlParameterName("RETENCION") + ", " +
				"AUTONUMERACIONES_ID=" + _db.CreateSqlParameterName("AUTONUMERACIONES_ID") + ", " +
				"CANTIDAD_MINIMA=" + _db.CreateSqlParameterName("CANTIDAD_MINIMA") + ", " +
				"CANTIDAD_MAXIMA=" + _db.CreateSqlParameterName("CANTIDAD_MAXIMA") + ", " +
				"UNIDAD_MEDIDA_CONTROL=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_CONTROL") + ", " +
				"CANTIDAD_MAYORISTA=" + _db.CreateSqlParameterName("CANTIDAD_MAYORISTA") + ", " +
				"PARA_COMPRA=" + _db.CreateSqlParameterName("PARA_COMPRA") + ", " +
				"ES_FORMULA=" + _db.CreateSqlParameterName("ES_FORMULA") + ", " +
				"TIPO_FORMULA=" + _db.CreateSqlParameterName("TIPO_FORMULA") + ", " +
				"CANTIDAD_MINIMA_PRODUCCION=" + _db.CreateSqlParameterName("CANTIDAD_MINIMA_PRODUCCION") + ", " +
				"CANTIDAD_MAXIMA_PRODUCCION=" + _db.CreateSqlParameterName("CANTIDAD_MAXIMA_PRODUCCION") + ", " +
				"PORCENTAJE_PRECIO_PADRE=" + _db.CreateSqlParameterName("PORCENTAJE_PRECIO_PADRE") + ", " +
				"MONTO_PRECIO_PADRE=" + _db.CreateSqlParameterName("MONTO_PRECIO_PADRE") + ", " +
				"CODIGO_BALANZA=" + _db.CreateSqlParameterName("CODIGO_BALANZA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "CODIGO_EMPRESA", value.CODIGO_EMPRESA);
			AddParameter(cmd, "CODIGO_PROVEEDOR", value.CODIGO_PROVEEDOR);
			AddParameter(cmd, "FAMILIA_ID",
				value.IsFAMILIA_IDNull ? DBNull.Value : (object)value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "CODIGO_BARRAS_EMPRESA", value.CODIGO_BARRAS_EMPRESA);
			AddParameter(cmd, "CODIGO_BARRAS_PROVEEDOR", value.CODIGO_BARRAS_PROVEEDOR);
			AddParameter(cmd, "DESCRIPCION_INTERNA", value.DESCRIPCION_INTERNA);
			AddParameter(cmd, "DESCRIPCION_IMPRESION", value.DESCRIPCION_IMPRESION);
			AddParameter(cmd, "DESCRIPCION_PROVEEDOR", value.DESCRIPCION_PROVEEDOR);
			AddParameter(cmd, "CODIGO_PRESENTACION_ID",
				value.IsCODIGO_PRESENTACION_IDNull ? DBNull.Value : (object)value.CODIGO_PRESENTACION_ID);
			AddParameter(cmd, "CODIGO_EMPAQUE_ID",
				value.IsCODIGO_EMPAQUE_IDNull ? DBNull.Value : (object)value.CODIGO_EMPAQUE_ID);
			AddParameter(cmd, "CODIGO_COLOR_ID",
				value.IsCODIGO_COLOR_IDNull ? DBNull.Value : (object)value.CODIGO_COLOR_ID);
			AddParameter(cmd, "CODIGO_TALLE_ID",
				value.IsCODIGO_TALLE_IDNull ? DBNull.Value : (object)value.CODIGO_TALLE_ID);
			AddParameter(cmd, "CODIGO_CATALOGO_PROVEEDOR", value.CODIGO_CATALOGO_PROVEEDOR);
			AddParameter(cmd, "IMPORTADO", value.IMPORTADO);
			AddParameter(cmd, "PRODUCCION_INTERNA", value.PRODUCCION_INTERNA);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "FACTOR_CONVERSION_KG",
				value.IsFACTOR_CONVERSION_KGNull ? DBNull.Value : (object)value.FACTOR_CONVERSION_KG);
			AddParameter(cmd, "FACTOR_CONVERSION_M",
				value.IsFACTOR_CONVERSION_MNull ? DBNull.Value : (object)value.FACTOR_CONVERSION_M);
			AddParameter(cmd, "CANTIDAD_POR_CAJA", value.CANTIDAD_POR_CAJA);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "IMPUESTO_COMPRA_ID",
				value.IsIMPUESTO_COMPRA_IDNull ? DBNull.Value : (object)value.IMPUESTO_COMPRA_ID);
			AddParameter(cmd, "SERVICIO", value.SERVICIO);
			AddParameter(cmd, "COMBO_ID",
				value.IsCOMBO_IDNull ? DBNull.Value : (object)value.COMBO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "ES_TRAZABLE", value.ES_TRAZABLE);
			AddParameter(cmd, "PARA_VENTA", value.PARA_VENTA);
			AddParameter(cmd, "ES_COMBO", value.ES_COMBO);
			AddParameter(cmd, "ARTICULO_LINEA_ID",
				value.IsARTICULO_LINEA_IDNull ? DBNull.Value : (object)value.ARTICULO_LINEA_ID);
			AddParameter(cmd, "PROCEDENCIA",
				value.IsPROCEDENCIANull ? DBNull.Value : (object)value.PROCEDENCIA);
			AddParameter(cmd, "GENERO", value.GENERO);
			AddParameter(cmd, "ARTICULO_PADRE_ID",
				value.IsARTICULO_PADRE_IDNull ? DBNull.Value : (object)value.ARTICULO_PADRE_ID);
			AddParameter(cmd, "NO_REPONER", value.NO_REPONER);
			AddParameter(cmd, "ES_COMBO_ABIERTO", value.ES_COMBO_ABIERTO);
			AddParameter(cmd, "ES_MODIFICABLE", value.ES_MODIFICABLE);
			AddParameter(cmd, "ARTICULO_MARCA_ID",
				value.IsARTICULO_MARCA_IDNull ? DBNull.Value : (object)value.ARTICULO_MARCA_ID);
			AddParameter(cmd, "RECARGO_FINANCIERO", value.RECARGO_FINANCIERO);
			AddParameter(cmd, "NOTA_CREDITO_ID",
				value.IsNOTA_CREDITO_IDNull ? DBNull.Value : (object)value.NOTA_CREDITO_ID);
			AddParameter(cmd, "CONTROLAR_PRECIO", value.CONTROLAR_PRECIO);
			AddParameter(cmd, "COSTO_BASE_MONTO",
				value.IsCOSTO_BASE_MONTONull ? DBNull.Value : (object)value.COSTO_BASE_MONTO);
			AddParameter(cmd, "COSTO_BASE_MONEDA_ID",
				value.IsCOSTO_BASE_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_BASE_MONEDA_ID);
			AddParameter(cmd, "COSTO_BASE_COTIZACION",
				value.IsCOSTO_BASE_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_BASE_COTIZACION);
			AddParameter(cmd, "ES_USADO", value.ES_USADO);
			AddParameter(cmd, "ES_DANHADO", value.ES_DANHADO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "ES_OBSOLETO", value.ES_OBSOLETO);
			AddParameter(cmd, "ES_COMBO_REPRESENTATIVO", value.ES_COMBO_REPRESENTATIVO);
			AddParameter(cmd, "DESCRIPCION_CATALOGO", value.DESCRIPCION_CATALOGO);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "IMAGEN_PATH_TMP", value.IMAGEN_PATH_TMP);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "RETENCION",
				value.IsRETENCIONNull ? DBNull.Value : (object)value.RETENCION);
			AddParameter(cmd, "AUTONUMERACIONES_ID",
				value.IsAUTONUMERACIONES_IDNull ? DBNull.Value : (object)value.AUTONUMERACIONES_ID);
			AddParameter(cmd, "CANTIDAD_MINIMA",
				value.IsCANTIDAD_MINIMANull ? DBNull.Value : (object)value.CANTIDAD_MINIMA);
			AddParameter(cmd, "CANTIDAD_MAXIMA",
				value.IsCANTIDAD_MAXIMANull ? DBNull.Value : (object)value.CANTIDAD_MAXIMA);
			AddParameter(cmd, "UNIDAD_MEDIDA_CONTROL", value.UNIDAD_MEDIDA_CONTROL);
			AddParameter(cmd, "CANTIDAD_MAYORISTA",
				value.IsCANTIDAD_MAYORISTANull ? DBNull.Value : (object)value.CANTIDAD_MAYORISTA);
			AddParameter(cmd, "PARA_COMPRA", value.PARA_COMPRA);
			AddParameter(cmd, "ES_FORMULA", value.ES_FORMULA);
			AddParameter(cmd, "TIPO_FORMULA", value.TIPO_FORMULA);
			AddParameter(cmd, "CANTIDAD_MINIMA_PRODUCCION",
				value.IsCANTIDAD_MINIMA_PRODUCCIONNull ? DBNull.Value : (object)value.CANTIDAD_MINIMA_PRODUCCION);
			AddParameter(cmd, "CANTIDAD_MAXIMA_PRODUCCION",
				value.IsCANTIDAD_MAXIMA_PRODUCCIONNull ? DBNull.Value : (object)value.CANTIDAD_MAXIMA_PRODUCCION);
			AddParameter(cmd, "PORCENTAJE_PRECIO_PADRE",
				value.IsPORCENTAJE_PRECIO_PADRENull ? DBNull.Value : (object)value.PORCENTAJE_PRECIO_PADRE);
			AddParameter(cmd, "MONTO_PRECIO_PADRE",
				value.IsMONTO_PRECIO_PADRENull ? DBNull.Value : (object)value.MONTO_PRECIO_PADRE);
			AddParameter(cmd, "CODIGO_BALANZA", value.CODIGO_BALANZA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
		/// argument when your code calls this method in an ADO.NET transaction context. Note that in 
		/// this case, after you call the Update method you need call either <c>AcceptChanges</c> 
		/// or <c>RejectChanges</c> method on the DataTable object.
		/// <code>
		/// MyDb db = new MyDb();
		/// try
		/// {
		///		db.BeginTransaction();
		///		db.MyCollection.Update(myDataTable, false);
		///		db.CommitTransaction();
		///		myDataTable.AcceptChanges();
		/// }
		/// catch(Exception)
		/// {
		///		db.RollbackTransaction();
		///		myDataTable.RejectChanges();
		/// }
		/// </code>
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		/// <param name="acceptChanges">Specifies whether this method calls the <c>AcceptChanges</c>
		/// method on the changed DataRow objects.</param>
		public virtual void Update(DataTable table, bool acceptChanges)
		{
			DataRowCollection rows = table.Rows;
			for(int i = rows.Count - 1; i >= 0; i--)
			{
				DataRow row = rows[i];
				switch(row.RowState)
				{
					case DataRowState.Added:
						Insert(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;

					case DataRowState.Deleted:
						// Temporary reject changes to be able to access to the PK column(s)
						row.RejectChanges();
						try
						{
							DeleteByPrimaryKey((decimal)row["ID"]);
						}
						finally
						{
							row.Delete();
						}
						if(acceptChanges)
							row.AcceptChanges();
						break;
						
					case DataRowState.Modified:
						Update(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;
				}
			}
		}

		/// <summary>
		/// Deletes the specified object from the <c>ARTICULOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ID", id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_BASE_MONEDA_ID(decimal costo_base_moneda_id)
		{
			return DeleteByCOSTO_BASE_MONEDA_ID(costo_base_moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <param name="costo_base_moneda_idNull">true if the method ignores the costo_base_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_BASE_MONEDA_ID(decimal costo_base_moneda_id, bool costo_base_moneda_idNull)
		{
			return CreateDeleteByCOSTO_BASE_MONEDA_IDCommand(costo_base_moneda_id, costo_base_moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULO_MONEDA_BASE</c> foreign key.
		/// </summary>
		/// <param name="costo_base_moneda_id">The <c>COSTO_BASE_MONEDA_ID</c> column value.</param>
		/// <param name="costo_base_moneda_idNull">true if the method ignores the costo_base_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTO_BASE_MONEDA_IDCommand(decimal costo_base_moneda_id, bool costo_base_moneda_idNull)
		{
			string whereSql = "";
			if(costo_base_moneda_idNull)
				whereSql += "COSTO_BASE_MONEDA_ID IS NULL";
			else
				whereSql += "COSTO_BASE_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_BASE_MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!costo_base_moneda_idNull)
				AddParameter(cmd, "COSTO_BASE_MONEDA_ID", costo_base_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return CreateDeleteByACTIVO_IDCommand(activo_id, activo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_ACTIVOS_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_PADRE_ID(decimal articulo_padre_id)
		{
			return DeleteByARTICULO_PADRE_ID(articulo_padre_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <param name="articulo_padre_idNull">true if the method ignores the articulo_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_PADRE_ID(decimal articulo_padre_id, bool articulo_padre_idNull)
		{
			return CreateDeleteByARTICULO_PADRE_IDCommand(articulo_padre_id, articulo_padre_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_ART_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_padre_id">The <c>ARTICULO_PADRE_ID</c> column value.</param>
		/// <param name="articulo_padre_idNull">true if the method ignores the articulo_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_PADRE_IDCommand(decimal articulo_padre_id, bool articulo_padre_idNull)
		{
			string whereSql = "";
			if(articulo_padre_idNull)
				whereSql += "ARTICULO_PADRE_ID IS NULL";
			else
				whereSql += "ARTICULO_PADRE_ID=" + _db.CreateSqlParameterName("ARTICULO_PADRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_padre_idNull)
				AddParameter(cmd, "ARTICULO_PADRE_ID", articulo_padre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACIONES_ID(decimal autonumeraciones_id)
		{
			return DeleteByAUTONUMERACIONES_ID(autonumeraciones_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <param name="autonumeraciones_idNull">true if the method ignores the autonumeraciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACIONES_ID(decimal autonumeraciones_id, bool autonumeraciones_idNull)
		{
			return CreateDeleteByAUTONUMERACIONES_IDCommand(autonumeraciones_id, autonumeraciones_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_AUTONUMERACIONES</c> foreign key.
		/// </summary>
		/// <param name="autonumeraciones_id">The <c>AUTONUMERACIONES_ID</c> column value.</param>
		/// <param name="autonumeraciones_idNull">true if the method ignores the autonumeraciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACIONES_IDCommand(decimal autonumeraciones_id, bool autonumeraciones_idNull)
		{
			string whereSql = "";
			if(autonumeraciones_idNull)
				whereSql += "AUTONUMERACIONES_ID IS NULL";
			else
				whereSql += "AUTONUMERACIONES_ID=" + _db.CreateSqlParameterName("AUTONUMERACIONES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeraciones_idNull)
				AddParameter(cmd, "AUTONUMERACIONES_ID", autonumeraciones_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return CreateDeleteByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_COLOR_ID(decimal codigo_color_id)
		{
			return DeleteByCODIGO_COLOR_ID(codigo_color_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <param name="codigo_color_idNull">true if the method ignores the codigo_color_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_COLOR_ID(decimal codigo_color_id, bool codigo_color_idNull)
		{
			return CreateDeleteByCODIGO_COLOR_IDCommand(codigo_color_id, codigo_color_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_COD_COLOR</c> foreign key.
		/// </summary>
		/// <param name="codigo_color_id">The <c>CODIGO_COLOR_ID</c> column value.</param>
		/// <param name="codigo_color_idNull">true if the method ignores the codigo_color_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCODIGO_COLOR_IDCommand(decimal codigo_color_id, bool codigo_color_idNull)
		{
			string whereSql = "";
			if(codigo_color_idNull)
				whereSql += "CODIGO_COLOR_ID IS NULL";
			else
				whereSql += "CODIGO_COLOR_ID=" + _db.CreateSqlParameterName("CODIGO_COLOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!codigo_color_idNull)
				AddParameter(cmd, "CODIGO_COLOR_ID", codigo_color_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_EMPAQUE_ID(decimal codigo_empaque_id)
		{
			return DeleteByCODIGO_EMPAQUE_ID(codigo_empaque_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <param name="codigo_empaque_idNull">true if the method ignores the codigo_empaque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_EMPAQUE_ID(decimal codigo_empaque_id, bool codigo_empaque_idNull)
		{
			return CreateDeleteByCODIGO_EMPAQUE_IDCommand(codigo_empaque_id, codigo_empaque_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_COD_EMPAQUE</c> foreign key.
		/// </summary>
		/// <param name="codigo_empaque_id">The <c>CODIGO_EMPAQUE_ID</c> column value.</param>
		/// <param name="codigo_empaque_idNull">true if the method ignores the codigo_empaque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCODIGO_EMPAQUE_IDCommand(decimal codigo_empaque_id, bool codigo_empaque_idNull)
		{
			string whereSql = "";
			if(codigo_empaque_idNull)
				whereSql += "CODIGO_EMPAQUE_ID IS NULL";
			else
				whereSql += "CODIGO_EMPAQUE_ID=" + _db.CreateSqlParameterName("CODIGO_EMPAQUE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!codigo_empaque_idNull)
				AddParameter(cmd, "CODIGO_EMPAQUE_ID", codigo_empaque_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_PRESENTACION_ID(decimal codigo_presentacion_id)
		{
			return DeleteByCODIGO_PRESENTACION_ID(codigo_presentacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <param name="codigo_presentacion_idNull">true if the method ignores the codigo_presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_PRESENTACION_ID(decimal codigo_presentacion_id, bool codigo_presentacion_idNull)
		{
			return CreateDeleteByCODIGO_PRESENTACION_IDCommand(codigo_presentacion_id, codigo_presentacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_COD_PRESENTACION</c> foreign key.
		/// </summary>
		/// <param name="codigo_presentacion_id">The <c>CODIGO_PRESENTACION_ID</c> column value.</param>
		/// <param name="codigo_presentacion_idNull">true if the method ignores the codigo_presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCODIGO_PRESENTACION_IDCommand(decimal codigo_presentacion_id, bool codigo_presentacion_idNull)
		{
			string whereSql = "";
			if(codigo_presentacion_idNull)
				whereSql += "CODIGO_PRESENTACION_ID IS NULL";
			else
				whereSql += "CODIGO_PRESENTACION_ID=" + _db.CreateSqlParameterName("CODIGO_PRESENTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!codigo_presentacion_idNull)
				AddParameter(cmd, "CODIGO_PRESENTACION_ID", codigo_presentacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_TALLE_ID(decimal codigo_talle_id)
		{
			return DeleteByCODIGO_TALLE_ID(codigo_talle_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <param name="codigo_talle_idNull">true if the method ignores the codigo_talle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCODIGO_TALLE_ID(decimal codigo_talle_id, bool codigo_talle_idNull)
		{
			return CreateDeleteByCODIGO_TALLE_IDCommand(codigo_talle_id, codigo_talle_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_COD_TALLE</c> foreign key.
		/// </summary>
		/// <param name="codigo_talle_id">The <c>CODIGO_TALLE_ID</c> column value.</param>
		/// <param name="codigo_talle_idNull">true if the method ignores the codigo_talle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCODIGO_TALLE_IDCommand(decimal codigo_talle_id, bool codigo_talle_idNull)
		{
			string whereSql = "";
			if(codigo_talle_idNull)
				whereSql += "CODIGO_TALLE_ID IS NULL";
			else
				whereSql += "CODIGO_TALLE_ID=" + _db.CreateSqlParameterName("CODIGO_TALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!codigo_talle_idNull)
				AddParameter(cmd, "CODIGO_TALLE_ID", codigo_talle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOMBO_ID(decimal combo_id)
		{
			return DeleteByCOMBO_ID(combo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <param name="combo_idNull">true if the method ignores the combo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOMBO_ID(decimal combo_id, bool combo_idNull)
		{
			return CreateDeleteByCOMBO_IDCommand(combo_id, combo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_COMBO</c> foreign key.
		/// </summary>
		/// <param name="combo_id">The <c>COMBO_ID</c> column value.</param>
		/// <param name="combo_idNull">true if the method ignores the combo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOMBO_IDCommand(decimal combo_id, bool combo_idNull)
		{
			string whereSql = "";
			if(combo_idNull)
				whereSql += "COMBO_ID IS NULL";
			else
				whereSql += "COMBO_ID=" + _db.CreateSqlParameterName("COMBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!combo_idNull)
				AddParameter(cmd, "COMBO_ID", combo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFAMILIA_ID(decimal familia_id)
		{
			return DeleteByFAMILIA_ID(familia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFAMILIA_ID(decimal familia_id, bool familia_idNull)
		{
			return CreateDeleteByFAMILIA_IDCommand(familia_id, familia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFAMILIA_IDCommand(decimal familia_id, bool familia_idNull)
		{
			string whereSql = "";
			if(familia_idNull)
				whereSql += "FAMILIA_ID IS NULL";
			else
				whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!familia_idNull)
				AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id)
		{
			return DeleteByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return CreateDeleteByGRUPO_IDCommand(grupo_id, grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPUESTO_IDCommand(decimal impuesto_id)
		{
			string whereSql = "";
			whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_COMPRA_ID(decimal impuesto_compra_id)
		{
			return DeleteByIMPUESTO_COMPRA_ID(impuesto_compra_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <param name="impuesto_compra_idNull">true if the method ignores the impuesto_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_COMPRA_ID(decimal impuesto_compra_id, bool impuesto_compra_idNull)
		{
			return CreateDeleteByIMPUESTO_COMPRA_IDCommand(impuesto_compra_id, impuesto_compra_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_IMPUESTO_COMPRA</c> foreign key.
		/// </summary>
		/// <param name="impuesto_compra_id">The <c>IMPUESTO_COMPRA_ID</c> column value.</param>
		/// <param name="impuesto_compra_idNull">true if the method ignores the impuesto_compra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPUESTO_COMPRA_IDCommand(decimal impuesto_compra_id, bool impuesto_compra_idNull)
		{
			string whereSql = "";
			if(impuesto_compra_idNull)
				whereSql += "IMPUESTO_COMPRA_ID IS NULL";
			else
				whereSql += "IMPUESTO_COMPRA_ID=" + _db.CreateSqlParameterName("IMPUESTO_COMPRA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!impuesto_compra_idNull)
				AddParameter(cmd, "IMPUESTO_COMPRA_ID", impuesto_compra_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_LINEA_ID(decimal articulo_linea_id)
		{
			return DeleteByARTICULO_LINEA_ID(articulo_linea_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <param name="articulo_linea_idNull">true if the method ignores the articulo_linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_LINEA_ID(decimal articulo_linea_id, bool articulo_linea_idNull)
		{
			return CreateDeleteByARTICULO_LINEA_IDCommand(articulo_linea_id, articulo_linea_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_linea_id">The <c>ARTICULO_LINEA_ID</c> column value.</param>
		/// <param name="articulo_linea_idNull">true if the method ignores the articulo_linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_LINEA_IDCommand(decimal articulo_linea_id, bool articulo_linea_idNull)
		{
			string whereSql = "";
			if(articulo_linea_idNull)
				whereSql += "ARTICULO_LINEA_ID IS NULL";
			else
				whereSql += "ARTICULO_LINEA_ID=" + _db.CreateSqlParameterName("ARTICULO_LINEA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_linea_idNull)
				AddParameter(cmd, "ARTICULO_LINEA_ID", articulo_linea_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_MARCA_ID(decimal articulo_marca_id)
		{
			return DeleteByARTICULO_MARCA_ID(articulo_marca_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <param name="articulo_marca_idNull">true if the method ignores the articulo_marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_MARCA_ID(decimal articulo_marca_id, bool articulo_marca_idNull)
		{
			return CreateDeleteByARTICULO_MARCA_IDCommand(articulo_marca_id, articulo_marca_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_MARCAS</c> foreign key.
		/// </summary>
		/// <param name="articulo_marca_id">The <c>ARTICULO_MARCA_ID</c> column value.</param>
		/// <param name="articulo_marca_idNull">true if the method ignores the articulo_marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_MARCA_IDCommand(decimal articulo_marca_id, bool articulo_marca_idNull)
		{
			string whereSql = "";
			if(articulo_marca_idNull)
				whereSql += "ARTICULO_MARCA_ID IS NULL";
			else
				whereSql += "ARTICULO_MARCA_ID=" + _db.CreateSqlParameterName("ARTICULO_MARCA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_marca_idNull)
				AddParameter(cmd, "ARTICULO_MARCA_ID", articulo_marca_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_CREDITO_ID(decimal nota_credito_id)
		{
			return DeleteByNOTA_CREDITO_ID(nota_credito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_CREDITO_ID(decimal nota_credito_id, bool nota_credito_idNull)
		{
			return CreateDeleteByNOTA_CREDITO_IDCommand(nota_credito_id, nota_credito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_NOTA_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNOTA_CREDITO_IDCommand(decimal nota_credito_id, bool nota_credito_idNull)
		{
			string whereSql = "";
			if(nota_credito_idNull)
				whereSql += "NOTA_CREDITO_ID IS NULL";
			else
				whereSql += "NOTA_CREDITO_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nota_credito_idNull)
				AddParameter(cmd, "NOTA_CREDITO_ID", nota_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCEDENCIA(decimal procedencia)
		{
			return DeleteByPROCEDENCIA(procedencia, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <param name="procedenciaNull">true if the method ignores the procedencia
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCEDENCIA(decimal procedencia, bool procedenciaNull)
		{
			return CreateDeleteByPROCEDENCIACommand(procedencia, procedenciaNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_PROCEDENCIA</c> foreign key.
		/// </summary>
		/// <param name="procedencia">The <c>PROCEDENCIA</c> column value.</param>
		/// <param name="procedenciaNull">true if the method ignores the procedencia
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROCEDENCIACommand(decimal procedencia, bool procedenciaNull)
		{
			string whereSql = "";
			if(procedenciaNull)
				whereSql += "PROCEDENCIA IS NULL";
			else
				whereSql += "PROCEDENCIA=" + _db.CreateSqlParameterName("PROCEDENCIA");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!procedenciaNull)
				AddParameter(cmd, "PROCEDENCIA", procedencia);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id)
		{
			return DeleteByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id, bool region_idNull)
		{
			return CreateDeleteByREGION_IDCommand(region_id, region_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return DeleteBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return CreateDeleteBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_UNIDAD_MEDIDA</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_IDCommand(unidad_medida_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_UNIDAD_MEDIDA</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_IDCommand(string unidad_medida_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", unidad_medida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return DeleteByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS</c> table using the 
		/// <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return CreateDeleteByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULOS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>The number of deleted records.</returns>
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used 
		/// to delete <c>ARTICULOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS</c> table.
		/// </summary>
		/// <returns>The number of deleted records.</returns>
		public int DeleteAll()
		{
			return Delete("");
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		protected ARTICULOSRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		protected ARTICULOSRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="ARTICULOSRow"/> objects.</returns>
		protected virtual ARTICULOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int codigo_empresaColumnIndex = reader.GetOrdinal("CODIGO_EMPRESA");
			int codigo_proveedorColumnIndex = reader.GetOrdinal("CODIGO_PROVEEDOR");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int codigo_barras_empresaColumnIndex = reader.GetOrdinal("CODIGO_BARRAS_EMPRESA");
			int codigo_barras_proveedorColumnIndex = reader.GetOrdinal("CODIGO_BARRAS_PROVEEDOR");
			int descripcion_internaColumnIndex = reader.GetOrdinal("DESCRIPCION_INTERNA");
			int descripcion_impresionColumnIndex = reader.GetOrdinal("DESCRIPCION_IMPRESION");
			int descripcion_proveedorColumnIndex = reader.GetOrdinal("DESCRIPCION_PROVEEDOR");
			int codigo_presentacion_idColumnIndex = reader.GetOrdinal("CODIGO_PRESENTACION_ID");
			int codigo_empaque_idColumnIndex = reader.GetOrdinal("CODIGO_EMPAQUE_ID");
			int codigo_color_idColumnIndex = reader.GetOrdinal("CODIGO_COLOR_ID");
			int codigo_talle_idColumnIndex = reader.GetOrdinal("CODIGO_TALLE_ID");
			int codigo_catalogo_proveedorColumnIndex = reader.GetOrdinal("CODIGO_CATALOGO_PROVEEDOR");
			int importadoColumnIndex = reader.GetOrdinal("IMPORTADO");
			int produccion_internaColumnIndex = reader.GetOrdinal("PRODUCCION_INTERNA");
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
			int es_trazableColumnIndex = reader.GetOrdinal("ES_TRAZABLE");
			int para_ventaColumnIndex = reader.GetOrdinal("PARA_VENTA");
			int es_comboColumnIndex = reader.GetOrdinal("ES_COMBO");
			int articulo_linea_idColumnIndex = reader.GetOrdinal("ARTICULO_LINEA_ID");
			int procedenciaColumnIndex = reader.GetOrdinal("PROCEDENCIA");
			int generoColumnIndex = reader.GetOrdinal("GENERO");
			int articulo_padre_idColumnIndex = reader.GetOrdinal("ARTICULO_PADRE_ID");
			int no_reponerColumnIndex = reader.GetOrdinal("NO_REPONER");
			int es_combo_abiertoColumnIndex = reader.GetOrdinal("ES_COMBO_ABIERTO");
			int es_modificableColumnIndex = reader.GetOrdinal("ES_MODIFICABLE");
			int articulo_marca_idColumnIndex = reader.GetOrdinal("ARTICULO_MARCA_ID");
			int recargo_financieroColumnIndex = reader.GetOrdinal("RECARGO_FINANCIERO");
			int nota_credito_idColumnIndex = reader.GetOrdinal("NOTA_CREDITO_ID");
			int controlar_precioColumnIndex = reader.GetOrdinal("CONTROLAR_PRECIO");
			int costo_base_montoColumnIndex = reader.GetOrdinal("COSTO_BASE_MONTO");
			int costo_base_moneda_idColumnIndex = reader.GetOrdinal("COSTO_BASE_MONEDA_ID");
			int costo_base_cotizacionColumnIndex = reader.GetOrdinal("COSTO_BASE_COTIZACION");
			int es_usadoColumnIndex = reader.GetOrdinal("ES_USADO");
			int es_danhadoColumnIndex = reader.GetOrdinal("ES_DANHADO");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int es_obsoletoColumnIndex = reader.GetOrdinal("ES_OBSOLETO");
			int es_combo_representativoColumnIndex = reader.GetOrdinal("ES_COMBO_REPRESENTATIVO");
			int descripcion_catalogoColumnIndex = reader.GetOrdinal("DESCRIPCION_CATALOGO");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int imagen_path_tmpColumnIndex = reader.GetOrdinal("IMAGEN_PATH_TMP");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int retencionColumnIndex = reader.GetOrdinal("RETENCION");
			int autonumeraciones_idColumnIndex = reader.GetOrdinal("AUTONUMERACIONES_ID");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int cantidad_maximaColumnIndex = reader.GetOrdinal("CANTIDAD_MAXIMA");
			int unidad_medida_controlColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_CONTROL");
			int cantidad_mayoristaColumnIndex = reader.GetOrdinal("CANTIDAD_MAYORISTA");
			int para_compraColumnIndex = reader.GetOrdinal("PARA_COMPRA");
			int es_formulaColumnIndex = reader.GetOrdinal("ES_FORMULA");
			int tipo_formulaColumnIndex = reader.GetOrdinal("TIPO_FORMULA");
			int cantidad_minima_produccionColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA_PRODUCCION");
			int cantidad_maxima_produccionColumnIndex = reader.GetOrdinal("CANTIDAD_MAXIMA_PRODUCCION");
			int porcentaje_precio_padreColumnIndex = reader.GetOrdinal("PORCENTAJE_PRECIO_PADRE");
			int monto_precio_padreColumnIndex = reader.GetOrdinal("MONTO_PRECIO_PADRE");
			int codigo_balanzaColumnIndex = reader.GetOrdinal("CODIGO_BALANZA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOSRow record = new ARTICULOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
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
					if(!reader.IsDBNull(descripcion_proveedorColumnIndex))
						record.DESCRIPCION_PROVEEDOR = Convert.ToString(reader.GetValue(descripcion_proveedorColumnIndex));
					if(!reader.IsDBNull(codigo_presentacion_idColumnIndex))
						record.CODIGO_PRESENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_presentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_empaque_idColumnIndex))
						record.CODIGO_EMPAQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_empaque_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_color_idColumnIndex))
						record.CODIGO_COLOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_color_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_talle_idColumnIndex))
						record.CODIGO_TALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(codigo_talle_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_catalogo_proveedorColumnIndex))
						record.CODIGO_CATALOGO_PROVEEDOR = Convert.ToString(reader.GetValue(codigo_catalogo_proveedorColumnIndex));
					record.IMPORTADO = Convert.ToString(reader.GetValue(importadoColumnIndex));
					record.PRODUCCION_INTERNA = Convert.ToString(reader.GetValue(produccion_internaColumnIndex));
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
					record.ES_TRAZABLE = Convert.ToString(reader.GetValue(es_trazableColumnIndex));
					record.PARA_VENTA = Convert.ToString(reader.GetValue(para_ventaColumnIndex));
					record.ES_COMBO = Convert.ToString(reader.GetValue(es_comboColumnIndex));
					if(!reader.IsDBNull(articulo_linea_idColumnIndex))
						record.ARTICULO_LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(procedenciaColumnIndex))
						record.PROCEDENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(procedenciaColumnIndex)), 9);
					if(!reader.IsDBNull(generoColumnIndex))
						record.GENERO = Convert.ToString(reader.GetValue(generoColumnIndex));
					if(!reader.IsDBNull(articulo_padre_idColumnIndex))
						record.ARTICULO_PADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_padre_idColumnIndex)), 9);
					record.NO_REPONER = Convert.ToString(reader.GetValue(no_reponerColumnIndex));
					record.ES_COMBO_ABIERTO = Convert.ToString(reader.GetValue(es_combo_abiertoColumnIndex));
					record.ES_MODIFICABLE = Convert.ToString(reader.GetValue(es_modificableColumnIndex));
					if(!reader.IsDBNull(articulo_marca_idColumnIndex))
						record.ARTICULO_MARCA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_marca_idColumnIndex)), 9);
					record.RECARGO_FINANCIERO = Convert.ToString(reader.GetValue(recargo_financieroColumnIndex));
					if(!reader.IsDBNull(nota_credito_idColumnIndex))
						record.NOTA_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_idColumnIndex)), 9);
					record.CONTROLAR_PRECIO = Convert.ToString(reader.GetValue(controlar_precioColumnIndex));
					if(!reader.IsDBNull(costo_base_montoColumnIndex))
						record.COSTO_BASE_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_base_montoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_base_moneda_idColumnIndex))
						record.COSTO_BASE_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_base_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_base_cotizacionColumnIndex))
						record.COSTO_BASE_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_base_cotizacionColumnIndex)), 9);
					record.ES_USADO = Convert.ToString(reader.GetValue(es_usadoColumnIndex));
					record.ES_DANHADO = Convert.ToString(reader.GetValue(es_danhadoColumnIndex));
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					record.ES_OBSOLETO = Convert.ToString(reader.GetValue(es_obsoletoColumnIndex));
					record.ES_COMBO_REPRESENTATIVO = Convert.ToString(reader.GetValue(es_combo_representativoColumnIndex));
					if(!reader.IsDBNull(descripcion_catalogoColumnIndex))
						record.DESCRIPCION_CATALOGO = Convert.ToString(reader.GetValue(descripcion_catalogoColumnIndex));
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					if(!reader.IsDBNull(imagen_path_tmpColumnIndex))
						record.IMAGEN_PATH_TMP = Convert.ToString(reader.GetValue(imagen_path_tmpColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencionColumnIndex))
						record.RETENCION = Math.Round(Convert.ToDecimal(reader.GetValue(retencionColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeraciones_idColumnIndex))
						record.AUTONUMERACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeraciones_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_minimaColumnIndex))
						record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_maximaColumnIndex))
						record.CANTIDAD_MAXIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_maximaColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_controlColumnIndex))
						record.UNIDAD_MEDIDA_CONTROL = Convert.ToString(reader.GetValue(unidad_medida_controlColumnIndex));
					if(!reader.IsDBNull(cantidad_mayoristaColumnIndex))
						record.CANTIDAD_MAYORISTA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_mayoristaColumnIndex)), 9);
					record.PARA_COMPRA = Convert.ToString(reader.GetValue(para_compraColumnIndex));
					record.ES_FORMULA = Convert.ToString(reader.GetValue(es_formulaColumnIndex));
					if(!reader.IsDBNull(tipo_formulaColumnIndex))
						record.TIPO_FORMULA = Convert.ToString(reader.GetValue(tipo_formulaColumnIndex));
					if(!reader.IsDBNull(cantidad_minima_produccionColumnIndex))
						record.CANTIDAD_MINIMA_PRODUCCION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minima_produccionColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_maxima_produccionColumnIndex))
						record.CANTIDAD_MAXIMA_PRODUCCION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_maxima_produccionColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_precio_padreColumnIndex))
						record.PORCENTAJE_PRECIO_PADRE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_precio_padreColumnIndex)), 9);
					if(!reader.IsDBNull(monto_precio_padreColumnIndex))
						record.MONTO_PRECIO_PADRE = Math.Round(Convert.ToDecimal(reader.GetValue(monto_precio_padreColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_balanzaColumnIndex))
						record.CODIGO_BALANZA = Convert.ToString(reader.GetValue(codigo_balanzaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOSRow[])(recordList.ToArray(typeof(ARTICULOSRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOSRow"/> object.</returns>
		protected virtual ARTICULOSRow MapRow(DataRow row)
		{
			ARTICULOSRow mappedObject = new ARTICULOSRow();
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
			// Column "DESCRIPCION_PROVEEDOR"
			dataColumn = dataTable.Columns["DESCRIPCION_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_PROVEEDOR = (string)row[dataColumn];
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
			// Column "CODIGO_CATALOGO_PROVEEDOR"
			dataColumn = dataTable.Columns["CODIGO_CATALOGO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_CATALOGO_PROVEEDOR = (string)row[dataColumn];
			// Column "IMPORTADO"
			dataColumn = dataTable.Columns["IMPORTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTADO = (string)row[dataColumn];
			// Column "PRODUCCION_INTERNA"
			dataColumn = dataTable.Columns["PRODUCCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRODUCCION_INTERNA = (string)row[dataColumn];
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
			// Column "ES_TRAZABLE"
			dataColumn = dataTable.Columns["ES_TRAZABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TRAZABLE = (string)row[dataColumn];
			// Column "PARA_VENTA"
			dataColumn = dataTable.Columns["PARA_VENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARA_VENTA = (string)row[dataColumn];
			// Column "ES_COMBO"
			dataColumn = dataTable.Columns["ES_COMBO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COMBO = (string)row[dataColumn];
			// Column "ARTICULO_LINEA_ID"
			dataColumn = dataTable.Columns["ARTICULO_LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LINEA_ID = (decimal)row[dataColumn];
			// Column "PROCEDENCIA"
			dataColumn = dataTable.Columns["PROCEDENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCEDENCIA = (decimal)row[dataColumn];
			// Column "GENERO"
			dataColumn = dataTable.Columns["GENERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERO = (string)row[dataColumn];
			// Column "ARTICULO_PADRE_ID"
			dataColumn = dataTable.Columns["ARTICULO_PADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_PADRE_ID = (decimal)row[dataColumn];
			// Column "NO_REPONER"
			dataColumn = dataTable.Columns["NO_REPONER"];
			if(!row.IsNull(dataColumn))
				mappedObject.NO_REPONER = (string)row[dataColumn];
			// Column "ES_COMBO_ABIERTO"
			dataColumn = dataTable.Columns["ES_COMBO_ABIERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COMBO_ABIERTO = (string)row[dataColumn];
			// Column "ES_MODIFICABLE"
			dataColumn = dataTable.Columns["ES_MODIFICABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_MODIFICABLE = (string)row[dataColumn];
			// Column "ARTICULO_MARCA_ID"
			dataColumn = dataTable.Columns["ARTICULO_MARCA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MARCA_ID = (decimal)row[dataColumn];
			// Column "RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECARGO_FINANCIERO = (string)row[dataColumn];
			// Column "NOTA_CREDITO_ID"
			dataColumn = dataTable.Columns["NOTA_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_ID = (decimal)row[dataColumn];
			// Column "CONTROLAR_PRECIO"
			dataColumn = dataTable.Columns["CONTROLAR_PRECIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROLAR_PRECIO = (string)row[dataColumn];
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
			// Column "ES_USADO"
			dataColumn = dataTable.Columns["ES_USADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_USADO = (string)row[dataColumn];
			// Column "ES_DANHADO"
			dataColumn = dataTable.Columns["ES_DANHADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_DANHADO = (string)row[dataColumn];
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
			// Column "DESCRIPCION_CATALOGO"
			dataColumn = dataTable.Columns["DESCRIPCION_CATALOGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_CATALOGO = (string)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "IMAGEN_PATH_TMP"
			dataColumn = dataTable.Columns["IMAGEN_PATH_TMP"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMAGEN_PATH_TMP = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "RETENCION"
			dataColumn = dataTable.Columns["RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION = (decimal)row[dataColumn];
			// Column "AUTONUMERACIONES_ID"
			dataColumn = dataTable.Columns["AUTONUMERACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACIONES_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "CANTIDAD_MAXIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MAXIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAXIMA = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_CONTROL"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_CONTROL"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_CONTROL = (string)row[dataColumn];
			// Column "CANTIDAD_MAYORISTA"
			dataColumn = dataTable.Columns["CANTIDAD_MAYORISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAYORISTA = (decimal)row[dataColumn];
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
			// Column "CANTIDAD_MINIMA_PRODUCCION"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA_PRODUCCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA_PRODUCCION = (decimal)row[dataColumn];
			// Column "CANTIDAD_MAXIMA_PRODUCCION"
			dataColumn = dataTable.Columns["CANTIDAD_MAXIMA_PRODUCCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAXIMA_PRODUCCION = (decimal)row[dataColumn];
			// Column "PORCENTAJE_PRECIO_PADRE"
			dataColumn = dataTable.Columns["PORCENTAJE_PRECIO_PADRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_PRECIO_PADRE = (decimal)row[dataColumn];
			// Column "MONTO_PRECIO_PADRE"
			dataColumn = dataTable.Columns["MONTO_PRECIO_PADRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRECIO_PADRE = (decimal)row[dataColumn];
			// Column "CODIGO_BALANZA"
			dataColumn = dataTable.Columns["CODIGO_BALANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BALANZA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CODIGO_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO_BARRAS_EMPRESA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CODIGO_BARRAS_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_IMPRESION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CODIGO_PRESENTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO_EMPAQUE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO_COLOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO_TALLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO_CATALOGO_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("IMPORTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRODUCCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION_KG", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION_M", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPUESTO_COMPRA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SERVICIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COMBO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ES_TRAZABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PARA_VENTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_COMBO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_LINEA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROCEDENCIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GENERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ARTICULO_PADRE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NO_REPONER", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_COMBO_ABIERTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_MODIFICABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_MARCA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RECARGO_FINANCIERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONTROLAR_PRECIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_BASE_MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_BASE_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_BASE_COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_USADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_DANHADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_OBSOLETO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_COMBO_REPRESENTATIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_CATALOGO", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMAGEN_PATH_TMP", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACIONES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAXIMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_CONTROL", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAYORISTA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PARA_COMPRA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_FORMULA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_FORMULA", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA_PRODUCCION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAXIMA_PRODUCCION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_PRECIO_PADRE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_PRECIO_PADRE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO_BALANZA", typeof(string));
			dataColumn.MaxLength = 5;
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

				case "DESCRIPCION_PROVEEDOR":
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

				case "CODIGO_CATALOGO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPORTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRODUCCION_INTERNA":
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

				case "ES_TRAZABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PARA_VENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COMBO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCEDENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GENERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_PADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NO_REPONER":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COMBO_ABIERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_MODIFICABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_MARCA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOTA_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTROLAR_PRECIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
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

				case "ES_USADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_DANHADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
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

				case "DESCRIPCION_CATALOGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMAGEN_PATH_TMP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MAXIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_CONTROL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_MAYORISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "CANTIDAD_MINIMA_PRODUCCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MAXIMA_PRODUCCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_PRECIO_PADRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PRECIO_PADRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_BALANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOSCollection_Base class
}  // End of namespace
