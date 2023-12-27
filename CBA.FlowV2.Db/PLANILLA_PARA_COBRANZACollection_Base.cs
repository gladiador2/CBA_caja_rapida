// <fileinfo name="PLANILLA_PARA_COBRANZACollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_PARA_COBRANZACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_PARA_COBRANZACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_PARA_COBRANZACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_PERSONA_IDColumnName = "CTACTE_PERSONA_ID";
		public const string MONTO_CUOTAColumnName = "MONTO_CUOTA";
		public const string PLANILLA_DE_COBRANZA_IDColumnName = "PLANILLA_DE_COBRANZA_ID";
		public const string PLANILLA_DE_COBRANZA_DET_IDColumnName = "PLANILLA_DE_COBRANZA_DET_ID";
		public const string COBRADOColumnName = "COBRADO";
		public const string MONTO_MORAColumnName = "MONTO_MORA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PARA_COBRANZACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_PARA_COBRANZACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_PARA_COBRANZA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_PARA_COBRANZARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_PARA_COBRANZA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_PARA_COBRANZA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_PARA_COBRANZARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_PARA_COBRANZARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_PARA_COBRANZARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_PARA_COBRANZARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		public PLANILLA_PARA_COBRANZARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_PARA_COBRANZARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_PARA_COBRANZA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANILLA_PARA_COBRANZARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANILLA_PARA_COBRANZARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANILLA_PARA_COBRANZARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANILLA_PARA_COBRANZARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		public PLANILLA_PARA_COBRANZARow[] GetByPLANILLA_DE_COBRANZA_DET_ID(decimal planilla_de_cobranza_det_id)
		{
			return GetByPLANILLA_DE_COBRANZA_DET_ID(planilla_de_cobranza_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <param name="planilla_de_cobranza_det_idNull">true if the method ignores the planilla_de_cobranza_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_PARA_COBRANZARow[] GetByPLANILLA_DE_COBRANZA_DET_ID(decimal planilla_de_cobranza_det_id, bool planilla_de_cobranza_det_idNull)
		{
			return MapRecords(CreateGetByPLANILLA_DE_COBRANZA_DET_IDCommand(planilla_de_cobranza_det_id, planilla_de_cobranza_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPLANILLA_DE_COBRANZA_DET_IDAsDataTable(decimal planilla_de_cobranza_det_id)
		{
			return GetByPLANILLA_DE_COBRANZA_DET_IDAsDataTable(planilla_de_cobranza_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <param name="planilla_de_cobranza_det_idNull">true if the method ignores the planilla_de_cobranza_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLANILLA_DE_COBRANZA_DET_IDAsDataTable(decimal planilla_de_cobranza_det_id, bool planilla_de_cobranza_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPLANILLA_DE_COBRANZA_DET_IDCommand(planilla_de_cobranza_det_id, planilla_de_cobranza_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <param name="planilla_de_cobranza_det_idNull">true if the method ignores the planilla_de_cobranza_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLANILLA_DE_COBRANZA_DET_IDCommand(decimal planilla_de_cobranza_det_id, bool planilla_de_cobranza_det_idNull)
		{
			string whereSql = "";
			if(planilla_de_cobranza_det_idNull)
				whereSql += "PLANILLA_DE_COBRANZA_DET_ID IS NULL";
			else
				whereSql += "PLANILLA_DE_COBRANZA_DET_ID=" + _db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!planilla_de_cobranza_det_idNull)
				AddParameter(cmd, "PLANILLA_DE_COBRANZA_DET_ID", planilla_de_cobranza_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_CO_PANILLA_COB_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_id">The <c>PLANILLA_DE_COBRANZA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_PARA_COBRANZARow[] GetByPLANILLA_DE_COBRANZA_ID(decimal planilla_de_cobranza_id)
		{
			return MapRecords(CreateGetByPLANILLA_DE_COBRANZA_IDCommand(planilla_de_cobranza_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_CO_PANILLA_COB_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_id">The <c>PLANILLA_DE_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLANILLA_DE_COBRANZA_IDAsDataTable(decimal planilla_de_cobranza_id)
		{
			return MapRecordsToDataTable(CreateGetByPLANILLA_DE_COBRANZA_IDCommand(planilla_de_cobranza_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_CO_PANILLA_COB_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_id">The <c>PLANILLA_DE_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLANILLA_DE_COBRANZA_IDCommand(decimal planilla_de_cobranza_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_DE_COBRANZA_ID=" + _db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PLANILLA_DE_COBRANZA_ID", planilla_de_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBRANZA_CTACTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_PARA_COBRANZARow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBRANZA_CTACTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBRANZA_CTACTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PLANILLA_PARA_COBRANZA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_PARA_COBRANZARow"/> object to be inserted.</param>
		public virtual void Insert(PLANILLA_PARA_COBRANZARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANILLA_PARA_COBRANZA (" +
				"ID, " +
				"CTACTE_PERSONA_ID, " +
				"MONTO_CUOTA, " +
				"PLANILLA_DE_COBRANZA_ID, " +
				"PLANILLA_DE_COBRANZA_DET_ID, " +
				"COBRADO, " +
				"MONTO_MORA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_CUOTA") + ", " +
				_db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_ID") + ", " +
				_db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_DET_ID") + ", " +
				_db.CreateSqlParameterName("COBRADO") + ", " +
				_db.CreateSqlParameterName("MONTO_MORA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID", value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "MONTO_CUOTA", value.MONTO_CUOTA);
			AddParameter(cmd, "PLANILLA_DE_COBRANZA_ID", value.PLANILLA_DE_COBRANZA_ID);
			AddParameter(cmd, "PLANILLA_DE_COBRANZA_DET_ID",
				value.IsPLANILLA_DE_COBRANZA_DET_IDNull ? DBNull.Value : (object)value.PLANILLA_DE_COBRANZA_DET_ID);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			AddParameter(cmd, "MONTO_MORA", value.MONTO_MORA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANILLA_PARA_COBRANZA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_PARA_COBRANZARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANILLA_PARA_COBRANZARow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANILLA_PARA_COBRANZA SET " +
				"CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				"MONTO_CUOTA=" + _db.CreateSqlParameterName("MONTO_CUOTA") + ", " +
				"PLANILLA_DE_COBRANZA_ID=" + _db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_ID") + ", " +
				"PLANILLA_DE_COBRANZA_DET_ID=" + _db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_DET_ID") + ", " +
				"COBRADO=" + _db.CreateSqlParameterName("COBRADO") + ", " +
				"MONTO_MORA=" + _db.CreateSqlParameterName("MONTO_MORA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_PERSONA_ID", value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "MONTO_CUOTA", value.MONTO_CUOTA);
			AddParameter(cmd, "PLANILLA_DE_COBRANZA_ID", value.PLANILLA_DE_COBRANZA_ID);
			AddParameter(cmd, "PLANILLA_DE_COBRANZA_DET_ID",
				value.IsPLANILLA_DE_COBRANZA_DET_IDNull ? DBNull.Value : (object)value.PLANILLA_DE_COBRANZA_DET_ID);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			AddParameter(cmd, "MONTO_MORA", value.MONTO_MORA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANILLA_PARA_COBRANZA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANILLA_PARA_COBRANZA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANILLA_PARA_COBRANZA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_PARA_COBRANZARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANILLA_PARA_COBRANZARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANILLA_PARA_COBRANZA</c> table using
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
		/// Deletes records from the <c>PLANILLA_PARA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_DE_COBRANZA_DET_ID(decimal planilla_de_cobranza_det_id)
		{
			return DeleteByPLANILLA_DE_COBRANZA_DET_ID(planilla_de_cobranza_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_PARA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <param name="planilla_de_cobranza_det_idNull">true if the method ignores the planilla_de_cobranza_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_DE_COBRANZA_DET_ID(decimal planilla_de_cobranza_det_id, bool planilla_de_cobranza_det_idNull)
		{
			return CreateDeleteByPLANILLA_DE_COBRANZA_DET_IDCommand(planilla_de_cobranza_det_id, planilla_de_cobranza_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_CO_PANI_COB_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_det_id">The <c>PLANILLA_DE_COBRANZA_DET_ID</c> column value.</param>
		/// <param name="planilla_de_cobranza_det_idNull">true if the method ignores the planilla_de_cobranza_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLANILLA_DE_COBRANZA_DET_IDCommand(decimal planilla_de_cobranza_det_id, bool planilla_de_cobranza_det_idNull)
		{
			string whereSql = "";
			if(planilla_de_cobranza_det_idNull)
				whereSql += "PLANILLA_DE_COBRANZA_DET_ID IS NULL";
			else
				whereSql += "PLANILLA_DE_COBRANZA_DET_ID=" + _db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!planilla_de_cobranza_det_idNull)
				AddParameter(cmd, "PLANILLA_DE_COBRANZA_DET_ID", planilla_de_cobranza_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_PARA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_CO_PANILLA_COB_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_id">The <c>PLANILLA_DE_COBRANZA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_DE_COBRANZA_ID(decimal planilla_de_cobranza_id)
		{
			return CreateDeleteByPLANILLA_DE_COBRANZA_IDCommand(planilla_de_cobranza_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_CO_PANILLA_COB_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_de_cobranza_id">The <c>PLANILLA_DE_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLANILLA_DE_COBRANZA_IDCommand(decimal planilla_de_cobranza_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_DE_COBRANZA_ID=" + _db.CreateSqlParameterName("PLANILLA_DE_COBRANZA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PLANILLA_DE_COBRANZA_ID", planilla_de_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_PARA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBRANZA_CTACTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return CreateDeleteByCTACTE_PERSONA_IDCommand(ctacte_persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBRANZA_CTACTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PLANILLA_PARA_COBRANZA</c> records that match the specified criteria.
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
		/// to delete <c>PLANILLA_PARA_COBRANZA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANILLA_PARA_COBRANZA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANILLA_PARA_COBRANZA</c> table.
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
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		protected PLANILLA_PARA_COBRANZARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		protected PLANILLA_PARA_COBRANZARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_PARA_COBRANZARow"/> objects.</returns>
		protected virtual PLANILLA_PARA_COBRANZARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ID");
			int monto_cuotaColumnIndex = reader.GetOrdinal("MONTO_CUOTA");
			int planilla_de_cobranza_idColumnIndex = reader.GetOrdinal("PLANILLA_DE_COBRANZA_ID");
			int planilla_de_cobranza_det_idColumnIndex = reader.GetOrdinal("PLANILLA_DE_COBRANZA_DET_ID");
			int cobradoColumnIndex = reader.GetOrdinal("COBRADO");
			int monto_moraColumnIndex = reader.GetOrdinal("MONTO_MORA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_PARA_COBRANZARow record = new PLANILLA_PARA_COBRANZARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_idColumnIndex)), 9);
					record.MONTO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_cuotaColumnIndex)), 9);
					record.PLANILLA_DE_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_de_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(planilla_de_cobranza_det_idColumnIndex))
						record.PLANILLA_DE_COBRANZA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_de_cobranza_det_idColumnIndex)), 9);
					record.COBRADO = Math.Round(Convert.ToDecimal(reader.GetValue(cobradoColumnIndex)), 9);
					record.MONTO_MORA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_moraColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_PARA_COBRANZARow[])(recordList.ToArray(typeof(PLANILLA_PARA_COBRANZARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_PARA_COBRANZARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_PARA_COBRANZARow"/> object.</returns>
		protected virtual PLANILLA_PARA_COBRANZARow MapRow(DataRow row)
		{
			PLANILLA_PARA_COBRANZARow mappedObject = new PLANILLA_PARA_COBRANZARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "MONTO_CUOTA"
			dataColumn = dataTable.Columns["MONTO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CUOTA = (decimal)row[dataColumn];
			// Column "PLANILLA_DE_COBRANZA_ID"
			dataColumn = dataTable.Columns["PLANILLA_DE_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_DE_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "PLANILLA_DE_COBRANZA_DET_ID"
			dataColumn = dataTable.Columns["PLANILLA_DE_COBRANZA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_DE_COBRANZA_DET_ID = (decimal)row[dataColumn];
			// Column "COBRADO"
			dataColumn = dataTable.Columns["COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRADO = (decimal)row[dataColumn];
			// Column "MONTO_MORA"
			dataColumn = dataTable.Columns["MONTO_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_MORA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_PARA_COBRANZA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_PARA_COBRANZA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLANILLA_DE_COBRANZA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLANILLA_DE_COBRANZA_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COBRADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_MORA", typeof(decimal));
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

				case "CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PLANILLA_DE_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PLANILLA_DE_COBRANZA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_PARA_COBRANZACollection_Base class
}  // End of namespace
