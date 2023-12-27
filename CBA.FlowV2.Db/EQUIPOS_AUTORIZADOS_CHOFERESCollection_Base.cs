// <fileinfo name="EQUIPOS_AUTORIZADOS_CHOFERESCollection_Base.cs">
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
	/// The base class for <see cref="EQUIPOS_AUTORIZADOS_CHOFERESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EQUIPOS_AUTORIZADOS_CHOFERESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EQUIPOS_AUTORIZADOS_CHOFERESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string EQUIPO_AUTORIZADO_IDColumnName = "EQUIPO_AUTORIZADO_ID";
		public const string NUMERO_DOCUMENTOColumnName = "NUMERO_DOCUMENTO";
		public const string NOMBRE_CHOFERColumnName = "NOMBRE_CHOFER";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EQUIPOS_AUTORIZADOS_CHOFERESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EQUIPOS_AUTORIZADOS_CHOFERESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_CHOFERESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EQUIPOS_AUTORIZADOS_CHOFERESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EQUIPOS_AUTORIZADOS_CHOFERESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_CHOFERESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects that 
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_CHOFERESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EQUIPOS_AUTORIZADOS_CHOFERES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EQUIPOS_AUTORIZADOS_CHOFERESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EQUIPOS_AUTORIZADOS_CHOFERESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_CHOFERESRow[] GetByEQUIPO_AUTORIZADO_ID(decimal equipo_autorizado_id)
		{
			return GetByEQUIPO_AUTORIZADO_ID(equipo_autorizado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <param name="equipo_autorizado_idNull">true if the method ignores the equipo_autorizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_CHOFERESRow[] GetByEQUIPO_AUTORIZADO_ID(decimal equipo_autorizado_id, bool equipo_autorizado_idNull)
		{
			return MapRecords(CreateGetByEQUIPO_AUTORIZADO_IDCommand(equipo_autorizado_id, equipo_autorizado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEQUIPO_AUTORIZADO_IDAsDataTable(decimal equipo_autorizado_id)
		{
			return GetByEQUIPO_AUTORIZADO_IDAsDataTable(equipo_autorizado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <param name="equipo_autorizado_idNull">true if the method ignores the equipo_autorizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEQUIPO_AUTORIZADO_IDAsDataTable(decimal equipo_autorizado_id, bool equipo_autorizado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEQUIPO_AUTORIZADO_IDCommand(equipo_autorizado_id, equipo_autorizado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <param name="equipo_autorizado_idNull">true if the method ignores the equipo_autorizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEQUIPO_AUTORIZADO_IDCommand(decimal equipo_autorizado_id, bool equipo_autorizado_idNull)
		{
			string whereSql = "";
			if(equipo_autorizado_idNull)
				whereSql += "EQUIPO_AUTORIZADO_ID IS NULL";
			else
				whereSql += "EQUIPO_AUTORIZADO_ID=" + _db.CreateSqlParameterName("EQUIPO_AUTORIZADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!equipo_autorizado_idNull)
				AddParameter(cmd, "EQUIPO_AUTORIZADO_ID", equipo_autorizado_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> object to be inserted.</param>
		public virtual void Insert(EQUIPOS_AUTORIZADOS_CHOFERESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EQUIPOS_AUTORIZADOS_CHOFERES (" +
				"ID, " +
				"EQUIPO_AUTORIZADO_ID, " +
				"NUMERO_DOCUMENTO, " +
				"NOMBRE_CHOFER" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("EQUIPO_AUTORIZADO_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("NOMBRE_CHOFER") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "EQUIPO_AUTORIZADO_ID",
				value.IsEQUIPO_AUTORIZADO_IDNull ? DBNull.Value : (object)value.EQUIPO_AUTORIZADO_ID);
			AddParameter(cmd, "NUMERO_DOCUMENTO", value.NUMERO_DOCUMENTO);
			AddParameter(cmd, "NOMBRE_CHOFER", value.NOMBRE_CHOFER);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EQUIPOS_AUTORIZADOS_CHOFERESRow value)
		{
			
			string sqlStr = "UPDATE TRC.EQUIPOS_AUTORIZADOS_CHOFERES SET " +
				"EQUIPO_AUTORIZADO_ID=" + _db.CreateSqlParameterName("EQUIPO_AUTORIZADO_ID") + ", " +
				"NUMERO_DOCUMENTO=" + _db.CreateSqlParameterName("NUMERO_DOCUMENTO") + ", " +
				"NOMBRE_CHOFER=" + _db.CreateSqlParameterName("NOMBRE_CHOFER") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "EQUIPO_AUTORIZADO_ID",
				value.IsEQUIPO_AUTORIZADO_IDNull ? DBNull.Value : (object)value.EQUIPO_AUTORIZADO_ID);
			AddParameter(cmd, "NUMERO_DOCUMENTO", value.NUMERO_DOCUMENTO);
			AddParameter(cmd, "NOMBRE_CHOFER", value.NOMBRE_CHOFER);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EQUIPOS_AUTORIZADOS_CHOFERESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table using
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
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEQUIPO_AUTORIZADO_ID(decimal equipo_autorizado_id)
		{
			return DeleteByEQUIPO_AUTORIZADO_ID(equipo_autorizado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <param name="equipo_autorizado_idNull">true if the method ignores the equipo_autorizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEQUIPO_AUTORIZADO_ID(decimal equipo_autorizado_id, bool equipo_autorizado_idNull)
		{
			return CreateDeleteByEQUIPO_AUTORIZADO_IDCommand(equipo_autorizado_id, equipo_autorizado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_CHOF_EQ_A_ID</c> foreign key.
		/// </summary>
		/// <param name="equipo_autorizado_id">The <c>EQUIPO_AUTORIZADO_ID</c> column value.</param>
		/// <param name="equipo_autorizado_idNull">true if the method ignores the equipo_autorizado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEQUIPO_AUTORIZADO_IDCommand(decimal equipo_autorizado_id, bool equipo_autorizado_idNull)
		{
			string whereSql = "";
			if(equipo_autorizado_idNull)
				whereSql += "EQUIPO_AUTORIZADO_ID IS NULL";
			else
				whereSql += "EQUIPO_AUTORIZADO_ID=" + _db.CreateSqlParameterName("EQUIPO_AUTORIZADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!equipo_autorizado_idNull)
				AddParameter(cmd, "EQUIPO_AUTORIZADO_ID", equipo_autorizado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> records that match the specified criteria.
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
		/// to delete <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EQUIPOS_AUTORIZADOS_CHOFERES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOS_CHOFERESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOS_CHOFERESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> objects.</returns>
		protected virtual EQUIPOS_AUTORIZADOS_CHOFERESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int equipo_autorizado_idColumnIndex = reader.GetOrdinal("EQUIPO_AUTORIZADO_ID");
			int numero_documentoColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO");
			int nombre_choferColumnIndex = reader.GetOrdinal("NOMBRE_CHOFER");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EQUIPOS_AUTORIZADOS_CHOFERESRow record = new EQUIPOS_AUTORIZADOS_CHOFERESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(equipo_autorizado_idColumnIndex))
						record.EQUIPO_AUTORIZADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(equipo_autorizado_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_documentoColumnIndex))
						record.NUMERO_DOCUMENTO = Convert.ToString(reader.GetValue(numero_documentoColumnIndex));
					if(!reader.IsDBNull(nombre_choferColumnIndex))
						record.NOMBRE_CHOFER = Convert.ToString(reader.GetValue(nombre_choferColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EQUIPOS_AUTORIZADOS_CHOFERESRow[])(recordList.ToArray(typeof(EQUIPOS_AUTORIZADOS_CHOFERESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> object.</returns>
		protected virtual EQUIPOS_AUTORIZADOS_CHOFERESRow MapRow(DataRow row)
		{
			EQUIPOS_AUTORIZADOS_CHOFERESRow mappedObject = new EQUIPOS_AUTORIZADOS_CHOFERESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "EQUIPO_AUTORIZADO_ID"
			dataColumn = dataTable.Columns["EQUIPO_AUTORIZADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EQUIPO_AUTORIZADO_ID = (decimal)row[dataColumn];
			// Column "NUMERO_DOCUMENTO"
			dataColumn = dataTable.Columns["NUMERO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_DOCUMENTO = (string)row[dataColumn];
			// Column "NOMBRE_CHOFER"
			dataColumn = dataTable.Columns["NOMBRE_CHOFER"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_CHOFER = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EQUIPOS_AUTORIZADOS_CHOFERES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EQUIPO_AUTORIZADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("NOMBRE_CHOFER", typeof(string));
			dataColumn.MaxLength = 200;
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

				case "EQUIPO_AUTORIZADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_CHOFER":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EQUIPOS_AUTORIZADOS_CHOFERESCollection_Base class
}  // End of namespace
