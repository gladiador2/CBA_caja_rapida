// <fileinfo name="CTB_PRESUPUESTOS_DETCollection_Base.cs">
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
	/// The base class for <see cref="CTB_PRESUPUESTOS_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_PRESUPUESTOS_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_PRESUPUESTOS_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_PRESUPUESTO_IDColumnName = "CTB_PRESUPUESTO_ID";
		public const string CTB_CUENTA_IDColumnName = "CTB_CUENTA_ID";
		public const string MES_DESDEColumnName = "MES_DESDE";
		public const string MES_HASTAColumnName = "MES_HASTA";
		public const string MONTOColumnName = "MONTO";
		public const string ESTADOColumnName = "ESTADO";
		public const string NOMBREColumnName = "NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PRESUPUESTOS_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_PRESUPUESTOS_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_PRESUPUESTOS_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		public virtual CTB_PRESUPUESTOS_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_PRESUPUESTOS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_PRESUPUESTOS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_PRESUPUESTOS_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_PRESUPUESTOS_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_PRESUPUESTOS_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_PRESUPUESTOS_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		public CTB_PRESUPUESTOS_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		public virtual CTB_PRESUPUESTOS_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_PRESUPUESTOS_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_PRESUPUESTOS_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_PRESUPUESTOS_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_PRESUPUESTOS_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_PRESUPUESTOS_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects 
		/// by the <c>FK_CTB_PRESUPUESTOS_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		public virtual CTB_PRESUPUESTOS_DETRow[] GetByCTB_CUENTA_ID(decimal ctb_cuenta_id)
		{
			return MapRecords(CreateGetByCTB_CUENTA_IDCommand(ctb_cuenta_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_PRESUPUESTOS_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_CUENTA_IDAsDataTable(decimal ctb_cuenta_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_CUENTA_IDCommand(ctb_cuenta_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_PRESUPUESTOS_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_CUENTA_IDCommand(decimal ctb_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_CUENTA_ID", ctb_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects 
		/// by the <c>FK_CTB_PRESUPUESTOS_DET_PRESU</c> foreign key.
		/// </summary>
		/// <param name="ctb_presupuesto_id">The <c>CTB_PRESUPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		public virtual CTB_PRESUPUESTOS_DETRow[] GetByCTB_PRESUPUESTO_ID(decimal ctb_presupuesto_id)
		{
			return MapRecords(CreateGetByCTB_PRESUPUESTO_IDCommand(ctb_presupuesto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_PRESUPUESTOS_DET_PRESU</c> foreign key.
		/// </summary>
		/// <param name="ctb_presupuesto_id">The <c>CTB_PRESUPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_PRESUPUESTO_IDAsDataTable(decimal ctb_presupuesto_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_PRESUPUESTO_IDCommand(ctb_presupuesto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_PRESUPUESTOS_DET_PRESU</c> foreign key.
		/// </summary>
		/// <param name="ctb_presupuesto_id">The <c>CTB_PRESUPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_PRESUPUESTO_IDCommand(decimal ctb_presupuesto_id)
		{
			string whereSql = "";
			whereSql += "CTB_PRESUPUESTO_ID=" + _db.CreateSqlParameterName("CTB_PRESUPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_PRESUPUESTO_ID", ctb_presupuesto_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_PRESUPUESTOS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_PRESUPUESTOS_DETRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_PRESUPUESTOS_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_PRESUPUESTOS_DET (" +
				"ID, " +
				"CTB_PRESUPUESTO_ID, " +
				"CTB_CUENTA_ID, " +
				"MES_DESDE, " +
				"MES_HASTA, " +
				"MONTO, " +
				"ESTADO, " +
				"NOMBRE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_PRESUPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("CTB_CUENTA_ID") + ", " +
				_db.CreateSqlParameterName("MES_DESDE") + ", " +
				_db.CreateSqlParameterName("MES_HASTA") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_PRESUPUESTO_ID", value.CTB_PRESUPUESTO_ID);
			AddParameter(cmd, "CTB_CUENTA_ID", value.CTB_CUENTA_ID);
			AddParameter(cmd, "MES_DESDE", value.MES_DESDE);
			AddParameter(cmd, "MES_HASTA", value.MES_HASTA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_PRESUPUESTOS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_PRESUPUESTOS_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_PRESUPUESTOS_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_PRESUPUESTOS_DET SET " +
				"CTB_PRESUPUESTO_ID=" + _db.CreateSqlParameterName("CTB_PRESUPUESTO_ID") + ", " +
				"CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID") + ", " +
				"MES_DESDE=" + _db.CreateSqlParameterName("MES_DESDE") + ", " +
				"MES_HASTA=" + _db.CreateSqlParameterName("MES_HASTA") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_PRESUPUESTO_ID", value.CTB_PRESUPUESTO_ID);
			AddParameter(cmd, "CTB_CUENTA_ID", value.CTB_CUENTA_ID);
			AddParameter(cmd, "MES_DESDE", value.MES_DESDE);
			AddParameter(cmd, "MES_HASTA", value.MES_HASTA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_PRESUPUESTOS_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_PRESUPUESTOS_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_PRESUPUESTOS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_PRESUPUESTOS_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_PRESUPUESTOS_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_PRESUPUESTOS_DET</c> table using
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
		/// Deletes records from the <c>CTB_PRESUPUESTOS_DET</c> table using the 
		/// <c>FK_CTB_PRESUPUESTOS_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_ID(decimal ctb_cuenta_id)
		{
			return CreateDeleteByCTB_CUENTA_IDCommand(ctb_cuenta_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_PRESUPUESTOS_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_CUENTA_IDCommand(decimal ctb_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_CUENTA_ID", ctb_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_PRESUPUESTOS_DET</c> table using the 
		/// <c>FK_CTB_PRESUPUESTOS_DET_PRESU</c> foreign key.
		/// </summary>
		/// <param name="ctb_presupuesto_id">The <c>CTB_PRESUPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_PRESUPUESTO_ID(decimal ctb_presupuesto_id)
		{
			return CreateDeleteByCTB_PRESUPUESTO_IDCommand(ctb_presupuesto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_PRESUPUESTOS_DET_PRESU</c> foreign key.
		/// </summary>
		/// <param name="ctb_presupuesto_id">The <c>CTB_PRESUPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_PRESUPUESTO_IDCommand(decimal ctb_presupuesto_id)
		{
			string whereSql = "";
			whereSql += "CTB_PRESUPUESTO_ID=" + _db.CreateSqlParameterName("CTB_PRESUPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_PRESUPUESTO_ID", ctb_presupuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_PRESUPUESTOS_DET</c> records that match the specified criteria.
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
		/// to delete <c>CTB_PRESUPUESTOS_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_PRESUPUESTOS_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_PRESUPUESTOS_DET</c> table.
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
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		protected CTB_PRESUPUESTOS_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		protected CTB_PRESUPUESTOS_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_PRESUPUESTOS_DETRow"/> objects.</returns>
		protected virtual CTB_PRESUPUESTOS_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_presupuesto_idColumnIndex = reader.GetOrdinal("CTB_PRESUPUESTO_ID");
			int ctb_cuenta_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_ID");
			int mes_desdeColumnIndex = reader.GetOrdinal("MES_DESDE");
			int mes_hastaColumnIndex = reader.GetOrdinal("MES_HASTA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_PRESUPUESTOS_DETRow record = new CTB_PRESUPUESTOS_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_PRESUPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_presupuesto_idColumnIndex)), 9);
					record.CTB_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_idColumnIndex)), 9);
					record.MES_DESDE = Math.Round(Convert.ToDecimal(reader.GetValue(mes_desdeColumnIndex)), 9);
					record.MES_HASTA = Math.Round(Convert.ToDecimal(reader.GetValue(mes_hastaColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_PRESUPUESTOS_DETRow[])(recordList.ToArray(typeof(CTB_PRESUPUESTOS_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_PRESUPUESTOS_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_PRESUPUESTOS_DETRow"/> object.</returns>
		protected virtual CTB_PRESUPUESTOS_DETRow MapRow(DataRow row)
		{
			CTB_PRESUPUESTOS_DETRow mappedObject = new CTB_PRESUPUESTOS_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_PRESUPUESTO_ID"
			dataColumn = dataTable.Columns["CTB_PRESUPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PRESUPUESTO_ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_ID = (decimal)row[dataColumn];
			// Column "MES_DESDE"
			dataColumn = dataTable.Columns["MES_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MES_DESDE = (decimal)row[dataColumn];
			// Column "MES_HASTA"
			dataColumn = dataTable.Columns["MES_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MES_HASTA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_PRESUPUESTOS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_PRESUPUESTOS_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_PRESUPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MES_DESDE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MES_HASTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
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

				case "CTB_PRESUPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MES_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MES_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_PRESUPUESTOS_DETCollection_Base class
}  // End of namespace
