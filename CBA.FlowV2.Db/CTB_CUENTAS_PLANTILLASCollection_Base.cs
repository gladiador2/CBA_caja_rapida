// <fileinfo name="CTB_CUENTAS_PLANTILLASCollection_Base.cs">
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
	/// The base class for <see cref="CTB_CUENTAS_PLANTILLASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_CUENTAS_PLANTILLASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_CUENTAS_PLANTILLASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_CUENTA_MADRE_IDColumnName = "CTB_CUENTA_MADRE_ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string NIVELColumnName = "NIVEL";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ASENTABLEColumnName = "ASENTABLE";
		public const string EDITABLEColumnName = "EDITABLE";
		public const string CODIGO_BASEColumnName = "CODIGO_BASE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_CUENTAS_PLANTILLASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_CUENTAS_PLANTILLASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_CUENTAS_PLANTILLAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		public virtual CTB_CUENTAS_PLANTILLASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_CUENTAS_PLANTILLAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_CUENTAS_PLANTILLAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_CUENTAS_PLANTILLASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_CUENTAS_PLANTILLASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_CUENTAS_PLANTILLASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		public CTB_CUENTAS_PLANTILLASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		public virtual CTB_CUENTAS_PLANTILLASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_CUENTAS_PLANTILLAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_CUENTAS_PLANTILLASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_CUENTAS_PLANTILLASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_CUENTAS_PLANTILLASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_CUENTAS_PLANTILLASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects 
		/// by the <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		public CTB_CUENTAS_PLANTILLASRow[] GetByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id)
		{
			return GetByCTB_CUENTA_MADRE_ID(ctb_cuenta_madre_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects 
		/// by the <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		public virtual CTB_CUENTAS_PLANTILLASRow[] GetByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			return MapRecords(CreateGetByCTB_CUENTA_MADRE_IDCommand(ctb_cuenta_madre_id, ctb_cuenta_madre_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_CUENTA_MADRE_IDAsDataTable(decimal ctb_cuenta_madre_id)
		{
			return GetByCTB_CUENTA_MADRE_IDAsDataTable(ctb_cuenta_madre_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_CUENTA_MADRE_IDAsDataTable(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_CUENTA_MADRE_IDCommand(ctb_cuenta_madre_id, ctb_cuenta_madre_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_CUENTA_MADRE_IDCommand(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			string whereSql = "";
			if(ctb_cuenta_madre_idNull)
				whereSql += "CTB_CUENTA_MADRE_ID IS NULL";
			else
				whereSql += "CTB_CUENTA_MADRE_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_cuenta_madre_idNull)
				AddParameter(cmd, "CTB_CUENTA_MADRE_ID", ctb_cuenta_madre_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_CUENTAS_PLANTILLAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_CUENTAS_PLANTILLASRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_CUENTAS_PLANTILLASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_CUENTAS_PLANTILLAS (" +
				"ID, " +
				"CTB_CUENTA_MADRE_ID, " +
				"CODIGO, " +
				"NIVEL, " +
				"NOMBRE, " +
				"ASENTABLE, " +
				"EDITABLE, " +
				"CODIGO_BASE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("NIVEL") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ASENTABLE") + ", " +
				_db.CreateSqlParameterName("EDITABLE") + ", " +
				_db.CreateSqlParameterName("CODIGO_BASE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_CUENTA_MADRE_ID",
				value.IsCTB_CUENTA_MADRE_IDNull ? DBNull.Value : (object)value.CTB_CUENTA_MADRE_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "NIVEL", value.NIVEL);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ASENTABLE", value.ASENTABLE);
			AddParameter(cmd, "EDITABLE", value.EDITABLE);
			AddParameter(cmd, "CODIGO_BASE", value.CODIGO_BASE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_CUENTAS_PLANTILLAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_CUENTAS_PLANTILLASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_CUENTAS_PLANTILLASRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_CUENTAS_PLANTILLAS SET " +
				"CTB_CUENTA_MADRE_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID") + ", " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"NIVEL=" + _db.CreateSqlParameterName("NIVEL") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ASENTABLE=" + _db.CreateSqlParameterName("ASENTABLE") + ", " +
				"EDITABLE=" + _db.CreateSqlParameterName("EDITABLE") + ", " +
				"CODIGO_BASE=" + _db.CreateSqlParameterName("CODIGO_BASE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_CUENTA_MADRE_ID",
				value.IsCTB_CUENTA_MADRE_IDNull ? DBNull.Value : (object)value.CTB_CUENTA_MADRE_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "NIVEL", value.NIVEL);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ASENTABLE", value.ASENTABLE);
			AddParameter(cmd, "EDITABLE", value.EDITABLE);
			AddParameter(cmd, "CODIGO_BASE", value.CODIGO_BASE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_CUENTAS_PLANTILLAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_CUENTAS_PLANTILLAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_CUENTAS_PLANTILLAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_CUENTAS_PLANTILLASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_CUENTAS_PLANTILLASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_CUENTAS_PLANTILLAS</c> table using
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
		/// Deletes records from the <c>CTB_CUENTAS_PLANTILLAS</c> table using the 
		/// <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id)
		{
			return DeleteByCTB_CUENTA_MADRE_ID(ctb_cuenta_madre_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_CUENTAS_PLANTILLAS</c> table using the 
		/// <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			return CreateDeleteByCTB_CUENTA_MADRE_IDCommand(ctb_cuenta_madre_id, ctb_cuenta_madre_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_CUENTA_MADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_CUENTA_MADRE_IDCommand(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			string whereSql = "";
			if(ctb_cuenta_madre_idNull)
				whereSql += "CTB_CUENTA_MADRE_ID IS NULL";
			else
				whereSql += "CTB_CUENTA_MADRE_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_cuenta_madre_idNull)
				AddParameter(cmd, "CTB_CUENTA_MADRE_ID", ctb_cuenta_madre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_CUENTAS_PLANTILLAS</c> records that match the specified criteria.
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
		/// to delete <c>CTB_CUENTAS_PLANTILLAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_CUENTAS_PLANTILLAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_CUENTAS_PLANTILLAS</c> table.
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
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		protected CTB_CUENTAS_PLANTILLASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		protected CTB_CUENTAS_PLANTILLASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_CUENTAS_PLANTILLASRow"/> objects.</returns>
		protected virtual CTB_CUENTAS_PLANTILLASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_cuenta_madre_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_MADRE_ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int nivelColumnIndex = reader.GetOrdinal("NIVEL");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int asentableColumnIndex = reader.GetOrdinal("ASENTABLE");
			int editableColumnIndex = reader.GetOrdinal("EDITABLE");
			int codigo_baseColumnIndex = reader.GetOrdinal("CODIGO_BASE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_CUENTAS_PLANTILLASRow record = new CTB_CUENTAS_PLANTILLASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_cuenta_madre_idColumnIndex))
						record.CTB_CUENTA_MADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_madre_idColumnIndex)), 9);
					record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.NIVEL = Math.Round(Convert.ToDecimal(reader.GetValue(nivelColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ASENTABLE = Convert.ToString(reader.GetValue(asentableColumnIndex));
					record.EDITABLE = Convert.ToString(reader.GetValue(editableColumnIndex));
					if(!reader.IsDBNull(codigo_baseColumnIndex))
						record.CODIGO_BASE = Convert.ToString(reader.GetValue(codigo_baseColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_CUENTAS_PLANTILLASRow[])(recordList.ToArray(typeof(CTB_CUENTAS_PLANTILLASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_CUENTAS_PLANTILLASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_CUENTAS_PLANTILLASRow"/> object.</returns>
		protected virtual CTB_CUENTAS_PLANTILLASRow MapRow(DataRow row)
		{
			CTB_CUENTAS_PLANTILLASRow mappedObject = new CTB_CUENTAS_PLANTILLASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_MADRE_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_MADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_MADRE_ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "NIVEL"
			dataColumn = dataTable.Columns["NIVEL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ASENTABLE"
			dataColumn = dataTable.Columns["ASENTABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ASENTABLE = (string)row[dataColumn];
			// Column "EDITABLE"
			dataColumn = dataTable.Columns["EDITABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDITABLE = (string)row[dataColumn];
			// Column "CODIGO_BASE"
			dataColumn = dataTable.Columns["CODIGO_BASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BASE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_CUENTAS_PLANTILLAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_CUENTAS_PLANTILLAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_MADRE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NIVEL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ASENTABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EDITABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO_BASE", typeof(string));
			dataColumn.MaxLength = 100;
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

				case "CTB_CUENTA_MADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NIVEL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ASENTABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDITABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CODIGO_BASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_CUENTAS_PLANTILLASCollection_Base class
}  // End of namespace
