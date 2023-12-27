// <fileinfo name="CTACTE_CONDICIONES_DESEMBOLSOCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CONDICIONES_DESEMBOLSOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CONDICIONES_DESEMBOLSOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CONDICIONES_DESEMBOLSOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string CANTIDAD_CUOTASColumnName = "CANTIDAD_CUOTAS";
		public const string FECHA_DESEMBOLSO_1ColumnName = "FECHA_DESEMBOLSO_1";
		public const string FECHA_DESEMBOLSO_2ColumnName = "FECHA_DESEMBOLSO_2";
		public const string FECHA_DESEMBOLSO_3ColumnName = "FECHA_DESEMBOLSO_3";
		public const string FECHA_DESEMBOLSO_4ColumnName = "FECHA_DESEMBOLSO_4";
		public const string FECHA_DESEMBOLSO_5ColumnName = "FECHA_DESEMBOLSO_5";
		public const string FECHA_DESEMBOLSO_6ColumnName = "FECHA_DESEMBOLSO_6";
		public const string FECHA_DESEMBOLSO_7ColumnName = "FECHA_DESEMBOLSO_7";
		public const string FECHA_DESEMBOLSO_8ColumnName = "FECHA_DESEMBOLSO_8";
		public const string FECHA_DESEMBOLSO_9ColumnName = "FECHA_DESEMBOLSO_9";
		public const string FECHA_DESEMBOLSO_10ColumnName = "FECHA_DESEMBOLSO_10";
		public const string FECHA_DESEMBOLSO_11ColumnName = "FECHA_DESEMBOLSO_11";
		public const string FECHA_DESEMBOLSO_12ColumnName = "FECHA_DESEMBOLSO_12";
		public const string ESTADOColumnName = "ESTADO";
		public const string TIPO_CALCULOColumnName = "TIPO_CALCULO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CONDICIONES_DESEMBOLSOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CONDICIONES_DESEMBOLSOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects.</returns>
		public virtual CTACTE_CONDICIONES_DESEMBOLSORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CONDICIONES_DESEMBOLSORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CONDICIONES_DESEMBOLSORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects.</returns>
		public CTACTE_CONDICIONES_DESEMBOLSORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects.</returns>
		public virtual CTACTE_CONDICIONES_DESEMBOLSORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CONDICIONES_DESEMBOLSO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CONDICIONES_DESEMBOLSORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CONDICIONES_DESEMBOLSORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CONDICIONES_DESEMBOLSORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CONDICIONES_DESEMBOLSO (" +
				"ID, " +
				"NOMBRE, " +
				"DESCRIPCION, " +
				"CANTIDAD_CUOTAS, " +
				"FECHA_DESEMBOLSO_1, " +
				"FECHA_DESEMBOLSO_2, " +
				"FECHA_DESEMBOLSO_3, " +
				"FECHA_DESEMBOLSO_4, " +
				"FECHA_DESEMBOLSO_5, " +
				"FECHA_DESEMBOLSO_6, " +
				"FECHA_DESEMBOLSO_7, " +
				"FECHA_DESEMBOLSO_8, " +
				"FECHA_DESEMBOLSO_9, " +
				"FECHA_DESEMBOLSO_10, " +
				"FECHA_DESEMBOLSO_11, " +
				"FECHA_DESEMBOLSO_12, " +
				"ESTADO, " +
				"TIPO_CALCULO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_1") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_2") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_3") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_4") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_5") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_6") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_7") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_8") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_9") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_10") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_11") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO_12") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("TIPO_CALCULO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "FECHA_DESEMBOLSO_1",
				value.IsFECHA_DESEMBOLSO_1Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_1);
			AddParameter(cmd, "FECHA_DESEMBOLSO_2",
				value.IsFECHA_DESEMBOLSO_2Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_2);
			AddParameter(cmd, "FECHA_DESEMBOLSO_3",
				value.IsFECHA_DESEMBOLSO_3Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_3);
			AddParameter(cmd, "FECHA_DESEMBOLSO_4",
				value.IsFECHA_DESEMBOLSO_4Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_4);
			AddParameter(cmd, "FECHA_DESEMBOLSO_5",
				value.IsFECHA_DESEMBOLSO_5Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_5);
			AddParameter(cmd, "FECHA_DESEMBOLSO_6",
				value.IsFECHA_DESEMBOLSO_6Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_6);
			AddParameter(cmd, "FECHA_DESEMBOLSO_7",
				value.IsFECHA_DESEMBOLSO_7Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_7);
			AddParameter(cmd, "FECHA_DESEMBOLSO_8",
				value.IsFECHA_DESEMBOLSO_8Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_8);
			AddParameter(cmd, "FECHA_DESEMBOLSO_9",
				value.IsFECHA_DESEMBOLSO_9Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_9);
			AddParameter(cmd, "FECHA_DESEMBOLSO_10",
				value.IsFECHA_DESEMBOLSO_10Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_10);
			AddParameter(cmd, "FECHA_DESEMBOLSO_11",
				value.IsFECHA_DESEMBOLSO_11Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_11);
			AddParameter(cmd, "FECHA_DESEMBOLSO_12",
				value.IsFECHA_DESEMBOLSO_12Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_12);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_CALCULO", value.TIPO_CALCULO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CONDICIONES_DESEMBOLSORow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CONDICIONES_DESEMBOLSO SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"CANTIDAD_CUOTAS=" + _db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				"FECHA_DESEMBOLSO_1=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_1") + ", " +
				"FECHA_DESEMBOLSO_2=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_2") + ", " +
				"FECHA_DESEMBOLSO_3=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_3") + ", " +
				"FECHA_DESEMBOLSO_4=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_4") + ", " +
				"FECHA_DESEMBOLSO_5=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_5") + ", " +
				"FECHA_DESEMBOLSO_6=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_6") + ", " +
				"FECHA_DESEMBOLSO_7=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_7") + ", " +
				"FECHA_DESEMBOLSO_8=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_8") + ", " +
				"FECHA_DESEMBOLSO_9=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_9") + ", " +
				"FECHA_DESEMBOLSO_10=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_10") + ", " +
				"FECHA_DESEMBOLSO_11=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_11") + ", " +
				"FECHA_DESEMBOLSO_12=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO_12") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"TIPO_CALCULO=" + _db.CreateSqlParameterName("TIPO_CALCULO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "FECHA_DESEMBOLSO_1",
				value.IsFECHA_DESEMBOLSO_1Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_1);
			AddParameter(cmd, "FECHA_DESEMBOLSO_2",
				value.IsFECHA_DESEMBOLSO_2Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_2);
			AddParameter(cmd, "FECHA_DESEMBOLSO_3",
				value.IsFECHA_DESEMBOLSO_3Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_3);
			AddParameter(cmd, "FECHA_DESEMBOLSO_4",
				value.IsFECHA_DESEMBOLSO_4Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_4);
			AddParameter(cmd, "FECHA_DESEMBOLSO_5",
				value.IsFECHA_DESEMBOLSO_5Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_5);
			AddParameter(cmd, "FECHA_DESEMBOLSO_6",
				value.IsFECHA_DESEMBOLSO_6Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_6);
			AddParameter(cmd, "FECHA_DESEMBOLSO_7",
				value.IsFECHA_DESEMBOLSO_7Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_7);
			AddParameter(cmd, "FECHA_DESEMBOLSO_8",
				value.IsFECHA_DESEMBOLSO_8Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_8);
			AddParameter(cmd, "FECHA_DESEMBOLSO_9",
				value.IsFECHA_DESEMBOLSO_9Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_9);
			AddParameter(cmd, "FECHA_DESEMBOLSO_10",
				value.IsFECHA_DESEMBOLSO_10Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_10);
			AddParameter(cmd, "FECHA_DESEMBOLSO_11",
				value.IsFECHA_DESEMBOLSO_11Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_11);
			AddParameter(cmd, "FECHA_DESEMBOLSO_12",
				value.IsFECHA_DESEMBOLSO_12Null ? DBNull.Value : (object)value.FECHA_DESEMBOLSO_12);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO_CALCULO", value.TIPO_CALCULO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CONDICIONES_DESEMBOLSORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table using
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
		/// Deletes <c>CTACTE_CONDICIONES_DESEMBOLSO</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CONDICIONES_DESEMBOLSO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CONDICIONES_DESEMBOLSO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects.</returns>
		protected CTACTE_CONDICIONES_DESEMBOLSORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects.</returns>
		protected CTACTE_CONDICIONES_DESEMBOLSORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> objects.</returns>
		protected virtual CTACTE_CONDICIONES_DESEMBOLSORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int cantidad_cuotasColumnIndex = reader.GetOrdinal("CANTIDAD_CUOTAS");
			int fecha_desembolso_1ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_1");
			int fecha_desembolso_2ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_2");
			int fecha_desembolso_3ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_3");
			int fecha_desembolso_4ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_4");
			int fecha_desembolso_5ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_5");
			int fecha_desembolso_6ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_6");
			int fecha_desembolso_7ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_7");
			int fecha_desembolso_8ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_8");
			int fecha_desembolso_9ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_9");
			int fecha_desembolso_10ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_10");
			int fecha_desembolso_11ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_11");
			int fecha_desembolso_12ColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO_12");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tipo_calculoColumnIndex = reader.GetOrdinal("TIPO_CALCULO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CONDICIONES_DESEMBOLSORow record = new CTACTE_CONDICIONES_DESEMBOLSORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.CANTIDAD_CUOTAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cuotasColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_1ColumnIndex))
						record.FECHA_DESEMBOLSO_1 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_1ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_2ColumnIndex))
						record.FECHA_DESEMBOLSO_2 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_2ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_3ColumnIndex))
						record.FECHA_DESEMBOLSO_3 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_3ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_4ColumnIndex))
						record.FECHA_DESEMBOLSO_4 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_4ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_5ColumnIndex))
						record.FECHA_DESEMBOLSO_5 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_5ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_6ColumnIndex))
						record.FECHA_DESEMBOLSO_6 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_6ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_7ColumnIndex))
						record.FECHA_DESEMBOLSO_7 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_7ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_8ColumnIndex))
						record.FECHA_DESEMBOLSO_8 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_8ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_9ColumnIndex))
						record.FECHA_DESEMBOLSO_9 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_9ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_10ColumnIndex))
						record.FECHA_DESEMBOLSO_10 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_10ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_11ColumnIndex))
						record.FECHA_DESEMBOLSO_11 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_11ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desembolso_12ColumnIndex))
						record.FECHA_DESEMBOLSO_12 = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_desembolso_12ColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.TIPO_CALCULO = Convert.ToString(reader.GetValue(tipo_calculoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CONDICIONES_DESEMBOLSORow[])(recordList.ToArray(typeof(CTACTE_CONDICIONES_DESEMBOLSORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CONDICIONES_DESEMBOLSORow"/> object.</returns>
		protected virtual CTACTE_CONDICIONES_DESEMBOLSORow MapRow(DataRow row)
		{
			CTACTE_CONDICIONES_DESEMBOLSORow mappedObject = new CTACTE_CONDICIONES_DESEMBOLSORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "CANTIDAD_CUOTAS"
			dataColumn = dataTable.Columns["CANTIDAD_CUOTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CUOTAS = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_1"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_1 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_2"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_2 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_3"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_3"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_3 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_4"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_4"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_4 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_5"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_5"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_5 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_6"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_6"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_6 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_7"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_7"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_7 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_8"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_8"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_8 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_9"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_9"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_9 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_10"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_10"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_10 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_11"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_11"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_11 = (decimal)row[dataColumn];
			// Column "FECHA_DESEMBOLSO_12"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO_12"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO_12 = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TIPO_CALCULO"
			dataColumn = dataTable.Columns["TIPO_CALCULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CALCULO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CONDICIONES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CONDICIONES_DESEMBOLSO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CUOTAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_3", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_4", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_5", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_6", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_7", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_8", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_9", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_10", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_11", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO_12", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_CALCULO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CUOTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_3":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_4":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_5":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_6":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_7":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_8":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_9":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_10":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_11":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESEMBOLSO_12":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_CALCULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CONDICIONES_DESEMBOLSOCollection_Base class
}  // End of namespace
