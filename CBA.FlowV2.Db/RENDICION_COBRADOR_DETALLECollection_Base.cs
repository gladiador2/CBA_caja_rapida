// <fileinfo name="RENDICION_COBRADOR_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="RENDICION_COBRADOR_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="RENDICION_COBRADOR_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RENDICION_COBRADOR_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string RENDICION_COBRADOR_IDColumnName = "RENDICION_COBRADOR_ID";
		public const string RECIBO_IDColumnName = "RECIBO_ID";
		public const string CASO_PAGOColumnName = "CASO_PAGO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="RENDICION_COBRADOR_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public RENDICION_COBRADOR_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>RENDICION_COBRADOR_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		public virtual RENDICION_COBRADOR_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>RENDICION_COBRADOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>RENDICION_COBRADOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="RENDICION_COBRADOR_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="RENDICION_COBRADOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public RENDICION_COBRADOR_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			RENDICION_COBRADOR_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		public RENDICION_COBRADOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		public virtual RENDICION_COBRADOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.RENDICION_COBRADOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="RENDICION_COBRADOR_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="RENDICION_COBRADOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual RENDICION_COBRADOR_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			RENDICION_COBRADOR_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects 
		/// by the <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		public RENDICION_COBRADOR_DETALLERow[] GetByCASO_PAGO(decimal caso_pago)
		{
			return GetByCASO_PAGO(caso_pago, false);
		}

		/// <summary>
		/// Gets an array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects 
		/// by the <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <param name="caso_pagoNull">true if the method ignores the caso_pago
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		public virtual RENDICION_COBRADOR_DETALLERow[] GetByCASO_PAGO(decimal caso_pago, bool caso_pagoNull)
		{
			return MapRecords(CreateGetByCASO_PAGOCommand(caso_pago, caso_pagoNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_PAGOAsDataTable(decimal caso_pago)
		{
			return GetByCASO_PAGOAsDataTable(caso_pago, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <param name="caso_pagoNull">true if the method ignores the caso_pago
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_PAGOAsDataTable(decimal caso_pago, bool caso_pagoNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_PAGOCommand(caso_pago, caso_pagoNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <param name="caso_pagoNull">true if the method ignores the caso_pago
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_PAGOCommand(decimal caso_pago, bool caso_pagoNull)
		{
			string whereSql = "";
			if(caso_pagoNull)
				whereSql += "CASO_PAGO IS NULL";
			else
				whereSql += "CASO_PAGO=" + _db.CreateSqlParameterName("CASO_PAGO");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_pagoNull)
				AddParameter(cmd, "CASO_PAGO", caso_pago);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects 
		/// by the <c>FK_RENDICION_COBRADOR_DET_REC</c> foreign key.
		/// </summary>
		/// <param name="recibo_id">The <c>RECIBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		public virtual RENDICION_COBRADOR_DETALLERow[] GetByRECIBO_ID(decimal recibo_id)
		{
			return MapRecords(CreateGetByRECIBO_IDCommand(recibo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RENDICION_COBRADOR_DET_REC</c> foreign key.
		/// </summary>
		/// <param name="recibo_id">The <c>RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRECIBO_IDAsDataTable(decimal recibo_id)
		{
			return MapRecordsToDataTable(CreateGetByRECIBO_IDCommand(recibo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_RENDICION_COBRADOR_DET_REC</c> foreign key.
		/// </summary>
		/// <param name="recibo_id">The <c>RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRECIBO_IDCommand(decimal recibo_id)
		{
			string whereSql = "";
			whereSql += "RECIBO_ID=" + _db.CreateSqlParameterName("RECIBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RECIBO_ID", recibo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects 
		/// by the <c>FK_RENDICION_COBRADOR_DET_REN</c> foreign key.
		/// </summary>
		/// <param name="rendicion_cobrador_id">The <c>RENDICION_COBRADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		public virtual RENDICION_COBRADOR_DETALLERow[] GetByRENDICION_COBRADOR_ID(decimal rendicion_cobrador_id)
		{
			return MapRecords(CreateGetByRENDICION_COBRADOR_IDCommand(rendicion_cobrador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RENDICION_COBRADOR_DET_REN</c> foreign key.
		/// </summary>
		/// <param name="rendicion_cobrador_id">The <c>RENDICION_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRENDICION_COBRADOR_IDAsDataTable(decimal rendicion_cobrador_id)
		{
			return MapRecordsToDataTable(CreateGetByRENDICION_COBRADOR_IDCommand(rendicion_cobrador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_RENDICION_COBRADOR_DET_REN</c> foreign key.
		/// </summary>
		/// <param name="rendicion_cobrador_id">The <c>RENDICION_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRENDICION_COBRADOR_IDCommand(decimal rendicion_cobrador_id)
		{
			string whereSql = "";
			whereSql += "RENDICION_COBRADOR_ID=" + _db.CreateSqlParameterName("RENDICION_COBRADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RENDICION_COBRADOR_ID", rendicion_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>RENDICION_COBRADOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RENDICION_COBRADOR_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(RENDICION_COBRADOR_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.RENDICION_COBRADOR_DETALLE (" +
				"ID, " +
				"RENDICION_COBRADOR_ID, " +
				"RECIBO_ID, " +
				"CASO_PAGO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("RENDICION_COBRADOR_ID") + ", " +
				_db.CreateSqlParameterName("RECIBO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_PAGO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "RENDICION_COBRADOR_ID", value.RENDICION_COBRADOR_ID);
			AddParameter(cmd, "RECIBO_ID", value.RECIBO_ID);
			AddParameter(cmd, "CASO_PAGO",
				value.IsCASO_PAGONull ? DBNull.Value : (object)value.CASO_PAGO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>RENDICION_COBRADOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RENDICION_COBRADOR_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(RENDICION_COBRADOR_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.RENDICION_COBRADOR_DETALLE SET " +
				"RENDICION_COBRADOR_ID=" + _db.CreateSqlParameterName("RENDICION_COBRADOR_ID") + ", " +
				"RECIBO_ID=" + _db.CreateSqlParameterName("RECIBO_ID") + ", " +
				"CASO_PAGO=" + _db.CreateSqlParameterName("CASO_PAGO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "RENDICION_COBRADOR_ID", value.RENDICION_COBRADOR_ID);
			AddParameter(cmd, "RECIBO_ID", value.RECIBO_ID);
			AddParameter(cmd, "CASO_PAGO",
				value.IsCASO_PAGONull ? DBNull.Value : (object)value.CASO_PAGO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>RENDICION_COBRADOR_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>RENDICION_COBRADOR_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>RENDICION_COBRADOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RENDICION_COBRADOR_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(RENDICION_COBRADOR_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>RENDICION_COBRADOR_DETALLE</c> table using
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
		/// Deletes records from the <c>RENDICION_COBRADOR_DETALLE</c> table using the 
		/// <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_PAGO(decimal caso_pago)
		{
			return DeleteByCASO_PAGO(caso_pago, false);
		}

		/// <summary>
		/// Deletes records from the <c>RENDICION_COBRADOR_DETALLE</c> table using the 
		/// <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <param name="caso_pagoNull">true if the method ignores the caso_pago
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_PAGO(decimal caso_pago, bool caso_pagoNull)
		{
			return CreateDeleteByCASO_PAGOCommand(caso_pago, caso_pagoNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_RENDICION_COBRADOR_DET_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_pago">The <c>CASO_PAGO</c> column value.</param>
		/// <param name="caso_pagoNull">true if the method ignores the caso_pago
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_PAGOCommand(decimal caso_pago, bool caso_pagoNull)
		{
			string whereSql = "";
			if(caso_pagoNull)
				whereSql += "CASO_PAGO IS NULL";
			else
				whereSql += "CASO_PAGO=" + _db.CreateSqlParameterName("CASO_PAGO");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_pagoNull)
				AddParameter(cmd, "CASO_PAGO", caso_pago);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>RENDICION_COBRADOR_DETALLE</c> table using the 
		/// <c>FK_RENDICION_COBRADOR_DET_REC</c> foreign key.
		/// </summary>
		/// <param name="recibo_id">The <c>RECIBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRECIBO_ID(decimal recibo_id)
		{
			return CreateDeleteByRECIBO_IDCommand(recibo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_RENDICION_COBRADOR_DET_REC</c> foreign key.
		/// </summary>
		/// <param name="recibo_id">The <c>RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRECIBO_IDCommand(decimal recibo_id)
		{
			string whereSql = "";
			whereSql += "RECIBO_ID=" + _db.CreateSqlParameterName("RECIBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "RECIBO_ID", recibo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>RENDICION_COBRADOR_DETALLE</c> table using the 
		/// <c>FK_RENDICION_COBRADOR_DET_REN</c> foreign key.
		/// </summary>
		/// <param name="rendicion_cobrador_id">The <c>RENDICION_COBRADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRENDICION_COBRADOR_ID(decimal rendicion_cobrador_id)
		{
			return CreateDeleteByRENDICION_COBRADOR_IDCommand(rendicion_cobrador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_RENDICION_COBRADOR_DET_REN</c> foreign key.
		/// </summary>
		/// <param name="rendicion_cobrador_id">The <c>RENDICION_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRENDICION_COBRADOR_IDCommand(decimal rendicion_cobrador_id)
		{
			string whereSql = "";
			whereSql += "RENDICION_COBRADOR_ID=" + _db.CreateSqlParameterName("RENDICION_COBRADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "RENDICION_COBRADOR_ID", rendicion_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>RENDICION_COBRADOR_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>RENDICION_COBRADOR_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.RENDICION_COBRADOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>RENDICION_COBRADOR_DETALLE</c> table.
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
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		protected RENDICION_COBRADOR_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		protected RENDICION_COBRADOR_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="RENDICION_COBRADOR_DETALLERow"/> objects.</returns>
		protected virtual RENDICION_COBRADOR_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int rendicion_cobrador_idColumnIndex = reader.GetOrdinal("RENDICION_COBRADOR_ID");
			int recibo_idColumnIndex = reader.GetOrdinal("RECIBO_ID");
			int caso_pagoColumnIndex = reader.GetOrdinal("CASO_PAGO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					RENDICION_COBRADOR_DETALLERow record = new RENDICION_COBRADOR_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.RENDICION_COBRADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rendicion_cobrador_idColumnIndex)), 9);
					record.RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_pagoColumnIndex))
						record.CASO_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(caso_pagoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (RENDICION_COBRADOR_DETALLERow[])(recordList.ToArray(typeof(RENDICION_COBRADOR_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="RENDICION_COBRADOR_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="RENDICION_COBRADOR_DETALLERow"/> object.</returns>
		protected virtual RENDICION_COBRADOR_DETALLERow MapRow(DataRow row)
		{
			RENDICION_COBRADOR_DETALLERow mappedObject = new RENDICION_COBRADOR_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "RENDICION_COBRADOR_ID"
			dataColumn = dataTable.Columns["RENDICION_COBRADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RENDICION_COBRADOR_ID = (decimal)row[dataColumn];
			// Column "RECIBO_ID"
			dataColumn = dataTable.Columns["RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_ID = (decimal)row[dataColumn];
			// Column "CASO_PAGO"
			dataColumn = dataTable.Columns["CASO_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_PAGO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>RENDICION_COBRADOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "RENDICION_COBRADOR_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RENDICION_COBRADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RECIBO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_PAGO", typeof(decimal));
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

				case "RENDICION_COBRADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of RENDICION_COBRADOR_DETALLECollection_Base class
}  // End of namespace
