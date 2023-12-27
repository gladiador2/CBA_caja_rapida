// <fileinfo name="IMPORTACION_INGRESO_COSTOSCollection_Base.cs">
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
	/// The base class for <see cref="IMPORTACION_INGRESO_COSTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="IMPORTACION_INGRESO_COSTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACION_INGRESO_COSTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string INGRESO_STOCK_IDColumnName = "INGRESO_STOCK_ID";
		public const string INGRESO_STOCK_DETALLE_IDColumnName = "INGRESO_STOCK_DETALLE_ID";
		public const string IMPORTACION_IDColumnName = "IMPORTACION_ID";
		public const string IMPORTACION_GASTOS_IDColumnName = "IMPORTACION_GASTOS_ID";
		public const string MONTOColumnName = "MONTO";
		public const string PORCENTAJEColumnName = "PORCENTAJE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACION_INGRESO_COSTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public IMPORTACION_INGRESO_COSTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>IMPORTACION_INGRESO_COSTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>IMPORTACION_INGRESO_COSTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>IMPORTACION_INGRESO_COSTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public IMPORTACION_INGRESO_COSTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			IMPORTACION_INGRESO_COSTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public IMPORTACION_INGRESO_COSTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.IMPORTACION_INGRESO_COSTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="IMPORTACION_INGRESO_COSTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			IMPORTACION_INGRESO_COSTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public IMPORTACION_INGRESO_COSTOSRow[] GetByIMPORTACION_GASTOS_ID(decimal importacion_gastos_id)
		{
			return GetByIMPORTACION_GASTOS_ID(importacion_gastos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <param name="importacion_gastos_idNull">true if the method ignores the importacion_gastos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow[] GetByIMPORTACION_GASTOS_ID(decimal importacion_gastos_id, bool importacion_gastos_idNull)
		{
			return MapRecords(CreateGetByIMPORTACION_GASTOS_IDCommand(importacion_gastos_id, importacion_gastos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPORTACION_GASTOS_IDAsDataTable(decimal importacion_gastos_id)
		{
			return GetByIMPORTACION_GASTOS_IDAsDataTable(importacion_gastos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <param name="importacion_gastos_idNull">true if the method ignores the importacion_gastos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPORTACION_GASTOS_IDAsDataTable(decimal importacion_gastos_id, bool importacion_gastos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByIMPORTACION_GASTOS_IDCommand(importacion_gastos_id, importacion_gastos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <param name="importacion_gastos_idNull">true if the method ignores the importacion_gastos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPORTACION_GASTOS_IDCommand(decimal importacion_gastos_id, bool importacion_gastos_idNull)
		{
			string whereSql = "";
			if(importacion_gastos_idNull)
				whereSql += "IMPORTACION_GASTOS_ID IS NULL";
			else
				whereSql += "IMPORTACION_GASTOS_ID=" + _db.CreateSqlParameterName("IMPORTACION_GASTOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!importacion_gastos_idNull)
				AddParameter(cmd, "IMPORTACION_GASTOS_ID", importacion_gastos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public IMPORTACION_INGRESO_COSTOSRow[] GetByIMPORTACION_ID(decimal importacion_id)
		{
			return GetByIMPORTACION_ID(importacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow[] GetByIMPORTACION_ID(decimal importacion_id, bool importacion_idNull)
		{
			return MapRecords(CreateGetByIMPORTACION_IDCommand(importacion_id, importacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPORTACION_IDAsDataTable(decimal importacion_id)
		{
			return GetByIMPORTACION_IDAsDataTable(importacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPORTACION_IDAsDataTable(decimal importacion_id, bool importacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByIMPORTACION_IDCommand(importacion_id, importacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPORTACION_IDCommand(decimal importacion_id, bool importacion_idNull)
		{
			string whereSql = "";
			if(importacion_idNull)
				whereSql += "IMPORTACION_ID IS NULL";
			else
				whereSql += "IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!importacion_idNull)
				AddParameter(cmd, "IMPORTACION_ID", importacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public IMPORTACION_INGRESO_COSTOSRow[] GetByINGRESO_STOCK_DETALLE_ID(decimal ingreso_stock_detalle_id)
		{
			return GetByINGRESO_STOCK_DETALLE_ID(ingreso_stock_detalle_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <param name="ingreso_stock_detalle_idNull">true if the method ignores the ingreso_stock_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow[] GetByINGRESO_STOCK_DETALLE_ID(decimal ingreso_stock_detalle_id, bool ingreso_stock_detalle_idNull)
		{
			return MapRecords(CreateGetByINGRESO_STOCK_DETALLE_IDCommand(ingreso_stock_detalle_id, ingreso_stock_detalle_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINGRESO_STOCK_DETALLE_IDAsDataTable(decimal ingreso_stock_detalle_id)
		{
			return GetByINGRESO_STOCK_DETALLE_IDAsDataTable(ingreso_stock_detalle_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <param name="ingreso_stock_detalle_idNull">true if the method ignores the ingreso_stock_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINGRESO_STOCK_DETALLE_IDAsDataTable(decimal ingreso_stock_detalle_id, bool ingreso_stock_detalle_idNull)
		{
			return MapRecordsToDataTable(CreateGetByINGRESO_STOCK_DETALLE_IDCommand(ingreso_stock_detalle_id, ingreso_stock_detalle_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <param name="ingreso_stock_detalle_idNull">true if the method ignores the ingreso_stock_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINGRESO_STOCK_DETALLE_IDCommand(decimal ingreso_stock_detalle_id, bool ingreso_stock_detalle_idNull)
		{
			string whereSql = "";
			if(ingreso_stock_detalle_idNull)
				whereSql += "INGRESO_STOCK_DETALLE_ID IS NULL";
			else
				whereSql += "INGRESO_STOCK_DETALLE_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ingreso_stock_detalle_idNull)
				AddParameter(cmd, "INGRESO_STOCK_DETALLE_ID", ingreso_stock_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public IMPORTACION_INGRESO_COSTOSRow[] GetByINGRESO_STOCK_ID(decimal ingreso_stock_id)
		{
			return GetByINGRESO_STOCK_ID(ingreso_stock_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <param name="ingreso_stock_idNull">true if the method ignores the ingreso_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow[] GetByINGRESO_STOCK_ID(decimal ingreso_stock_id, bool ingreso_stock_idNull)
		{
			return MapRecords(CreateGetByINGRESO_STOCK_IDCommand(ingreso_stock_id, ingreso_stock_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINGRESO_STOCK_IDAsDataTable(decimal ingreso_stock_id)
		{
			return GetByINGRESO_STOCK_IDAsDataTable(ingreso_stock_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <param name="ingreso_stock_idNull">true if the method ignores the ingreso_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINGRESO_STOCK_IDAsDataTable(decimal ingreso_stock_id, bool ingreso_stock_idNull)
		{
			return MapRecordsToDataTable(CreateGetByINGRESO_STOCK_IDCommand(ingreso_stock_id, ingreso_stock_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <param name="ingreso_stock_idNull">true if the method ignores the ingreso_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINGRESO_STOCK_IDCommand(decimal ingreso_stock_id, bool ingreso_stock_idNull)
		{
			string whereSql = "";
			if(ingreso_stock_idNull)
				whereSql += "INGRESO_STOCK_ID IS NULL";
			else
				whereSql += "INGRESO_STOCK_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ingreso_stock_idNull)
				AddParameter(cmd, "INGRESO_STOCK_ID", ingreso_stock_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public IMPORTACION_INGRESO_COSTOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects 
		/// by the <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		public virtual IMPORTACION_INGRESO_COSTOSRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>IMPORTACION_INGRESO_COSTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACION_INGRESO_COSTOSRow"/> object to be inserted.</param>
		public virtual void Insert(IMPORTACION_INGRESO_COSTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.IMPORTACION_INGRESO_COSTOS (" +
				"ID, " +
				"INGRESO_STOCK_ID, " +
				"INGRESO_STOCK_DETALLE_ID, " +
				"IMPORTACION_ID, " +
				"IMPORTACION_GASTOS_ID, " +
				"MONTO, " +
				"PORCENTAJE, " +
				"MONEDA_ID, " +
				"COTIZACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("INGRESO_STOCK_ID") + ", " +
				_db.CreateSqlParameterName("INGRESO_STOCK_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("IMPORTACION_ID") + ", " +
				_db.CreateSqlParameterName("IMPORTACION_GASTOS_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "INGRESO_STOCK_ID",
				value.IsINGRESO_STOCK_IDNull ? DBNull.Value : (object)value.INGRESO_STOCK_ID);
			AddParameter(cmd, "INGRESO_STOCK_DETALLE_ID",
				value.IsINGRESO_STOCK_DETALLE_IDNull ? DBNull.Value : (object)value.INGRESO_STOCK_DETALLE_ID);
			AddParameter(cmd, "IMPORTACION_ID",
				value.IsIMPORTACION_IDNull ? DBNull.Value : (object)value.IMPORTACION_ID);
			AddParameter(cmd, "IMPORTACION_GASTOS_ID",
				value.IsIMPORTACION_GASTOS_IDNull ? DBNull.Value : (object)value.IMPORTACION_GASTOS_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>IMPORTACION_INGRESO_COSTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACION_INGRESO_COSTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(IMPORTACION_INGRESO_COSTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.IMPORTACION_INGRESO_COSTOS SET " +
				"INGRESO_STOCK_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_ID") + ", " +
				"INGRESO_STOCK_DETALLE_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_DETALLE_ID") + ", " +
				"IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID") + ", " +
				"IMPORTACION_GASTOS_ID=" + _db.CreateSqlParameterName("IMPORTACION_GASTOS_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"PORCENTAJE=" + _db.CreateSqlParameterName("PORCENTAJE") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "INGRESO_STOCK_ID",
				value.IsINGRESO_STOCK_IDNull ? DBNull.Value : (object)value.INGRESO_STOCK_ID);
			AddParameter(cmd, "INGRESO_STOCK_DETALLE_ID",
				value.IsINGRESO_STOCK_DETALLE_IDNull ? DBNull.Value : (object)value.INGRESO_STOCK_DETALLE_ID);
			AddParameter(cmd, "IMPORTACION_ID",
				value.IsIMPORTACION_IDNull ? DBNull.Value : (object)value.IMPORTACION_ID);
			AddParameter(cmd, "IMPORTACION_GASTOS_ID",
				value.IsIMPORTACION_GASTOS_IDNull ? DBNull.Value : (object)value.IMPORTACION_GASTOS_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>IMPORTACION_INGRESO_COSTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>IMPORTACION_INGRESO_COSTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>IMPORTACION_INGRESO_COSTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACION_INGRESO_COSTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(IMPORTACION_INGRESO_COSTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>IMPORTACION_INGRESO_COSTOS</c> table using
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
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPORTACION_GASTOS_ID(decimal importacion_gastos_id)
		{
			return DeleteByIMPORTACION_GASTOS_ID(importacion_gastos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <param name="importacion_gastos_idNull">true if the method ignores the importacion_gastos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPORTACION_GASTOS_ID(decimal importacion_gastos_id, bool importacion_gastos_idNull)
		{
			return CreateDeleteByIMPORTACION_GASTOS_IDCommand(importacion_gastos_id, importacion_gastos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IMP_ING_CT_IMP_GTS_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_gastos_id">The <c>IMPORTACION_GASTOS_ID</c> column value.</param>
		/// <param name="importacion_gastos_idNull">true if the method ignores the importacion_gastos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPORTACION_GASTOS_IDCommand(decimal importacion_gastos_id, bool importacion_gastos_idNull)
		{
			string whereSql = "";
			if(importacion_gastos_idNull)
				whereSql += "IMPORTACION_GASTOS_ID IS NULL";
			else
				whereSql += "IMPORTACION_GASTOS_ID=" + _db.CreateSqlParameterName("IMPORTACION_GASTOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!importacion_gastos_idNull)
				AddParameter(cmd, "IMPORTACION_GASTOS_ID", importacion_gastos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPORTACION_ID(decimal importacion_id)
		{
			return DeleteByIMPORTACION_ID(importacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPORTACION_ID(decimal importacion_id, bool importacion_idNull)
		{
			return CreateDeleteByIMPORTACION_IDCommand(importacion_id, importacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IMP_ING_CT_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPORTACION_IDCommand(decimal importacion_id, bool importacion_idNull)
		{
			string whereSql = "";
			if(importacion_idNull)
				whereSql += "IMPORTACION_ID IS NULL";
			else
				whereSql += "IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!importacion_idNull)
				AddParameter(cmd, "IMPORTACION_ID", importacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINGRESO_STOCK_DETALLE_ID(decimal ingreso_stock_detalle_id)
		{
			return DeleteByINGRESO_STOCK_DETALLE_ID(ingreso_stock_detalle_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <param name="ingreso_stock_detalle_idNull">true if the method ignores the ingreso_stock_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINGRESO_STOCK_DETALLE_ID(decimal ingreso_stock_detalle_id, bool ingreso_stock_detalle_idNull)
		{
			return CreateDeleteByINGRESO_STOCK_DETALLE_IDCommand(ingreso_stock_detalle_id, ingreso_stock_detalle_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IMP_ING_CT_INGR_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_detalle_id">The <c>INGRESO_STOCK_DETALLE_ID</c> column value.</param>
		/// <param name="ingreso_stock_detalle_idNull">true if the method ignores the ingreso_stock_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINGRESO_STOCK_DETALLE_IDCommand(decimal ingreso_stock_detalle_id, bool ingreso_stock_detalle_idNull)
		{
			string whereSql = "";
			if(ingreso_stock_detalle_idNull)
				whereSql += "INGRESO_STOCK_DETALLE_ID IS NULL";
			else
				whereSql += "INGRESO_STOCK_DETALLE_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ingreso_stock_detalle_idNull)
				AddParameter(cmd, "INGRESO_STOCK_DETALLE_ID", ingreso_stock_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINGRESO_STOCK_ID(decimal ingreso_stock_id)
		{
			return DeleteByINGRESO_STOCK_ID(ingreso_stock_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <param name="ingreso_stock_idNull">true if the method ignores the ingreso_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINGRESO_STOCK_ID(decimal ingreso_stock_id, bool ingreso_stock_idNull)
		{
			return CreateDeleteByINGRESO_STOCK_IDCommand(ingreso_stock_id, ingreso_stock_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IMP_ING_CT_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_stock_id">The <c>INGRESO_STOCK_ID</c> column value.</param>
		/// <param name="ingreso_stock_idNull">true if the method ignores the ingreso_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINGRESO_STOCK_IDCommand(decimal ingreso_stock_id, bool ingreso_stock_idNull)
		{
			string whereSql = "";
			if(ingreso_stock_idNull)
				whereSql += "INGRESO_STOCK_ID IS NULL";
			else
				whereSql += "INGRESO_STOCK_ID=" + _db.CreateSqlParameterName("INGRESO_STOCK_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ingreso_stock_idNull)
				AddParameter(cmd, "INGRESO_STOCK_ID", ingreso_stock_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACION_INGRESO_COSTOS</c> table using the 
		/// <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id, moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IMP_ING_CT_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>IMPORTACION_INGRESO_COSTOS</c> records that match the specified criteria.
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
		/// to delete <c>IMPORTACION_INGRESO_COSTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.IMPORTACION_INGRESO_COSTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>IMPORTACION_INGRESO_COSTOS</c> table.
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
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		protected IMPORTACION_INGRESO_COSTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		protected IMPORTACION_INGRESO_COSTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="IMPORTACION_INGRESO_COSTOSRow"/> objects.</returns>
		protected virtual IMPORTACION_INGRESO_COSTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ingreso_stock_idColumnIndex = reader.GetOrdinal("INGRESO_STOCK_ID");
			int ingreso_stock_detalle_idColumnIndex = reader.GetOrdinal("INGRESO_STOCK_DETALLE_ID");
			int importacion_idColumnIndex = reader.GetOrdinal("IMPORTACION_ID");
			int importacion_gastos_idColumnIndex = reader.GetOrdinal("IMPORTACION_GASTOS_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					IMPORTACION_INGRESO_COSTOSRow record = new IMPORTACION_INGRESO_COSTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_stock_idColumnIndex))
						record.INGRESO_STOCK_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_stock_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_stock_detalle_idColumnIndex))
						record.INGRESO_STOCK_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_stock_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_idColumnIndex))
						record.IMPORTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_gastos_idColumnIndex))
						record.IMPORTACION_GASTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_gastos_idColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentajeColumnIndex))
						record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (IMPORTACION_INGRESO_COSTOSRow[])(recordList.ToArray(typeof(IMPORTACION_INGRESO_COSTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="IMPORTACION_INGRESO_COSTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="IMPORTACION_INGRESO_COSTOSRow"/> object.</returns>
		protected virtual IMPORTACION_INGRESO_COSTOSRow MapRow(DataRow row)
		{
			IMPORTACION_INGRESO_COSTOSRow mappedObject = new IMPORTACION_INGRESO_COSTOSRow();
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
			// Column "INGRESO_STOCK_DETALLE_ID"
			dataColumn = dataTable.Columns["INGRESO_STOCK_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_STOCK_DETALLE_ID = (decimal)row[dataColumn];
			// Column "IMPORTACION_ID"
			dataColumn = dataTable.Columns["IMPORTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_ID = (decimal)row[dataColumn];
			// Column "IMPORTACION_GASTOS_ID"
			dataColumn = dataTable.Columns["IMPORTACION_GASTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_GASTOS_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>IMPORTACION_INGRESO_COSTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "IMPORTACION_INGRESO_COSTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO_STOCK_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INGRESO_STOCK_DETALLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPORTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPORTACION_GASTOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
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

				case "INGRESO_STOCK_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_GASTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of IMPORTACION_INGRESO_COSTOSCollection_Base class
}  // End of namespace
