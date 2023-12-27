// <fileinfo name="TRANSACCIONES_CIERRES_CASOSCollection_Base.cs">
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
	/// The base class for <see cref="TRANSACCIONES_CIERRES_CASOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSACCIONES_CIERRES_CASOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSACCIONES_CIERRES_CASOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TRANSACCION_CIERRE_IDColumnName = "TRANSACCION_CIERRE_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string COMISION_TOTALColumnName = "COMISION_TOTAL";
		public const string COMISION_RECAUDADORColumnName = "COMISION_RECAUDADOR";
		public const string COMISION_PROCESADORColumnName = "COMISION_PROCESADOR";
		public const string COMISION_CLEARINGColumnName = "COMISION_CLEARING";
		public const string COMISION_OTROColumnName = "COMISION_OTRO";
		public const string COMISION_REDColumnName = "COMISION_RED";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSACCIONES_CIERRES_CASOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSACCIONES_CIERRES_CASOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public virtual TRANSACCIONES_CIERRES_CASOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSACCIONES_CIERRES_CASOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSACCIONES_CIERRES_CASOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public TRANSACCIONES_CIERRES_CASOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public virtual TRANSACCIONES_CIERRES_CASOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSACCIONES_CIERRES_CASOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRANSACCIONES_CIERRES_CASOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TRANSACCIONES_CIERRES_CASOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects 
		/// by the <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public TRANSACCIONES_CIERRES_CASOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects 
		/// by the <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public virtual TRANSACCIONES_CIERRES_CASOSRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects 
		/// by the <c>FK_TRANSAC_CIERRES_CAS_TRANS_C</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public virtual TRANSACCIONES_CIERRES_CASOSRow[] GetByTRANSACCION_CIERRE_ID(decimal transaccion_cierre_id)
		{
			return MapRecords(CreateGetByTRANSACCION_CIERRE_IDCommand(transaccion_cierre_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSAC_CIERRES_CAS_TRANS_C</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSACCION_CIERRE_IDAsDataTable(decimal transaccion_cierre_id)
		{
			return MapRecordsToDataTable(CreateGetByTRANSACCION_CIERRE_IDCommand(transaccion_cierre_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSAC_CIERRES_CAS_TRANS_C</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSACCION_CIERRE_IDCommand(decimal transaccion_cierre_id)
		{
			string whereSql = "";
			whereSql += "TRANSACCION_CIERRE_ID=" + _db.CreateSqlParameterName("TRANSACCION_CIERRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TRANSACCION_CIERRE_ID", transaccion_cierre_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects 
		/// by the <c>FK_TRANSAC_CIERRES_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public virtual TRANSACCIONES_CIERRES_CASOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSAC_CIERRES_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSAC_CIERRES_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects 
		/// by the <c>FK_TRANSAC_CIERRES_CASOS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		public virtual TRANSACCIONES_CIERRES_CASOSRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSAC_CIERRES_CASOS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSAC_CIERRES_CASOS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> object to be inserted.</param>
		public virtual void Insert(TRANSACCIONES_CIERRES_CASOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRANSACCIONES_CIERRES_CASOS (" +
				"ID, " +
				"TRANSACCION_CIERRE_ID, " +
				"FLUJO_ID, " +
				"CASO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"MONTO_TOTAL, " +
				"COMISION_TOTAL, " +
				"COMISION_RECAUDADOR, " +
				"COMISION_PROCESADOR, " +
				"COMISION_CLEARING, " +
				"COMISION_OTRO, " +
				"COMISION_RED" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TRANSACCION_CIERRE_ID") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("COMISION_TOTAL") + ", " +
				_db.CreateSqlParameterName("COMISION_RECAUDADOR") + ", " +
				_db.CreateSqlParameterName("COMISION_PROCESADOR") + ", " +
				_db.CreateSqlParameterName("COMISION_CLEARING") + ", " +
				_db.CreateSqlParameterName("COMISION_OTRO") + ", " +
				_db.CreateSqlParameterName("COMISION_RED") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TRANSACCION_CIERRE_ID", value.TRANSACCION_CIERRE_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "MONTO_TOTAL",
				value.IsMONTO_TOTALNull ? DBNull.Value : (object)value.MONTO_TOTAL);
			AddParameter(cmd, "COMISION_TOTAL",
				value.IsCOMISION_TOTALNull ? DBNull.Value : (object)value.COMISION_TOTAL);
			AddParameter(cmd, "COMISION_RECAUDADOR",
				value.IsCOMISION_RECAUDADORNull ? DBNull.Value : (object)value.COMISION_RECAUDADOR);
			AddParameter(cmd, "COMISION_PROCESADOR",
				value.IsCOMISION_PROCESADORNull ? DBNull.Value : (object)value.COMISION_PROCESADOR);
			AddParameter(cmd, "COMISION_CLEARING",
				value.IsCOMISION_CLEARINGNull ? DBNull.Value : (object)value.COMISION_CLEARING);
			AddParameter(cmd, "COMISION_OTRO",
				value.IsCOMISION_OTRONull ? DBNull.Value : (object)value.COMISION_OTRO);
			AddParameter(cmd, "COMISION_RED",
				value.IsCOMISION_REDNull ? DBNull.Value : (object)value.COMISION_RED);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSACCIONES_CIERRES_CASOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRANSACCIONES_CIERRES_CASOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRANSACCIONES_CIERRES_CASOS SET " +
				"TRANSACCION_CIERRE_ID=" + _db.CreateSqlParameterName("TRANSACCION_CIERRE_ID") + ", " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"COMISION_TOTAL=" + _db.CreateSqlParameterName("COMISION_TOTAL") + ", " +
				"COMISION_RECAUDADOR=" + _db.CreateSqlParameterName("COMISION_RECAUDADOR") + ", " +
				"COMISION_PROCESADOR=" + _db.CreateSqlParameterName("COMISION_PROCESADOR") + ", " +
				"COMISION_CLEARING=" + _db.CreateSqlParameterName("COMISION_CLEARING") + ", " +
				"COMISION_OTRO=" + _db.CreateSqlParameterName("COMISION_OTRO") + ", " +
				"COMISION_RED=" + _db.CreateSqlParameterName("COMISION_RED") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TRANSACCION_CIERRE_ID", value.TRANSACCION_CIERRE_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "MONTO_TOTAL",
				value.IsMONTO_TOTALNull ? DBNull.Value : (object)value.MONTO_TOTAL);
			AddParameter(cmd, "COMISION_TOTAL",
				value.IsCOMISION_TOTALNull ? DBNull.Value : (object)value.COMISION_TOTAL);
			AddParameter(cmd, "COMISION_RECAUDADOR",
				value.IsCOMISION_RECAUDADORNull ? DBNull.Value : (object)value.COMISION_RECAUDADOR);
			AddParameter(cmd, "COMISION_PROCESADOR",
				value.IsCOMISION_PROCESADORNull ? DBNull.Value : (object)value.COMISION_PROCESADOR);
			AddParameter(cmd, "COMISION_CLEARING",
				value.IsCOMISION_CLEARINGNull ? DBNull.Value : (object)value.COMISION_CLEARING);
			AddParameter(cmd, "COMISION_OTRO",
				value.IsCOMISION_OTRONull ? DBNull.Value : (object)value.COMISION_OTRO);
			AddParameter(cmd, "COMISION_RED",
				value.IsCOMISION_REDNull ? DBNull.Value : (object)value.COMISION_RED);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRANSACCIONES_CIERRES_CASOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRANSACCIONES_CIERRES_CASOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRANSACCIONES_CIERRES_CASOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRANSACCIONES_CIERRES_CASOS</c> table using
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
		/// Deletes records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table using the 
		/// <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table using the 
		/// <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id, moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSAC_CIERRES_CAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table using the 
		/// <c>FK_TRANSAC_CIERRES_CAS_TRANS_C</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSACCION_CIERRE_ID(decimal transaccion_cierre_id)
		{
			return CreateDeleteByTRANSACCION_CIERRE_IDCommand(transaccion_cierre_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSAC_CIERRES_CAS_TRANS_C</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSACCION_CIERRE_IDCommand(decimal transaccion_cierre_id)
		{
			string whereSql = "";
			whereSql += "TRANSACCION_CIERRE_ID=" + _db.CreateSqlParameterName("TRANSACCION_CIERRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TRANSACCION_CIERRE_ID", transaccion_cierre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table using the 
		/// <c>FK_TRANSAC_CIERRES_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSAC_CIERRES_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table using the 
		/// <c>FK_TRANSAC_CIERRES_CASOS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSAC_CIERRES_CASOS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TRANSACCIONES_CIERRES_CASOS</c> records that match the specified criteria.
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
		/// to delete <c>TRANSACCIONES_CIERRES_CASOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRANSACCIONES_CIERRES_CASOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
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
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		protected TRANSACCIONES_CIERRES_CASOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		protected TRANSACCIONES_CIERRES_CASOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> objects.</returns>
		protected virtual TRANSACCIONES_CIERRES_CASOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int transaccion_cierre_idColumnIndex = reader.GetOrdinal("TRANSACCION_CIERRE_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int comision_totalColumnIndex = reader.GetOrdinal("COMISION_TOTAL");
			int comision_recaudadorColumnIndex = reader.GetOrdinal("COMISION_RECAUDADOR");
			int comision_procesadorColumnIndex = reader.GetOrdinal("COMISION_PROCESADOR");
			int comision_clearingColumnIndex = reader.GetOrdinal("COMISION_CLEARING");
			int comision_otroColumnIndex = reader.GetOrdinal("COMISION_OTRO");
			int comision_redColumnIndex = reader.GetOrdinal("COMISION_RED");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSACCIONES_CIERRES_CASOSRow record = new TRANSACCIONES_CIERRES_CASOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TRANSACCION_CIERRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transaccion_cierre_idColumnIndex)), 9);
					record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(monto_totalColumnIndex))
						record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					if(!reader.IsDBNull(comision_totalColumnIndex))
						record.COMISION_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(comision_totalColumnIndex)), 9);
					if(!reader.IsDBNull(comision_recaudadorColumnIndex))
						record.COMISION_RECAUDADOR = Math.Round(Convert.ToDecimal(reader.GetValue(comision_recaudadorColumnIndex)), 9);
					if(!reader.IsDBNull(comision_procesadorColumnIndex))
						record.COMISION_PROCESADOR = Math.Round(Convert.ToDecimal(reader.GetValue(comision_procesadorColumnIndex)), 9);
					if(!reader.IsDBNull(comision_clearingColumnIndex))
						record.COMISION_CLEARING = Math.Round(Convert.ToDecimal(reader.GetValue(comision_clearingColumnIndex)), 9);
					if(!reader.IsDBNull(comision_otroColumnIndex))
						record.COMISION_OTRO = Math.Round(Convert.ToDecimal(reader.GetValue(comision_otroColumnIndex)), 9);
					if(!reader.IsDBNull(comision_redColumnIndex))
						record.COMISION_RED = Math.Round(Convert.ToDecimal(reader.GetValue(comision_redColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSACCIONES_CIERRES_CASOSRow[])(recordList.ToArray(typeof(TRANSACCIONES_CIERRES_CASOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSACCIONES_CIERRES_CASOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSACCIONES_CIERRES_CASOSRow"/> object.</returns>
		protected virtual TRANSACCIONES_CIERRES_CASOSRow MapRow(DataRow row)
		{
			TRANSACCIONES_CIERRES_CASOSRow mappedObject = new TRANSACCIONES_CIERRES_CASOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TRANSACCION_CIERRE_ID"
			dataColumn = dataTable.Columns["TRANSACCION_CIERRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSACCION_CIERRE_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "COMISION_TOTAL"
			dataColumn = dataTable.Columns["COMISION_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_TOTAL = (decimal)row[dataColumn];
			// Column "COMISION_RECAUDADOR"
			dataColumn = dataTable.Columns["COMISION_RECAUDADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_RECAUDADOR = (decimal)row[dataColumn];
			// Column "COMISION_PROCESADOR"
			dataColumn = dataTable.Columns["COMISION_PROCESADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_PROCESADOR = (decimal)row[dataColumn];
			// Column "COMISION_CLEARING"
			dataColumn = dataTable.Columns["COMISION_CLEARING"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_CLEARING = (decimal)row[dataColumn];
			// Column "COMISION_OTRO"
			dataColumn = dataTable.Columns["COMISION_OTRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_OTRO = (decimal)row[dataColumn];
			// Column "COMISION_RED"
			dataColumn = dataTable.Columns["COMISION_RED"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_RED = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSACCIONES_CIERRES_CASOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSACCIONES_CIERRES_CASOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRANSACCION_CIERRE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_RECAUDADOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_PROCESADOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_CLEARING", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_OTRO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_RED", typeof(decimal));
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

				case "TRANSACCION_CIERRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_RECAUDADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_PROCESADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_CLEARING":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_OTRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_RED":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSACCIONES_CIERRES_CASOSCollection_Base class
}  // End of namespace
