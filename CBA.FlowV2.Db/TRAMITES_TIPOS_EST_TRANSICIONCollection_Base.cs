// <fileinfo name="TRAMITES_TIPOS_EST_TRANSICIONCollection_Base.cs">
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
	/// The base class for <see cref="TRAMITES_TIPOS_EST_TRANSICIONCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRAMITES_TIPOS_EST_TRANSICIONCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_TIPOS_EST_TRANSICIONCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TRAMITE_TIPO_ESTADO_ORIGEN_IDColumnName = "TRAMITE_TIPO_ESTADO_ORIGEN_ID";
		public const string TRAMITE_TIPO_ESTADO_DESTINO_IDColumnName = "TRAMITE_TIPO_ESTADO_DESTINO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_TIPOS_EST_TRANSICIONCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRAMITES_TIPOS_EST_TRANSICIONCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		public virtual TRAMITES_TIPOS_EST_TRANSICIONRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRAMITES_TIPOS_EST_TRANSICIONRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRAMITES_TIPOS_EST_TRANSICIONRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		public TRAMITES_TIPOS_EST_TRANSICIONRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects that 
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		public virtual TRAMITES_TIPOS_EST_TRANSICIONRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRAMITES_TIPOS_EST_TRANSICION";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRAMITES_TIPOS_EST_TRANSICIONRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TRAMITES_TIPOS_EST_TRANSICIONRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects 
		/// by the <c>FK_TRAM_TIP_EST_TRANS_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_destino_id">The <c>TRAMITE_TIPO_ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		public virtual TRAMITES_TIPOS_EST_TRANSICIONRow[] GetByTRAMITE_TIPO_ESTADO_DESTINO_ID(decimal tramite_tipo_estado_destino_id)
		{
			return MapRecords(CreateGetByTRAMITE_TIPO_ESTADO_DESTINO_IDCommand(tramite_tipo_estado_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAM_TIP_EST_TRANS_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_destino_id">The <c>TRAMITE_TIPO_ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRAMITE_TIPO_ESTADO_DESTINO_IDAsDataTable(decimal tramite_tipo_estado_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByTRAMITE_TIPO_ESTADO_DESTINO_IDCommand(tramite_tipo_estado_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAM_TIP_EST_TRANS_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_destino_id">The <c>TRAMITE_TIPO_ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRAMITE_TIPO_ESTADO_DESTINO_IDCommand(decimal tramite_tipo_estado_destino_id)
		{
			string whereSql = "";
			whereSql += "TRAMITE_TIPO_ESTADO_DESTINO_ID=" + _db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_DESTINO_ID", tramite_tipo_estado_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects 
		/// by the <c>FK_TRAM_TIP_EST_TRANS_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_origen_id">The <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		public virtual TRAMITES_TIPOS_EST_TRANSICIONRow[] GetByTRAMITE_TIPO_ESTADO_ORIGEN_ID(decimal tramite_tipo_estado_origen_id)
		{
			return MapRecords(CreateGetByTRAMITE_TIPO_ESTADO_ORIGEN_IDCommand(tramite_tipo_estado_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAM_TIP_EST_TRANS_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_origen_id">The <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRAMITE_TIPO_ESTADO_ORIGEN_IDAsDataTable(decimal tramite_tipo_estado_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByTRAMITE_TIPO_ESTADO_ORIGEN_IDCommand(tramite_tipo_estado_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAM_TIP_EST_TRANS_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_origen_id">The <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRAMITE_TIPO_ESTADO_ORIGEN_IDCommand(decimal tramite_tipo_estado_origen_id)
		{
			string whereSql = "";
			whereSql += "TRAMITE_TIPO_ESTADO_ORIGEN_ID=" + _db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_ORIGEN_ID", tramite_tipo_estado_origen_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> object to be inserted.</param>
		public virtual void Insert(TRAMITES_TIPOS_EST_TRANSICIONRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRAMITES_TIPOS_EST_TRANSICION (" +
				"ID, " +
				"TRAMITE_TIPO_ESTADO_ORIGEN_ID, " +
				"TRAMITE_TIPO_ESTADO_DESTINO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_DESTINO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_ORIGEN_ID", value.TRAMITE_TIPO_ESTADO_ORIGEN_ID);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_DESTINO_ID", value.TRAMITE_TIPO_ESTADO_DESTINO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRAMITES_TIPOS_EST_TRANSICIONRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRAMITES_TIPOS_EST_TRANSICION SET " +
				"TRAMITE_TIPO_ESTADO_ORIGEN_ID=" + _db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_ORIGEN_ID") + ", " +
				"TRAMITE_TIPO_ESTADO_DESTINO_ID=" + _db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_DESTINO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_ORIGEN_ID", value.TRAMITE_TIPO_ESTADO_ORIGEN_ID);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_DESTINO_ID", value.TRAMITE_TIPO_ESTADO_DESTINO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRAMITES_TIPOS_EST_TRANSICIONRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table using
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
		/// Deletes records from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table using the 
		/// <c>FK_TRAM_TIP_EST_TRANS_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_destino_id">The <c>TRAMITE_TIPO_ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRAMITE_TIPO_ESTADO_DESTINO_ID(decimal tramite_tipo_estado_destino_id)
		{
			return CreateDeleteByTRAMITE_TIPO_ESTADO_DESTINO_IDCommand(tramite_tipo_estado_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAM_TIP_EST_TRANS_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_destino_id">The <c>TRAMITE_TIPO_ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRAMITE_TIPO_ESTADO_DESTINO_IDCommand(decimal tramite_tipo_estado_destino_id)
		{
			string whereSql = "";
			whereSql += "TRAMITE_TIPO_ESTADO_DESTINO_ID=" + _db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_DESTINO_ID", tramite_tipo_estado_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table using the 
		/// <c>FK_TRAM_TIP_EST_TRANS_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_origen_id">The <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRAMITE_TIPO_ESTADO_ORIGEN_ID(decimal tramite_tipo_estado_origen_id)
		{
			return CreateDeleteByTRAMITE_TIPO_ESTADO_ORIGEN_IDCommand(tramite_tipo_estado_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAM_TIP_EST_TRANS_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_tipo_estado_origen_id">The <c>TRAMITE_TIPO_ESTADO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRAMITE_TIPO_ESTADO_ORIGEN_IDCommand(decimal tramite_tipo_estado_origen_id)
		{
			string whereSql = "";
			whereSql += "TRAMITE_TIPO_ESTADO_ORIGEN_ID=" + _db.CreateSqlParameterName("TRAMITE_TIPO_ESTADO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TRAMITE_TIPO_ESTADO_ORIGEN_ID", tramite_tipo_estado_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TRAMITES_TIPOS_EST_TRANSICION</c> records that match the specified criteria.
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
		/// to delete <c>TRAMITES_TIPOS_EST_TRANSICION</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRAMITES_TIPOS_EST_TRANSICION";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		protected TRAMITES_TIPOS_EST_TRANSICIONRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		protected TRAMITES_TIPOS_EST_TRANSICIONRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> objects.</returns>
		protected virtual TRAMITES_TIPOS_EST_TRANSICIONRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tramite_tipo_estado_origen_idColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ESTADO_ORIGEN_ID");
			int tramite_tipo_estado_destino_idColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ESTADO_DESTINO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRAMITES_TIPOS_EST_TRANSICIONRow record = new TRAMITES_TIPOS_EST_TRANSICIONRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TRAMITE_TIPO_ESTADO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_tipo_estado_origen_idColumnIndex)), 9);
					record.TRAMITE_TIPO_ESTADO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_tipo_estado_destino_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRAMITES_TIPOS_EST_TRANSICIONRow[])(recordList.ToArray(typeof(TRAMITES_TIPOS_EST_TRANSICIONRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRAMITES_TIPOS_EST_TRANSICIONRow"/> object.</returns>
		protected virtual TRAMITES_TIPOS_EST_TRANSICIONRow MapRow(DataRow row)
		{
			TRAMITES_TIPOS_EST_TRANSICIONRow mappedObject = new TRAMITES_TIPOS_EST_TRANSICIONRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TRAMITE_TIPO_ESTADO_ORIGEN_ID"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_ESTADO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_ESTADO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "TRAMITE_TIPO_ESTADO_DESTINO_ID"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_ESTADO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_ESTADO_DESTINO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRAMITES_TIPOS_EST_TRANSICION</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRAMITES_TIPOS_EST_TRANSICION";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ESTADO_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ESTADO_DESTINO_ID", typeof(decimal));
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

				case "TRAMITE_TIPO_ESTADO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITE_TIPO_ESTADO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRAMITES_TIPOS_EST_TRANSICIONCollection_Base class
}  // End of namespace
