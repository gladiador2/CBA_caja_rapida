// <fileinfo name="RECALENDARIZACION_MAS_CUOTASCollection_Base.cs">
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
	/// The base class for <see cref="RECALENDARIZACION_MAS_CUOTASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="RECALENDARIZACION_MAS_CUOTASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RECALENDARIZACION_MAS_CUOTASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string RECAL_MASIVA_DET_IDColumnName = "RECAL_MASIVA_DET_ID";
		public const string CAL_PAGO_CLI_FC_ORIGINAL_IDColumnName = "CAL_PAGO_CLI_FC_ORIGINAL_ID";
		public const string CAL_PAGO_CLI_FC_NUEVO_IDColumnName = "CAL_PAGO_CLI_FC_NUEVO_ID";
		public const string NUEVO_VENCIMIENTOColumnName = "NUEVO_VENCIMIENTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="RECALENDARIZACION_MAS_CUOTASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public RECALENDARIZACION_MAS_CUOTASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		public virtual RECALENDARIZACION_MAS_CUOTASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public RECALENDARIZACION_MAS_CUOTASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			RECALENDARIZACION_MAS_CUOTASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		public RECALENDARIZACION_MAS_CUOTASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects that 
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
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		public virtual RECALENDARIZACION_MAS_CUOTASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.RECALENDARIZACION_MAS_CUOTAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual RECALENDARIZACION_MAS_CUOTASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			RECALENDARIZACION_MAS_CUOTASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects 
		/// by the <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		public RECALENDARIZACION_MAS_CUOTASRow[] GetByCAL_PAGO_CLI_FC_NUEVO_ID(decimal cal_pago_cli_fc_nuevo_id)
		{
			return GetByCAL_PAGO_CLI_FC_NUEVO_ID(cal_pago_cli_fc_nuevo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects 
		/// by the <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <param name="cal_pago_cli_fc_nuevo_idNull">true if the method ignores the cal_pago_cli_fc_nuevo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		public virtual RECALENDARIZACION_MAS_CUOTASRow[] GetByCAL_PAGO_CLI_FC_NUEVO_ID(decimal cal_pago_cli_fc_nuevo_id, bool cal_pago_cli_fc_nuevo_idNull)
		{
			return MapRecords(CreateGetByCAL_PAGO_CLI_FC_NUEVO_IDCommand(cal_pago_cli_fc_nuevo_id, cal_pago_cli_fc_nuevo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCAL_PAGO_CLI_FC_NUEVO_IDAsDataTable(decimal cal_pago_cli_fc_nuevo_id)
		{
			return GetByCAL_PAGO_CLI_FC_NUEVO_IDAsDataTable(cal_pago_cli_fc_nuevo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <param name="cal_pago_cli_fc_nuevo_idNull">true if the method ignores the cal_pago_cli_fc_nuevo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCAL_PAGO_CLI_FC_NUEVO_IDAsDataTable(decimal cal_pago_cli_fc_nuevo_id, bool cal_pago_cli_fc_nuevo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCAL_PAGO_CLI_FC_NUEVO_IDCommand(cal_pago_cli_fc_nuevo_id, cal_pago_cli_fc_nuevo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <param name="cal_pago_cli_fc_nuevo_idNull">true if the method ignores the cal_pago_cli_fc_nuevo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCAL_PAGO_CLI_FC_NUEVO_IDCommand(decimal cal_pago_cli_fc_nuevo_id, bool cal_pago_cli_fc_nuevo_idNull)
		{
			string whereSql = "";
			if(cal_pago_cli_fc_nuevo_idNull)
				whereSql += "CAL_PAGO_CLI_FC_NUEVO_ID IS NULL";
			else
				whereSql += "CAL_PAGO_CLI_FC_NUEVO_ID=" + _db.CreateSqlParameterName("CAL_PAGO_CLI_FC_NUEVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cal_pago_cli_fc_nuevo_idNull)
				AddParameter(cmd, "CAL_PAGO_CLI_FC_NUEVO_ID", cal_pago_cli_fc_nuevo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects 
		/// by the <c>FK_CAL_PAGO_CLI_FC_ORIGINAL_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_original_id">The <c>CAL_PAGO_CLI_FC_ORIGINAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		public virtual RECALENDARIZACION_MAS_CUOTASRow[] GetByCAL_PAGO_CLI_FC_ORIGINAL_ID(decimal cal_pago_cli_fc_original_id)
		{
			return MapRecords(CreateGetByCAL_PAGO_CLI_FC_ORIGINAL_IDCommand(cal_pago_cli_fc_original_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAL_PAGO_CLI_FC_ORIGINAL_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_original_id">The <c>CAL_PAGO_CLI_FC_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCAL_PAGO_CLI_FC_ORIGINAL_IDAsDataTable(decimal cal_pago_cli_fc_original_id)
		{
			return MapRecordsToDataTable(CreateGetByCAL_PAGO_CLI_FC_ORIGINAL_IDCommand(cal_pago_cli_fc_original_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CAL_PAGO_CLI_FC_ORIGINAL_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_original_id">The <c>CAL_PAGO_CLI_FC_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCAL_PAGO_CLI_FC_ORIGINAL_IDCommand(decimal cal_pago_cli_fc_original_id)
		{
			string whereSql = "";
			whereSql += "CAL_PAGO_CLI_FC_ORIGINAL_ID=" + _db.CreateSqlParameterName("CAL_PAGO_CLI_FC_ORIGINAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CAL_PAGO_CLI_FC_ORIGINAL_ID", cal_pago_cli_fc_original_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects 
		/// by the <c>FK_RECAL_MASIVA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="recal_masiva_det_id">The <c>RECAL_MASIVA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		public virtual RECALENDARIZACION_MAS_CUOTASRow[] GetByRECAL_MASIVA_DET_ID(decimal recal_masiva_det_id)
		{
			return MapRecords(CreateGetByRECAL_MASIVA_DET_IDCommand(recal_masiva_det_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RECAL_MASIVA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="recal_masiva_det_id">The <c>RECAL_MASIVA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRECAL_MASIVA_DET_IDAsDataTable(decimal recal_masiva_det_id)
		{
			return MapRecordsToDataTable(CreateGetByRECAL_MASIVA_DET_IDCommand(recal_masiva_det_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_RECAL_MASIVA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="recal_masiva_det_id">The <c>RECAL_MASIVA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRECAL_MASIVA_DET_IDCommand(decimal recal_masiva_det_id)
		{
			string whereSql = "";
			whereSql += "RECAL_MASIVA_DET_ID=" + _db.CreateSqlParameterName("RECAL_MASIVA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "RECAL_MASIVA_DET_ID", recal_masiva_det_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> object to be inserted.</param>
		public virtual void Insert(RECALENDARIZACION_MAS_CUOTASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.RECALENDARIZACION_MAS_CUOTAS (" +
				"ID, " +
				"RECAL_MASIVA_DET_ID, " +
				"CAL_PAGO_CLI_FC_ORIGINAL_ID, " +
				"CAL_PAGO_CLI_FC_NUEVO_ID, " +
				"NUEVO_VENCIMIENTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("RECAL_MASIVA_DET_ID") + ", " +
				_db.CreateSqlParameterName("CAL_PAGO_CLI_FC_ORIGINAL_ID") + ", " +
				_db.CreateSqlParameterName("CAL_PAGO_CLI_FC_NUEVO_ID") + ", " +
				_db.CreateSqlParameterName("NUEVO_VENCIMIENTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "RECAL_MASIVA_DET_ID", value.RECAL_MASIVA_DET_ID);
			AddParameter(cmd, "CAL_PAGO_CLI_FC_ORIGINAL_ID", value.CAL_PAGO_CLI_FC_ORIGINAL_ID);
			AddParameter(cmd, "CAL_PAGO_CLI_FC_NUEVO_ID",
				value.IsCAL_PAGO_CLI_FC_NUEVO_IDNull ? DBNull.Value : (object)value.CAL_PAGO_CLI_FC_NUEVO_ID);
			AddParameter(cmd, "NUEVO_VENCIMIENTO", value.NUEVO_VENCIMIENTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RECALENDARIZACION_MAS_CUOTASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(RECALENDARIZACION_MAS_CUOTASRow value)
		{
			
			string sqlStr = "UPDATE TRC.RECALENDARIZACION_MAS_CUOTAS SET " +
				"RECAL_MASIVA_DET_ID=" + _db.CreateSqlParameterName("RECAL_MASIVA_DET_ID") + ", " +
				"CAL_PAGO_CLI_FC_ORIGINAL_ID=" + _db.CreateSqlParameterName("CAL_PAGO_CLI_FC_ORIGINAL_ID") + ", " +
				"CAL_PAGO_CLI_FC_NUEVO_ID=" + _db.CreateSqlParameterName("CAL_PAGO_CLI_FC_NUEVO_ID") + ", " +
				"NUEVO_VENCIMIENTO=" + _db.CreateSqlParameterName("NUEVO_VENCIMIENTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "RECAL_MASIVA_DET_ID", value.RECAL_MASIVA_DET_ID);
			AddParameter(cmd, "CAL_PAGO_CLI_FC_ORIGINAL_ID", value.CAL_PAGO_CLI_FC_ORIGINAL_ID);
			AddParameter(cmd, "CAL_PAGO_CLI_FC_NUEVO_ID",
				value.IsCAL_PAGO_CLI_FC_NUEVO_IDNull ? DBNull.Value : (object)value.CAL_PAGO_CLI_FC_NUEVO_ID);
			AddParameter(cmd, "NUEVO_VENCIMIENTO", value.NUEVO_VENCIMIENTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>RECALENDARIZACION_MAS_CUOTAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>RECALENDARIZACION_MAS_CUOTAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(RECALENDARIZACION_MAS_CUOTASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table using
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
		/// Deletes records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table using the 
		/// <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAL_PAGO_CLI_FC_NUEVO_ID(decimal cal_pago_cli_fc_nuevo_id)
		{
			return DeleteByCAL_PAGO_CLI_FC_NUEVO_ID(cal_pago_cli_fc_nuevo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table using the 
		/// <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <param name="cal_pago_cli_fc_nuevo_idNull">true if the method ignores the cal_pago_cli_fc_nuevo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAL_PAGO_CLI_FC_NUEVO_ID(decimal cal_pago_cli_fc_nuevo_id, bool cal_pago_cli_fc_nuevo_idNull)
		{
			return CreateDeleteByCAL_PAGO_CLI_FC_NUEVO_IDCommand(cal_pago_cli_fc_nuevo_id, cal_pago_cli_fc_nuevo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CAL_PAGO_CLI_FC_NUEVO_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_nuevo_id">The <c>CAL_PAGO_CLI_FC_NUEVO_ID</c> column value.</param>
		/// <param name="cal_pago_cli_fc_nuevo_idNull">true if the method ignores the cal_pago_cli_fc_nuevo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCAL_PAGO_CLI_FC_NUEVO_IDCommand(decimal cal_pago_cli_fc_nuevo_id, bool cal_pago_cli_fc_nuevo_idNull)
		{
			string whereSql = "";
			if(cal_pago_cli_fc_nuevo_idNull)
				whereSql += "CAL_PAGO_CLI_FC_NUEVO_ID IS NULL";
			else
				whereSql += "CAL_PAGO_CLI_FC_NUEVO_ID=" + _db.CreateSqlParameterName("CAL_PAGO_CLI_FC_NUEVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cal_pago_cli_fc_nuevo_idNull)
				AddParameter(cmd, "CAL_PAGO_CLI_FC_NUEVO_ID", cal_pago_cli_fc_nuevo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table using the 
		/// <c>FK_CAL_PAGO_CLI_FC_ORIGINAL_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_original_id">The <c>CAL_PAGO_CLI_FC_ORIGINAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAL_PAGO_CLI_FC_ORIGINAL_ID(decimal cal_pago_cli_fc_original_id)
		{
			return CreateDeleteByCAL_PAGO_CLI_FC_ORIGINAL_IDCommand(cal_pago_cli_fc_original_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CAL_PAGO_CLI_FC_ORIGINAL_ID</c> foreign key.
		/// </summary>
		/// <param name="cal_pago_cli_fc_original_id">The <c>CAL_PAGO_CLI_FC_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCAL_PAGO_CLI_FC_ORIGINAL_IDCommand(decimal cal_pago_cli_fc_original_id)
		{
			string whereSql = "";
			whereSql += "CAL_PAGO_CLI_FC_ORIGINAL_ID=" + _db.CreateSqlParameterName("CAL_PAGO_CLI_FC_ORIGINAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CAL_PAGO_CLI_FC_ORIGINAL_ID", cal_pago_cli_fc_original_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table using the 
		/// <c>FK_RECAL_MASIVA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="recal_masiva_det_id">The <c>RECAL_MASIVA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRECAL_MASIVA_DET_ID(decimal recal_masiva_det_id)
		{
			return CreateDeleteByRECAL_MASIVA_DET_IDCommand(recal_masiva_det_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_RECAL_MASIVA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="recal_masiva_det_id">The <c>RECAL_MASIVA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRECAL_MASIVA_DET_IDCommand(decimal recal_masiva_det_id)
		{
			string whereSql = "";
			whereSql += "RECAL_MASIVA_DET_ID=" + _db.CreateSqlParameterName("RECAL_MASIVA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "RECAL_MASIVA_DET_ID", recal_masiva_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>RECALENDARIZACION_MAS_CUOTAS</c> records that match the specified criteria.
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
		/// to delete <c>RECALENDARIZACION_MAS_CUOTAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.RECALENDARIZACION_MAS_CUOTAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
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
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		protected RECALENDARIZACION_MAS_CUOTASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		protected RECALENDARIZACION_MAS_CUOTASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> objects.</returns>
		protected virtual RECALENDARIZACION_MAS_CUOTASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int recal_masiva_det_idColumnIndex = reader.GetOrdinal("RECAL_MASIVA_DET_ID");
			int cal_pago_cli_fc_original_idColumnIndex = reader.GetOrdinal("CAL_PAGO_CLI_FC_ORIGINAL_ID");
			int cal_pago_cli_fc_nuevo_idColumnIndex = reader.GetOrdinal("CAL_PAGO_CLI_FC_NUEVO_ID");
			int nuevo_vencimientoColumnIndex = reader.GetOrdinal("NUEVO_VENCIMIENTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					RECALENDARIZACION_MAS_CUOTASRow record = new RECALENDARIZACION_MAS_CUOTASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.RECAL_MASIVA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(recal_masiva_det_idColumnIndex)), 9);
					record.CAL_PAGO_CLI_FC_ORIGINAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cal_pago_cli_fc_original_idColumnIndex)), 9);
					if(!reader.IsDBNull(cal_pago_cli_fc_nuevo_idColumnIndex))
						record.CAL_PAGO_CLI_FC_NUEVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cal_pago_cli_fc_nuevo_idColumnIndex)), 9);
					record.NUEVO_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(nuevo_vencimientoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (RECALENDARIZACION_MAS_CUOTASRow[])(recordList.ToArray(typeof(RECALENDARIZACION_MAS_CUOTASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="RECALENDARIZACION_MAS_CUOTASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="RECALENDARIZACION_MAS_CUOTASRow"/> object.</returns>
		protected virtual RECALENDARIZACION_MAS_CUOTASRow MapRow(DataRow row)
		{
			RECALENDARIZACION_MAS_CUOTASRow mappedObject = new RECALENDARIZACION_MAS_CUOTASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "RECAL_MASIVA_DET_ID"
			dataColumn = dataTable.Columns["RECAL_MASIVA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECAL_MASIVA_DET_ID = (decimal)row[dataColumn];
			// Column "CAL_PAGO_CLI_FC_ORIGINAL_ID"
			dataColumn = dataTable.Columns["CAL_PAGO_CLI_FC_ORIGINAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAL_PAGO_CLI_FC_ORIGINAL_ID = (decimal)row[dataColumn];
			// Column "CAL_PAGO_CLI_FC_NUEVO_ID"
			dataColumn = dataTable.Columns["CAL_PAGO_CLI_FC_NUEVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAL_PAGO_CLI_FC_NUEVO_ID = (decimal)row[dataColumn];
			// Column "NUEVO_VENCIMIENTO"
			dataColumn = dataTable.Columns["NUEVO_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUEVO_VENCIMIENTO = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>RECALENDARIZACION_MAS_CUOTAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "RECALENDARIZACION_MAS_CUOTAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RECAL_MASIVA_DET_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAL_PAGO_CLI_FC_ORIGINAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAL_PAGO_CLI_FC_NUEVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUEVO_VENCIMIENTO", typeof(System.DateTime));
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

				case "RECAL_MASIVA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAL_PAGO_CLI_FC_ORIGINAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAL_PAGO_CLI_FC_NUEVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUEVO_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of RECALENDARIZACION_MAS_CUOTASCollection_Base class
}  // End of namespace
