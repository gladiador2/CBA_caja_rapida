// <fileinfo name="OBJ_VEND_CLIE_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="OBJ_VEND_CLIE_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="OBJ_VEND_CLIE_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJ_VEND_CLIE_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string OBJETIVO_VENDEDOR_CLIENTE_IDColumnName = "OBJETIVO_VENDEDOR_CLIENTE_ID";
		public const string CLIENTE_IDColumnName = "CLIENTE_ID";
		public const string VENDEDOR_IDColumnName = "VENDEDOR_ID";
		public const string MONTOColumnName = "MONTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJ_VEND_CLIE_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public OBJ_VEND_CLIE_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>OBJ_VEND_CLIE_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_CLIE_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>OBJ_VEND_CLIE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>OBJ_VEND_CLIE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="OBJ_VEND_CLIE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public OBJ_VEND_CLIE_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			OBJ_VEND_CLIE_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public OBJ_VEND_CLIE_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_CLIE_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.OBJ_VEND_CLIE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="OBJ_VEND_CLIE_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="OBJ_VEND_CLIE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual OBJ_VEND_CLIE_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			OBJ_VEND_CLIE_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public OBJ_VEND_CLIE_DETALLERow[] GetByOBJETIVO_VENDEDOR_CLIENTE_ID(decimal objetivo_vendedor_cliente_id)
		{
			return GetByOBJETIVO_VENDEDOR_CLIENTE_ID(objetivo_vendedor_cliente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_cliente_idNull">true if the method ignores the objetivo_vendedor_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_CLIE_DETALLERow[] GetByOBJETIVO_VENDEDOR_CLIENTE_ID(decimal objetivo_vendedor_cliente_id, bool objetivo_vendedor_cliente_idNull)
		{
			return MapRecords(CreateGetByOBJETIVO_VENDEDOR_CLIENTE_IDCommand(objetivo_vendedor_cliente_id, objetivo_vendedor_cliente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByOBJETIVO_VENDEDOR_CLIENTE_IDAsDataTable(decimal objetivo_vendedor_cliente_id)
		{
			return GetByOBJETIVO_VENDEDOR_CLIENTE_IDAsDataTable(objetivo_vendedor_cliente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_cliente_idNull">true if the method ignores the objetivo_vendedor_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByOBJETIVO_VENDEDOR_CLIENTE_IDAsDataTable(decimal objetivo_vendedor_cliente_id, bool objetivo_vendedor_cliente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByOBJETIVO_VENDEDOR_CLIENTE_IDCommand(objetivo_vendedor_cliente_id, objetivo_vendedor_cliente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_cliente_idNull">true if the method ignores the objetivo_vendedor_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByOBJETIVO_VENDEDOR_CLIENTE_IDCommand(decimal objetivo_vendedor_cliente_id, bool objetivo_vendedor_cliente_idNull)
		{
			string whereSql = "";
			if(objetivo_vendedor_cliente_idNull)
				whereSql += "OBJETIVO_VENDEDOR_CLIENTE_ID IS NULL";
			else
				whereSql += "OBJETIVO_VENDEDOR_CLIENTE_ID=" + _db.CreateSqlParameterName("OBJETIVO_VENDEDOR_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!objetivo_vendedor_cliente_idNull)
				AddParameter(cmd, "OBJETIVO_VENDEDOR_CLIENTE_ID", objetivo_vendedor_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public OBJ_VEND_CLIE_DETALLERow[] GetByCLIENTE_ID(decimal cliente_id)
		{
			return GetByCLIENTE_ID(cliente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <param name="cliente_idNull">true if the method ignores the cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_CLIE_DETALLERow[] GetByCLIENTE_ID(decimal cliente_id, bool cliente_idNull)
		{
			return MapRecords(CreateGetByCLIENTE_IDCommand(cliente_id, cliente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCLIENTE_IDAsDataTable(decimal cliente_id)
		{
			return GetByCLIENTE_IDAsDataTable(cliente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <param name="cliente_idNull">true if the method ignores the cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCLIENTE_IDAsDataTable(decimal cliente_id, bool cliente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCLIENTE_IDCommand(cliente_id, cliente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <param name="cliente_idNull">true if the method ignores the cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCLIENTE_IDCommand(decimal cliente_id, bool cliente_idNull)
		{
			string whereSql = "";
			if(cliente_idNull)
				whereSql += "CLIENTE_ID IS NULL";
			else
				whereSql += "CLIENTE_ID=" + _db.CreateSqlParameterName("CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cliente_idNull)
				AddParameter(cmd, "CLIENTE_ID", cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public OBJ_VEND_CLIE_DETALLERow[] GetByVENDEDOR_ID(decimal vendedor_id)
		{
			return GetByVENDEDOR_ID(vendedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_CLIE_DETALLERow[] GetByVENDEDOR_ID(decimal vendedor_id, bool vendedor_idNull)
		{
			return MapRecords(CreateGetByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVENDEDOR_IDAsDataTable(decimal vendedor_id)
		{
			return GetByVENDEDOR_IDAsDataTable(vendedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVENDEDOR_IDAsDataTable(decimal vendedor_id, bool vendedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVENDEDOR_IDCommand(decimal vendedor_id, bool vendedor_idNull)
		{
			string whereSql = "";
			if(vendedor_idNull)
				whereSql += "VENDEDOR_ID IS NULL";
			else
				whereSql += "VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vendedor_idNull)
				AddParameter(cmd, "VENDEDOR_ID", vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>OBJ_VEND_CLIE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJ_VEND_CLIE_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(OBJ_VEND_CLIE_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.OBJ_VEND_CLIE_DETALLE (" +
				"ID, " +
				"OBJETIVO_VENDEDOR_CLIENTE_ID, " +
				"CLIENTE_ID, " +
				"VENDEDOR_ID, " +
				"MONTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("OBJETIVO_VENDEDOR_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("VENDEDOR_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "OBJETIVO_VENDEDOR_CLIENTE_ID",
				value.IsOBJETIVO_VENDEDOR_CLIENTE_IDNull ? DBNull.Value : (object)value.OBJETIVO_VENDEDOR_CLIENTE_ID);
			AddParameter(cmd, "CLIENTE_ID",
				value.IsCLIENTE_IDNull ? DBNull.Value : (object)value.CLIENTE_ID);
			AddParameter(cmd, "VENDEDOR_ID",
				value.IsVENDEDOR_IDNull ? DBNull.Value : (object)value.VENDEDOR_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>OBJ_VEND_CLIE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJ_VEND_CLIE_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(OBJ_VEND_CLIE_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.OBJ_VEND_CLIE_DETALLE SET " +
				"OBJETIVO_VENDEDOR_CLIENTE_ID=" + _db.CreateSqlParameterName("OBJETIVO_VENDEDOR_CLIENTE_ID") + ", " +
				"CLIENTE_ID=" + _db.CreateSqlParameterName("CLIENTE_ID") + ", " +
				"VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "OBJETIVO_VENDEDOR_CLIENTE_ID",
				value.IsOBJETIVO_VENDEDOR_CLIENTE_IDNull ? DBNull.Value : (object)value.OBJETIVO_VENDEDOR_CLIENTE_ID);
			AddParameter(cmd, "CLIENTE_ID",
				value.IsCLIENTE_IDNull ? DBNull.Value : (object)value.CLIENTE_ID);
			AddParameter(cmd, "VENDEDOR_ID",
				value.IsVENDEDOR_IDNull ? DBNull.Value : (object)value.VENDEDOR_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>OBJ_VEND_CLIE_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>OBJ_VEND_CLIE_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>OBJ_VEND_CLIE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJ_VEND_CLIE_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(OBJ_VEND_CLIE_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>OBJ_VEND_CLIE_DETALLE</c> table using
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
		/// Deletes records from the <c>OBJ_VEND_CLIE_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOBJETIVO_VENDEDOR_CLIENTE_ID(decimal objetivo_vendedor_cliente_id)
		{
			return DeleteByOBJETIVO_VENDEDOR_CLIENTE_ID(objetivo_vendedor_cliente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_CLIE_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_cliente_idNull">true if the method ignores the objetivo_vendedor_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOBJETIVO_VENDEDOR_CLIENTE_ID(decimal objetivo_vendedor_cliente_id, bool objetivo_vendedor_cliente_idNull)
		{
			return CreateDeleteByOBJETIVO_VENDEDOR_CLIENTE_IDCommand(objetivo_vendedor_cliente_id, objetivo_vendedor_cliente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_CLI_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_cliente_id">The <c>OBJETIVO_VENDEDOR_CLIENTE_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_cliente_idNull">true if the method ignores the objetivo_vendedor_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByOBJETIVO_VENDEDOR_CLIENTE_IDCommand(decimal objetivo_vendedor_cliente_id, bool objetivo_vendedor_cliente_idNull)
		{
			string whereSql = "";
			if(objetivo_vendedor_cliente_idNull)
				whereSql += "OBJETIVO_VENDEDOR_CLIENTE_ID IS NULL";
			else
				whereSql += "OBJETIVO_VENDEDOR_CLIENTE_ID=" + _db.CreateSqlParameterName("OBJETIVO_VENDEDOR_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!objetivo_vendedor_cliente_idNull)
				AddParameter(cmd, "OBJETIVO_VENDEDOR_CLIENTE_ID", objetivo_vendedor_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_CLIE_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCLIENTE_ID(decimal cliente_id)
		{
			return DeleteByCLIENTE_ID(cliente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_CLIE_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <param name="cliente_idNull">true if the method ignores the cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCLIENTE_ID(decimal cliente_id, bool cliente_idNull)
		{
			return CreateDeleteByCLIENTE_IDCommand(cliente_id, cliente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_CLIE_DET_CLIE_ID</c> foreign key.
		/// </summary>
		/// <param name="cliente_id">The <c>CLIENTE_ID</c> column value.</param>
		/// <param name="cliente_idNull">true if the method ignores the cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCLIENTE_IDCommand(decimal cliente_id, bool cliente_idNull)
		{
			string whereSql = "";
			if(cliente_idNull)
				whereSql += "CLIENTE_ID IS NULL";
			else
				whereSql += "CLIENTE_ID=" + _db.CreateSqlParameterName("CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cliente_idNull)
				AddParameter(cmd, "CLIENTE_ID", cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_CLIE_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_ID(decimal vendedor_id)
		{
			return DeleteByVENDEDOR_ID(vendedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_CLIE_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_ID(decimal vendedor_id, bool vendedor_idNull)
		{
			return CreateDeleteByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_CLIEN_DET_VEND_ID</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVENDEDOR_IDCommand(decimal vendedor_id, bool vendedor_idNull)
		{
			string whereSql = "";
			if(vendedor_idNull)
				whereSql += "VENDEDOR_ID IS NULL";
			else
				whereSql += "VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vendedor_idNull)
				AddParameter(cmd, "VENDEDOR_ID", vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>OBJ_VEND_CLIE_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>OBJ_VEND_CLIE_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.OBJ_VEND_CLIE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>OBJ_VEND_CLIE_DETALLE</c> table.
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
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		protected OBJ_VEND_CLIE_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		protected OBJ_VEND_CLIE_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="OBJ_VEND_CLIE_DETALLERow"/> objects.</returns>
		protected virtual OBJ_VEND_CLIE_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int objetivo_vendedor_cliente_idColumnIndex = reader.GetOrdinal("OBJETIVO_VENDEDOR_CLIENTE_ID");
			int cliente_idColumnIndex = reader.GetOrdinal("CLIENTE_ID");
			int vendedor_idColumnIndex = reader.GetOrdinal("VENDEDOR_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					OBJ_VEND_CLIE_DETALLERow record = new OBJ_VEND_CLIE_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(objetivo_vendedor_cliente_idColumnIndex))
						record.OBJETIVO_VENDEDOR_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(objetivo_vendedor_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(cliente_idColumnIndex))
						record.CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_idColumnIndex))
						record.VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OBJ_VEND_CLIE_DETALLERow[])(recordList.ToArray(typeof(OBJ_VEND_CLIE_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="OBJ_VEND_CLIE_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="OBJ_VEND_CLIE_DETALLERow"/> object.</returns>
		protected virtual OBJ_VEND_CLIE_DETALLERow MapRow(DataRow row)
		{
			OBJ_VEND_CLIE_DETALLERow mappedObject = new OBJ_VEND_CLIE_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "OBJETIVO_VENDEDOR_CLIENTE_ID"
			dataColumn = dataTable.Columns["OBJETIVO_VENDEDOR_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBJETIVO_VENDEDOR_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "CLIENTE_ID"
			dataColumn = dataTable.Columns["CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLIENTE_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR_ID"
			dataColumn = dataTable.Columns["VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>OBJ_VEND_CLIE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "OBJ_VEND_CLIE_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBJETIVO_VENDEDOR_CLIENTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CLIENTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VENDEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
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

				case "OBJETIVO_VENDEDOR_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of OBJ_VEND_CLIE_DETALLECollection_Base class
}  // End of namespace
