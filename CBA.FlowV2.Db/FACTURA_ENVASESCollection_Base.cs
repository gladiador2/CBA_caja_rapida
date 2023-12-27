// <fileinfo name="FACTURA_ENVASESCollection_Base.cs">
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
	/// The base class for <see cref="FACTURA_ENVASESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURA_ENVASESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURA_ENVASESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FACTURA_CLIENTE_DETALLE_IDColumnName = "FACTURA_CLIENTE_DETALLE_ID";
		public const string ENVASE_IDColumnName = "ENVASE_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string PESOColumnName = "PESO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURA_ENVASESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURA_ENVASESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURA_ENVASES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		public virtual FACTURA_ENVASESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURA_ENVASES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURA_ENVASES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURA_ENVASESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURA_ENVASESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURA_ENVASESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURA_ENVASESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURA_ENVASESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		public FACTURA_ENVASESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURA_ENVASESRow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		public virtual FACTURA_ENVASESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURA_ENVASES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FACTURA_ENVASESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FACTURA_ENVASESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FACTURA_ENVASESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FACTURA_ENVASESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURA_ENVASESRow"/> objects 
		/// by the <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		public FACTURA_ENVASESRow[] GetByENVASE_ID(decimal envase_id)
		{
			return GetByENVASE_ID(envase_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURA_ENVASESRow"/> objects 
		/// by the <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <param name="envase_idNull">true if the method ignores the envase_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		public virtual FACTURA_ENVASESRow[] GetByENVASE_ID(decimal envase_id, bool envase_idNull)
		{
			return MapRecords(CreateGetByENVASE_IDCommand(envase_id, envase_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByENVASE_IDAsDataTable(decimal envase_id)
		{
			return GetByENVASE_IDAsDataTable(envase_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <param name="envase_idNull">true if the method ignores the envase_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENVASE_IDAsDataTable(decimal envase_id, bool envase_idNull)
		{
			return MapRecordsToDataTable(CreateGetByENVASE_IDCommand(envase_id, envase_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <param name="envase_idNull">true if the method ignores the envase_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENVASE_IDCommand(decimal envase_id, bool envase_idNull)
		{
			string whereSql = "";
			if(envase_idNull)
				whereSql += "ENVASE_ID IS NULL";
			else
				whereSql += "ENVASE_ID=" + _db.CreateSqlParameterName("ENVASE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!envase_idNull)
				AddParameter(cmd, "ENVASE_ID", envase_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURA_ENVASESRow"/> objects 
		/// by the <c>FK_FACTURA_ENVASES_FC</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_detalle_id">The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		public virtual FACTURA_ENVASESRow[] GetByFACTURA_CLIENTE_DETALLE_ID(decimal factura_cliente_detalle_id)
		{
			return MapRecords(CreateGetByFACTURA_CLIENTE_DETALLE_IDCommand(factura_cliente_detalle_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURA_ENVASES_FC</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_detalle_id">The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFACTURA_CLIENTE_DETALLE_IDAsDataTable(decimal factura_cliente_detalle_id)
		{
			return MapRecordsToDataTable(CreateGetByFACTURA_CLIENTE_DETALLE_IDCommand(factura_cliente_detalle_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURA_ENVASES_FC</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_detalle_id">The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFACTURA_CLIENTE_DETALLE_IDCommand(decimal factura_cliente_detalle_id)
		{
			string whereSql = "";
			whereSql += "FACTURA_CLIENTE_DETALLE_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FACTURA_CLIENTE_DETALLE_ID", factura_cliente_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FACTURA_ENVASES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURA_ENVASESRow"/> object to be inserted.</param>
		public virtual void Insert(FACTURA_ENVASESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FACTURA_ENVASES (" +
				"ID, " +
				"FACTURA_CLIENTE_DETALLE_ID, " +
				"ENVASE_ID, " +
				"CANTIDAD, " +
				"PESO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FACTURA_CLIENTE_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("ENVASE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("PESO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FACTURA_CLIENTE_DETALLE_ID", value.FACTURA_CLIENTE_DETALLE_ID);
			AddParameter(cmd, "ENVASE_ID",
				value.IsENVASE_IDNull ? DBNull.Value : (object)value.ENVASE_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "PESO",
				value.IsPESONull ? DBNull.Value : (object)value.PESO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FACTURA_ENVASES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURA_ENVASESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FACTURA_ENVASESRow value)
		{
			
			string sqlStr = "UPDATE TRC.FACTURA_ENVASES SET " +
				"FACTURA_CLIENTE_DETALLE_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_DETALLE_ID") + ", " +
				"ENVASE_ID=" + _db.CreateSqlParameterName("ENVASE_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"PESO=" + _db.CreateSqlParameterName("PESO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FACTURA_CLIENTE_DETALLE_ID", value.FACTURA_CLIENTE_DETALLE_ID);
			AddParameter(cmd, "ENVASE_ID",
				value.IsENVASE_IDNull ? DBNull.Value : (object)value.ENVASE_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "PESO",
				value.IsPESONull ? DBNull.Value : (object)value.PESO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FACTURA_ENVASES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FACTURA_ENVASES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FACTURA_ENVASES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURA_ENVASESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FACTURA_ENVASESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FACTURA_ENVASES</c> table using
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
		/// Deletes records from the <c>FACTURA_ENVASES</c> table using the 
		/// <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENVASE_ID(decimal envase_id)
		{
			return DeleteByENVASE_ID(envase_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURA_ENVASES</c> table using the 
		/// <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <param name="envase_idNull">true if the method ignores the envase_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENVASE_ID(decimal envase_id, bool envase_idNull)
		{
			return CreateDeleteByENVASE_IDCommand(envase_id, envase_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURA_ENVASES_ENVASES</c> foreign key.
		/// </summary>
		/// <param name="envase_id">The <c>ENVASE_ID</c> column value.</param>
		/// <param name="envase_idNull">true if the method ignores the envase_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENVASE_IDCommand(decimal envase_id, bool envase_idNull)
		{
			string whereSql = "";
			if(envase_idNull)
				whereSql += "ENVASE_ID IS NULL";
			else
				whereSql += "ENVASE_ID=" + _db.CreateSqlParameterName("ENVASE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!envase_idNull)
				AddParameter(cmd, "ENVASE_ID", envase_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURA_ENVASES</c> table using the 
		/// <c>FK_FACTURA_ENVASES_FC</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_detalle_id">The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_CLIENTE_DETALLE_ID(decimal factura_cliente_detalle_id)
		{
			return CreateDeleteByFACTURA_CLIENTE_DETALLE_IDCommand(factura_cliente_detalle_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURA_ENVASES_FC</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_detalle_id">The <c>FACTURA_CLIENTE_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFACTURA_CLIENTE_DETALLE_IDCommand(decimal factura_cliente_detalle_id)
		{
			string whereSql = "";
			whereSql += "FACTURA_CLIENTE_DETALLE_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FACTURA_CLIENTE_DETALLE_ID", factura_cliente_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FACTURA_ENVASES</c> records that match the specified criteria.
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
		/// to delete <c>FACTURA_ENVASES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FACTURA_ENVASES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FACTURA_ENVASES</c> table.
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
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		protected FACTURA_ENVASESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		protected FACTURA_ENVASESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURA_ENVASESRow"/> objects.</returns>
		protected virtual FACTURA_ENVASESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int factura_cliente_detalle_idColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_DETALLE_ID");
			int envase_idColumnIndex = reader.GetOrdinal("ENVASE_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int pesoColumnIndex = reader.GetOrdinal("PESO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURA_ENVASESRow record = new FACTURA_ENVASESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FACTURA_CLIENTE_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_cliente_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(envase_idColumnIndex))
						record.ENVASE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(envase_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(pesoColumnIndex))
						record.PESO = Math.Round(Convert.ToDecimal(reader.GetValue(pesoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURA_ENVASESRow[])(recordList.ToArray(typeof(FACTURA_ENVASESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURA_ENVASESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURA_ENVASESRow"/> object.</returns>
		protected virtual FACTURA_ENVASESRow MapRow(DataRow row)
		{
			FACTURA_ENVASESRow mappedObject = new FACTURA_ENVASESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FACTURA_CLIENTE_DETALLE_ID"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_DETALLE_ID = (decimal)row[dataColumn];
			// Column "ENVASE_ID"
			dataColumn = dataTable.Columns["ENVASE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENVASE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "PESO"
			dataColumn = dataTable.Columns["PESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURA_ENVASES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURA_ENVASES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_DETALLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENVASE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO", typeof(decimal));
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

				case "FACTURA_CLIENTE_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENVASE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURA_ENVASESCollection_Base class
}  // End of namespace
