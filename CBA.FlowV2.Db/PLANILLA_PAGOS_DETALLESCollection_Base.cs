// <fileinfo name="PLANILLA_PAGOS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_PAGOS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_PAGOS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_PAGOS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLANILLA_PAGO_IDColumnName = "PLANILLA_PAGO_ID";
		public const string CTACTE_PROVEEDOR_IDColumnName = "CTACTE_PROVEEDOR_ID";
		public const string OP_CASO_IDColumnName = "OP_CASO_ID";
		public const string MONTO_PAGARColumnName = "MONTO_PAGAR";
		public const string CTACTE_PROV_CASO_IDColumnName = "CTACTE_PROV_CASO_ID";
		public const string MONTO_BRUTOColumnName = "MONTO_BRUTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PAGOS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_PAGOS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_PAGOS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_PAGOS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_PAGOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_PAGOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_PAGOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_PAGOS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_PAGOS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		public PLANILLA_PAGOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_PAGOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_PAGOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANILLA_PAGOS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANILLA_PAGOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANILLA_PAGOS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANILLA_PAGOS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects 
		/// by the <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		public PLANILLA_PAGOS_DETALLESRow[] GetByOP_CASO_ID(decimal op_caso_id)
		{
			return GetByOP_CASO_ID(op_caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects 
		/// by the <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <param name="op_caso_idNull">true if the method ignores the op_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_PAGOS_DETALLESRow[] GetByOP_CASO_ID(decimal op_caso_id, bool op_caso_idNull)
		{
			return MapRecords(CreateGetByOP_CASO_IDCommand(op_caso_id, op_caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByOP_CASO_IDAsDataTable(decimal op_caso_id)
		{
			return GetByOP_CASO_IDAsDataTable(op_caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <param name="op_caso_idNull">true if the method ignores the op_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByOP_CASO_IDAsDataTable(decimal op_caso_id, bool op_caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByOP_CASO_IDCommand(op_caso_id, op_caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <param name="op_caso_idNull">true if the method ignores the op_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByOP_CASO_IDCommand(decimal op_caso_id, bool op_caso_idNull)
		{
			string whereSql = "";
			if(op_caso_idNull)
				whereSql += "OP_CASO_ID IS NULL";
			else
				whereSql += "OP_CASO_ID=" + _db.CreateSqlParameterName("OP_CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!op_caso_idNull)
				AddParameter(cmd, "OP_CASO_ID", op_caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects 
		/// by the <c>FK_PLANILLA_PAGO_DET_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_PAGOS_DETALLESRow[] GetByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id)
		{
			return MapRecords(CreateGetByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_PAGO_DET_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROVEEDOR_IDAsDataTable(decimal ctacte_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_PAGO_DET_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROVEEDOR_IDCommand(decimal ctacte_proveedor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID", ctacte_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects 
		/// by the <c>FK_PLANILLA_PAGO_DET_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_pago_id">The <c>PLANILLA_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_PAGOS_DETALLESRow[] GetByPLANILLA_PAGO_ID(decimal planilla_pago_id)
		{
			return MapRecords(CreateGetByPLANILLA_PAGO_IDCommand(planilla_pago_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_PAGO_DET_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_pago_id">The <c>PLANILLA_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLANILLA_PAGO_IDAsDataTable(decimal planilla_pago_id)
		{
			return MapRecordsToDataTable(CreateGetByPLANILLA_PAGO_IDCommand(planilla_pago_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_PAGO_DET_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_pago_id">The <c>PLANILLA_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLANILLA_PAGO_IDCommand(decimal planilla_pago_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_PAGO_ID=" + _db.CreateSqlParameterName("PLANILLA_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PLANILLA_PAGO_ID", planilla_pago_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PLANILLA_PAGOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_PAGOS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(PLANILLA_PAGOS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANILLA_PAGOS_DETALLES (" +
				"ID, " +
				"PLANILLA_PAGO_ID, " +
				"CTACTE_PROVEEDOR_ID, " +
				"OP_CASO_ID, " +
				"MONTO_PAGAR, " +
				"CTACTE_PROV_CASO_ID, " +
				"MONTO_BRUTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PLANILLA_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("OP_CASO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_PAGAR") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROV_CASO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_BRUTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PLANILLA_PAGO_ID", value.PLANILLA_PAGO_ID);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID", value.CTACTE_PROVEEDOR_ID);
			AddParameter(cmd, "OP_CASO_ID",
				value.IsOP_CASO_IDNull ? DBNull.Value : (object)value.OP_CASO_ID);
			AddParameter(cmd, "MONTO_PAGAR",
				value.IsMONTO_PAGARNull ? DBNull.Value : (object)value.MONTO_PAGAR);
			AddParameter(cmd, "CTACTE_PROV_CASO_ID",
				value.IsCTACTE_PROV_CASO_IDNull ? DBNull.Value : (object)value.CTACTE_PROV_CASO_ID);
			AddParameter(cmd, "MONTO_BRUTO",
				value.IsMONTO_BRUTONull ? DBNull.Value : (object)value.MONTO_BRUTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANILLA_PAGOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_PAGOS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANILLA_PAGOS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANILLA_PAGOS_DETALLES SET " +
				"PLANILLA_PAGO_ID=" + _db.CreateSqlParameterName("PLANILLA_PAGO_ID") + ", " +
				"CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID") + ", " +
				"OP_CASO_ID=" + _db.CreateSqlParameterName("OP_CASO_ID") + ", " +
				"MONTO_PAGAR=" + _db.CreateSqlParameterName("MONTO_PAGAR") + ", " +
				"CTACTE_PROV_CASO_ID=" + _db.CreateSqlParameterName("CTACTE_PROV_CASO_ID") + ", " +
				"MONTO_BRUTO=" + _db.CreateSqlParameterName("MONTO_BRUTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PLANILLA_PAGO_ID", value.PLANILLA_PAGO_ID);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID", value.CTACTE_PROVEEDOR_ID);
			AddParameter(cmd, "OP_CASO_ID",
				value.IsOP_CASO_IDNull ? DBNull.Value : (object)value.OP_CASO_ID);
			AddParameter(cmd, "MONTO_PAGAR",
				value.IsMONTO_PAGARNull ? DBNull.Value : (object)value.MONTO_PAGAR);
			AddParameter(cmd, "CTACTE_PROV_CASO_ID",
				value.IsCTACTE_PROV_CASO_IDNull ? DBNull.Value : (object)value.CTACTE_PROV_CASO_ID);
			AddParameter(cmd, "MONTO_BRUTO",
				value.IsMONTO_BRUTONull ? DBNull.Value : (object)value.MONTO_BRUTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANILLA_PAGOS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANILLA_PAGOS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANILLA_PAGOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_PAGOS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANILLA_PAGOS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANILLA_PAGOS_DETALLES</c> table using
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
		/// Deletes records from the <c>PLANILLA_PAGOS_DETALLES</c> table using the 
		/// <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOP_CASO_ID(decimal op_caso_id)
		{
			return DeleteByOP_CASO_ID(op_caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_PAGOS_DETALLES</c> table using the 
		/// <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <param name="op_caso_idNull">true if the method ignores the op_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOP_CASO_ID(decimal op_caso_id, bool op_caso_idNull)
		{
			return CreateDeleteByOP_CASO_IDCommand(op_caso_id, op_caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_PAGO_DET_CASO_OP</c> foreign key.
		/// </summary>
		/// <param name="op_caso_id">The <c>OP_CASO_ID</c> column value.</param>
		/// <param name="op_caso_idNull">true if the method ignores the op_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByOP_CASO_IDCommand(decimal op_caso_id, bool op_caso_idNull)
		{
			string whereSql = "";
			if(op_caso_idNull)
				whereSql += "OP_CASO_ID IS NULL";
			else
				whereSql += "OP_CASO_ID=" + _db.CreateSqlParameterName("OP_CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!op_caso_idNull)
				AddParameter(cmd, "OP_CASO_ID", op_caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_PAGOS_DETALLES</c> table using the 
		/// <c>FK_PLANILLA_PAGO_DET_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id)
		{
			return CreateDeleteByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_PAGO_DET_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROVEEDOR_IDCommand(decimal ctacte_proveedor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID", ctacte_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_PAGOS_DETALLES</c> table using the 
		/// <c>FK_PLANILLA_PAGO_DET_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_pago_id">The <c>PLANILLA_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_PAGO_ID(decimal planilla_pago_id)
		{
			return CreateDeleteByPLANILLA_PAGO_IDCommand(planilla_pago_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_PAGO_DET_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_pago_id">The <c>PLANILLA_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLANILLA_PAGO_IDCommand(decimal planilla_pago_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_PAGO_ID=" + _db.CreateSqlParameterName("PLANILLA_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PLANILLA_PAGO_ID", planilla_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PLANILLA_PAGOS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>PLANILLA_PAGOS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANILLA_PAGOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANILLA_PAGOS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		protected PLANILLA_PAGOS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		protected PLANILLA_PAGOS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_PAGOS_DETALLESRow"/> objects.</returns>
		protected virtual PLANILLA_PAGOS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int planilla_pago_idColumnIndex = reader.GetOrdinal("PLANILLA_PAGO_ID");
			int ctacte_proveedor_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_ID");
			int op_caso_idColumnIndex = reader.GetOrdinal("OP_CASO_ID");
			int monto_pagarColumnIndex = reader.GetOrdinal("MONTO_PAGAR");
			int ctacte_prov_caso_idColumnIndex = reader.GetOrdinal("CTACTE_PROV_CASO_ID");
			int monto_brutoColumnIndex = reader.GetOrdinal("MONTO_BRUTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_PAGOS_DETALLESRow record = new PLANILLA_PAGOS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLANILLA_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_pago_idColumnIndex)), 9);
					record.CTACTE_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(op_caso_idColumnIndex))
						record.OP_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(op_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_pagarColumnIndex))
						record.MONTO_PAGAR = Math.Round(Convert.ToDecimal(reader.GetValue(monto_pagarColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_prov_caso_idColumnIndex))
						record.CTACTE_PROV_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_prov_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_brutoColumnIndex))
						record.MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_brutoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_PAGOS_DETALLESRow[])(recordList.ToArray(typeof(PLANILLA_PAGOS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_PAGOS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_PAGOS_DETALLESRow"/> object.</returns>
		protected virtual PLANILLA_PAGOS_DETALLESRow MapRow(DataRow row)
		{
			PLANILLA_PAGOS_DETALLESRow mappedObject = new PLANILLA_PAGOS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLANILLA_PAGO_ID"
			dataColumn = dataTable.Columns["PLANILLA_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "OP_CASO_ID"
			dataColumn = dataTable.Columns["OP_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.OP_CASO_ID = (decimal)row[dataColumn];
			// Column "MONTO_PAGAR"
			dataColumn = dataTable.Columns["MONTO_PAGAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PAGAR = (decimal)row[dataColumn];
			// Column "CTACTE_PROV_CASO_ID"
			dataColumn = dataTable.Columns["CTACTE_PROV_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROV_CASO_ID = (decimal)row[dataColumn];
			// Column "MONTO_BRUTO"
			dataColumn = dataTable.Columns["MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_PAGOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_PAGOS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLANILLA_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OP_CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_PAGAR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PROV_CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO", typeof(decimal));
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

				case "PLANILLA_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OP_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PAGAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROV_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_PAGOS_DETALLESCollection_Base class
}  // End of namespace
