// <fileinfo name="COPARN_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="COPARN_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="COPARN_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COPARN_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string COPARN_IDColumnName = "COPARN_ID";
		public const string NUMERO_CONTENEDORColumnName = "NUMERO_CONTENEDOR";
		public const string TIPO_CONTENEDOR_IDColumnName = "TIPO_CONTENEDOR_ID";
		public const string MERCADERIAColumnName = "MERCADERIA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="COPARN_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public COPARN_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>COPARN_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		public virtual COPARN_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>COPARN_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>COPARN_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="COPARN_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="COPARN_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public COPARN_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			COPARN_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COPARN_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		public COPARN_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="COPARN_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		public virtual COPARN_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.COPARN_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="COPARN_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="COPARN_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual COPARN_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			COPARN_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COPARN_DETALLESRow"/> objects 
		/// by the <c>FK_COPARN_DET_COPARN_ID</c> foreign key.
		/// </summary>
		/// <param name="coparn_id">The <c>COPARN_ID</c> column value.</param>
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		public virtual COPARN_DETALLESRow[] GetByCOPARN_ID(decimal coparn_id)
		{
			return MapRecords(CreateGetByCOPARN_IDCommand(coparn_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COPARN_DET_COPARN_ID</c> foreign key.
		/// </summary>
		/// <param name="coparn_id">The <c>COPARN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOPARN_IDAsDataTable(decimal coparn_id)
		{
			return MapRecordsToDataTable(CreateGetByCOPARN_IDCommand(coparn_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COPARN_DET_COPARN_ID</c> foreign key.
		/// </summary>
		/// <param name="coparn_id">The <c>COPARN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOPARN_IDCommand(decimal coparn_id)
		{
			string whereSql = "";
			whereSql += "COPARN_ID=" + _db.CreateSqlParameterName("COPARN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "COPARN_ID", coparn_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="COPARN_DETALLESRow"/> objects 
		/// by the <c>FK_COPARN_DET_TIPO_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		public virtual COPARN_DETALLESRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return MapRecords(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COPARN_DET_TIPO_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COPARN_DET_TIPO_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>COPARN_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COPARN_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(COPARN_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.COPARN_DETALLES (" +
				"ID, " +
				"COPARN_ID, " +
				"NUMERO_CONTENEDOR, " +
				"TIPO_CONTENEDOR_ID, " +
				"MERCADERIA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("COPARN_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("MERCADERIA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "COPARN_ID", value.COPARN_ID);
			AddParameter(cmd, "NUMERO_CONTENEDOR", value.NUMERO_CONTENEDOR);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>COPARN_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COPARN_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(COPARN_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.COPARN_DETALLES SET " +
				"COPARN_ID=" + _db.CreateSqlParameterName("COPARN_ID") + ", " +
				"NUMERO_CONTENEDOR=" + _db.CreateSqlParameterName("NUMERO_CONTENEDOR") + ", " +
				"TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				"MERCADERIA=" + _db.CreateSqlParameterName("MERCADERIA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "COPARN_ID", value.COPARN_ID);
			AddParameter(cmd, "NUMERO_CONTENEDOR", value.NUMERO_CONTENEDOR);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>COPARN_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>COPARN_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>COPARN_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COPARN_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(COPARN_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>COPARN_DETALLES</c> table using
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
		/// Deletes records from the <c>COPARN_DETALLES</c> table using the 
		/// <c>FK_COPARN_DET_COPARN_ID</c> foreign key.
		/// </summary>
		/// <param name="coparn_id">The <c>COPARN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOPARN_ID(decimal coparn_id)
		{
			return CreateDeleteByCOPARN_IDCommand(coparn_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COPARN_DET_COPARN_ID</c> foreign key.
		/// </summary>
		/// <param name="coparn_id">The <c>COPARN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOPARN_IDCommand(decimal coparn_id)
		{
			string whereSql = "";
			whereSql += "COPARN_ID=" + _db.CreateSqlParameterName("COPARN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "COPARN_ID", coparn_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>COPARN_DETALLES</c> table using the 
		/// <c>FK_COPARN_DET_TIPO_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return CreateDeleteByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COPARN_DET_TIPO_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>COPARN_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>COPARN_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.COPARN_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>COPARN_DETALLES</c> table.
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
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		protected COPARN_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		protected COPARN_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="COPARN_DETALLESRow"/> objects.</returns>
		protected virtual COPARN_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int coparn_idColumnIndex = reader.GetOrdinal("COPARN_ID");
			int numero_contenedorColumnIndex = reader.GetOrdinal("NUMERO_CONTENEDOR");
			int tipo_contenedor_idColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_ID");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					COPARN_DETALLESRow record = new COPARN_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.COPARN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(coparn_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_contenedorColumnIndex))
						record.NUMERO_CONTENEDOR = Convert.ToString(reader.GetValue(numero_contenedorColumnIndex));
					record.TIPO_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (COPARN_DETALLESRow[])(recordList.ToArray(typeof(COPARN_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="COPARN_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="COPARN_DETALLESRow"/> object.</returns>
		protected virtual COPARN_DETALLESRow MapRow(DataRow row)
		{
			COPARN_DETALLESRow mappedObject = new COPARN_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "COPARN_ID"
			dataColumn = dataTable.Columns["COPARN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COPARN_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CONTENEDOR"
			dataColumn = dataTable.Columns["NUMERO_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CONTENEDOR = (string)row[dataColumn];
			// Column "TIPO_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "MERCADERIA"
			dataColumn = dataTable.Columns["MERCADERIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>COPARN_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "COPARN_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COPARN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
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

				case "COPARN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MERCADERIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of COPARN_DETALLESCollection_Base class
}  // End of namespace
