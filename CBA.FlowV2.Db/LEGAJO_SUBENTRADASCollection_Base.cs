// <fileinfo name="LEGAJO_SUBENTRADASCollection_Base.cs">
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
	/// The base class for <see cref="LEGAJO_SUBENTRADASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="LEGAJO_SUBENTRADASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LEGAJO_SUBENTRADASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LEGAJO_ENTRADA_IDColumnName = "LEGAJO_ENTRADA_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string ESTADOColumnName = "ESTADO";
		public const string TIPO_DETALLE_PERSONALIZADO_IDColumnName = "TIPO_DETALLE_PERSONALIZADO_ID";
		public const string UNICOColumnName = "UNICO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="LEGAJO_SUBENTRADASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public LEGAJO_SUBENTRADASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>LEGAJO_SUBENTRADAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		public virtual LEGAJO_SUBENTRADASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>LEGAJO_SUBENTRADAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>LEGAJO_SUBENTRADAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="LEGAJO_SUBENTRADASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="LEGAJO_SUBENTRADASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public LEGAJO_SUBENTRADASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			LEGAJO_SUBENTRADASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LEGAJO_SUBENTRADASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		public LEGAJO_SUBENTRADASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="LEGAJO_SUBENTRADASRow"/> objects that 
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
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		public virtual LEGAJO_SUBENTRADASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.LEGAJO_SUBENTRADAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="LEGAJO_SUBENTRADASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="LEGAJO_SUBENTRADASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual LEGAJO_SUBENTRADASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			LEGAJO_SUBENTRADASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LEGAJO_SUBENTRADASRow"/> objects 
		/// by the <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		public LEGAJO_SUBENTRADASRow[] GetByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id)
		{
			return GetByTIPO_DETALLE_PERSONALIZADO_ID(tipo_detalle_personalizado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="LEGAJO_SUBENTRADASRow"/> objects 
		/// by the <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <param name="tipo_detalle_personalizado_idNull">true if the method ignores the tipo_detalle_personalizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		public virtual LEGAJO_SUBENTRADASRow[] GetByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id, bool tipo_detalle_personalizado_idNull)
		{
			return MapRecords(CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id, tipo_detalle_personalizado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_DETALLE_PERSONALIZADO_IDAsDataTable(decimal tipo_detalle_personalizado_id)
		{
			return GetByTIPO_DETALLE_PERSONALIZADO_IDAsDataTable(tipo_detalle_personalizado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <param name="tipo_detalle_personalizado_idNull">true if the method ignores the tipo_detalle_personalizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_DETALLE_PERSONALIZADO_IDAsDataTable(decimal tipo_detalle_personalizado_id, bool tipo_detalle_personalizado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id, tipo_detalle_personalizado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <param name="tipo_detalle_personalizado_idNull">true if the method ignores the tipo_detalle_personalizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(decimal tipo_detalle_personalizado_id, bool tipo_detalle_personalizado_idNull)
		{
			string whereSql = "";
			if(tipo_detalle_personalizado_idNull)
				whereSql += "TIPO_DETALLE_PERSONALIZADO_ID IS NULL";
			else
				whereSql += "TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_detalle_personalizado_idNull)
				AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", tipo_detalle_personalizado_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>LEGAJO_SUBENTRADAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LEGAJO_SUBENTRADASRow"/> object to be inserted.</param>
		public virtual void Insert(LEGAJO_SUBENTRADASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.LEGAJO_SUBENTRADAS (" +
				"ID, " +
				"LEGAJO_ENTRADA_ID, " +
				"NOMBRE, " +
				"DESCRIPCION, " +
				"ESTADO, " +
				"TIPO_DETALLE_PERSONALIZADO_ID, " +
				"UNICO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("LEGAJO_ENTRADA_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID") + ", " +
				_db.CreateSqlParameterName("UNICO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "LEGAJO_ENTRADA_ID", value.LEGAJO_ENTRADA_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID",
				value.IsTIPO_DETALLE_PERSONALIZADO_IDNull ? DBNull.Value : (object)value.TIPO_DETALLE_PERSONALIZADO_ID);
			AddParameter(cmd, "UNICO", value.UNICO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>LEGAJO_SUBENTRADAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LEGAJO_SUBENTRADASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(LEGAJO_SUBENTRADASRow value)
		{
			
			string sqlStr = "UPDATE TRC.LEGAJO_SUBENTRADAS SET " +
				"LEGAJO_ENTRADA_ID=" + _db.CreateSqlParameterName("LEGAJO_ENTRADA_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID") + ", " +
				"UNICO=" + _db.CreateSqlParameterName("UNICO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "LEGAJO_ENTRADA_ID", value.LEGAJO_ENTRADA_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID",
				value.IsTIPO_DETALLE_PERSONALIZADO_IDNull ? DBNull.Value : (object)value.TIPO_DETALLE_PERSONALIZADO_ID);
			AddParameter(cmd, "UNICO", value.UNICO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>LEGAJO_SUBENTRADAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>LEGAJO_SUBENTRADAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>LEGAJO_SUBENTRADAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LEGAJO_SUBENTRADASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(LEGAJO_SUBENTRADASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>LEGAJO_SUBENTRADAS</c> table using
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
		/// Deletes records from the <c>LEGAJO_SUBENTRADAS</c> table using the 
		/// <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id)
		{
			return DeleteByTIPO_DETALLE_PERSONALIZADO_ID(tipo_detalle_personalizado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>LEGAJO_SUBENTRADAS</c> table using the 
		/// <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <param name="tipo_detalle_personalizado_idNull">true if the method ignores the tipo_detalle_personalizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id, bool tipo_detalle_personalizado_idNull)
		{
			return CreateDeleteByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id, tipo_detalle_personalizado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LEGAJO_SUB_TIPO_DET_PE</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <param name="tipo_detalle_personalizado_idNull">true if the method ignores the tipo_detalle_personalizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_DETALLE_PERSONALIZADO_IDCommand(decimal tipo_detalle_personalizado_id, bool tipo_detalle_personalizado_idNull)
		{
			string whereSql = "";
			if(tipo_detalle_personalizado_idNull)
				whereSql += "TIPO_DETALLE_PERSONALIZADO_ID IS NULL";
			else
				whereSql += "TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_detalle_personalizado_idNull)
				AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", tipo_detalle_personalizado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>LEGAJO_SUBENTRADAS</c> records that match the specified criteria.
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
		/// to delete <c>LEGAJO_SUBENTRADAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.LEGAJO_SUBENTRADAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>LEGAJO_SUBENTRADAS</c> table.
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
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		protected LEGAJO_SUBENTRADASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		protected LEGAJO_SUBENTRADASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="LEGAJO_SUBENTRADASRow"/> objects.</returns>
		protected virtual LEGAJO_SUBENTRADASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int legajo_entrada_idColumnIndex = reader.GetOrdinal("LEGAJO_ENTRADA_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tipo_detalle_personalizado_idColumnIndex = reader.GetOrdinal("TIPO_DETALLE_PERSONALIZADO_ID");
			int unicoColumnIndex = reader.GetOrdinal("UNICO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					LEGAJO_SUBENTRADASRow record = new LEGAJO_SUBENTRADASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.LEGAJO_ENTRADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(legajo_entrada_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(tipo_detalle_personalizado_idColumnIndex))
						record.TIPO_DETALLE_PERSONALIZADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_detalle_personalizado_idColumnIndex)), 9);
					record.UNICO = Convert.ToString(reader.GetValue(unicoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LEGAJO_SUBENTRADASRow[])(recordList.ToArray(typeof(LEGAJO_SUBENTRADASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="LEGAJO_SUBENTRADASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="LEGAJO_SUBENTRADASRow"/> object.</returns>
		protected virtual LEGAJO_SUBENTRADASRow MapRow(DataRow row)
		{
			LEGAJO_SUBENTRADASRow mappedObject = new LEGAJO_SUBENTRADASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "LEGAJO_ENTRADA_ID"
			dataColumn = dataTable.Columns["LEGAJO_ENTRADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LEGAJO_ENTRADA_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TIPO_DETALLE_PERSONALIZADO_ID"
			dataColumn = dataTable.Columns["TIPO_DETALLE_PERSONALIZADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DETALLE_PERSONALIZADO_ID = (decimal)row[dataColumn];
			// Column "UNICO"
			dataColumn = dataTable.Columns["UNICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNICO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>LEGAJO_SUBENTRADAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "LEGAJO_SUBENTRADAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LEGAJO_ENTRADA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_DETALLE_PERSONALIZADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNICO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "LEGAJO_ENTRADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_DETALLE_PERSONALIZADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of LEGAJO_SUBENTRADASCollection_Base class
}  // End of namespace
