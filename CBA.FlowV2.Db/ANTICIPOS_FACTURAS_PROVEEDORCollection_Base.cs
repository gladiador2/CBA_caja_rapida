// <fileinfo name="ANTICIPOS_FACTURAS_PROVEEDORCollection_Base.cs">
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
	/// The base class for <see cref="ANTICIPOS_FACTURAS_PROVEEDORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ANTICIPOS_FACTURAS_PROVEEDORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ANTICIPOS_FACTURAS_PROVEEDORCollection_Base
	{
		// Constants
		public const string ANTICIPO_PROVEEDOR_IDColumnName = "ANTICIPO_PROVEEDOR_ID";
		public const string FACTURA_PROVEEDOR_IDColumnName = "FACTURA_PROVEEDOR_ID";
		public const string FECHAColumnName = "FECHA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ANTICIPOS_FACTURAS_PROVEEDORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ANTICIPOS_FACTURAS_PROVEEDORCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual ANTICIPOS_FACTURAS_PROVEEDORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ANTICIPOS_FACTURAS_PROVEEDORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ANTICIPOS_FACTURAS_PROVEEDORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		public ANTICIPOS_FACTURAS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects that 
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
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual ANTICIPOS_FACTURAS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ANTICIPOS_FACTURAS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> by the primary key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="factura_proveedor_id">The <c>FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An instance of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ANTICIPOS_FACTURAS_PROVEEDORRow GetByPrimaryKey(decimal anticipo_proveedor_id, decimal factura_proveedor_id)
		{
			string whereSql = "ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID") + " AND " +
							  "FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURA_PROVEEDOR_ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", anticipo_proveedor_id);
			AddParameter(cmd, "FACTURA_PROVEEDOR_ID", factura_proveedor_id);
			ANTICIPOS_FACTURAS_PROVEEDORRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_ANTICIPOS_FAC_PROV_ANTICIPO</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual ANTICIPOS_FACTURAS_PROVEEDORRow[] GetByANTICIPO_PROVEEDOR_ID(decimal anticipo_proveedor_id)
		{
			return MapRecords(CreateGetByANTICIPO_PROVEEDOR_IDCommand(anticipo_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_FAC_PROV_ANTICIPO</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByANTICIPO_PROVEEDOR_IDAsDataTable(decimal anticipo_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByANTICIPO_PROVEEDOR_IDCommand(anticipo_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_FAC_PROV_ANTICIPO</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByANTICIPO_PROVEEDOR_IDCommand(decimal anticipo_proveedor_id)
		{
			string whereSql = "";
			whereSql += "ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", anticipo_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_ANTICIPOS_FAC_PROV_PROV</c> foreign key.
		/// </summary>
		/// <param name="factura_proveedor_id">The <c>FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual ANTICIPOS_FACTURAS_PROVEEDORRow[] GetByFACTURA_PROVEEDOR_ID(decimal factura_proveedor_id)
		{
			return MapRecords(CreateGetByFACTURA_PROVEEDOR_IDCommand(factura_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_FAC_PROV_PROV</c> foreign key.
		/// </summary>
		/// <param name="factura_proveedor_id">The <c>FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFACTURA_PROVEEDOR_IDAsDataTable(decimal factura_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByFACTURA_PROVEEDOR_IDCommand(factura_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_FAC_PROV_PROV</c> foreign key.
		/// </summary>
		/// <param name="factura_proveedor_id">The <c>FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFACTURA_PROVEEDOR_IDCommand(decimal factura_proveedor_id)
		{
			string whereSql = "";
			whereSql += "FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURA_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FACTURA_PROVEEDOR_ID", factura_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> object to be inserted.</param>
		public virtual void Insert(ANTICIPOS_FACTURAS_PROVEEDORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ANTICIPOS_FACTURAS_PROVEEDOR (" +
				"ANTICIPO_PROVEEDOR_ID, " +
				"FACTURA_PROVEEDOR_ID, " +
				"FECHA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("FACTURA_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", value.ANTICIPO_PROVEEDOR_ID);
			AddParameter(cmd, "FACTURA_PROVEEDOR_ID", value.FACTURA_PROVEEDOR_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ANTICIPOS_FACTURAS_PROVEEDORRow value)
		{
			
			string sqlStr = "UPDATE TRC.ANTICIPOS_FACTURAS_PROVEEDOR SET " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") +
				" WHERE " +
				"ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID") + " AND " +
				"FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURA_PROVEEDOR_ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", value.ANTICIPO_PROVEEDOR_ID);
			AddParameter(cmd, "FACTURA_PROVEEDOR_ID", value.FACTURA_PROVEEDOR_ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
							DeleteByPrimaryKey((decimal)row["ANTICIPO_PROVEEDOR_ID"], (decimal)row["FACTURA_PROVEEDOR_ID"]);
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
		/// Deletes the specified object from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ANTICIPOS_FACTURAS_PROVEEDORRow value)
		{
			return DeleteByPrimaryKey(value.ANTICIPO_PROVEEDOR_ID, value.FACTURA_PROVEEDOR_ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="factura_proveedor_id">The <c>FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal anticipo_proveedor_id, decimal factura_proveedor_id)
		{
			string whereSql = "ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID") + " AND " +
							  "FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURA_PROVEEDOR_ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", anticipo_proveedor_id);
			AddParameter(cmd, "FACTURA_PROVEEDOR_ID", factura_proveedor_id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_ANTICIPOS_FAC_PROV_ANTICIPO</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_PROVEEDOR_ID(decimal anticipo_proveedor_id)
		{
			return CreateDeleteByANTICIPO_PROVEEDOR_IDCommand(anticipo_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_FAC_PROV_ANTICIPO</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByANTICIPO_PROVEEDOR_IDCommand(decimal anticipo_proveedor_id)
		{
			string whereSql = "";
			whereSql += "ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", anticipo_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_ANTICIPOS_FAC_PROV_PROV</c> foreign key.
		/// </summary>
		/// <param name="factura_proveedor_id">The <c>FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_PROVEEDOR_ID(decimal factura_proveedor_id)
		{
			return CreateDeleteByFACTURA_PROVEEDOR_IDCommand(factura_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_FAC_PROV_PROV</c> foreign key.
		/// </summary>
		/// <param name="factura_proveedor_id">The <c>FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFACTURA_PROVEEDOR_IDCommand(decimal factura_proveedor_id)
		{
			string whereSql = "";
			whereSql += "FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FACTURA_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FACTURA_PROVEEDOR_ID", factura_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> records that match the specified criteria.
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
		/// to delete <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ANTICIPOS_FACTURAS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
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
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		protected ANTICIPOS_FACTURAS_PROVEEDORRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		protected ANTICIPOS_FACTURAS_PROVEEDORRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> objects.</returns>
		protected virtual ANTICIPOS_FACTURAS_PROVEEDORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int anticipo_proveedor_idColumnIndex = reader.GetOrdinal("ANTICIPO_PROVEEDOR_ID");
			int factura_proveedor_idColumnIndex = reader.GetOrdinal("FACTURA_PROVEEDOR_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ANTICIPOS_FACTURAS_PROVEEDORRow record = new ANTICIPOS_FACTURAS_PROVEEDORRow();
					recordList.Add(record);

					record.ANTICIPO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_proveedor_idColumnIndex)), 9);
					record.FACTURA_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ANTICIPOS_FACTURAS_PROVEEDORRow[])(recordList.ToArray(typeof(ANTICIPOS_FACTURAS_PROVEEDORRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ANTICIPOS_FACTURAS_PROVEEDORRow"/> object.</returns>
		protected virtual ANTICIPOS_FACTURAS_PROVEEDORRow MapRow(DataRow row)
		{
			ANTICIPOS_FACTURAS_PROVEEDORRow mappedObject = new ANTICIPOS_FACTURAS_PROVEEDORRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ANTICIPO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "FACTURA_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["FACTURA_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ANTICIPOS_FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ANTICIPOS_FACTURAS_PROVEEDOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ANTICIPO_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURA_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
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
				case "ANTICIPO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ANTICIPOS_FACTURAS_PROVEEDORCollection_Base class
}  // End of namespace
