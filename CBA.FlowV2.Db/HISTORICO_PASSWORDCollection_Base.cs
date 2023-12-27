// <fileinfo name="HISTORICO_PASSWORDCollection_Base.cs">
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
	/// The base class for <see cref="HISTORICO_PASSWORDCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="HISTORICO_PASSWORDCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HISTORICO_PASSWORDCollection_Base
	{
		// Constants
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string PASSWD1ColumnName = "PASSWD1";
		public const string PASSWD2ColumnName = "PASSWD2";
		public const string PASSWD3ColumnName = "PASSWD3";
		public const string PASSWD4ColumnName = "PASSWD4";
		public const string PASSWD5ColumnName = "PASSWD5";
		public const string PASSWD6ColumnName = "PASSWD6";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="HISTORICO_PASSWORDCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public HISTORICO_PASSWORDCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>HISTORICO_PASSWORD</c> table.
		/// </summary>
		/// <returns>An array of <see cref="HISTORICO_PASSWORDRow"/> objects.</returns>
		public virtual HISTORICO_PASSWORDRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>HISTORICO_PASSWORD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>HISTORICO_PASSWORD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="HISTORICO_PASSWORDRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="HISTORICO_PASSWORDRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public HISTORICO_PASSWORDRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			HISTORICO_PASSWORDRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="HISTORICO_PASSWORDRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="HISTORICO_PASSWORDRow"/> objects.</returns>
		public HISTORICO_PASSWORDRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="HISTORICO_PASSWORDRow"/> objects that 
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
		/// <returns>An array of <see cref="HISTORICO_PASSWORDRow"/> objects.</returns>
		public virtual HISTORICO_PASSWORDRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.HISTORICO_PASSWORD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="HISTORICO_PASSWORDRow"/> by the primary key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An instance of <see cref="HISTORICO_PASSWORDRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual HISTORICO_PASSWORDRow GetByPrimaryKey(decimal usuario_id)
		{
			string whereSql = "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			HISTORICO_PASSWORDRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="HISTORICO_PASSWORDRow"/> objects 
		/// by the <c>FK_HISTORICO_PASSWORD_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="HISTORICO_PASSWORDRow"/> objects.</returns>
		public virtual HISTORICO_PASSWORDRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HISTORICO_PASSWORD_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_HISTORICO_PASSWORD_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>HISTORICO_PASSWORD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HISTORICO_PASSWORDRow"/> object to be inserted.</param>
		public virtual void Insert(HISTORICO_PASSWORDRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.HISTORICO_PASSWORD (" +
				"USUARIO_ID, " +
				"PASSWD1, " +
				"PASSWD2, " +
				"PASSWD3, " +
				"PASSWD4, " +
				"PASSWD5, " +
				"PASSWD6" +
				") VALUES (" +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("PASSWD1") + ", " +
				_db.CreateSqlParameterName("PASSWD2") + ", " +
				_db.CreateSqlParameterName("PASSWD3") + ", " +
				_db.CreateSqlParameterName("PASSWD4") + ", " +
				_db.CreateSqlParameterName("PASSWD5") + ", " +
				_db.CreateSqlParameterName("PASSWD6") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "PASSWD1", value.PASSWD1);
			AddParameter(cmd, "PASSWD2", value.PASSWD2);
			AddParameter(cmd, "PASSWD3", value.PASSWD3);
			AddParameter(cmd, "PASSWD4", value.PASSWD4);
			AddParameter(cmd, "PASSWD5", value.PASSWD5);
			AddParameter(cmd, "PASSWD6", value.PASSWD6);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>HISTORICO_PASSWORD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HISTORICO_PASSWORDRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(HISTORICO_PASSWORDRow value)
		{
			
			string sqlStr = "UPDATE TRC.HISTORICO_PASSWORD SET " +
				"PASSWD1=" + _db.CreateSqlParameterName("PASSWD1") + ", " +
				"PASSWD2=" + _db.CreateSqlParameterName("PASSWD2") + ", " +
				"PASSWD3=" + _db.CreateSqlParameterName("PASSWD3") + ", " +
				"PASSWD4=" + _db.CreateSqlParameterName("PASSWD4") + ", " +
				"PASSWD5=" + _db.CreateSqlParameterName("PASSWD5") + ", " +
				"PASSWD6=" + _db.CreateSqlParameterName("PASSWD6") +
				" WHERE " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PASSWD1", value.PASSWD1);
			AddParameter(cmd, "PASSWD2", value.PASSWD2);
			AddParameter(cmd, "PASSWD3", value.PASSWD3);
			AddParameter(cmd, "PASSWD4", value.PASSWD4);
			AddParameter(cmd, "PASSWD5", value.PASSWD5);
			AddParameter(cmd, "PASSWD6", value.PASSWD6);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>HISTORICO_PASSWORD</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>HISTORICO_PASSWORD</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
							DeleteByPrimaryKey((decimal)row["USUARIO_ID"]);
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
		/// Deletes the specified object from the <c>HISTORICO_PASSWORD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HISTORICO_PASSWORDRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(HISTORICO_PASSWORDRow value)
		{
			return DeleteByPrimaryKey(value.USUARIO_ID);
		}

		/// <summary>
		/// Deletes a record from the <c>HISTORICO_PASSWORD</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal usuario_id)
		{
			string whereSql = "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>HISTORICO_PASSWORD</c> table using the 
		/// <c>FK_HISTORICO_PASSWORD_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_HISTORICO_PASSWORD_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>HISTORICO_PASSWORD</c> records that match the specified criteria.
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
		/// to delete <c>HISTORICO_PASSWORD</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.HISTORICO_PASSWORD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>HISTORICO_PASSWORD</c> table.
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
		/// <returns>An array of <see cref="HISTORICO_PASSWORDRow"/> objects.</returns>
		protected HISTORICO_PASSWORDRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="HISTORICO_PASSWORDRow"/> objects.</returns>
		protected HISTORICO_PASSWORDRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="HISTORICO_PASSWORDRow"/> objects.</returns>
		protected virtual HISTORICO_PASSWORDRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int passwd1ColumnIndex = reader.GetOrdinal("PASSWD1");
			int passwd2ColumnIndex = reader.GetOrdinal("PASSWD2");
			int passwd3ColumnIndex = reader.GetOrdinal("PASSWD3");
			int passwd4ColumnIndex = reader.GetOrdinal("PASSWD4");
			int passwd5ColumnIndex = reader.GetOrdinal("PASSWD5");
			int passwd6ColumnIndex = reader.GetOrdinal("PASSWD6");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					HISTORICO_PASSWORDRow record = new HISTORICO_PASSWORDRow();
					recordList.Add(record);

					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(passwd1ColumnIndex))
						record.PASSWD1 = Convert.ToString(reader.GetValue(passwd1ColumnIndex));
					if(!reader.IsDBNull(passwd2ColumnIndex))
						record.PASSWD2 = Convert.ToString(reader.GetValue(passwd2ColumnIndex));
					if(!reader.IsDBNull(passwd3ColumnIndex))
						record.PASSWD3 = Convert.ToString(reader.GetValue(passwd3ColumnIndex));
					if(!reader.IsDBNull(passwd4ColumnIndex))
						record.PASSWD4 = Convert.ToString(reader.GetValue(passwd4ColumnIndex));
					if(!reader.IsDBNull(passwd5ColumnIndex))
						record.PASSWD5 = Convert.ToString(reader.GetValue(passwd5ColumnIndex));
					if(!reader.IsDBNull(passwd6ColumnIndex))
						record.PASSWD6 = Convert.ToString(reader.GetValue(passwd6ColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (HISTORICO_PASSWORDRow[])(recordList.ToArray(typeof(HISTORICO_PASSWORDRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="HISTORICO_PASSWORDRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="HISTORICO_PASSWORDRow"/> object.</returns>
		protected virtual HISTORICO_PASSWORDRow MapRow(DataRow row)
		{
			HISTORICO_PASSWORDRow mappedObject = new HISTORICO_PASSWORDRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "PASSWD1"
			dataColumn = dataTable.Columns["PASSWD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASSWD1 = (string)row[dataColumn];
			// Column "PASSWD2"
			dataColumn = dataTable.Columns["PASSWD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASSWD2 = (string)row[dataColumn];
			// Column "PASSWD3"
			dataColumn = dataTable.Columns["PASSWD3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASSWD3 = (string)row[dataColumn];
			// Column "PASSWD4"
			dataColumn = dataTable.Columns["PASSWD4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASSWD4 = (string)row[dataColumn];
			// Column "PASSWD5"
			dataColumn = dataTable.Columns["PASSWD5"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASSWD5 = (string)row[dataColumn];
			// Column "PASSWD6"
			dataColumn = dataTable.Columns["PASSWD6"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASSWD6 = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>HISTORICO_PASSWORD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "HISTORICO_PASSWORD";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PASSWD1", typeof(string));
			dataColumn.MaxLength = 96;
			dataColumn = dataTable.Columns.Add("PASSWD2", typeof(string));
			dataColumn.MaxLength = 96;
			dataColumn = dataTable.Columns.Add("PASSWD3", typeof(string));
			dataColumn.MaxLength = 96;
			dataColumn = dataTable.Columns.Add("PASSWD4", typeof(string));
			dataColumn.MaxLength = 96;
			dataColumn = dataTable.Columns.Add("PASSWD5", typeof(string));
			dataColumn.MaxLength = 96;
			dataColumn = dataTable.Columns.Add("PASSWD6", typeof(string));
			dataColumn.MaxLength = 96;
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
				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PASSWD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PASSWD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PASSWD3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PASSWD4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PASSWD5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PASSWD6":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of HISTORICO_PASSWORDCollection_Base class
}  // End of namespace
