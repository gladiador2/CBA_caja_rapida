// <fileinfo name="CTB_CUENTASCollection_Base.cs">
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
	/// The base class for <see cref="CTB_CUENTASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_CUENTASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_CUENTASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_PLAN_CUENTA_IDColumnName = "CTB_PLAN_CUENTA_ID";
		public const string CTB_CUENTA_MADRE_IDColumnName = "CTB_CUENTA_MADRE_ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string NIVELColumnName = "NIVEL";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ASENTABLEColumnName = "ASENTABLE";
		public const string EDITABLEColumnName = "EDITABLE";
		public const string UTILIZARColumnName = "UTILIZAR";
		public const string CODIGO_BASEColumnName = "CODIGO_BASE";
		public const string DESGLOSARColumnName = "DESGLOSAR";
		public const string CTB_CLASIFICACION_CUENTAS_IDColumnName = "CTB_CLASIFICACION_CUENTAS_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_CUENTASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_CUENTASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_CUENTAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public virtual CTB_CUENTASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_CUENTAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_CUENTAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_CUENTASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_CUENTASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_CUENTASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_CUENTASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public CTB_CUENTASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTASRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public virtual CTB_CUENTASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_CUENTAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_CUENTASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_CUENTASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_CUENTASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_CUENTASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTASRow"/> objects 
		/// by the <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public CTB_CUENTASRow[] GetByCTB_CLASIFICACION_CUENTAS_ID(decimal ctb_clasificacion_cuentas_id)
		{
			return GetByCTB_CLASIFICACION_CUENTAS_ID(ctb_clasificacion_cuentas_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTASRow"/> objects 
		/// by the <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <param name="ctb_clasificacion_cuentas_idNull">true if the method ignores the ctb_clasificacion_cuentas_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public virtual CTB_CUENTASRow[] GetByCTB_CLASIFICACION_CUENTAS_ID(decimal ctb_clasificacion_cuentas_id, bool ctb_clasificacion_cuentas_idNull)
		{
			return MapRecords(CreateGetByCTB_CLASIFICACION_CUENTAS_IDCommand(ctb_clasificacion_cuentas_id, ctb_clasificacion_cuentas_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_CLASIFICACION_CUENTAS_IDAsDataTable(decimal ctb_clasificacion_cuentas_id)
		{
			return GetByCTB_CLASIFICACION_CUENTAS_IDAsDataTable(ctb_clasificacion_cuentas_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <param name="ctb_clasificacion_cuentas_idNull">true if the method ignores the ctb_clasificacion_cuentas_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_CLASIFICACION_CUENTAS_IDAsDataTable(decimal ctb_clasificacion_cuentas_id, bool ctb_clasificacion_cuentas_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_CLASIFICACION_CUENTAS_IDCommand(ctb_clasificacion_cuentas_id, ctb_clasificacion_cuentas_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <param name="ctb_clasificacion_cuentas_idNull">true if the method ignores the ctb_clasificacion_cuentas_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_CLASIFICACION_CUENTAS_IDCommand(decimal ctb_clasificacion_cuentas_id, bool ctb_clasificacion_cuentas_idNull)
		{
			string whereSql = "";
			if(ctb_clasificacion_cuentas_idNull)
				whereSql += "CTB_CLASIFICACION_CUENTAS_ID IS NULL";
			else
				whereSql += "CTB_CLASIFICACION_CUENTAS_ID=" + _db.CreateSqlParameterName("CTB_CLASIFICACION_CUENTAS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_clasificacion_cuentas_idNull)
				AddParameter(cmd, "CTB_CLASIFICACION_CUENTAS_ID", ctb_clasificacion_cuentas_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTASRow"/> objects 
		/// by the <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public CTB_CUENTASRow[] GetByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id)
		{
			return GetByCTB_CUENTA_MADRE_ID(ctb_cuenta_madre_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTASRow"/> objects 
		/// by the <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public virtual CTB_CUENTASRow[] GetByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			return MapRecords(CreateGetByCTB_CUENTA_MADRE_IDCommand(ctb_cuenta_madre_id, ctb_cuenta_madre_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_CUENTA_MADRE_IDAsDataTable(decimal ctb_cuenta_madre_id)
		{
			return GetByCTB_CUENTA_MADRE_IDAsDataTable(ctb_cuenta_madre_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_CUENTA_MADRE_IDAsDataTable(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_CUENTA_MADRE_IDCommand(ctb_cuenta_madre_id, ctb_cuenta_madre_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_CUENTA_MADRE_IDCommand(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			string whereSql = "";
			if(ctb_cuenta_madre_idNull)
				whereSql += "CTB_CUENTA_MADRE_ID IS NULL";
			else
				whereSql += "CTB_CUENTA_MADRE_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_cuenta_madre_idNull)
				AddParameter(cmd, "CTB_CUENTA_MADRE_ID", ctb_cuenta_madre_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTASRow"/> objects 
		/// by the <c>FK_CTB_CUENTAS_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		public virtual CTB_CUENTASRow[] GetByCTB_PLAN_CUENTA_ID(decimal ctb_plan_cuenta_id)
		{
			return MapRecords(CreateGetByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_CUENTAS_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_PLAN_CUENTA_IDAsDataTable(decimal ctb_plan_cuenta_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_CUENTAS_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_PLAN_CUENTA_IDCommand(decimal ctb_plan_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", ctb_plan_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_CUENTAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_CUENTASRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_CUENTASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_CUENTAS (" +
				"ID, " +
				"CTB_PLAN_CUENTA_ID, " +
				"CTB_CUENTA_MADRE_ID, " +
				"CODIGO, " +
				"NIVEL, " +
				"NOMBRE, " +
				"ASENTABLE, " +
				"EDITABLE, " +
				"UTILIZAR, " +
				"CODIGO_BASE, " +
				"DESGLOSAR, " +
				"CTB_CLASIFICACION_CUENTAS_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID") + ", " +
				_db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("NIVEL") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ASENTABLE") + ", " +
				_db.CreateSqlParameterName("EDITABLE") + ", " +
				_db.CreateSqlParameterName("UTILIZAR") + ", " +
				_db.CreateSqlParameterName("CODIGO_BASE") + ", " +
				_db.CreateSqlParameterName("DESGLOSAR") + ", " +
				_db.CreateSqlParameterName("CTB_CLASIFICACION_CUENTAS_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", value.CTB_PLAN_CUENTA_ID);
			AddParameter(cmd, "CTB_CUENTA_MADRE_ID",
				value.IsCTB_CUENTA_MADRE_IDNull ? DBNull.Value : (object)value.CTB_CUENTA_MADRE_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "NIVEL", value.NIVEL);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ASENTABLE", value.ASENTABLE);
			AddParameter(cmd, "EDITABLE", value.EDITABLE);
			AddParameter(cmd, "UTILIZAR", value.UTILIZAR);
			AddParameter(cmd, "CODIGO_BASE", value.CODIGO_BASE);
			AddParameter(cmd, "DESGLOSAR", value.DESGLOSAR);
			AddParameter(cmd, "CTB_CLASIFICACION_CUENTAS_ID",
				value.IsCTB_CLASIFICACION_CUENTAS_IDNull ? DBNull.Value : (object)value.CTB_CLASIFICACION_CUENTAS_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_CUENTAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_CUENTASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_CUENTASRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_CUENTAS SET " +
				"CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID") + ", " +
				"CTB_CUENTA_MADRE_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID") + ", " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"NIVEL=" + _db.CreateSqlParameterName("NIVEL") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ASENTABLE=" + _db.CreateSqlParameterName("ASENTABLE") + ", " +
				"EDITABLE=" + _db.CreateSqlParameterName("EDITABLE") + ", " +
				"UTILIZAR=" + _db.CreateSqlParameterName("UTILIZAR") + ", " +
				"CODIGO_BASE=" + _db.CreateSqlParameterName("CODIGO_BASE") + ", " +
				"DESGLOSAR=" + _db.CreateSqlParameterName("DESGLOSAR") + ", " +
				"CTB_CLASIFICACION_CUENTAS_ID=" + _db.CreateSqlParameterName("CTB_CLASIFICACION_CUENTAS_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", value.CTB_PLAN_CUENTA_ID);
			AddParameter(cmd, "CTB_CUENTA_MADRE_ID",
				value.IsCTB_CUENTA_MADRE_IDNull ? DBNull.Value : (object)value.CTB_CUENTA_MADRE_ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "NIVEL", value.NIVEL);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ASENTABLE", value.ASENTABLE);
			AddParameter(cmd, "EDITABLE", value.EDITABLE);
			AddParameter(cmd, "UTILIZAR", value.UTILIZAR);
			AddParameter(cmd, "CODIGO_BASE", value.CODIGO_BASE);
			AddParameter(cmd, "DESGLOSAR", value.DESGLOSAR);
			AddParameter(cmd, "CTB_CLASIFICACION_CUENTAS_ID",
				value.IsCTB_CLASIFICACION_CUENTAS_IDNull ? DBNull.Value : (object)value.CTB_CLASIFICACION_CUENTAS_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_CUENTAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_CUENTAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_CUENTAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_CUENTASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_CUENTASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_CUENTAS</c> table using
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
		/// Deletes records from the <c>CTB_CUENTAS</c> table using the 
		/// <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CLASIFICACION_CUENTAS_ID(decimal ctb_clasificacion_cuentas_id)
		{
			return DeleteByCTB_CLASIFICACION_CUENTAS_ID(ctb_clasificacion_cuentas_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_CUENTAS</c> table using the 
		/// <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <param name="ctb_clasificacion_cuentas_idNull">true if the method ignores the ctb_clasificacion_cuentas_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CLASIFICACION_CUENTAS_ID(decimal ctb_clasificacion_cuentas_id, bool ctb_clasificacion_cuentas_idNull)
		{
			return CreateDeleteByCTB_CLASIFICACION_CUENTAS_IDCommand(ctb_clasificacion_cuentas_id, ctb_clasificacion_cuentas_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_CLASIF_CUENTAS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_clasificacion_cuentas_id">The <c>CTB_CLASIFICACION_CUENTAS_ID</c> column value.</param>
		/// <param name="ctb_clasificacion_cuentas_idNull">true if the method ignores the ctb_clasificacion_cuentas_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_CLASIFICACION_CUENTAS_IDCommand(decimal ctb_clasificacion_cuentas_id, bool ctb_clasificacion_cuentas_idNull)
		{
			string whereSql = "";
			if(ctb_clasificacion_cuentas_idNull)
				whereSql += "CTB_CLASIFICACION_CUENTAS_ID IS NULL";
			else
				whereSql += "CTB_CLASIFICACION_CUENTAS_ID=" + _db.CreateSqlParameterName("CTB_CLASIFICACION_CUENTAS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_clasificacion_cuentas_idNull)
				AddParameter(cmd, "CTB_CLASIFICACION_CUENTAS_ID", ctb_clasificacion_cuentas_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_CUENTAS</c> table using the 
		/// <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id)
		{
			return DeleteByCTB_CUENTA_MADRE_ID(ctb_cuenta_madre_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_CUENTAS</c> table using the 
		/// <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_MADRE_ID(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			return CreateDeleteByCTB_CUENTA_MADRE_IDCommand(ctb_cuenta_madre_id, ctb_cuenta_madre_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_CUENTAS_CUENTA_MADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_madre_id">The <c>CTB_CUENTA_MADRE_ID</c> column value.</param>
		/// <param name="ctb_cuenta_madre_idNull">true if the method ignores the ctb_cuenta_madre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_CUENTA_MADRE_IDCommand(decimal ctb_cuenta_madre_id, bool ctb_cuenta_madre_idNull)
		{
			string whereSql = "";
			if(ctb_cuenta_madre_idNull)
				whereSql += "CTB_CUENTA_MADRE_ID IS NULL";
			else
				whereSql += "CTB_CUENTA_MADRE_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_MADRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_cuenta_madre_idNull)
				AddParameter(cmd, "CTB_CUENTA_MADRE_ID", ctb_cuenta_madre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_CUENTAS</c> table using the 
		/// <c>FK_CTB_CUENTAS_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_PLAN_CUENTA_ID(decimal ctb_plan_cuenta_id)
		{
			return CreateDeleteByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_CUENTAS_PLAN</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_PLAN_CUENTA_IDCommand(decimal ctb_plan_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", ctb_plan_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_CUENTAS</c> records that match the specified criteria.
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
		/// to delete <c>CTB_CUENTAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_CUENTAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_CUENTAS</c> table.
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
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		protected CTB_CUENTASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		protected CTB_CUENTASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_CUENTASRow"/> objects.</returns>
		protected virtual CTB_CUENTASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_plan_cuenta_idColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_ID");
			int ctb_cuenta_madre_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_MADRE_ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int nivelColumnIndex = reader.GetOrdinal("NIVEL");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int asentableColumnIndex = reader.GetOrdinal("ASENTABLE");
			int editableColumnIndex = reader.GetOrdinal("EDITABLE");
			int utilizarColumnIndex = reader.GetOrdinal("UTILIZAR");
			int codigo_baseColumnIndex = reader.GetOrdinal("CODIGO_BASE");
			int desglosarColumnIndex = reader.GetOrdinal("DESGLOSAR");
			int ctb_clasificacion_cuentas_idColumnIndex = reader.GetOrdinal("CTB_CLASIFICACION_CUENTAS_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_CUENTASRow record = new CTB_CUENTASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_plan_cuenta_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_cuenta_madre_idColumnIndex))
						record.CTB_CUENTA_MADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_madre_idColumnIndex)), 9);
					record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.NIVEL = Math.Round(Convert.ToDecimal(reader.GetValue(nivelColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ASENTABLE = Convert.ToString(reader.GetValue(asentableColumnIndex));
					record.EDITABLE = Convert.ToString(reader.GetValue(editableColumnIndex));
					record.UTILIZAR = Convert.ToString(reader.GetValue(utilizarColumnIndex));
					if(!reader.IsDBNull(codigo_baseColumnIndex))
						record.CODIGO_BASE = Convert.ToString(reader.GetValue(codigo_baseColumnIndex));
					record.DESGLOSAR = Convert.ToString(reader.GetValue(desglosarColumnIndex));
					if(!reader.IsDBNull(ctb_clasificacion_cuentas_idColumnIndex))
						record.CTB_CLASIFICACION_CUENTAS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_clasificacion_cuentas_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_CUENTASRow[])(recordList.ToArray(typeof(CTB_CUENTASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_CUENTASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_CUENTASRow"/> object.</returns>
		protected virtual CTB_CUENTASRow MapRow(DataRow row)
		{
			CTB_CUENTASRow mappedObject = new CTB_CUENTASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_MADRE_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_MADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_MADRE_ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "NIVEL"
			dataColumn = dataTable.Columns["NIVEL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ASENTABLE"
			dataColumn = dataTable.Columns["ASENTABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ASENTABLE = (string)row[dataColumn];
			// Column "EDITABLE"
			dataColumn = dataTable.Columns["EDITABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDITABLE = (string)row[dataColumn];
			// Column "UTILIZAR"
			dataColumn = dataTable.Columns["UTILIZAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.UTILIZAR = (string)row[dataColumn];
			// Column "CODIGO_BASE"
			dataColumn = dataTable.Columns["CODIGO_BASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BASE = (string)row[dataColumn];
			// Column "DESGLOSAR"
			dataColumn = dataTable.Columns["DESGLOSAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESGLOSAR = (string)row[dataColumn];
			// Column "CTB_CLASIFICACION_CUENTAS_ID"
			dataColumn = dataTable.Columns["CTB_CLASIFICACION_CUENTAS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CLASIFICACION_CUENTAS_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_CUENTAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_CUENTAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_MADRE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NIVEL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ASENTABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EDITABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UTILIZAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO_BASE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DESGLOSAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_CLASIFICACION_CUENTAS_ID", typeof(decimal));
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

				case "CTB_PLAN_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA_MADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NIVEL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ASENTABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDITABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "UTILIZAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CODIGO_BASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESGLOSAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTB_CLASIFICACION_CUENTAS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_CUENTASCollection_Base class
}  // End of namespace
