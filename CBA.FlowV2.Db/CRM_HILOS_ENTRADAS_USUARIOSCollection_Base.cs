// <fileinfo name="CRM_HILOS_ENTRADAS_USUARIOSCollection_Base.cs">
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
	/// The base class for <see cref="CRM_HILOS_ENTRADAS_USUARIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CRM_HILOS_ENTRADAS_USUARIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CRM_HILOS_ENTRADAS_USUARIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CRM_HILOS_ENTRADA_IDColumnName = "CRM_HILOS_ENTRADA_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FECHA_LECTURAColumnName = "FECHA_LECTURA";
		public const string FECHA_RECORDATORIOColumnName = "FECHA_RECORDATORIO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CRM_HILOS_ENTRADAS_USUARIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CRM_HILOS_ENTRADAS_USUARIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		public virtual CRM_HILOS_ENTRADAS_USUARIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CRM_HILOS_ENTRADAS_USUARIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CRM_HILOS_ENTRADAS_USUARIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		public CRM_HILOS_ENTRADAS_USUARIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		public virtual CRM_HILOS_ENTRADAS_USUARIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CRM_HILOS_ENTRADAS_USUARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CRM_HILOS_ENTRADAS_USUARIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CRM_HILOS_ENTRADAS_USUARIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects 
		/// by the <c>FK_CRM_HILOS_ENTR_USR_HILO_ENT</c> foreign key.
		/// </summary>
		/// <param name="crm_hilos_entrada_id">The <c>CRM_HILOS_ENTRADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		public virtual CRM_HILOS_ENTRADAS_USUARIOSRow[] GetByCRM_HILOS_ENTRADA_ID(decimal crm_hilos_entrada_id)
		{
			return MapRecords(CreateGetByCRM_HILOS_ENTRADA_IDCommand(crm_hilos_entrada_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CRM_HILOS_ENTR_USR_HILO_ENT</c> foreign key.
		/// </summary>
		/// <param name="crm_hilos_entrada_id">The <c>CRM_HILOS_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCRM_HILOS_ENTRADA_IDAsDataTable(decimal crm_hilos_entrada_id)
		{
			return MapRecordsToDataTable(CreateGetByCRM_HILOS_ENTRADA_IDCommand(crm_hilos_entrada_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CRM_HILOS_ENTR_USR_HILO_ENT</c> foreign key.
		/// </summary>
		/// <param name="crm_hilos_entrada_id">The <c>CRM_HILOS_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCRM_HILOS_ENTRADA_IDCommand(decimal crm_hilos_entrada_id)
		{
			string whereSql = "";
			whereSql += "CRM_HILOS_ENTRADA_ID=" + _db.CreateSqlParameterName("CRM_HILOS_ENTRADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CRM_HILOS_ENTRADA_ID", crm_hilos_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects 
		/// by the <c>FK_CRM_HILOS_ENTR_USR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		public virtual CRM_HILOS_ENTRADAS_USUARIOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CRM_HILOS_ENTR_USR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CRM_HILOS_ENTR_USR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> object to be inserted.</param>
		public virtual void Insert(CRM_HILOS_ENTRADAS_USUARIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CRM_HILOS_ENTRADAS_USUARIOS (" +
				"ID, " +
				"CRM_HILOS_ENTRADA_ID, " +
				"USUARIO_ID, " +
				"FECHA_LECTURA, " +
				"FECHA_RECORDATORIO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CRM_HILOS_ENTRADA_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_LECTURA") + ", " +
				_db.CreateSqlParameterName("FECHA_RECORDATORIO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CRM_HILOS_ENTRADA_ID", value.CRM_HILOS_ENTRADA_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA_LECTURA",
				value.IsFECHA_LECTURANull ? DBNull.Value : (object)value.FECHA_LECTURA);
			AddParameter(cmd, "FECHA_RECORDATORIO",
				value.IsFECHA_RECORDATORIONull ? DBNull.Value : (object)value.FECHA_RECORDATORIO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CRM_HILOS_ENTRADAS_USUARIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CRM_HILOS_ENTRADAS_USUARIOS SET " +
				"CRM_HILOS_ENTRADA_ID=" + _db.CreateSqlParameterName("CRM_HILOS_ENTRADA_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"FECHA_LECTURA=" + _db.CreateSqlParameterName("FECHA_LECTURA") + ", " +
				"FECHA_RECORDATORIO=" + _db.CreateSqlParameterName("FECHA_RECORDATORIO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CRM_HILOS_ENTRADA_ID", value.CRM_HILOS_ENTRADA_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA_LECTURA",
				value.IsFECHA_LECTURANull ? DBNull.Value : (object)value.FECHA_LECTURA);
			AddParameter(cmd, "FECHA_RECORDATORIO",
				value.IsFECHA_RECORDATORIONull ? DBNull.Value : (object)value.FECHA_RECORDATORIO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CRM_HILOS_ENTRADAS_USUARIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table using
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
		/// Deletes records from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table using the 
		/// <c>FK_CRM_HILOS_ENTR_USR_HILO_ENT</c> foreign key.
		/// </summary>
		/// <param name="crm_hilos_entrada_id">The <c>CRM_HILOS_ENTRADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCRM_HILOS_ENTRADA_ID(decimal crm_hilos_entrada_id)
		{
			return CreateDeleteByCRM_HILOS_ENTRADA_IDCommand(crm_hilos_entrada_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CRM_HILOS_ENTR_USR_HILO_ENT</c> foreign key.
		/// </summary>
		/// <param name="crm_hilos_entrada_id">The <c>CRM_HILOS_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCRM_HILOS_ENTRADA_IDCommand(decimal crm_hilos_entrada_id)
		{
			string whereSql = "";
			whereSql += "CRM_HILOS_ENTRADA_ID=" + _db.CreateSqlParameterName("CRM_HILOS_ENTRADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CRM_HILOS_ENTRADA_ID", crm_hilos_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table using the 
		/// <c>FK_CRM_HILOS_ENTR_USR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CRM_HILOS_ENTR_USR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CRM_HILOS_ENTRADAS_USUARIOS</c> records that match the specified criteria.
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
		/// to delete <c>CRM_HILOS_ENTRADAS_USUARIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CRM_HILOS_ENTRADAS_USUARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
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
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		protected CRM_HILOS_ENTRADAS_USUARIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		protected CRM_HILOS_ENTRADAS_USUARIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> objects.</returns>
		protected virtual CRM_HILOS_ENTRADAS_USUARIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int crm_hilos_entrada_idColumnIndex = reader.GetOrdinal("CRM_HILOS_ENTRADA_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int fecha_lecturaColumnIndex = reader.GetOrdinal("FECHA_LECTURA");
			int fecha_recordatorioColumnIndex = reader.GetOrdinal("FECHA_RECORDATORIO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CRM_HILOS_ENTRADAS_USUARIOSRow record = new CRM_HILOS_ENTRADAS_USUARIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CRM_HILOS_ENTRADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(crm_hilos_entrada_idColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_lecturaColumnIndex))
						record.FECHA_LECTURA = Convert.ToDateTime(reader.GetValue(fecha_lecturaColumnIndex));
					if(!reader.IsDBNull(fecha_recordatorioColumnIndex))
						record.FECHA_RECORDATORIO = Convert.ToDateTime(reader.GetValue(fecha_recordatorioColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CRM_HILOS_ENTRADAS_USUARIOSRow[])(recordList.ToArray(typeof(CRM_HILOS_ENTRADAS_USUARIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CRM_HILOS_ENTRADAS_USUARIOSRow"/> object.</returns>
		protected virtual CRM_HILOS_ENTRADAS_USUARIOSRow MapRow(DataRow row)
		{
			CRM_HILOS_ENTRADAS_USUARIOSRow mappedObject = new CRM_HILOS_ENTRADAS_USUARIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CRM_HILOS_ENTRADA_ID"
			dataColumn = dataTable.Columns["CRM_HILOS_ENTRADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CRM_HILOS_ENTRADA_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA_LECTURA"
			dataColumn = dataTable.Columns["FECHA_LECTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_LECTURA = (System.DateTime)row[dataColumn];
			// Column "FECHA_RECORDATORIO"
			dataColumn = dataTable.Columns["FECHA_RECORDATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECORDATORIO = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CRM_HILOS_ENTRADAS_USUARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CRM_HILOS_ENTRADAS_USUARIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CRM_HILOS_ENTRADA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_LECTURA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_RECORDATORIO", typeof(System.DateTime));
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

				case "CRM_HILOS_ENTRADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_LECTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_RECORDATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CRM_HILOS_ENTRADAS_USUARIOSCollection_Base class
}  // End of namespace
