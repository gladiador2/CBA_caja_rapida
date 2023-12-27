// <fileinfo name="MOV_FONDO_FIJO_DET_CENT_CCollection_Base.cs">
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
	/// The base class for <see cref="MOV_FONDO_FIJO_DET_CENT_CCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MOV_FONDO_FIJO_DET_CENT_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOV_FONDO_FIJO_DET_CENT_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string MOVIMIENTO_FONDO_FIJO_DET_IDColumnName = "MOVIMIENTO_FONDO_FIJO_DET_ID";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string PORCENTAJEColumnName = "PORCENTAJE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOV_FONDO_FIJO_DET_CENT_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public MOV_FONDO_FIJO_DET_CENT_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
		/// </summary>
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		public virtual MOV_FONDO_FIJO_DET_CENT_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MOV_FONDO_FIJO_DET_CENT_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MOV_FONDO_FIJO_DET_CENT_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		public MOV_FONDO_FIJO_DET_CENT_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects that 
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
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		public virtual MOV_FONDO_FIJO_DET_CENT_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.MOV_FONDO_FIJO_DET_CENT_C";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual MOV_FONDO_FIJO_DET_CENT_CRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			MOV_FONDO_FIJO_DET_CENT_CRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects 
		/// by the <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		public MOV_FONDO_FIJO_DET_CENT_CRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects 
		/// by the <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		public virtual MOV_FONDO_FIJO_DET_CENT_CRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects 
		/// by the <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		public MOV_FONDO_FIJO_DET_CENT_CRow[] GetByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_DET_ID(movimiento_fondo_fijo_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects 
		/// by the <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		public virtual MOV_FONDO_FIJO_DET_CENT_CRow[] GetByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			return MapRecords(CreateGetByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(movimiento_fondo_fijo_det_id, movimiento_fondo_fijo_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOVIMIENTO_FONDO_FIJO_DET_IDAsDataTable(decimal movimiento_fondo_fijo_det_id)
		{
			return GetByMOVIMIENTO_FONDO_FIJO_DET_IDAsDataTable(movimiento_fondo_fijo_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOVIMIENTO_FONDO_FIJO_DET_IDAsDataTable(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(movimiento_fondo_fijo_det_id, movimiento_fondo_fijo_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			string whereSql = "";
			if(movimiento_fondo_fijo_det_idNull)
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!movimiento_fondo_fijo_det_idNull)
				AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID", movimiento_fondo_fijo_det_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> object to be inserted.</param>
		public virtual void Insert(MOV_FONDO_FIJO_DET_CENT_CRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.MOV_FONDO_FIJO_DET_CENT_C (" +
				"ID, " +
				"MOVIMIENTO_FONDO_FIJO_DET_ID, " +
				"CENTRO_COSTO_ID, " +
				"ESTADO, " +
				"PORCENTAJE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_DET_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(MOV_FONDO_FIJO_DET_CENT_CRow value)
		{
			
			string sqlStr = "UPDATE TRC.MOV_FONDO_FIJO_DET_CENT_C SET " +
				"MOVIMIENTO_FONDO_FIJO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"PORCENTAJE=" + _db.CreateSqlParameterName("PORCENTAJE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID",
				value.IsMOVIMIENTO_FONDO_FIJO_DET_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_FONDO_FIJO_DET_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(MOV_FONDO_FIJO_DET_CENT_CRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table using
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
		/// Deletes records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table using the 
		/// <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table using the 
		/// <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return CreateDeleteByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MOV_FF_DET_CC_CC</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table using the 
		/// <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id)
		{
			return DeleteByMOVIMIENTO_FONDO_FIJO_DET_ID(movimiento_fondo_fijo_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table using the 
		/// <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_FONDO_FIJO_DET_ID(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			return CreateDeleteByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(movimiento_fondo_fijo_det_id, movimiento_fondo_fijo_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_MOV_FF_DET_CC_MFFD</c> foreign key.
		/// </summary>
		/// <param name="movimiento_fondo_fijo_det_id">The <c>MOVIMIENTO_FONDO_FIJO_DET_ID</c> column value.</param>
		/// <param name="movimiento_fondo_fijo_det_idNull">true if the method ignores the movimiento_fondo_fijo_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOVIMIENTO_FONDO_FIJO_DET_IDCommand(decimal movimiento_fondo_fijo_det_id, bool movimiento_fondo_fijo_det_idNull)
		{
			string whereSql = "";
			if(movimiento_fondo_fijo_det_idNull)
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_FONDO_FIJO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_FONDO_FIJO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!movimiento_fondo_fijo_det_idNull)
				AddParameter(cmd, "MOVIMIENTO_FONDO_FIJO_DET_ID", movimiento_fondo_fijo_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>MOV_FONDO_FIJO_DET_CENT_C</c> records that match the specified criteria.
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
		/// to delete <c>MOV_FONDO_FIJO_DET_CENT_C</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.MOV_FONDO_FIJO_DET_CENT_C";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
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
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		protected MOV_FONDO_FIJO_DET_CENT_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		protected MOV_FONDO_FIJO_DET_CENT_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> objects.</returns>
		protected virtual MOV_FONDO_FIJO_DET_CENT_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int movimiento_fondo_fijo_det_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_FONDO_FIJO_DET_ID");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					MOV_FONDO_FIJO_DET_CENT_CRow record = new MOV_FONDO_FIJO_DET_CENT_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_fondo_fijo_det_idColumnIndex))
						record.MOVIMIENTO_FONDO_FIJO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_fondo_fijo_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(porcentajeColumnIndex))
						record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MOV_FONDO_FIJO_DET_CENT_CRow[])(recordList.ToArray(typeof(MOV_FONDO_FIJO_DET_CENT_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MOV_FONDO_FIJO_DET_CENT_CRow"/> object.</returns>
		protected virtual MOV_FONDO_FIJO_DET_CENT_CRow MapRow(DataRow row)
		{
			MOV_FONDO_FIJO_DET_CENT_CRow mappedObject = new MOV_FONDO_FIJO_DET_CENT_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_FONDO_FIJO_DET_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_FONDO_FIJO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_FONDO_FIJO_DET_ID = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>MOV_FONDO_FIJO_DET_CENT_C</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MOV_FONDO_FIJO_DET_CENT_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_FONDO_FIJO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
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

				case "MOVIMIENTO_FONDO_FIJO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of MOV_FONDO_FIJO_DET_CENT_CCollection_Base class
}  // End of namespace
