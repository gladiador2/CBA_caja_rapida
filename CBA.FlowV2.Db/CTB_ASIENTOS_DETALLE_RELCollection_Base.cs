// <fileinfo name="CTB_ASIENTOS_DETALLE_RELCollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_DETALLE_RELCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_DETALLE_RELCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_DETALLE_RELCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_ASIENTOS_DETALLEColumnName = "CTB_ASIENTOS_DETALLE";
		public const string TABLA_RELACIONADA_IDColumnName = "TABLA_RELACIONADA_ID";
		public const string REGISTRO_RELACIONADO_IDColumnName = "REGISTRO_RELACIONADO_ID";
		public const string MONTOColumnName = "MONTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_DETALLE_RELCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_DETALLE_RELCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLE_RELRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_DETALLE_RELRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_DETALLE_RELRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects.</returns>
		public CTB_ASIENTOS_DETALLE_RELRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLE_RELRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_DETALLE_REL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_ASIENTOS_DETALLE_RELRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_ASIENTOS_DETALLE_RELRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects 
		/// by the <c>FK_CTB_ASI_DET_REL_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLE_RELRow[] GetByTABLA_RELACIONADA_ID(string tabla_relacionada_id)
		{
			return MapRecords(CreateGetByTABLA_RELACIONADA_IDCommand(tabla_relacionada_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASI_DET_REL_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_RELACIONADA_IDAsDataTable(string tabla_relacionada_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_RELACIONADA_IDCommand(tabla_relacionada_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASI_DET_REL_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTABLA_RELACIONADA_IDCommand(string tabla_relacionada_id)
		{
			string whereSql = "";
			if(null == tabla_relacionada_id)
				whereSql += "TABLA_RELACIONADA_ID IS NULL";
			else
				whereSql += "TABLA_RELACIONADA_ID=" + _db.CreateSqlParameterName("TABLA_RELACIONADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tabla_relacionada_id)
				AddParameter(cmd, "TABLA_RELACIONADA_ID", tabla_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_ASIENTOS_DETALLE_RELRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_ASIENTOS_DETALLE_REL (" +
				"ID, " +
				"CTB_ASIENTOS_DETALLE, " +
				"TABLA_RELACIONADA_ID, " +
				"REGISTRO_RELACIONADO_ID, " +
				"MONTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_ASIENTOS_DETALLE") + ", " +
				_db.CreateSqlParameterName("TABLA_RELACIONADA_ID") + ", " +
				_db.CreateSqlParameterName("REGISTRO_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_ASIENTOS_DETALLE", value.CTB_ASIENTOS_DETALLE);
			AddParameter(cmd, "TABLA_RELACIONADA_ID", value.TABLA_RELACIONADA_ID);
			AddParameter(cmd, "REGISTRO_RELACIONADO_ID",
				value.IsREGISTRO_RELACIONADO_IDNull ? DBNull.Value : (object)value.REGISTRO_RELACIONADO_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_DETALLE_RELRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_ASIENTOS_DETALLE_RELRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_ASIENTOS_DETALLE_REL SET " +
				"CTB_ASIENTOS_DETALLE=" + _db.CreateSqlParameterName("CTB_ASIENTOS_DETALLE") + ", " +
				"TABLA_RELACIONADA_ID=" + _db.CreateSqlParameterName("TABLA_RELACIONADA_ID") + ", " +
				"REGISTRO_RELACIONADO_ID=" + _db.CreateSqlParameterName("REGISTRO_RELACIONADO_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_ASIENTOS_DETALLE", value.CTB_ASIENTOS_DETALLE);
			AddParameter(cmd, "TABLA_RELACIONADA_ID", value.TABLA_RELACIONADA_ID);
			AddParameter(cmd, "REGISTRO_RELACIONADO_ID",
				value.IsREGISTRO_RELACIONADO_IDNull ? DBNull.Value : (object)value.REGISTRO_RELACIONADO_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_DETALLE_REL</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_DETALLE_REL</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_ASIENTOS_DETALLE_RELRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_ASIENTOS_DETALLE_REL</c> table using
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
		/// Deletes records from the <c>CTB_ASIENTOS_DETALLE_REL</c> table using the 
		/// <c>FK_CTB_ASI_DET_REL_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_RELACIONADA_ID(string tabla_relacionada_id)
		{
			return CreateDeleteByTABLA_RELACIONADA_IDCommand(tabla_relacionada_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASI_DET_REL_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTABLA_RELACIONADA_IDCommand(string tabla_relacionada_id)
		{
			string whereSql = "";
			if(null == tabla_relacionada_id)
				whereSql += "TABLA_RELACIONADA_ID IS NULL";
			else
				whereSql += "TABLA_RELACIONADA_ID=" + _db.CreateSqlParameterName("TABLA_RELACIONADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tabla_relacionada_id)
				AddParameter(cmd, "TABLA_RELACIONADA_ID", tabla_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_ASIENTOS_DETALLE_REL</c> records that match the specified criteria.
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
		/// to delete <c>CTB_ASIENTOS_DETALLE_REL</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_ASIENTOS_DETALLE_REL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects.</returns>
		protected CTB_ASIENTOS_DETALLE_RELRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects.</returns>
		protected CTB_ASIENTOS_DETALLE_RELRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_DETALLE_RELRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_asientos_detalleColumnIndex = reader.GetOrdinal("CTB_ASIENTOS_DETALLE");
			int tabla_relacionada_idColumnIndex = reader.GetOrdinal("TABLA_RELACIONADA_ID");
			int registro_relacionado_idColumnIndex = reader.GetOrdinal("REGISTRO_RELACIONADO_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_DETALLE_RELRow record = new CTB_ASIENTOS_DETALLE_RELRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_ASIENTOS_DETALLE = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asientos_detalleColumnIndex)), 9);
					if(!reader.IsDBNull(tabla_relacionada_idColumnIndex))
						record.TABLA_RELACIONADA_ID = Convert.ToString(reader.GetValue(tabla_relacionada_idColumnIndex));
					if(!reader.IsDBNull(registro_relacionado_idColumnIndex))
						record.REGISTRO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(registro_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_DETALLE_RELRow[])(recordList.ToArray(typeof(CTB_ASIENTOS_DETALLE_RELRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_DETALLE_RELRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_DETALLE_RELRow"/> object.</returns>
		protected virtual CTB_ASIENTOS_DETALLE_RELRow MapRow(DataRow row)
		{
			CTB_ASIENTOS_DETALLE_RELRow mappedObject = new CTB_ASIENTOS_DETALLE_RELRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_ASIENTOS_DETALLE"
			dataColumn = dataTable.Columns["CTB_ASIENTOS_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTOS_DETALLE = (decimal)row[dataColumn];
			// Column "TABLA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["TABLA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_RELACIONADA_ID = (string)row[dataColumn];
			// Column "REGISTRO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["REGISTRO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_DETALLE_REL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_DETALLE_REL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTOS_DETALLE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TABLA_RELACIONADA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("REGISTRO_RELACIONADO_ID", typeof(decimal));
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

				case "CTB_ASIENTOS_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TABLA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGISTRO_RELACIONADO_ID":
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
	} // End of CTB_ASIENTOS_DETALLE_RELCollection_Base class
}  // End of namespace
