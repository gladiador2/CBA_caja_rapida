// <fileinfo name="CTACTE_PROCESADORAS_TARJETACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PROCESADORAS_TARJETACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PROCESADORAS_TARJETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PROCESADORAS_TARJETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string CUENTA_CORRIENTE_BANCARIA_IDColumnName = "CUENTA_CORRIENTE_BANCARIA_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string ES_TARJETA_CREDITOColumnName = "ES_TARJETA_CREDITO";
		public const string PROCESADORA_IDColumnName = "PROCESADORA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PROCESADORAS_TARJETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PROCESADORAS_TARJETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PROCESADORAS_TARJETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PROCESADORAS_TARJETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		public CTACTE_PROCESADORAS_TARJETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PROCESADORAS_TARJETA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PROCESADORAS_TARJETARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PROCESADORAS_TARJETARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects 
		/// by the <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		public CTACTE_PROCESADORAS_TARJETARow[] GetByPROCESADORA_ID(decimal procesadora_id)
		{
			return GetByPROCESADORA_ID(procesadora_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects 
		/// by the <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <param name="procesadora_idNull">true if the method ignores the procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETARow[] GetByPROCESADORA_ID(decimal procesadora_id, bool procesadora_idNull)
		{
			return MapRecords(CreateGetByPROCESADORA_IDCommand(procesadora_id, procesadora_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROCESADORA_IDAsDataTable(decimal procesadora_id)
		{
			return GetByPROCESADORA_IDAsDataTable(procesadora_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <param name="procesadora_idNull">true if the method ignores the procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROCESADORA_IDAsDataTable(decimal procesadora_id, bool procesadora_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROCESADORA_IDCommand(procesadora_id, procesadora_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <param name="procesadora_idNull">true if the method ignores the procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROCESADORA_IDCommand(decimal procesadora_id, bool procesadora_idNull)
		{
			string whereSql = "";
			if(procesadora_idNull)
				whereSql += "PROCESADORA_ID IS NULL";
			else
				whereSql += "PROCESADORA_ID=" + _db.CreateSqlParameterName("PROCESADORA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!procesadora_idNull)
				AddParameter(cmd, "PROCESADORA_ID", procesadora_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects 
		/// by the <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		public CTACTE_PROCESADORAS_TARJETARow[] GetByCUENTA_CORRIENTE_BANCARIA_ID(decimal cuenta_corriente_bancaria_id)
		{
			return GetByCUENTA_CORRIENTE_BANCARIA_ID(cuenta_corriente_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects 
		/// by the <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cuenta_corriente_bancaria_idNull">true if the method ignores the cuenta_corriente_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		public virtual CTACTE_PROCESADORAS_TARJETARow[] GetByCUENTA_CORRIENTE_BANCARIA_ID(decimal cuenta_corriente_bancaria_id, bool cuenta_corriente_bancaria_idNull)
		{
			return MapRecords(CreateGetByCUENTA_CORRIENTE_BANCARIA_IDCommand(cuenta_corriente_bancaria_id, cuenta_corriente_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCUENTA_CORRIENTE_BANCARIA_IDAsDataTable(decimal cuenta_corriente_bancaria_id)
		{
			return GetByCUENTA_CORRIENTE_BANCARIA_IDAsDataTable(cuenta_corriente_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cuenta_corriente_bancaria_idNull">true if the method ignores the cuenta_corriente_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCUENTA_CORRIENTE_BANCARIA_IDAsDataTable(decimal cuenta_corriente_bancaria_id, bool cuenta_corriente_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCUENTA_CORRIENTE_BANCARIA_IDCommand(cuenta_corriente_bancaria_id, cuenta_corriente_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cuenta_corriente_bancaria_idNull">true if the method ignores the cuenta_corriente_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCUENTA_CORRIENTE_BANCARIA_IDCommand(decimal cuenta_corriente_bancaria_id, bool cuenta_corriente_bancaria_idNull)
		{
			string whereSql = "";
			if(cuenta_corriente_bancaria_idNull)
				whereSql += "CUENTA_CORRIENTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CUENTA_CORRIENTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CUENTA_CORRIENTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cuenta_corriente_bancaria_idNull)
				AddParameter(cmd, "CUENTA_CORRIENTE_BANCARIA_ID", cuenta_corriente_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROCESADORAS_TARJETARow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PROCESADORAS_TARJETARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PROCESADORAS_TARJETA (" +
				"ID, " +
				"NOMBRE, " +
				"ABREVIATURA, " +
				"CUENTA_CORRIENTE_BANCARIA_ID, " +
				"ESTADO, " +
				"ES_TARJETA_CREDITO, " +
				"PROCESADORA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ABREVIATURA") + ", " +
				_db.CreateSqlParameterName("CUENTA_CORRIENTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("ES_TARJETA_CREDITO") + ", " +
				_db.CreateSqlParameterName("PROCESADORA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "CUENTA_CORRIENTE_BANCARIA_ID",
				value.IsCUENTA_CORRIENTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CUENTA_CORRIENTE_BANCARIA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ES_TARJETA_CREDITO", value.ES_TARJETA_CREDITO);
			AddParameter(cmd, "PROCESADORA_ID",
				value.IsPROCESADORA_IDNull ? DBNull.Value : (object)value.PROCESADORA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROCESADORAS_TARJETARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PROCESADORAS_TARJETARow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PROCESADORAS_TARJETA SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ABREVIATURA=" + _db.CreateSqlParameterName("ABREVIATURA") + ", " +
				"CUENTA_CORRIENTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CUENTA_CORRIENTE_BANCARIA_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"ES_TARJETA_CREDITO=" + _db.CreateSqlParameterName("ES_TARJETA_CREDITO") + ", " +
				"PROCESADORA_ID=" + _db.CreateSqlParameterName("PROCESADORA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "CUENTA_CORRIENTE_BANCARIA_ID",
				value.IsCUENTA_CORRIENTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CUENTA_CORRIENTE_BANCARIA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ES_TARJETA_CREDITO", value.ES_TARJETA_CREDITO);
			AddParameter(cmd, "PROCESADORA_ID",
				value.IsPROCESADORA_IDNull ? DBNull.Value : (object)value.PROCESADORA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PROCESADORAS_TARJETA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PROCESADORAS_TARJETA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROCESADORAS_TARJETARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PROCESADORAS_TARJETARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PROCESADORAS_TARJETA</c> table using
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
		/// Deletes records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table using the 
		/// <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCESADORA_ID(decimal procesadora_id)
		{
			return DeleteByPROCESADORA_ID(procesadora_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table using the 
		/// <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <param name="procesadora_idNull">true if the method ignores the procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCESADORA_ID(decimal procesadora_id, bool procesadora_idNull)
		{
			return CreateDeleteByPROCESADORA_IDCommand(procesadora_id, procesadora_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CCTE_PROC_TAR_ENT_PROCESADORAID</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <param name="procesadora_idNull">true if the method ignores the procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROCESADORA_IDCommand(decimal procesadora_id, bool procesadora_idNull)
		{
			string whereSql = "";
			if(procesadora_idNull)
				whereSql += "PROCESADORA_ID IS NULL";
			else
				whereSql += "PROCESADORA_ID=" + _db.CreateSqlParameterName("PROCESADORA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!procesadora_idNull)
				AddParameter(cmd, "PROCESADORA_ID", procesadora_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table using the 
		/// <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUENTA_CORRIENTE_BANCARIA_ID(decimal cuenta_corriente_bancaria_id)
		{
			return DeleteByCUENTA_CORRIENTE_BANCARIA_ID(cuenta_corriente_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table using the 
		/// <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cuenta_corriente_bancaria_idNull">true if the method ignores the cuenta_corriente_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUENTA_CORRIENTE_BANCARIA_ID(decimal cuenta_corriente_bancaria_id, bool cuenta_corriente_bancaria_idNull)
		{
			return CreateDeleteByCUENTA_CORRIENTE_BANCARIA_IDCommand(cuenta_corriente_bancaria_id, cuenta_corriente_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROC_TARJ_CTABANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cuenta_corriente_bancaria_id">The <c>CUENTA_CORRIENTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cuenta_corriente_bancaria_idNull">true if the method ignores the cuenta_corriente_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCUENTA_CORRIENTE_BANCARIA_IDCommand(decimal cuenta_corriente_bancaria_id, bool cuenta_corriente_bancaria_idNull)
		{
			string whereSql = "";
			if(cuenta_corriente_bancaria_idNull)
				whereSql += "CUENTA_CORRIENTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CUENTA_CORRIENTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CUENTA_CORRIENTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cuenta_corriente_bancaria_idNull)
				AddParameter(cmd, "CUENTA_CORRIENTE_BANCARIA_ID", cuenta_corriente_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_PROCESADORAS_TARJETA</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PROCESADORAS_TARJETA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PROCESADORAS_TARJETA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		protected CTACTE_PROCESADORAS_TARJETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		protected CTACTE_PROCESADORAS_TARJETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PROCESADORAS_TARJETARow"/> objects.</returns>
		protected virtual CTACTE_PROCESADORAS_TARJETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int cuenta_corriente_bancaria_idColumnIndex = reader.GetOrdinal("CUENTA_CORRIENTE_BANCARIA_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int es_tarjeta_creditoColumnIndex = reader.GetOrdinal("ES_TARJETA_CREDITO");
			int procesadora_idColumnIndex = reader.GetOrdinal("PROCESADORA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PROCESADORAS_TARJETARow record = new CTACTE_PROCESADORAS_TARJETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					if(!reader.IsDBNull(cuenta_corriente_bancaria_idColumnIndex))
						record.CUENTA_CORRIENTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cuenta_corriente_bancaria_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(es_tarjeta_creditoColumnIndex))
						record.ES_TARJETA_CREDITO = Convert.ToString(reader.GetValue(es_tarjeta_creditoColumnIndex));
					if(!reader.IsDBNull(procesadora_idColumnIndex))
						record.PROCESADORA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(procesadora_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PROCESADORAS_TARJETARow[])(recordList.ToArray(typeof(CTACTE_PROCESADORAS_TARJETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PROCESADORAS_TARJETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PROCESADORAS_TARJETARow"/> object.</returns>
		protected virtual CTACTE_PROCESADORAS_TARJETARow MapRow(DataRow row)
		{
			CTACTE_PROCESADORAS_TARJETARow mappedObject = new CTACTE_PROCESADORAS_TARJETARow();
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
			// Column "CUENTA_CORRIENTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CUENTA_CORRIENTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_CORRIENTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "ES_TARJETA_CREDITO"
			dataColumn = dataTable.Columns["ES_TARJETA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TARJETA_CREDITO = (string)row[dataColumn];
			// Column "PROCESADORA_ID"
			dataColumn = dataTable.Columns["PROCESADORA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PROCESADORAS_TARJETA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PROCESADORAS_TARJETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUENTA_CORRIENTE_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_TARJETA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PROCESADORA_ID", typeof(decimal));
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

				case "CUENTA_CORRIENTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_TARJETA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROCESADORA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PROCESADORAS_TARJETACollection_Base class
}  // End of namespace
