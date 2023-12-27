// <fileinfo name="CENTROS_COSTOCollection_Base.cs">
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
	/// The base class for <see cref="CENTROS_COSTOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CENTROS_COSTOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CENTROS_COSTOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string ESTADOColumnName = "ESTADO";
		public const string ORDENColumnName = "ORDEN";
		public const string ES_UNIDAD_NEGOCIOColumnName = "ES_UNIDAD_NEGOCIO";
		public const string CENTRO_COSTO_GRUPO_IDColumnName = "CENTRO_COSTO_GRUPO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CENTROS_COSTOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CENTROS_COSTOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CENTROS_COSTO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		public virtual CENTROS_COSTORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CENTROS_COSTO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CENTROS_COSTO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CENTROS_COSTORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CENTROS_COSTORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CENTROS_COSTORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CENTROS_COSTORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CENTROS_COSTORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		public CENTROS_COSTORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CENTROS_COSTORow"/> objects that 
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
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		public virtual CENTROS_COSTORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CENTROS_COSTO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CENTROS_COSTORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CENTROS_COSTORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CENTROS_COSTORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CENTROS_COSTORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CENTROS_COSTORow"/> objects 
		/// by the <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		public CENTROS_COSTORow[] GetByCENTRO_COSTO_GRUPO_ID(decimal centro_costo_grupo_id)
		{
			return GetByCENTRO_COSTO_GRUPO_ID(centro_costo_grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CENTROS_COSTORow"/> objects 
		/// by the <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <param name="centro_costo_grupo_idNull">true if the method ignores the centro_costo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		public virtual CENTROS_COSTORow[] GetByCENTRO_COSTO_GRUPO_ID(decimal centro_costo_grupo_id, bool centro_costo_grupo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_GRUPO_IDCommand(centro_costo_grupo_id, centro_costo_grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_GRUPO_IDAsDataTable(decimal centro_costo_grupo_id)
		{
			return GetByCENTRO_COSTO_GRUPO_IDAsDataTable(centro_costo_grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <param name="centro_costo_grupo_idNull">true if the method ignores the centro_costo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCENTRO_COSTO_GRUPO_IDAsDataTable(decimal centro_costo_grupo_id, bool centro_costo_grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCENTRO_COSTO_GRUPO_IDCommand(centro_costo_grupo_id, centro_costo_grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <param name="centro_costo_grupo_idNull">true if the method ignores the centro_costo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCENTRO_COSTO_GRUPO_IDCommand(decimal centro_costo_grupo_id, bool centro_costo_grupo_idNull)
		{
			string whereSql = "";
			if(centro_costo_grupo_idNull)
				whereSql += "CENTRO_COSTO_GRUPO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_GRUPO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!centro_costo_grupo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_GRUPO_ID", centro_costo_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CENTROS_COSTO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CENTROS_COSTORow"/> object to be inserted.</param>
		public virtual void Insert(CENTROS_COSTORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CENTROS_COSTO (" +
				"ID, " +
				"NOMBRE, " +
				"ABREVIATURA, " +
				"ESTADO, " +
				"ORDEN, " +
				"ES_UNIDAD_NEGOCIO, " +
				"CENTRO_COSTO_GRUPO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ABREVIATURA") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("ES_UNIDAD_NEGOCIO") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_GRUPO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "ES_UNIDAD_NEGOCIO", value.ES_UNIDAD_NEGOCIO);
			AddParameter(cmd, "CENTRO_COSTO_GRUPO_ID",
				value.IsCENTRO_COSTO_GRUPO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_GRUPO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CENTROS_COSTO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CENTROS_COSTORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CENTROS_COSTORow value)
		{
			
			string sqlStr = "UPDATE TRC.CENTROS_COSTO SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ABREVIATURA=" + _db.CreateSqlParameterName("ABREVIATURA") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"ES_UNIDAD_NEGOCIO=" + _db.CreateSqlParameterName("ES_UNIDAD_NEGOCIO") + ", " +
				"CENTRO_COSTO_GRUPO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_GRUPO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "ES_UNIDAD_NEGOCIO", value.ES_UNIDAD_NEGOCIO);
			AddParameter(cmd, "CENTRO_COSTO_GRUPO_ID",
				value.IsCENTRO_COSTO_GRUPO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_GRUPO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CENTROS_COSTO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CENTROS_COSTO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CENTROS_COSTO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CENTROS_COSTORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CENTROS_COSTORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CENTROS_COSTO</c> table using
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
		/// Deletes records from the <c>CENTROS_COSTO</c> table using the 
		/// <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_GRUPO_ID(decimal centro_costo_grupo_id)
		{
			return DeleteByCENTRO_COSTO_GRUPO_ID(centro_costo_grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CENTROS_COSTO</c> table using the 
		/// <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <param name="centro_costo_grupo_idNull">true if the method ignores the centro_costo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_GRUPO_ID(decimal centro_costo_grupo_id, bool centro_costo_grupo_idNull)
		{
			return CreateDeleteByCENTRO_COSTO_GRUPO_IDCommand(centro_costo_grupo_id, centro_costo_grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CENTROS_COSTO_CC_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_grupo_id">The <c>CENTRO_COSTO_GRUPO_ID</c> column value.</param>
		/// <param name="centro_costo_grupo_idNull">true if the method ignores the centro_costo_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCENTRO_COSTO_GRUPO_IDCommand(decimal centro_costo_grupo_id, bool centro_costo_grupo_idNull)
		{
			string whereSql = "";
			if(centro_costo_grupo_idNull)
				whereSql += "CENTRO_COSTO_GRUPO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_GRUPO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!centro_costo_grupo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_GRUPO_ID", centro_costo_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CENTROS_COSTO</c> records that match the specified criteria.
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
		/// to delete <c>CENTROS_COSTO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CENTROS_COSTO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CENTROS_COSTO</c> table.
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
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		protected CENTROS_COSTORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		protected CENTROS_COSTORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CENTROS_COSTORow"/> objects.</returns>
		protected virtual CENTROS_COSTORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int es_unidad_negocioColumnIndex = reader.GetOrdinal("ES_UNIDAD_NEGOCIO");
			int centro_costo_grupo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_GRUPO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CENTROS_COSTORow record = new CENTROS_COSTORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					record.ES_UNIDAD_NEGOCIO = Convert.ToString(reader.GetValue(es_unidad_negocioColumnIndex));
					if(!reader.IsDBNull(centro_costo_grupo_idColumnIndex))
						record.CENTRO_COSTO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_grupo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CENTROS_COSTORow[])(recordList.ToArray(typeof(CENTROS_COSTORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CENTROS_COSTORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CENTROS_COSTORow"/> object.</returns>
		protected virtual CENTROS_COSTORow MapRow(DataRow row)
		{
			CENTROS_COSTORow mappedObject = new CENTROS_COSTORow();
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
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "ES_UNIDAD_NEGOCIO"
			dataColumn = dataTable.Columns["ES_UNIDAD_NEGOCIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_UNIDAD_NEGOCIO = (string)row[dataColumn];
			// Column "CENTRO_COSTO_GRUPO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_GRUPO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CENTROS_COSTO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CENTROS_COSTO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_UNIDAD_NEGOCIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_GRUPO_ID", typeof(decimal));
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

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_UNIDAD_NEGOCIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CENTRO_COSTO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CENTROS_COSTOCollection_Base class
}  // End of namespace
