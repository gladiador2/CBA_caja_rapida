// <fileinfo name="PLANTILLAS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="PLANTILLAS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANTILLAS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANTILLAS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLANTILLA_IDColumnName = "PLANTILLA_ID";
		public const string SQLColumnName = "SQL";
		public const string PARAMETROColumnName = "PARAMETRO";
		public const string LONGITUD_MINIMAColumnName = "LONGITUD_MINIMA";
		public const string CARACTER_RELLENOColumnName = "CARACTER_RELLENO";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string PREGUNTAColumnName = "PREGUNTA";
		public const string TIPO_DATOColumnName = "TIPO_DATO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANTILLAS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANTILLAS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANTILLAS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		public virtual PLANTILLAS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANTILLAS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANTILLAS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANTILLAS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANTILLAS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANTILLAS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANTILLAS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANTILLAS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		public PLANTILLAS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANTILLAS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		public virtual PLANTILLAS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANTILLAS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANTILLAS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANTILLAS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANTILLAS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANTILLAS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANTILLAS_DETALLESRow"/> objects 
		/// by the <c>FK_PLANT_DET_PLANTILLAS_ID</c> foreign key.
		/// </summary>
		/// <param name="plantilla_id">The <c>PLANTILLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		public virtual PLANTILLAS_DETALLESRow[] GetByPLANTILLA_ID(decimal plantilla_id)
		{
			return MapRecords(CreateGetByPLANTILLA_IDCommand(plantilla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANT_DET_PLANTILLAS_ID</c> foreign key.
		/// </summary>
		/// <param name="plantilla_id">The <c>PLANTILLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLANTILLA_IDAsDataTable(decimal plantilla_id)
		{
			return MapRecordsToDataTable(CreateGetByPLANTILLA_IDCommand(plantilla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANT_DET_PLANTILLAS_ID</c> foreign key.
		/// </summary>
		/// <param name="plantilla_id">The <c>PLANTILLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLANTILLA_IDCommand(decimal plantilla_id)
		{
			string whereSql = "";
			whereSql += "PLANTILLA_ID=" + _db.CreateSqlParameterName("PLANTILLA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PLANTILLA_ID", plantilla_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANTILLAS_DETALLESRow"/> objects 
		/// by the <c>FK_PLANT_DET_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		public virtual PLANTILLAS_DETALLESRow[] GetByTABLA_ID(string tabla_id)
		{
			return MapRecords(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANT_DET_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_IDAsDataTable(string tabla_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANT_DET_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			if(null == tabla_id)
				whereSql += "TABLA_ID IS NULL";
			else
				whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tabla_id)
				AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PLANTILLAS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANTILLAS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(PLANTILLAS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANTILLAS_DETALLES (" +
				"ID, " +
				"PLANTILLA_ID, " +
				"SQL, " +
				"PARAMETRO, " +
				"LONGITUD_MINIMA, " +
				"CARACTER_RELLENO, " +
				"TABLA_ID, " +
				"PREGUNTA, " +
				"TIPO_DATO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PLANTILLA_ID") + ", " +
				_db.CreateSqlParameterName("SQL") + ", " +
				_db.CreateSqlParameterName("PARAMETRO") + ", " +
				_db.CreateSqlParameterName("LONGITUD_MINIMA") + ", " +
				_db.CreateSqlParameterName("CARACTER_RELLENO") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("PREGUNTA") + ", " +
				_db.CreateSqlParameterName("TIPO_DATO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PLANTILLA_ID", value.PLANTILLA_ID);
			AddParameter(cmd, "SQL", value.SQL);
			AddParameter(cmd, "PARAMETRO", value.PARAMETRO);
			AddParameter(cmd, "LONGITUD_MINIMA",
				value.IsLONGITUD_MINIMANull ? DBNull.Value : (object)value.LONGITUD_MINIMA);
			AddParameter(cmd, "CARACTER_RELLENO", value.CARACTER_RELLENO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "PREGUNTA", value.PREGUNTA);
			AddParameter(cmd, "TIPO_DATO", value.TIPO_DATO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANTILLAS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANTILLAS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANTILLAS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANTILLAS_DETALLES SET " +
				"PLANTILLA_ID=" + _db.CreateSqlParameterName("PLANTILLA_ID") + ", " +
				"SQL=" + _db.CreateSqlParameterName("SQL") + ", " +
				"PARAMETRO=" + _db.CreateSqlParameterName("PARAMETRO") + ", " +
				"LONGITUD_MINIMA=" + _db.CreateSqlParameterName("LONGITUD_MINIMA") + ", " +
				"CARACTER_RELLENO=" + _db.CreateSqlParameterName("CARACTER_RELLENO") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"PREGUNTA=" + _db.CreateSqlParameterName("PREGUNTA") + ", " +
				"TIPO_DATO=" + _db.CreateSqlParameterName("TIPO_DATO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PLANTILLA_ID", value.PLANTILLA_ID);
			AddParameter(cmd, "SQL", value.SQL);
			AddParameter(cmd, "PARAMETRO", value.PARAMETRO);
			AddParameter(cmd, "LONGITUD_MINIMA",
				value.IsLONGITUD_MINIMANull ? DBNull.Value : (object)value.LONGITUD_MINIMA);
			AddParameter(cmd, "CARACTER_RELLENO", value.CARACTER_RELLENO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "PREGUNTA", value.PREGUNTA);
			AddParameter(cmd, "TIPO_DATO", value.TIPO_DATO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANTILLAS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANTILLAS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANTILLAS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANTILLAS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANTILLAS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANTILLAS_DETALLES</c> table using
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
		/// Deletes records from the <c>PLANTILLAS_DETALLES</c> table using the 
		/// <c>FK_PLANT_DET_PLANTILLAS_ID</c> foreign key.
		/// </summary>
		/// <param name="plantilla_id">The <c>PLANTILLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANTILLA_ID(decimal plantilla_id)
		{
			return CreateDeleteByPLANTILLA_IDCommand(plantilla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANT_DET_PLANTILLAS_ID</c> foreign key.
		/// </summary>
		/// <param name="plantilla_id">The <c>PLANTILLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLANTILLA_IDCommand(decimal plantilla_id)
		{
			string whereSql = "";
			whereSql += "PLANTILLA_ID=" + _db.CreateSqlParameterName("PLANTILLA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PLANTILLA_ID", plantilla_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANTILLAS_DETALLES</c> table using the 
		/// <c>FK_PLANT_DET_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_ID(string tabla_id)
		{
			return CreateDeleteByTABLA_IDCommand(tabla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANT_DET_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			if(null == tabla_id)
				whereSql += "TABLA_ID IS NULL";
			else
				whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tabla_id)
				AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PLANTILLAS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>PLANTILLAS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANTILLAS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANTILLAS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		protected PLANTILLAS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		protected PLANTILLAS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANTILLAS_DETALLESRow"/> objects.</returns>
		protected virtual PLANTILLAS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int plantilla_idColumnIndex = reader.GetOrdinal("PLANTILLA_ID");
			int sqlColumnIndex = reader.GetOrdinal("SQL");
			int parametroColumnIndex = reader.GetOrdinal("PARAMETRO");
			int longitud_minimaColumnIndex = reader.GetOrdinal("LONGITUD_MINIMA");
			int caracter_rellenoColumnIndex = reader.GetOrdinal("CARACTER_RELLENO");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int preguntaColumnIndex = reader.GetOrdinal("PREGUNTA");
			int tipo_datoColumnIndex = reader.GetOrdinal("TIPO_DATO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANTILLAS_DETALLESRow record = new PLANTILLAS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLANTILLA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(plantilla_idColumnIndex)), 9);
					if(!reader.IsDBNull(sqlColumnIndex))
						record.SQL = Convert.ToString(reader.GetValue(sqlColumnIndex));
					if(!reader.IsDBNull(parametroColumnIndex))
						record.PARAMETRO = Convert.ToString(reader.GetValue(parametroColumnIndex));
					if(!reader.IsDBNull(longitud_minimaColumnIndex))
						record.LONGITUD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(longitud_minimaColumnIndex)), 9);
					if(!reader.IsDBNull(caracter_rellenoColumnIndex))
						record.CARACTER_RELLENO = Convert.ToString(reader.GetValue(caracter_rellenoColumnIndex));
					if(!reader.IsDBNull(tabla_idColumnIndex))
						record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					if(!reader.IsDBNull(preguntaColumnIndex))
						record.PREGUNTA = Convert.ToString(reader.GetValue(preguntaColumnIndex));
					if(!reader.IsDBNull(tipo_datoColumnIndex))
						record.TIPO_DATO = Convert.ToString(reader.GetValue(tipo_datoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANTILLAS_DETALLESRow[])(recordList.ToArray(typeof(PLANTILLAS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANTILLAS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANTILLAS_DETALLESRow"/> object.</returns>
		protected virtual PLANTILLAS_DETALLESRow MapRow(DataRow row)
		{
			PLANTILLAS_DETALLESRow mappedObject = new PLANTILLAS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLANTILLA_ID"
			dataColumn = dataTable.Columns["PLANTILLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANTILLA_ID = (decimal)row[dataColumn];
			// Column "SQL"
			dataColumn = dataTable.Columns["SQL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SQL = (string)row[dataColumn];
			// Column "PARAMETRO"
			dataColumn = dataTable.Columns["PARAMETRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARAMETRO = (string)row[dataColumn];
			// Column "LONGITUD_MINIMA"
			dataColumn = dataTable.Columns["LONGITUD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD_MINIMA = (decimal)row[dataColumn];
			// Column "CARACTER_RELLENO"
			dataColumn = dataTable.Columns["CARACTER_RELLENO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CARACTER_RELLENO = (string)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "PREGUNTA"
			dataColumn = dataTable.Columns["PREGUNTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PREGUNTA = (string)row[dataColumn];
			// Column "TIPO_DATO"
			dataColumn = dataTable.Columns["TIPO_DATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DATO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANTILLAS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANTILLAS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLANTILLA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SQL", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("PARAMETRO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("LONGITUD_MINIMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CARACTER_RELLENO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PREGUNTA", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("TIPO_DATO", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "PLANTILLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SQL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PARAMETRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LONGITUD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CARACTER_RELLENO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PREGUNTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_DATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANTILLAS_DETALLESCollection_Base class
}  // End of namespace
