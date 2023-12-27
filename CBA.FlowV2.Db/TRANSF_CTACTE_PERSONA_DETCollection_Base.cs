// <fileinfo name="TRANSF_CTACTE_PERSONA_DETCollection_Base.cs">
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
	/// The base class for <see cref="TRANSF_CTACTE_PERSONA_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSF_CTACTE_PERSONA_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSF_CTACTE_PERSONA_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TRANSF_CTACTE_PERSONA_IDColumnName = "TRANSF_CTACTE_PERSONA_ID";
		public const string CTACTE_PERSONA_ORIG_IDColumnName = "CTACTE_PERSONA_ORIG_ID";
		public const string MONTO_CREDITO_ORIGENColumnName = "MONTO_CREDITO_ORIGEN";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CTACTE_PERSONA_DEST_IDColumnName = "CTACTE_PERSONA_DEST_ID";
		public const string MONTO_CREDITO_DESTINOColumnName = "MONTO_CREDITO_DESTINO";
		public const string MONTO_DEBITO_ORIGENColumnName = "MONTO_DEBITO_ORIGEN";
		public const string MONTO_DEBITO_DESTINOColumnName = "MONTO_DEBITO_DESTINO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSF_CTACTE_PERSONA_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSF_CTACTE_PERSONA_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERSONA_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSF_CTACTE_PERSONA_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSF_CTACTE_PERSONA_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public TRANSF_CTACTE_PERSONA_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERSONA_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSF_CTACTE_PERSONA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRANSF_CTACTE_PERSONA_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TRANSF_CTACTE_PERSONA_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public TRANSF_CTACTE_PERSONA_DETRow[] GetByCTACTE_PERSONA_DEST_ID(decimal ctacte_persona_dest_id)
		{
			return GetByCTACTE_PERSONA_DEST_ID(ctacte_persona_dest_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <param name="ctacte_persona_dest_idNull">true if the method ignores the ctacte_persona_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERSONA_DETRow[] GetByCTACTE_PERSONA_DEST_ID(decimal ctacte_persona_dest_id, bool ctacte_persona_dest_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_DEST_IDCommand(ctacte_persona_dest_id, ctacte_persona_dest_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PERSONA_DEST_IDAsDataTable(decimal ctacte_persona_dest_id)
		{
			return GetByCTACTE_PERSONA_DEST_IDAsDataTable(ctacte_persona_dest_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <param name="ctacte_persona_dest_idNull">true if the method ignores the ctacte_persona_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_DEST_IDAsDataTable(decimal ctacte_persona_dest_id, bool ctacte_persona_dest_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_DEST_IDCommand(ctacte_persona_dest_id, ctacte_persona_dest_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <param name="ctacte_persona_dest_idNull">true if the method ignores the ctacte_persona_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_DEST_IDCommand(decimal ctacte_persona_dest_id, bool ctacte_persona_dest_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_dest_idNull)
				whereSql += "CTACTE_PERSONA_DEST_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_DEST_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_DEST_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_persona_dest_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_DEST_ID", ctacte_persona_dest_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERSONA_DETRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAN_CTACTE_PERS_D_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_TR_P</c> foreign key.
		/// </summary>
		/// <param name="transf_ctacte_persona_id">The <c>TRANSF_CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERSONA_DETRow[] GetByTRANSF_CTACTE_PERSONA_ID(decimal transf_ctacte_persona_id)
		{
			return MapRecords(CreateGetByTRANSF_CTACTE_PERSONA_IDCommand(transf_ctacte_persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAN_CTACTE_PERS_D_TR_P</c> foreign key.
		/// </summary>
		/// <param name="transf_ctacte_persona_id">The <c>TRANSF_CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSF_CTACTE_PERSONA_IDAsDataTable(decimal transf_ctacte_persona_id)
		{
			return MapRecordsToDataTable(CreateGetByTRANSF_CTACTE_PERSONA_IDCommand(transf_ctacte_persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAN_CTACTE_PERS_D_TR_P</c> foreign key.
		/// </summary>
		/// <param name="transf_ctacte_persona_id">The <c>TRANSF_CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSF_CTACTE_PERSONA_IDCommand(decimal transf_ctacte_persona_id)
		{
			string whereSql = "";
			whereSql += "TRANSF_CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSF_CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TRANSF_CTACTE_PERSONA_ID", transf_ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects 
		/// by the <c>FK_TRAN_CTACTE_PERSONA_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_orig_id">The <c>CTACTE_PERSONA_ORIG_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERSONA_DETRow[] GetByCTACTE_PERSONA_ORIG_ID(decimal ctacte_persona_orig_id)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_ORIG_IDCommand(ctacte_persona_orig_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAN_CTACTE_PERSONA_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_orig_id">The <c>CTACTE_PERSONA_ORIG_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_ORIG_IDAsDataTable(decimal ctacte_persona_orig_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_ORIG_IDCommand(ctacte_persona_orig_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAN_CTACTE_PERSONA_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_orig_id">The <c>CTACTE_PERSONA_ORIG_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_ORIG_IDCommand(decimal ctacte_persona_orig_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PERSONA_ORIG_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ORIG_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_PERSONA_ORIG_ID", ctacte_persona_orig_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> object to be inserted.</param>
		public virtual void Insert(TRANSF_CTACTE_PERSONA_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRANSF_CTACTE_PERSONA_DET (" +
				"ID, " +
				"TRANSF_CTACTE_PERSONA_ID, " +
				"CTACTE_PERSONA_ORIG_ID, " +
				"MONTO_CREDITO_ORIGEN, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"OBSERVACION, " +
				"CTACTE_PERSONA_DEST_ID, " +
				"MONTO_CREDITO_DESTINO, " +
				"MONTO_DEBITO_ORIGEN, " +
				"MONTO_DEBITO_DESTINO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TRANSF_CTACTE_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_ORIG_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_CREDITO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_DEST_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_CREDITO_DESTINO") + ", " +
				_db.CreateSqlParameterName("MONTO_DEBITO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_DEBITO_DESTINO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TRANSF_CTACTE_PERSONA_ID", value.TRANSF_CTACTE_PERSONA_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ORIG_ID", value.CTACTE_PERSONA_ORIG_ID);
			AddParameter(cmd, "MONTO_CREDITO_ORIGEN", value.MONTO_CREDITO_ORIGEN);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_PERSONA_DEST_ID",
				value.IsCTACTE_PERSONA_DEST_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_DEST_ID);
			AddParameter(cmd, "MONTO_CREDITO_DESTINO",
				value.IsMONTO_CREDITO_DESTINONull ? DBNull.Value : (object)value.MONTO_CREDITO_DESTINO);
			AddParameter(cmd, "MONTO_DEBITO_ORIGEN", value.MONTO_DEBITO_ORIGEN);
			AddParameter(cmd, "MONTO_DEBITO_DESTINO",
				value.IsMONTO_DEBITO_DESTINONull ? DBNull.Value : (object)value.MONTO_DEBITO_DESTINO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSF_CTACTE_PERSONA_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRANSF_CTACTE_PERSONA_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRANSF_CTACTE_PERSONA_DET SET " +
				"TRANSF_CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSF_CTACTE_PERSONA_ID") + ", " +
				"CTACTE_PERSONA_ORIG_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ORIG_ID") + ", " +
				"MONTO_CREDITO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_CREDITO_ORIGEN") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CTACTE_PERSONA_DEST_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_DEST_ID") + ", " +
				"MONTO_CREDITO_DESTINO=" + _db.CreateSqlParameterName("MONTO_CREDITO_DESTINO") + ", " +
				"MONTO_DEBITO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_DEBITO_ORIGEN") + ", " +
				"MONTO_DEBITO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DEBITO_DESTINO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TRANSF_CTACTE_PERSONA_ID", value.TRANSF_CTACTE_PERSONA_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ORIG_ID", value.CTACTE_PERSONA_ORIG_ID);
			AddParameter(cmd, "MONTO_CREDITO_ORIGEN", value.MONTO_CREDITO_ORIGEN);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_PERSONA_DEST_ID",
				value.IsCTACTE_PERSONA_DEST_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_DEST_ID);
			AddParameter(cmd, "MONTO_CREDITO_DESTINO",
				value.IsMONTO_CREDITO_DESTINONull ? DBNull.Value : (object)value.MONTO_CREDITO_DESTINO);
			AddParameter(cmd, "MONTO_DEBITO_ORIGEN", value.MONTO_DEBITO_ORIGEN);
			AddParameter(cmd, "MONTO_DEBITO_DESTINO",
				value.IsMONTO_DEBITO_DESTINONull ? DBNull.Value : (object)value.MONTO_DEBITO_DESTINO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRANSF_CTACTE_PERSONA_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRANSF_CTACTE_PERSONA_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRANSF_CTACTE_PERSONA_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRANSF_CTACTE_PERSONA_DET</c> table using
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
		/// Deletes records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table using the 
		/// <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_DEST_ID(decimal ctacte_persona_dest_id)
		{
			return DeleteByCTACTE_PERSONA_DEST_ID(ctacte_persona_dest_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table using the 
		/// <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <param name="ctacte_persona_dest_idNull">true if the method ignores the ctacte_persona_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_DEST_ID(decimal ctacte_persona_dest_id, bool ctacte_persona_dest_idNull)
		{
			return CreateDeleteByCTACTE_PERSONA_DEST_IDCommand(ctacte_persona_dest_id, ctacte_persona_dest_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAN_CTACTE_PERS_D_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_dest_id">The <c>CTACTE_PERSONA_DEST_ID</c> column value.</param>
		/// <param name="ctacte_persona_dest_idNull">true if the method ignores the ctacte_persona_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_DEST_IDCommand(decimal ctacte_persona_dest_id, bool ctacte_persona_dest_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_dest_idNull)
				whereSql += "CTACTE_PERSONA_DEST_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_DEST_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_DEST_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_persona_dest_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_DEST_ID", ctacte_persona_dest_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table using the 
		/// <c>FK_TRAN_CTACTE_PERS_D_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAN_CTACTE_PERS_D_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table using the 
		/// <c>FK_TRAN_CTACTE_PERS_D_TR_P</c> foreign key.
		/// </summary>
		/// <param name="transf_ctacte_persona_id">The <c>TRANSF_CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSF_CTACTE_PERSONA_ID(decimal transf_ctacte_persona_id)
		{
			return CreateDeleteByTRANSF_CTACTE_PERSONA_IDCommand(transf_ctacte_persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAN_CTACTE_PERS_D_TR_P</c> foreign key.
		/// </summary>
		/// <param name="transf_ctacte_persona_id">The <c>TRANSF_CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSF_CTACTE_PERSONA_IDCommand(decimal transf_ctacte_persona_id)
		{
			string whereSql = "";
			whereSql += "TRANSF_CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSF_CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TRANSF_CTACTE_PERSONA_ID", transf_ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table using the 
		/// <c>FK_TRAN_CTACTE_PERSONA_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_orig_id">The <c>CTACTE_PERSONA_ORIG_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ORIG_ID(decimal ctacte_persona_orig_id)
		{
			return CreateDeleteByCTACTE_PERSONA_ORIG_IDCommand(ctacte_persona_orig_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAN_CTACTE_PERSONA_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_orig_id">The <c>CTACTE_PERSONA_ORIG_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_ORIG_IDCommand(decimal ctacte_persona_orig_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PERSONA_ORIG_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ORIG_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_PERSONA_ORIG_ID", ctacte_persona_orig_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TRANSF_CTACTE_PERSONA_DET</c> records that match the specified criteria.
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
		/// to delete <c>TRANSF_CTACTE_PERSONA_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRANSF_CTACTE_PERSONA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		protected TRANSF_CTACTE_PERSONA_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		protected TRANSF_CTACTE_PERSONA_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> objects.</returns>
		protected virtual TRANSF_CTACTE_PERSONA_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int transf_ctacte_persona_idColumnIndex = reader.GetOrdinal("TRANSF_CTACTE_PERSONA_ID");
			int ctacte_persona_orig_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ORIG_ID");
			int monto_credito_origenColumnIndex = reader.GetOrdinal("MONTO_CREDITO_ORIGEN");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int ctacte_persona_dest_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_DEST_ID");
			int monto_credito_destinoColumnIndex = reader.GetOrdinal("MONTO_CREDITO_DESTINO");
			int monto_debito_origenColumnIndex = reader.GetOrdinal("MONTO_DEBITO_ORIGEN");
			int monto_debito_destinoColumnIndex = reader.GetOrdinal("MONTO_DEBITO_DESTINO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSF_CTACTE_PERSONA_DETRow record = new TRANSF_CTACTE_PERSONA_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TRANSF_CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transf_ctacte_persona_idColumnIndex)), 9);
					record.CTACTE_PERSONA_ORIG_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_orig_idColumnIndex)), 9);
					record.MONTO_CREDITO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_credito_origenColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(ctacte_persona_dest_idColumnIndex))
						record.CTACTE_PERSONA_DEST_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_dest_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_credito_destinoColumnIndex))
						record.MONTO_CREDITO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_credito_destinoColumnIndex)), 9);
					record.MONTO_DEBITO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_debito_origenColumnIndex)), 9);
					if(!reader.IsDBNull(monto_debito_destinoColumnIndex))
						record.MONTO_DEBITO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_debito_destinoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSF_CTACTE_PERSONA_DETRow[])(recordList.ToArray(typeof(TRANSF_CTACTE_PERSONA_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSF_CTACTE_PERSONA_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSF_CTACTE_PERSONA_DETRow"/> object.</returns>
		protected virtual TRANSF_CTACTE_PERSONA_DETRow MapRow(DataRow row)
		{
			TRANSF_CTACTE_PERSONA_DETRow mappedObject = new TRANSF_CTACTE_PERSONA_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TRANSF_CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSF_CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSF_CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ORIG_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ORIG_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ORIG_ID = (decimal)row[dataColumn];
			// Column "MONTO_CREDITO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_CREDITO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CREDITO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CTACTE_PERSONA_DEST_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_DEST_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_DEST_ID = (decimal)row[dataColumn];
			// Column "MONTO_CREDITO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_CREDITO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CREDITO_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_DEBITO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_DEBITO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DEBITO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DEBITO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DEBITO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DEBITO_DESTINO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSF_CTACTE_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSF_CTACTE_PERSONA_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRANSF_CTACTE_PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ORIG_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CREDITO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_DEST_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_CREDITO_DESTINO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_DEBITO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DEBITO_DESTINO", typeof(decimal));
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

				case "TRANSF_CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_ORIG_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CREDITO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PERSONA_DEST_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CREDITO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DEBITO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DEBITO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSF_CTACTE_PERSONA_DETCollection_Base class
}  // End of namespace
