// <fileinfo name="STOCK_DEPOSITOSCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_DEPOSITOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_DEPOSITOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_DEPOSITOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string ORDENColumnName = "ORDEN";
		public const string PARA_FACTURARColumnName = "PARA_FACTURAR";
		public const string ESTADOColumnName = "ESTADO";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string SUCURSAL_SECTOR_IDColumnName = "SUCURSAL_SECTOR_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_DEPOSITOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_DEPOSITOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_DEPOSITOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public virtual STOCK_DEPOSITOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_DEPOSITOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_DEPOSITOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_DEPOSITOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_DEPOSITOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_DEPOSITOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_DEPOSITOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_DEPOSITOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public STOCK_DEPOSITOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_DEPOSITOSRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public virtual STOCK_DEPOSITOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_DEPOSITOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="STOCK_DEPOSITOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="STOCK_DEPOSITOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual STOCK_DEPOSITOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			STOCK_DEPOSITOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_DEPOSITOSRow"/> objects 
		/// by the <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public STOCK_DEPOSITOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_DEPOSITOSRow"/> objects 
		/// by the <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public virtual STOCK_DEPOSITOSRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
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
		/// return records by the <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_DEPOSITOSRow"/> objects 
		/// by the <c>FK_STOCK_DEPOSITOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public virtual STOCK_DEPOSITOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_DEPOSITOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_DEPOSITOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_DEPOSITOSRow"/> objects 
		/// by the <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public STOCK_DEPOSITOSRow[] GetBySUCURSAL_SECTOR_ID(decimal sucursal_sector_id)
		{
			return GetBySUCURSAL_SECTOR_ID(sucursal_sector_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_DEPOSITOSRow"/> objects 
		/// by the <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <param name="sucursal_sector_idNull">true if the method ignores the sucursal_sector_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		public virtual STOCK_DEPOSITOSRow[] GetBySUCURSAL_SECTOR_ID(decimal sucursal_sector_id, bool sucursal_sector_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_SECTOR_IDCommand(sucursal_sector_id, sucursal_sector_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_SECTOR_IDAsDataTable(decimal sucursal_sector_id)
		{
			return GetBySUCURSAL_SECTOR_IDAsDataTable(sucursal_sector_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <param name="sucursal_sector_idNull">true if the method ignores the sucursal_sector_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_SECTOR_IDAsDataTable(decimal sucursal_sector_id, bool sucursal_sector_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_SECTOR_IDCommand(sucursal_sector_id, sucursal_sector_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <param name="sucursal_sector_idNull">true if the method ignores the sucursal_sector_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_SECTOR_IDCommand(decimal sucursal_sector_id, bool sucursal_sector_idNull)
		{
			string whereSql = "";
			if(sucursal_sector_idNull)
				whereSql += "SUCURSAL_SECTOR_ID IS NULL";
			else
				whereSql += "SUCURSAL_SECTOR_ID=" + _db.CreateSqlParameterName("SUCURSAL_SECTOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_sector_idNull)
				AddParameter(cmd, "SUCURSAL_SECTOR_ID", sucursal_sector_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>STOCK_DEPOSITOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_DEPOSITOSRow"/> object to be inserted.</param>
		public virtual void Insert(STOCK_DEPOSITOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.STOCK_DEPOSITOS (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"NOMBRE, " +
				"ABREVIATURA, " +
				"ORDEN, " +
				"PARA_FACTURAR, " +
				"ESTADO, " +
				"CENTRO_COSTO_ID, " +
				"SUCURSAL_SECTOR_ID, " +
				"PROVEEDOR_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ABREVIATURA") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("PARA_FACTURAR") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_SECTOR_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			AddParameter(cmd, "PARA_FACTURAR", value.PARA_FACTURAR);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "SUCURSAL_SECTOR_ID",
				value.IsSUCURSAL_SECTOR_IDNull ? DBNull.Value : (object)value.SUCURSAL_SECTOR_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>STOCK_DEPOSITOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_DEPOSITOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(STOCK_DEPOSITOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.STOCK_DEPOSITOS SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ABREVIATURA=" + _db.CreateSqlParameterName("ABREVIATURA") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"PARA_FACTURAR=" + _db.CreateSqlParameterName("PARA_FACTURAR") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"SUCURSAL_SECTOR_ID=" + _db.CreateSqlParameterName("SUCURSAL_SECTOR_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			AddParameter(cmd, "PARA_FACTURAR", value.PARA_FACTURAR);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "SUCURSAL_SECTOR_ID",
				value.IsSUCURSAL_SECTOR_IDNull ? DBNull.Value : (object)value.SUCURSAL_SECTOR_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>STOCK_DEPOSITOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>STOCK_DEPOSITOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>STOCK_DEPOSITOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_DEPOSITOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(STOCK_DEPOSITOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>STOCK_DEPOSITOS</c> table using
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
		/// Deletes records from the <c>STOCK_DEPOSITOS</c> table using the 
		/// <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_DEPOSITOS</c> table using the 
		/// <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_DEPOSITOS_CENTRO_C</c> foreign key.
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
		/// Deletes records from the <c>STOCK_DEPOSITOS</c> table using the 
		/// <c>FK_STOCK_DEPOSITOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_DEPOSITOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_DEPOSITOS</c> table using the 
		/// <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_SECTOR_ID(decimal sucursal_sector_id)
		{
			return DeleteBySUCURSAL_SECTOR_ID(sucursal_sector_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_DEPOSITOS</c> table using the 
		/// <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <param name="sucursal_sector_idNull">true if the method ignores the sucursal_sector_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_SECTOR_ID(decimal sucursal_sector_id, bool sucursal_sector_idNull)
		{
			return CreateDeleteBySUCURSAL_SECTOR_IDCommand(sucursal_sector_id, sucursal_sector_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_DEPOSITOS_SUC_SEC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_sector_id">The <c>SUCURSAL_SECTOR_ID</c> column value.</param>
		/// <param name="sucursal_sector_idNull">true if the method ignores the sucursal_sector_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_SECTOR_IDCommand(decimal sucursal_sector_id, bool sucursal_sector_idNull)
		{
			string whereSql = "";
			if(sucursal_sector_idNull)
				whereSql += "SUCURSAL_SECTOR_ID IS NULL";
			else
				whereSql += "SUCURSAL_SECTOR_ID=" + _db.CreateSqlParameterName("SUCURSAL_SECTOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_sector_idNull)
				AddParameter(cmd, "SUCURSAL_SECTOR_ID", sucursal_sector_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>STOCK_DEPOSITOS</c> records that match the specified criteria.
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
		/// to delete <c>STOCK_DEPOSITOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.STOCK_DEPOSITOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>STOCK_DEPOSITOS</c> table.
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
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		protected STOCK_DEPOSITOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		protected STOCK_DEPOSITOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_DEPOSITOSRow"/> objects.</returns>
		protected virtual STOCK_DEPOSITOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int para_facturarColumnIndex = reader.GetOrdinal("PARA_FACTURAR");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int sucursal_sector_idColumnIndex = reader.GetOrdinal("SUCURSAL_SECTOR_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_DEPOSITOSRow record = new STOCK_DEPOSITOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					if(!reader.IsDBNull(ordenColumnIndex))
						record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					record.PARA_FACTURAR = Convert.ToString(reader.GetValue(para_facturarColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_sector_idColumnIndex))
						record.SUCURSAL_SECTOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_sector_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_DEPOSITOSRow[])(recordList.ToArray(typeof(STOCK_DEPOSITOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_DEPOSITOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_DEPOSITOSRow"/> object.</returns>
		protected virtual STOCK_DEPOSITOSRow MapRow(DataRow row)
		{
			STOCK_DEPOSITOSRow mappedObject = new STOCK_DEPOSITOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "PARA_FACTURAR"
			dataColumn = dataTable.Columns["PARA_FACTURAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARA_FACTURAR = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_SECTOR_ID"
			dataColumn = dataTable.Columns["SUCURSAL_SECTOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_SECTOR_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_DEPOSITOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_DEPOSITOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PARA_FACTURAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_SECTOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PARA_FACTURAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_SECTOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_DEPOSITOSCollection_Base class
}  // End of namespace
