// <fileinfo name="CREDITOS_PROVEEDOR_DETCollection_Base.cs">
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
	/// The base class for <see cref="CREDITOS_PROVEEDOR_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CREDITOS_PROVEEDOR_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOS_PROVEEDOR_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CREDITO_PROVEEDOR_IDColumnName = "CREDITO_PROVEEDOR_ID";
		public const string NUMERO_CUOTAColumnName = "NUMERO_CUOTA";
		public const string MONTO_CAPITALColumnName = "MONTO_CAPITAL";
		public const string MONTO_INTERESColumnName = "MONTO_INTERES";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_PROVEEDOR_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CREDITOS_PROVEEDOR_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CREDITOS_PROVEEDOR_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDOR_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CREDITOS_PROVEEDOR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CREDITOS_PROVEEDOR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CREDITOS_PROVEEDOR_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CREDITOS_PROVEEDOR_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CREDITOS_PROVEEDOR_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects.</returns>
		public CREDITOS_PROVEEDOR_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDOR_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CREDITOS_PROVEEDOR_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CREDITOS_PROVEEDOR_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CREDITOS_PROVEEDOR_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CREDITOS_PROVEEDOR_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CREDITOS_PROVEEDOR_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects 
		/// by the <c>FK_CREDITOS_PROVEEDOR_DET_CRED</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_id">The <c>CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects.</returns>
		public virtual CREDITOS_PROVEEDOR_DETRow[] GetByCREDITO_PROVEEDOR_ID(decimal credito_proveedor_id)
		{
			return MapRecords(CreateGetByCREDITO_PROVEEDOR_IDCommand(credito_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PROVEEDOR_DET_CRED</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_id">The <c>CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCREDITO_PROVEEDOR_IDAsDataTable(decimal credito_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByCREDITO_PROVEEDOR_IDCommand(credito_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PROVEEDOR_DET_CRED</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_id">The <c>CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCREDITO_PROVEEDOR_IDCommand(decimal credito_proveedor_id)
		{
			string whereSql = "";
			whereSql += "CREDITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CREDITO_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CREDITO_PROVEEDOR_ID", credito_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CREDITOS_PROVEEDOR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_PROVEEDOR_DETRow"/> object to be inserted.</param>
		public virtual void Insert(CREDITOS_PROVEEDOR_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CREDITOS_PROVEEDOR_DET (" +
				"ID, " +
				"CREDITO_PROVEEDOR_ID, " +
				"NUMERO_CUOTA, " +
				"MONTO_CAPITAL, " +
				"MONTO_INTERES, " +
				"FECHA_VENCIMIENTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CREDITO_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_CUOTA") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CREDITO_PROVEEDOR_ID", value.CREDITO_PROVEEDOR_ID);
			AddParameter(cmd, "NUMERO_CUOTA", value.NUMERO_CUOTA);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERES", value.MONTO_INTERES);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CREDITOS_PROVEEDOR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_PROVEEDOR_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CREDITOS_PROVEEDOR_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.CREDITOS_PROVEEDOR_DET SET " +
				"CREDITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CREDITO_PROVEEDOR_ID") + ", " +
				"NUMERO_CUOTA=" + _db.CreateSqlParameterName("NUMERO_CUOTA") + ", " +
				"MONTO_CAPITAL=" + _db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				"MONTO_INTERES=" + _db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CREDITO_PROVEEDOR_ID", value.CREDITO_PROVEEDOR_ID);
			AddParameter(cmd, "NUMERO_CUOTA", value.NUMERO_CUOTA);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERES", value.MONTO_INTERES);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CREDITOS_PROVEEDOR_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CREDITOS_PROVEEDOR_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CREDITOS_PROVEEDOR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_PROVEEDOR_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CREDITOS_PROVEEDOR_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CREDITOS_PROVEEDOR_DET</c> table using
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
		/// Deletes records from the <c>CREDITOS_PROVEEDOR_DET</c> table using the 
		/// <c>FK_CREDITOS_PROVEEDOR_DET_CRED</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_id">The <c>CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCREDITO_PROVEEDOR_ID(decimal credito_proveedor_id)
		{
			return CreateDeleteByCREDITO_PROVEEDOR_IDCommand(credito_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PROVEEDOR_DET_CRED</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_id">The <c>CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCREDITO_PROVEEDOR_IDCommand(decimal credito_proveedor_id)
		{
			string whereSql = "";
			whereSql += "CREDITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CREDITO_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CREDITO_PROVEEDOR_ID", credito_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CREDITOS_PROVEEDOR_DET</c> records that match the specified criteria.
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
		/// to delete <c>CREDITOS_PROVEEDOR_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CREDITOS_PROVEEDOR_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CREDITOS_PROVEEDOR_DET</c> table.
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects.</returns>
		protected CREDITOS_PROVEEDOR_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects.</returns>
		protected CREDITOS_PROVEEDOR_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CREDITOS_PROVEEDOR_DETRow"/> objects.</returns>
		protected virtual CREDITOS_PROVEEDOR_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int credito_proveedor_idColumnIndex = reader.GetOrdinal("CREDITO_PROVEEDOR_ID");
			int numero_cuotaColumnIndex = reader.GetOrdinal("NUMERO_CUOTA");
			int monto_capitalColumnIndex = reader.GetOrdinal("MONTO_CAPITAL");
			int monto_interesColumnIndex = reader.GetOrdinal("MONTO_INTERES");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CREDITOS_PROVEEDOR_DETRow record = new CREDITOS_PROVEEDOR_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CREDITO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(credito_proveedor_idColumnIndex)), 9);
					record.NUMERO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(numero_cuotaColumnIndex)), 9);
					record.MONTO_CAPITAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capitalColumnIndex)), 9);
					record.MONTO_INTERES = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interesColumnIndex)), 9);
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CREDITOS_PROVEEDOR_DETRow[])(recordList.ToArray(typeof(CREDITOS_PROVEEDOR_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CREDITOS_PROVEEDOR_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CREDITOS_PROVEEDOR_DETRow"/> object.</returns>
		protected virtual CREDITOS_PROVEEDOR_DETRow MapRow(DataRow row)
		{
			CREDITOS_PROVEEDOR_DETRow mappedObject = new CREDITOS_PROVEEDOR_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CREDITO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CREDITO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CUOTA"
			dataColumn = dataTable.Columns["NUMERO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUOTA = (decimal)row[dataColumn];
			// Column "MONTO_CAPITAL"
			dataColumn = dataTable.Columns["MONTO_CAPITAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL = (decimal)row[dataColumn];
			// Column "MONTO_INTERES"
			dataColumn = dataTable.Columns["MONTO_INTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERES = (decimal)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CREDITOS_PROVEEDOR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CREDITOS_PROVEEDOR_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CREDITO_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INTERES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
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

				case "CREDITO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CAPITAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CREDITOS_PROVEEDOR_DETCollection_Base class
}  // End of namespace
