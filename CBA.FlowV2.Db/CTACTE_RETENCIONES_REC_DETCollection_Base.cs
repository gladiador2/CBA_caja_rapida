// <fileinfo name="CTACTE_RETENCIONES_REC_DETCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_RETENCIONES_REC_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_RETENCIONES_REC_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_RETENCIONES_REC_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_RETENCION_RECIBIDA_IDColumnName = "CTACTE_RETENCION_RECIBIDA_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string MONTOColumnName = "MONTO";
		public const string TIPO_IDColumnName = "TIPO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RETENCIONES_REC_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_RETENCIONES_REC_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_RETENCIONES_REC_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		public virtual CTACTE_RETENCIONES_REC_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_RETENCIONES_REC_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_RETENCIONES_REC_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_RETENCIONES_REC_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_RETENCIONES_REC_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		public CTACTE_RETENCIONES_REC_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		public virtual CTACTE_RETENCIONES_REC_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_RETENCIONES_REC_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_RETENCIONES_REC_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_RETENCIONES_REC_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_RETENCIONES_REC_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		public virtual CTACTE_RETENCIONES_REC_DETRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RETENC_REC_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		public virtual CTACTE_RETENCIONES_REC_DETRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RETENC_REC_DET_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_RET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_retencion_recibida_id">The <c>CTACTE_RETENCION_RECIBIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		public virtual CTACTE_RETENCIONES_REC_DETRow[] GetByCTACTE_RETENCION_RECIBIDA_ID(decimal ctacte_retencion_recibida_id)
		{
			return MapRecords(CreateGetByCTACTE_RETENCION_RECIBIDA_IDCommand(ctacte_retencion_recibida_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_RET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_retencion_recibida_id">The <c>CTACTE_RETENCION_RECIBIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RETENCION_RECIBIDA_IDAsDataTable(decimal ctacte_retencion_recibida_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RETENCION_RECIBIDA_IDCommand(ctacte_retencion_recibida_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RETENC_REC_DET_RET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_retencion_recibida_id">The <c>CTACTE_RETENCION_RECIBIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RETENCION_RECIBIDA_IDCommand(decimal ctacte_retencion_recibida_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_RETENCION_RECIBIDA_ID=" + _db.CreateSqlParameterName("CTACTE_RETENCION_RECIBIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_RETENCION_RECIBIDA_ID", ctacte_retencion_recibida_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		public virtual CTACTE_RETENCIONES_REC_DETRow[] GetByTIPO_ID(decimal tipo_id)
		{
			return MapRecords(CreateGetByTIPO_IDCommand(tipo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RETENC_REC_DET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_IDAsDataTable(decimal tipo_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_IDCommand(tipo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RETENC_REC_DET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_IDCommand(decimal tipo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ID=" + _db.CreateSqlParameterName("TIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_ID", tipo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_RETENCIONES_REC_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_RETENCIONES_REC_DETRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_RETENCIONES_REC_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_RETENCIONES_REC_DET (" +
				"ID, " +
				"CTACTE_RETENCION_RECIBIDA_ID, " +
				"FLUJO_ID, " +
				"CASO_ID, " +
				"MONTO, " +
				"TIPO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RETENCION_RECIBIDA_ID") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("TIPO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_RETENCION_RECIBIDA_ID", value.CTACTE_RETENCION_RECIBIDA_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "TIPO_ID", value.TIPO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_RETENCIONES_REC_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_RETENCIONES_REC_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_RETENCIONES_REC_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_RETENCIONES_REC_DET SET " +
				"CTACTE_RETENCION_RECIBIDA_ID=" + _db.CreateSqlParameterName("CTACTE_RETENCION_RECIBIDA_ID") + ", " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"TIPO_ID=" + _db.CreateSqlParameterName("TIPO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_RETENCION_RECIBIDA_ID", value.CTACTE_RETENCION_RECIBIDA_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "TIPO_ID", value.TIPO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_RETENCIONES_REC_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_RETENCIONES_REC_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_RETENCIONES_REC_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_RETENCIONES_REC_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_RETENCIONES_REC_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_RETENCIONES_REC_DET</c> table using
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
		/// Deletes records from the <c>CTACTE_RETENCIONES_REC_DET</c> table using the 
		/// <c>FK_CTACTE_RETENC_REC_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RETENC_REC_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RETENCIONES_REC_DET</c> table using the 
		/// <c>FK_CTACTE_RETENC_REC_DET_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RETENC_REC_DET_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RETENCIONES_REC_DET</c> table using the 
		/// <c>FK_CTACTE_RETENC_REC_DET_RET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_retencion_recibida_id">The <c>CTACTE_RETENCION_RECIBIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RETENCION_RECIBIDA_ID(decimal ctacte_retencion_recibida_id)
		{
			return CreateDeleteByCTACTE_RETENCION_RECIBIDA_IDCommand(ctacte_retencion_recibida_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RETENC_REC_DET_RET</c> foreign key.
		/// </summary>
		/// <param name="ctacte_retencion_recibida_id">The <c>CTACTE_RETENCION_RECIBIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RETENCION_RECIBIDA_IDCommand(decimal ctacte_retencion_recibida_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_RETENCION_RECIBIDA_ID=" + _db.CreateSqlParameterName("CTACTE_RETENCION_RECIBIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_RETENCION_RECIBIDA_ID", ctacte_retencion_recibida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RETENCIONES_REC_DET</c> table using the 
		/// <c>FK_CTACTE_RETENC_REC_DET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ID(decimal tipo_id)
		{
			return CreateDeleteByTIPO_IDCommand(tipo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RETENC_REC_DET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_IDCommand(decimal tipo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ID=" + _db.CreateSqlParameterName("TIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_ID", tipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_RETENCIONES_REC_DET</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_RETENCIONES_REC_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_RETENCIONES_REC_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_RETENCIONES_REC_DET</c> table.
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
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		protected CTACTE_RETENCIONES_REC_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		protected CTACTE_RETENCIONES_REC_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_RETENCIONES_REC_DETRow"/> objects.</returns>
		protected virtual CTACTE_RETENCIONES_REC_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_retencion_recibida_idColumnIndex = reader.GetOrdinal("CTACTE_RETENCION_RECIBIDA_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int tipo_idColumnIndex = reader.GetOrdinal("TIPO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_RETENCIONES_REC_DETRow record = new CTACTE_RETENCIONES_REC_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_RETENCION_RECIBIDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_retencion_recibida_idColumnIndex)), 9);
					record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_RETENCIONES_REC_DETRow[])(recordList.ToArray(typeof(CTACTE_RETENCIONES_REC_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_RETENCIONES_REC_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_RETENCIONES_REC_DETRow"/> object.</returns>
		protected virtual CTACTE_RETENCIONES_REC_DETRow MapRow(DataRow row)
		{
			CTACTE_RETENCIONES_REC_DETRow mappedObject = new CTACTE_RETENCIONES_REC_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_RETENCION_RECIBIDA_ID"
			dataColumn = dataTable.Columns["CTACTE_RETENCION_RECIBIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RETENCION_RECIBIDA_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "TIPO_ID"
			dataColumn = dataTable.Columns["TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_RETENCIONES_REC_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_RETENCIONES_REC_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_RETENCION_RECIBIDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_ID", typeof(decimal));
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

				case "CTACTE_RETENCION_RECIBIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_RETENCIONES_REC_DETCollection_Base class
}  // End of namespace
