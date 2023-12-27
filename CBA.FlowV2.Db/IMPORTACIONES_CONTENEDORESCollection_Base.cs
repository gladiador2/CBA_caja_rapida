// <fileinfo name="IMPORTACIONES_CONTENEDORESCollection_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONES_CONTENEDORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="IMPORTACIONES_CONTENEDORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONES_CONTENEDORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string IMPORTACION_IDColumnName = "IMPORTACION_ID";
		public const string TIPO_CONTENEDOR_IDColumnName = "TIPO_CONTENEDOR_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string CANTIDAD_CAJASColumnName = "CANTIDAD_CAJAS";
		public const string NOMBRE_INTERNOColumnName = "NOMBRE_INTERNO";
		public const string SALDOColumnName = "SALDO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_CONTENEDORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public IMPORTACIONES_CONTENEDORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>IMPORTACIONES_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		public virtual IMPORTACIONES_CONTENEDORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>IMPORTACIONES_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>IMPORTACIONES_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="IMPORTACIONES_CONTENEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public IMPORTACIONES_CONTENEDORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			IMPORTACIONES_CONTENEDORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		public IMPORTACIONES_CONTENEDORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects that 
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
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		public virtual IMPORTACIONES_CONTENEDORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.IMPORTACIONES_CONTENEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="IMPORTACIONES_CONTENEDORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="IMPORTACIONES_CONTENEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual IMPORTACIONES_CONTENEDORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			IMPORTACIONES_CONTENEDORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects 
		/// by the <c>FK_IMPORT_CONT_IMPORTACION</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		public virtual IMPORTACIONES_CONTENEDORESRow[] GetByIMPORTACION_ID(decimal importacion_id)
		{
			return MapRecords(CreateGetByIMPORTACION_IDCommand(importacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMPORT_CONT_IMPORTACION</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPORTACION_IDAsDataTable(decimal importacion_id)
		{
			return MapRecordsToDataTable(CreateGetByIMPORTACION_IDCommand(importacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IMPORT_CONT_IMPORTACION</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPORTACION_IDCommand(decimal importacion_id)
		{
			string whereSql = "";
			whereSql += "IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IMPORTACION_ID", importacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects 
		/// by the <c>FK_IMPORT_CONT_TIPO_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		public virtual IMPORTACIONES_CONTENEDORESRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return MapRecords(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IMPORT_CONT_TIPO_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IMPORT_CONT_TIPO_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>IMPORTACIONES_CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACIONES_CONTENEDORESRow"/> object to be inserted.</param>
		public virtual void Insert(IMPORTACIONES_CONTENEDORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.IMPORTACIONES_CONTENEDORES (" +
				"ID, " +
				"IMPORTACION_ID, " +
				"TIPO_CONTENEDOR_ID, " +
				"CANTIDAD, " +
				"CANTIDAD_CAJAS, " +
				"NOMBRE_INTERNO, " +
				"SALDO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("IMPORTACION_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CAJAS") + ", " +
				_db.CreateSqlParameterName("NOMBRE_INTERNO") + ", " +
				_db.CreateSqlParameterName("SALDO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "IMPORTACION_ID", value.IMPORTACION_ID);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "CANTIDAD", value.CANTIDAD);
			AddParameter(cmd, "CANTIDAD_CAJAS",
				value.IsCANTIDAD_CAJASNull ? DBNull.Value : (object)value.CANTIDAD_CAJAS);
			AddParameter(cmd, "NOMBRE_INTERNO", value.NOMBRE_INTERNO);
			AddParameter(cmd, "SALDO",
				value.IsSALDONull ? DBNull.Value : (object)value.SALDO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>IMPORTACIONES_CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACIONES_CONTENEDORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(IMPORTACIONES_CONTENEDORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.IMPORTACIONES_CONTENEDORES SET " +
				"IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID") + ", " +
				"TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"CANTIDAD_CAJAS=" + _db.CreateSqlParameterName("CANTIDAD_CAJAS") + ", " +
				"NOMBRE_INTERNO=" + _db.CreateSqlParameterName("NOMBRE_INTERNO") + ", " +
				"SALDO=" + _db.CreateSqlParameterName("SALDO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "IMPORTACION_ID", value.IMPORTACION_ID);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "CANTIDAD", value.CANTIDAD);
			AddParameter(cmd, "CANTIDAD_CAJAS",
				value.IsCANTIDAD_CAJASNull ? DBNull.Value : (object)value.CANTIDAD_CAJAS);
			AddParameter(cmd, "NOMBRE_INTERNO", value.NOMBRE_INTERNO);
			AddParameter(cmd, "SALDO",
				value.IsSALDONull ? DBNull.Value : (object)value.SALDO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>IMPORTACIONES_CONTENEDORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>IMPORTACIONES_CONTENEDORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>IMPORTACIONES_CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACIONES_CONTENEDORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(IMPORTACIONES_CONTENEDORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>IMPORTACIONES_CONTENEDORES</c> table using
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
		/// Deletes records from the <c>IMPORTACIONES_CONTENEDORES</c> table using the 
		/// <c>FK_IMPORT_CONT_IMPORTACION</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPORTACION_ID(decimal importacion_id)
		{
			return CreateDeleteByIMPORTACION_IDCommand(importacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IMPORT_CONT_IMPORTACION</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPORTACION_IDCommand(decimal importacion_id)
		{
			string whereSql = "";
			whereSql += "IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "IMPORTACION_ID", importacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>IMPORTACIONES_CONTENEDORES</c> table using the 
		/// <c>FK_IMPORT_CONT_TIPO_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return CreateDeleteByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IMPORT_CONT_TIPO_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>IMPORTACIONES_CONTENEDORES</c> records that match the specified criteria.
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
		/// to delete <c>IMPORTACIONES_CONTENEDORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.IMPORTACIONES_CONTENEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>IMPORTACIONES_CONTENEDORES</c> table.
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
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		protected IMPORTACIONES_CONTENEDORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		protected IMPORTACIONES_CONTENEDORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="IMPORTACIONES_CONTENEDORESRow"/> objects.</returns>
		protected virtual IMPORTACIONES_CONTENEDORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int importacion_idColumnIndex = reader.GetOrdinal("IMPORTACION_ID");
			int tipo_contenedor_idColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int cantidad_cajasColumnIndex = reader.GetOrdinal("CANTIDAD_CAJAS");
			int nombre_internoColumnIndex = reader.GetOrdinal("NOMBRE_INTERNO");
			int saldoColumnIndex = reader.GetOrdinal("SALDO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					IMPORTACIONES_CONTENEDORESRow record = new IMPORTACIONES_CONTENEDORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.IMPORTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_idColumnIndex)), 9);
					record.TIPO_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_contenedor_idColumnIndex)), 9);
					record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_cajasColumnIndex))
						record.CANTIDAD_CAJAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cajasColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_internoColumnIndex))
						record.NOMBRE_INTERNO = Convert.ToString(reader.GetValue(nombre_internoColumnIndex));
					if(!reader.IsDBNull(saldoColumnIndex))
						record.SALDO = Math.Round(Convert.ToDecimal(reader.GetValue(saldoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (IMPORTACIONES_CONTENEDORESRow[])(recordList.ToArray(typeof(IMPORTACIONES_CONTENEDORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="IMPORTACIONES_CONTENEDORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="IMPORTACIONES_CONTENEDORESRow"/> object.</returns>
		protected virtual IMPORTACIONES_CONTENEDORESRow MapRow(DataRow row)
		{
			IMPORTACIONES_CONTENEDORESRow mappedObject = new IMPORTACIONES_CONTENEDORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "IMPORTACION_ID"
			dataColumn = dataTable.Columns["IMPORTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_ID = (decimal)row[dataColumn];
			// Column "TIPO_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "CANTIDAD_CAJAS"
			dataColumn = dataTable.Columns["CANTIDAD_CAJAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CAJAS = (decimal)row[dataColumn];
			// Column "NOMBRE_INTERNO"
			dataColumn = dataTable.Columns["NOMBRE_INTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_INTERNO = (string)row[dataColumn];
			// Column "SALDO"
			dataColumn = dataTable.Columns["SALDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>IMPORTACIONES_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "IMPORTACIONES_CONTENEDORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPORTACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CAJAS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOMBRE_INTERNO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("SALDO", typeof(decimal));
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

				case "IMPORTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_CAJAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_INTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SALDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of IMPORTACIONES_CONTENEDORESCollection_Base class
}  // End of namespace
