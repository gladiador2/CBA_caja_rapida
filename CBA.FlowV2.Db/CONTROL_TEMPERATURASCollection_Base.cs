// <fileinfo name="CONTROL_TEMPERATURASCollection_Base.cs">
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
	/// The base class for <see cref="CONTROL_TEMPERATURASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTROL_TEMPERATURASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTROL_TEMPERATURASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FUNCIONARIO_ENCARGADO_IDColumnName = "FUNCIONARIO_ENCARGADO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string CONTROL_TEMP_ANTERIOR_IDColumnName = "CONTROL_TEMP_ANTERIOR_ID";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string CARGADOColumnName = "CARGADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTROL_TEMPERATURASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTROL_TEMPERATURASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTROL_TEMPERATURAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		public virtual CONTROL_TEMPERATURASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTROL_TEMPERATURAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTROL_TEMPERATURAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTROL_TEMPERATURASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTROL_TEMPERATURASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTROL_TEMPERATURASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTROL_TEMPERATURASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTROL_TEMPERATURASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		public CONTROL_TEMPERATURASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTROL_TEMPERATURASRow"/> objects that 
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
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		public virtual CONTROL_TEMPERATURASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTROL_TEMPERATURAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONTROL_TEMPERATURASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONTROL_TEMPERATURASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONTROL_TEMPERATURASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONTROL_TEMPERATURASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTROL_TEMPERATURASRow"/> objects 
		/// by the <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		public CONTROL_TEMPERATURASRow[] GetByCONTROL_TEMP_ANTERIOR_ID(decimal control_temp_anterior_id)
		{
			return GetByCONTROL_TEMP_ANTERIOR_ID(control_temp_anterior_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTROL_TEMPERATURASRow"/> objects 
		/// by the <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <param name="control_temp_anterior_idNull">true if the method ignores the control_temp_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		public virtual CONTROL_TEMPERATURASRow[] GetByCONTROL_TEMP_ANTERIOR_ID(decimal control_temp_anterior_id, bool control_temp_anterior_idNull)
		{
			return MapRecords(CreateGetByCONTROL_TEMP_ANTERIOR_IDCommand(control_temp_anterior_id, control_temp_anterior_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTROL_TEMP_ANTERIOR_IDAsDataTable(decimal control_temp_anterior_id)
		{
			return GetByCONTROL_TEMP_ANTERIOR_IDAsDataTable(control_temp_anterior_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <param name="control_temp_anterior_idNull">true if the method ignores the control_temp_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTROL_TEMP_ANTERIOR_IDAsDataTable(decimal control_temp_anterior_id, bool control_temp_anterior_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONTROL_TEMP_ANTERIOR_IDCommand(control_temp_anterior_id, control_temp_anterior_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <param name="control_temp_anterior_idNull">true if the method ignores the control_temp_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTROL_TEMP_ANTERIOR_IDCommand(decimal control_temp_anterior_id, bool control_temp_anterior_idNull)
		{
			string whereSql = "";
			if(control_temp_anterior_idNull)
				whereSql += "CONTROL_TEMP_ANTERIOR_ID IS NULL";
			else
				whereSql += "CONTROL_TEMP_ANTERIOR_ID=" + _db.CreateSqlParameterName("CONTROL_TEMP_ANTERIOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!control_temp_anterior_idNull)
				AddParameter(cmd, "CONTROL_TEMP_ANTERIOR_ID", control_temp_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONTROL_TEMPERATURASRow"/> objects 
		/// by the <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		public CONTROL_TEMPERATURASRow[] GetByFUNCIONARIO_ENCARGADO_ID(decimal funcionario_encargado_id)
		{
			return GetByFUNCIONARIO_ENCARGADO_ID(funcionario_encargado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTROL_TEMPERATURASRow"/> objects 
		/// by the <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <param name="funcionario_encargado_idNull">true if the method ignores the funcionario_encargado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		public virtual CONTROL_TEMPERATURASRow[] GetByFUNCIONARIO_ENCARGADO_ID(decimal funcionario_encargado_id, bool funcionario_encargado_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_ENCARGADO_IDCommand(funcionario_encargado_id, funcionario_encargado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_ENCARGADO_IDAsDataTable(decimal funcionario_encargado_id)
		{
			return GetByFUNCIONARIO_ENCARGADO_IDAsDataTable(funcionario_encargado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <param name="funcionario_encargado_idNull">true if the method ignores the funcionario_encargado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_ENCARGADO_IDAsDataTable(decimal funcionario_encargado_id, bool funcionario_encargado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_ENCARGADO_IDCommand(funcionario_encargado_id, funcionario_encargado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <param name="funcionario_encargado_idNull">true if the method ignores the funcionario_encargado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_ENCARGADO_IDCommand(decimal funcionario_encargado_id, bool funcionario_encargado_idNull)
		{
			string whereSql = "";
			if(funcionario_encargado_idNull)
				whereSql += "FUNCIONARIO_ENCARGADO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ENCARGADO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ENCARGADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_encargado_idNull)
				AddParameter(cmd, "FUNCIONARIO_ENCARGADO_ID", funcionario_encargado_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CONTROL_TEMPERATURAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTROL_TEMPERATURASRow"/> object to be inserted.</param>
		public virtual void Insert(CONTROL_TEMPERATURASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONTROL_TEMPERATURAS (" +
				"ID, " +
				"FUNCIONARIO_ENCARGADO_ID, " +
				"FECHA, " +
				"CONTROL_TEMP_ANTERIOR_ID, " +
				"OBSERVACIONES, " +
				"NRO_COMPROBANTE, " +
				"CARGADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ENCARGADO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CONTROL_TEMP_ANTERIOR_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("CARGADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FUNCIONARIO_ENCARGADO_ID",
				value.IsFUNCIONARIO_ENCARGADO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ENCARGADO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CONTROL_TEMP_ANTERIOR_ID",
				value.IsCONTROL_TEMP_ANTERIOR_IDNull ? DBNull.Value : (object)value.CONTROL_TEMP_ANTERIOR_ID);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "CARGADO", value.CARGADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONTROL_TEMPERATURAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTROL_TEMPERATURASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONTROL_TEMPERATURASRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONTROL_TEMPERATURAS SET " +
				"FUNCIONARIO_ENCARGADO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ENCARGADO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CONTROL_TEMP_ANTERIOR_ID=" + _db.CreateSqlParameterName("CONTROL_TEMP_ANTERIOR_ID") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"CARGADO=" + _db.CreateSqlParameterName("CARGADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FUNCIONARIO_ENCARGADO_ID",
				value.IsFUNCIONARIO_ENCARGADO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ENCARGADO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CONTROL_TEMP_ANTERIOR_ID",
				value.IsCONTROL_TEMP_ANTERIOR_IDNull ? DBNull.Value : (object)value.CONTROL_TEMP_ANTERIOR_ID);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "CARGADO", value.CARGADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONTROL_TEMPERATURAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONTROL_TEMPERATURAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONTROL_TEMPERATURAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTROL_TEMPERATURASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONTROL_TEMPERATURASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONTROL_TEMPERATURAS</c> table using
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
		/// Deletes records from the <c>CONTROL_TEMPERATURAS</c> table using the 
		/// <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTROL_TEMP_ANTERIOR_ID(decimal control_temp_anterior_id)
		{
			return DeleteByCONTROL_TEMP_ANTERIOR_ID(control_temp_anterior_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTROL_TEMPERATURAS</c> table using the 
		/// <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <param name="control_temp_anterior_idNull">true if the method ignores the control_temp_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTROL_TEMP_ANTERIOR_ID(decimal control_temp_anterior_id, bool control_temp_anterior_idNull)
		{
			return CreateDeleteByCONTROL_TEMP_ANTERIOR_IDCommand(control_temp_anterior_id, control_temp_anterior_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTROL_TEMP_CONT_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="control_temp_anterior_id">The <c>CONTROL_TEMP_ANTERIOR_ID</c> column value.</param>
		/// <param name="control_temp_anterior_idNull">true if the method ignores the control_temp_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTROL_TEMP_ANTERIOR_IDCommand(decimal control_temp_anterior_id, bool control_temp_anterior_idNull)
		{
			string whereSql = "";
			if(control_temp_anterior_idNull)
				whereSql += "CONTROL_TEMP_ANTERIOR_ID IS NULL";
			else
				whereSql += "CONTROL_TEMP_ANTERIOR_ID=" + _db.CreateSqlParameterName("CONTROL_TEMP_ANTERIOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!control_temp_anterior_idNull)
				AddParameter(cmd, "CONTROL_TEMP_ANTERIOR_ID", control_temp_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONTROL_TEMPERATURAS</c> table using the 
		/// <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ENCARGADO_ID(decimal funcionario_encargado_id)
		{
			return DeleteByFUNCIONARIO_ENCARGADO_ID(funcionario_encargado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTROL_TEMPERATURAS</c> table using the 
		/// <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <param name="funcionario_encargado_idNull">true if the method ignores the funcionario_encargado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ENCARGADO_ID(decimal funcionario_encargado_id, bool funcionario_encargado_idNull)
		{
			return CreateDeleteByFUNCIONARIO_ENCARGADO_IDCommand(funcionario_encargado_id, funcionario_encargado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTROL_TEMP_FUNC_ENC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_encargado_id">The <c>FUNCIONARIO_ENCARGADO_ID</c> column value.</param>
		/// <param name="funcionario_encargado_idNull">true if the method ignores the funcionario_encargado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_ENCARGADO_IDCommand(decimal funcionario_encargado_id, bool funcionario_encargado_idNull)
		{
			string whereSql = "";
			if(funcionario_encargado_idNull)
				whereSql += "FUNCIONARIO_ENCARGADO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ENCARGADO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ENCARGADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_encargado_idNull)
				AddParameter(cmd, "FUNCIONARIO_ENCARGADO_ID", funcionario_encargado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CONTROL_TEMPERATURAS</c> records that match the specified criteria.
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
		/// to delete <c>CONTROL_TEMPERATURAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONTROL_TEMPERATURAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONTROL_TEMPERATURAS</c> table.
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
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		protected CONTROL_TEMPERATURASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		protected CONTROL_TEMPERATURASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTROL_TEMPERATURASRow"/> objects.</returns>
		protected virtual CONTROL_TEMPERATURASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int funcionario_encargado_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ENCARGADO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int control_temp_anterior_idColumnIndex = reader.GetOrdinal("CONTROL_TEMP_ANTERIOR_ID");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int cargadoColumnIndex = reader.GetOrdinal("CARGADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTROL_TEMPERATURASRow record = new CONTROL_TEMPERATURASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_encargado_idColumnIndex))
						record.FUNCIONARIO_ENCARGADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_encargado_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(control_temp_anterior_idColumnIndex))
						record.CONTROL_TEMP_ANTERIOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(control_temp_anterior_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.CARGADO = Convert.ToString(reader.GetValue(cargadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTROL_TEMPERATURASRow[])(recordList.ToArray(typeof(CONTROL_TEMPERATURASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTROL_TEMPERATURASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTROL_TEMPERATURASRow"/> object.</returns>
		protected virtual CONTROL_TEMPERATURASRow MapRow(DataRow row)
		{
			CONTROL_TEMPERATURASRow mappedObject = new CONTROL_TEMPERATURASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ENCARGADO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ENCARGADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ENCARGADO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CONTROL_TEMP_ANTERIOR_ID"
			dataColumn = dataTable.Columns["CONTROL_TEMP_ANTERIOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROL_TEMP_ANTERIOR_ID = (decimal)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CARGADO"
			dataColumn = dataTable.Columns["CARGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CARGADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTROL_TEMPERATURAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTROL_TEMPERATURAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ENCARGADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTROL_TEMP_ANTERIOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CARGADO", typeof(string));
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

				case "FUNCIONARIO_ENCARGADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONTROL_TEMP_ANTERIOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CARGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTROL_TEMPERATURASCollection_Base class
}  // End of namespace
