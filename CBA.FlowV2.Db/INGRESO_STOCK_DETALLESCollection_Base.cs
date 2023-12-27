// <fileinfo name="INGRESO_STOCK_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="INGRESO_STOCK_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INGRESO_STOCK_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_STOCK_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string INGRESO_STOCK_IDColumnName = "INGRESO_STOCK_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string CANTIDAD_TOTAL_ORIGENColumnName = "CANTIDAD_TOTAL_ORIGEN";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string COSTOColumnName = "COSTO";
		public const string COSTO_IMPUESTO_PORCColumnName = "COSTO_IMPUESTO_PORC";
		public const string UNIDAD_IDColumnName = "UNIDAD_ID";
		public const string CANTIDAD_TOTAL_DESTINOColumnName = "CANTIDAD_TOTAL_DESTINO";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string PORCENTAJE_PRORRATEO_DETALLEColumnName = "PORCENTAJE_PRORRATEO_DETALLE";
		public const string MONTO_PRORRATEO_DETALLEColumnName = "MONTO_PRORRATEO_DETALLE";
		public const string MONTO_PRORRATEADOColumnName = "MONTO_PRORRATEADO";
		public const string COSTO_NETO_SIN_DTO_ORIGINALColumnName = "COSTO_NETO_SIN_DTO_ORIGINAL";
		public const string MONEDA_ORIGINAL_IDColumnName = "MONEDA_ORIGINAL_ID";
		public const string CANTIDAD_ORIGINALColumnName = "CANTIDAD_ORIGINAL";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string GASTO_UNITARIO_APLICADOColumnName = "GASTO_UNITARIO_APLICADO";
		public const string GASTO_TOTAL_APLICADOColumnName = "GASTO_TOTAL_APLICADO";
		public const string COSTO_PRORRATEADOColumnName = "COSTO_PRORRATEADO";
		public const string MONTO_TOTAL_PRORRATEADOColumnName = "MONTO_TOTAL_PRORRATEADO";
		public const string MONEDA_PAIS_COTIZACIONColumnName = "MONEDA_PAIS_COTIZACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_STOCK_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INGRESO_STOCK_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INGRESO_STOCK_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INGRESO_STOCK_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INGRESO_STOCK_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INGRESO_STOCK_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INGRESO_STOCK_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INGRESO_STOCK_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INGRESO_STOCK_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public INGRESO_STOCK_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INGRESO_STOCK_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="INGRESO_STOCK_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="INGRESO_STOCK_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual INGRESO_STOCK_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			INGRESO_STOCK_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public INGRESO_STOCK_DETALLESRow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DETALLESRow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
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
		/// return records by the <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_ING_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DETALLESRow[] GetByINGRESO_STOCK_ID(decimal ingreso_stock_id)
		{
			return MapRecords(CreateGetByINGRESO_STOCK_IDCommand(ingreso_stock_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_ING_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINGRESO_STOCK_IDAsDataTable(decimal ingreso_stock_id)
		{
			return MapRecordsToDataTable(CreateGetByINGRESO_STOCK_IDCommand(ingreso_stock_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_DET_ING_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINGRESO_STOCK_IDCommand(decimal ingreso_stock_id)
		{
			string whereSql = "";
			whereSql += "INGRESO_STOCK_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "INGRESO_STOCK_ID", ingreso_stock_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public INGRESO_STOCK_DETALLESRow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DETALLESRow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOTE_IDAsDataTable(decimal lote_id, bool lote_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DETALLESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public INGRESO_STOCK_DETALLESRow[] GetByMONEDA_ORIGINAL_ID(decimal moneda_original_id)
		{
			return GetByMONEDA_ORIGINAL_ID(moneda_original_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects 
		/// by the <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <param name="moneda_original_idNull">true if the method ignores the moneda_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DETALLESRow[] GetByMONEDA_ORIGINAL_ID(decimal moneda_original_id, bool moneda_original_idNull)
		{
			return MapRecords(CreateGetByMONEDA_ORIGINAL_IDCommand(moneda_original_id, moneda_original_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_ORIGINAL_IDAsDataTable(decimal moneda_original_id)
		{
			return GetByMONEDA_ORIGINAL_IDAsDataTable(moneda_original_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <param name="moneda_original_idNull">true if the method ignores the moneda_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGINAL_IDAsDataTable(decimal moneda_original_id, bool moneda_original_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGINAL_IDCommand(moneda_original_id, moneda_original_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <param name="moneda_original_idNull">true if the method ignores the moneda_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_ORIGINAL_IDCommand(decimal moneda_original_id, bool moneda_original_idNull)
		{
			string whereSql = "";
			if(moneda_original_idNull)
				whereSql += "MONEDA_ORIGINAL_ID IS NULL";
			else
				whereSql += "MONEDA_ORIGINAL_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGINAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_original_idNull)
				AddParameter(cmd, "MONEDA_ORIGINAL_ID", moneda_original_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>INGRESO_STOCK_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_STOCK_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(INGRESO_STOCK_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.INGRESO_STOCK_DETALLES (" +
				"ID, " +
				"INGRESO_STOCK_ID, " +
				"LOTE_ID, " +
				"CANTIDAD_TOTAL_ORIGEN, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"COSTO, " +
				"COSTO_IMPUESTO_PORC, " +
				"UNIDAD_ID, " +
				"CANTIDAD_TOTAL_DESTINO, " +
				"FACTOR_CONVERSION, " +
				"PORCENTAJE_PRORRATEO_DETALLE, " +
				"MONTO_PRORRATEO_DETALLE, " +
				"MONTO_PRORRATEADO, " +
				"COSTO_NETO_SIN_DTO_ORIGINAL, " +
				"MONEDA_ORIGINAL_ID, " +
				"CANTIDAD_ORIGINAL, " +
				"ACTIVO_ID, " +
				"GASTO_UNITARIO_APLICADO, " +
				"GASTO_TOTAL_APLICADO, " +
				"COSTO_PRORRATEADO, " +
				"MONTO_TOTAL_PRORRATEADO, " +
				"MONEDA_PAIS_COTIZACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("INGRESO_STOCK_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_TOTAL_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("COSTO") + ", " +
				_db.CreateSqlParameterName("COSTO_IMPUESTO_PORC") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_TOTAL_DESTINO") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_PRORRATEO_DETALLE") + ", " +
				_db.CreateSqlParameterName("MONTO_PRORRATEO_DETALLE") + ", " +
				_db.CreateSqlParameterName("MONTO_PRORRATEADO") + ", " +
				_db.CreateSqlParameterName("COSTO_NETO_SIN_DTO_ORIGINAL") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGINAL_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIGINAL") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("GASTO_UNITARIO_APLICADO") + ", " +
				_db.CreateSqlParameterName("GASTO_TOTAL_APLICADO") + ", " +
				_db.CreateSqlParameterName("COSTO_PRORRATEADO") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL_PRORRATEADO") + ", " +
				_db.CreateSqlParameterName("MONEDA_PAIS_COTIZACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "INGRESO_STOCK_ID", value.INGRESO_STOCK_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_TOTAL_ORIGEN", value.CANTIDAD_TOTAL_ORIGEN);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "COSTO", value.COSTO);
			AddParameter(cmd, "COSTO_IMPUESTO_PORC", value.COSTO_IMPUESTO_PORC);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "CANTIDAD_TOTAL_DESTINO",
				value.IsCANTIDAD_TOTAL_DESTINONull ? DBNull.Value : (object)value.CANTIDAD_TOTAL_DESTINO);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "PORCENTAJE_PRORRATEO_DETALLE",
				value.IsPORCENTAJE_PRORRATEO_DETALLENull ? DBNull.Value : (object)value.PORCENTAJE_PRORRATEO_DETALLE);
			AddParameter(cmd, "MONTO_PRORRATEO_DETALLE",
				value.IsMONTO_PRORRATEO_DETALLENull ? DBNull.Value : (object)value.MONTO_PRORRATEO_DETALLE);
			AddParameter(cmd, "MONTO_PRORRATEADO",
				value.IsMONTO_PRORRATEADONull ? DBNull.Value : (object)value.MONTO_PRORRATEADO);
			AddParameter(cmd, "COSTO_NETO_SIN_DTO_ORIGINAL",
				value.IsCOSTO_NETO_SIN_DTO_ORIGINALNull ? DBNull.Value : (object)value.COSTO_NETO_SIN_DTO_ORIGINAL);
			AddParameter(cmd, "MONEDA_ORIGINAL_ID",
				value.IsMONEDA_ORIGINAL_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGINAL_ID);
			AddParameter(cmd, "CANTIDAD_ORIGINAL",
				value.IsCANTIDAD_ORIGINALNull ? DBNull.Value : (object)value.CANTIDAD_ORIGINAL);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "GASTO_UNITARIO_APLICADO",
				value.IsGASTO_UNITARIO_APLICADONull ? DBNull.Value : (object)value.GASTO_UNITARIO_APLICADO);
			AddParameter(cmd, "GASTO_TOTAL_APLICADO",
				value.IsGASTO_TOTAL_APLICADONull ? DBNull.Value : (object)value.GASTO_TOTAL_APLICADO);
			AddParameter(cmd, "COSTO_PRORRATEADO",
				value.IsCOSTO_PRORRATEADONull ? DBNull.Value : (object)value.COSTO_PRORRATEADO);
			AddParameter(cmd, "MONTO_TOTAL_PRORRATEADO",
				value.IsMONTO_TOTAL_PRORRATEADONull ? DBNull.Value : (object)value.MONTO_TOTAL_PRORRATEADO);
			AddParameter(cmd, "MONEDA_PAIS_COTIZACION", value.MONEDA_PAIS_COTIZACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>INGRESO_STOCK_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_STOCK_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(INGRESO_STOCK_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.INGRESO_STOCK_DETALLES SET " +
				"INGRESO_STOCK_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"CANTIDAD_TOTAL_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_TOTAL_ORIGEN") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"COSTO=" + _db.CreateSqlParameterName("COSTO") + ", " +
				"COSTO_IMPUESTO_PORC=" + _db.CreateSqlParameterName("COSTO_IMPUESTO_PORC") + ", " +
				"UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				"CANTIDAD_TOTAL_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_TOTAL_DESTINO") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				"PORCENTAJE_PRORRATEO_DETALLE=" + _db.CreateSqlParameterName("PORCENTAJE_PRORRATEO_DETALLE") + ", " +
				"MONTO_PRORRATEO_DETALLE=" + _db.CreateSqlParameterName("MONTO_PRORRATEO_DETALLE") + ", " +
				"MONTO_PRORRATEADO=" + _db.CreateSqlParameterName("MONTO_PRORRATEADO") + ", " +
				"COSTO_NETO_SIN_DTO_ORIGINAL=" + _db.CreateSqlParameterName("COSTO_NETO_SIN_DTO_ORIGINAL") + ", " +
				"MONEDA_ORIGINAL_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGINAL_ID") + ", " +
				"CANTIDAD_ORIGINAL=" + _db.CreateSqlParameterName("CANTIDAD_ORIGINAL") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"GASTO_UNITARIO_APLICADO=" + _db.CreateSqlParameterName("GASTO_UNITARIO_APLICADO") + ", " +
				"GASTO_TOTAL_APLICADO=" + _db.CreateSqlParameterName("GASTO_TOTAL_APLICADO") + ", " +
				"COSTO_PRORRATEADO=" + _db.CreateSqlParameterName("COSTO_PRORRATEADO") + ", " +
				"MONTO_TOTAL_PRORRATEADO=" + _db.CreateSqlParameterName("MONTO_TOTAL_PRORRATEADO") + ", " +
				"MONEDA_PAIS_COTIZACION=" + _db.CreateSqlParameterName("MONEDA_PAIS_COTIZACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "INGRESO_STOCK_ID", value.INGRESO_STOCK_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_TOTAL_ORIGEN", value.CANTIDAD_TOTAL_ORIGEN);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "COSTO", value.COSTO);
			AddParameter(cmd, "COSTO_IMPUESTO_PORC", value.COSTO_IMPUESTO_PORC);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "CANTIDAD_TOTAL_DESTINO",
				value.IsCANTIDAD_TOTAL_DESTINONull ? DBNull.Value : (object)value.CANTIDAD_TOTAL_DESTINO);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "PORCENTAJE_PRORRATEO_DETALLE",
				value.IsPORCENTAJE_PRORRATEO_DETALLENull ? DBNull.Value : (object)value.PORCENTAJE_PRORRATEO_DETALLE);
			AddParameter(cmd, "MONTO_PRORRATEO_DETALLE",
				value.IsMONTO_PRORRATEO_DETALLENull ? DBNull.Value : (object)value.MONTO_PRORRATEO_DETALLE);
			AddParameter(cmd, "MONTO_PRORRATEADO",
				value.IsMONTO_PRORRATEADONull ? DBNull.Value : (object)value.MONTO_PRORRATEADO);
			AddParameter(cmd, "COSTO_NETO_SIN_DTO_ORIGINAL",
				value.IsCOSTO_NETO_SIN_DTO_ORIGINALNull ? DBNull.Value : (object)value.COSTO_NETO_SIN_DTO_ORIGINAL);
			AddParameter(cmd, "MONEDA_ORIGINAL_ID",
				value.IsMONEDA_ORIGINAL_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGINAL_ID);
			AddParameter(cmd, "CANTIDAD_ORIGINAL",
				value.IsCANTIDAD_ORIGINALNull ? DBNull.Value : (object)value.CANTIDAD_ORIGINAL);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "GASTO_UNITARIO_APLICADO",
				value.IsGASTO_UNITARIO_APLICADONull ? DBNull.Value : (object)value.GASTO_UNITARIO_APLICADO);
			AddParameter(cmd, "GASTO_TOTAL_APLICADO",
				value.IsGASTO_TOTAL_APLICADONull ? DBNull.Value : (object)value.GASTO_TOTAL_APLICADO);
			AddParameter(cmd, "COSTO_PRORRATEADO",
				value.IsCOSTO_PRORRATEADONull ? DBNull.Value : (object)value.COSTO_PRORRATEADO);
			AddParameter(cmd, "MONTO_TOTAL_PRORRATEADO",
				value.IsMONTO_TOTAL_PRORRATEADONull ? DBNull.Value : (object)value.MONTO_TOTAL_PRORRATEADO);
			AddParameter(cmd, "MONEDA_PAIS_COTIZACION", value.MONEDA_PAIS_COTIZACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>INGRESO_STOCK_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>INGRESO_STOCK_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>INGRESO_STOCK_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_STOCK_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(INGRESO_STOCK_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>INGRESO_STOCK_DETALLES</c> table using
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
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
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
		/// delete records using the <c>FK_ING_STOCK_DET_ACTIVO_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_ING_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINGRESO_STOCK_ID(decimal ingreso_stock_id)
		{
			return CreateDeleteByINGRESO_STOCK_IDCommand(ingreso_stock_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_DET_ING_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINGRESO_STOCK_IDCommand(decimal ingreso_stock_id)
		{
			string whereSql = "";
			whereSql += "INGRESO_STOCK_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "INGRESO_STOCK_ID", ingreso_stock_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return CreateDeleteByLOTE_IDCommand(lote_id, lote_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGINAL_ID(decimal moneda_original_id)
		{
			return DeleteByMONEDA_ORIGINAL_ID(moneda_original_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_STOCK_DETALLES</c> table using the 
		/// <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <param name="moneda_original_idNull">true if the method ignores the moneda_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGINAL_ID(decimal moneda_original_id, bool moneda_original_idNull)
		{
			return CreateDeleteByMONEDA_ORIGINAL_IDCommand(moneda_original_id, moneda_original_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ING_STOCK_DET_MONEDA_ORIG</c> foreign key.
		/// </summary>
		/// <param name="moneda_original_id">The <c>MONEDA_ORIGINAL_ID</c> column value.</param>
		/// <param name="moneda_original_idNull">true if the method ignores the moneda_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_ORIGINAL_IDCommand(decimal moneda_original_id, bool moneda_original_idNull)
		{
			string whereSql = "";
			if(moneda_original_idNull)
				whereSql += "MONEDA_ORIGINAL_ID IS NULL";
			else
				whereSql += "MONEDA_ORIGINAL_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGINAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_original_idNull)
				AddParameter(cmd, "MONEDA_ORIGINAL_ID", moneda_original_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>INGRESO_STOCK_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>INGRESO_STOCK_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.INGRESO_STOCK_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>INGRESO_STOCK_DETALLES</c> table.
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		protected INGRESO_STOCK_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		protected INGRESO_STOCK_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DETALLESRow"/> objects.</returns>
		protected virtual INGRESO_STOCK_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ingreso_stock_idColumnIndex = reader.GetOrdinal("INGRESO_STOCK_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int cantidad_total_origenColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_ORIGEN");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int costo_impuesto_porcColumnIndex = reader.GetOrdinal("COSTO_IMPUESTO_PORC");
			int unidad_idColumnIndex = reader.GetOrdinal("UNIDAD_ID");
			int cantidad_total_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_DESTINO");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int porcentaje_prorrateo_detalleColumnIndex = reader.GetOrdinal("PORCENTAJE_PRORRATEO_DETALLE");
			int monto_prorrateo_detalleColumnIndex = reader.GetOrdinal("MONTO_PRORRATEO_DETALLE");
			int monto_prorrateadoColumnIndex = reader.GetOrdinal("MONTO_PRORRATEADO");
			int costo_neto_sin_dto_originalColumnIndex = reader.GetOrdinal("COSTO_NETO_SIN_DTO_ORIGINAL");
			int moneda_original_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGINAL_ID");
			int cantidad_originalColumnIndex = reader.GetOrdinal("CANTIDAD_ORIGINAL");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int gasto_unitario_aplicadoColumnIndex = reader.GetOrdinal("GASTO_UNITARIO_APLICADO");
			int gasto_total_aplicadoColumnIndex = reader.GetOrdinal("GASTO_TOTAL_APLICADO");
			int costo_prorrateadoColumnIndex = reader.GetOrdinal("COSTO_PRORRATEADO");
			int monto_total_prorrateadoColumnIndex = reader.GetOrdinal("MONTO_TOTAL_PRORRATEADO");
			int moneda_pais_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_PAIS_COTIZACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INGRESO_STOCK_DETALLESRow record = new INGRESO_STOCK_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.INGRESO_STOCK_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_stock_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					record.CANTIDAD_TOTAL_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_origenColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					record.COSTO_IMPUESTO_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(costo_impuesto_porcColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_idColumnIndex))
						record.UNIDAD_ID = Convert.ToString(reader.GetValue(unidad_idColumnIndex));
					if(!reader.IsDBNull(cantidad_total_destinoColumnIndex))
						record.CANTIDAD_TOTAL_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_prorrateo_detalleColumnIndex))
						record.PORCENTAJE_PRORRATEO_DETALLE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_prorrateo_detalleColumnIndex)), 9);
					if(!reader.IsDBNull(monto_prorrateo_detalleColumnIndex))
						record.MONTO_PRORRATEO_DETALLE = Math.Round(Convert.ToDecimal(reader.GetValue(monto_prorrateo_detalleColumnIndex)), 9);
					if(!reader.IsDBNull(monto_prorrateadoColumnIndex))
						record.MONTO_PRORRATEADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_prorrateadoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_neto_sin_dto_originalColumnIndex))
						record.COSTO_NETO_SIN_DTO_ORIGINAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_neto_sin_dto_originalColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_original_idColumnIndex))
						record.MONEDA_ORIGINAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_original_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_originalColumnIndex))
						record.CANTIDAD_ORIGINAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_originalColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(gasto_unitario_aplicadoColumnIndex))
						record.GASTO_UNITARIO_APLICADO = Math.Round(Convert.ToDecimal(reader.GetValue(gasto_unitario_aplicadoColumnIndex)), 9);
					if(!reader.IsDBNull(gasto_total_aplicadoColumnIndex))
						record.GASTO_TOTAL_APLICADO = Math.Round(Convert.ToDecimal(reader.GetValue(gasto_total_aplicadoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_prorrateadoColumnIndex))
						record.COSTO_PRORRATEADO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_prorrateadoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_total_prorrateadoColumnIndex))
						record.MONTO_TOTAL_PRORRATEADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_prorrateadoColumnIndex)), 9);
					record.MONEDA_PAIS_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_pais_cotizacionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INGRESO_STOCK_DETALLESRow[])(recordList.ToArray(typeof(INGRESO_STOCK_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INGRESO_STOCK_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INGRESO_STOCK_DETALLESRow"/> object.</returns>
		protected virtual INGRESO_STOCK_DETALLESRow MapRow(DataRow row)
		{
			INGRESO_STOCK_DETALLESRow mappedObject = new INGRESO_STOCK_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "INGRESO_STOCK_ID"
			dataColumn = dataTable.Columns["INGRESO_STOCK_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_STOCK_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_TOTAL_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_ORIGEN = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "COSTO_IMPUESTO_PORC"
			dataColumn = dataTable.Columns["COSTO_IMPUESTO_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_IMPUESTO_PORC = (decimal)row[dataColumn];
			// Column "UNIDAD_ID"
			dataColumn = dataTable.Columns["UNIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID = (string)row[dataColumn];
			// Column "CANTIDAD_TOTAL_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_DESTINO = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "PORCENTAJE_PRORRATEO_DETALLE"
			dataColumn = dataTable.Columns["PORCENTAJE_PRORRATEO_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_PRORRATEO_DETALLE = (decimal)row[dataColumn];
			// Column "MONTO_PRORRATEO_DETALLE"
			dataColumn = dataTable.Columns["MONTO_PRORRATEO_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRORRATEO_DETALLE = (decimal)row[dataColumn];
			// Column "MONTO_PRORRATEADO"
			dataColumn = dataTable.Columns["MONTO_PRORRATEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRORRATEADO = (decimal)row[dataColumn];
			// Column "COSTO_NETO_SIN_DTO_ORIGINAL"
			dataColumn = dataTable.Columns["COSTO_NETO_SIN_DTO_ORIGINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_NETO_SIN_DTO_ORIGINAL = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGINAL_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGINAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGINAL_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_ORIGINAL"
			dataColumn = dataTable.Columns["CANTIDAD_ORIGINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIGINAL = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "GASTO_UNITARIO_APLICADO"
			dataColumn = dataTable.Columns["GASTO_UNITARIO_APLICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GASTO_UNITARIO_APLICADO = (decimal)row[dataColumn];
			// Column "GASTO_TOTAL_APLICADO"
			dataColumn = dataTable.Columns["GASTO_TOTAL_APLICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GASTO_TOTAL_APLICADO = (decimal)row[dataColumn];
			// Column "COSTO_PRORRATEADO"
			dataColumn = dataTable.Columns["COSTO_PRORRATEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_PRORRATEADO = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL_PRORRATEADO"
			dataColumn = dataTable.Columns["MONTO_TOTAL_PRORRATEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_PRORRATEADO = (decimal)row[dataColumn];
			// Column "MONEDA_PAIS_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_PAIS_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_PAIS_COTIZACION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INGRESO_STOCK_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INGRESO_STOCK_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO_STOCK_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_IMPUESTO_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_DESTINO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_PRORRATEO_DETALLE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_PRORRATEO_DETALLE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_PRORRATEADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_NETO_SIN_DTO_ORIGINAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGINAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIGINAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GASTO_UNITARIO_APLICADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GASTO_TOTAL_APLICADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_PRORRATEADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_PRORRATEADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_PAIS_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
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

				case "INGRESO_STOCK_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_TOTAL_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_IMPUESTO_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_TOTAL_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_PRORRATEO_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PRORRATEO_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PRORRATEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_NETO_SIN_DTO_ORIGINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGINAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ORIGINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GASTO_UNITARIO_APLICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GASTO_TOTAL_APLICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_PRORRATEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL_PRORRATEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_PAIS_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INGRESO_STOCK_DETALLESCollection_Base class
}  // End of namespace
