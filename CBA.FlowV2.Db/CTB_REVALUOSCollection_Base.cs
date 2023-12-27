// <fileinfo name="CTB_REVALUOSCollection_Base.cs">
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
	/// The base class for <see cref="CTB_REVALUOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_REVALUOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_REVALUOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string FECHA_REVALUOColumnName = "FECHA_REVALUO";
		public const string COEFICIENTEColumnName = "COEFICIENTE";
		public const string CTB_REVALUO_ANTERIOR_IDColumnName = "CTB_REVALUO_ANTERIOR_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string VIDA_UTILColumnName = "VIDA_UTIL";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONTOColumnName = "MONTO";
		public const string VALOR_FISCAL_REVColumnName = "VALOR_FISCAL_REV";
		public const string VALOR_FISCAL_NET_CIERREColumnName = "VALOR_FISCAL_NET_CIERRE";
		public const string CUOTA_FISCAL_DEPR_ANUALColumnName = "CUOTA_FISCAL_DEPR_ANUAL";
		public const string DEPREC_FISCAL_ACUMColumnName = "DEPREC_FISCAL_ACUM";
		public const string VIDA_UTIL_RESTANTEColumnName = "VIDA_UTIL_RESTANTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_REVALUOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_REVALUOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_REVALUOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		public virtual CTB_REVALUOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_REVALUOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_REVALUOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_REVALUOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_REVALUOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_REVALUOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_REVALUOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_REVALUOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		public CTB_REVALUOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_REVALUOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		public virtual CTB_REVALUOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_REVALUOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_REVALUOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_REVALUOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_REVALUOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_REVALUOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_REVALUOSRow"/> objects 
		/// by the <c>FK_CTB_REVALUO_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		public virtual CTB_REVALUOSRow[] GetByACTIVO_ID(decimal activo_id)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_REVALUO_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_IDCommand(activo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_REVALUO_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_IDCommand(decimal activo_id)
		{
			string whereSql = "";
			whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_REVALUOSRow"/> objects 
		/// by the <c>FK_CTB_REVALUO_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		public virtual CTB_REVALUOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_REVALUO_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_REVALUO_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="CTB_REVALUOSRow"/> objects 
		/// by the <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		public CTB_REVALUOSRow[] GetByCTB_REVALUO_ANTERIOR_ID(decimal ctb_revaluo_anterior_id)
		{
			return GetByCTB_REVALUO_ANTERIOR_ID(ctb_revaluo_anterior_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_REVALUOSRow"/> objects 
		/// by the <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctb_revaluo_anterior_idNull">true if the method ignores the ctb_revaluo_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		public virtual CTB_REVALUOSRow[] GetByCTB_REVALUO_ANTERIOR_ID(decimal ctb_revaluo_anterior_id, bool ctb_revaluo_anterior_idNull)
		{
			return MapRecords(CreateGetByCTB_REVALUO_ANTERIOR_IDCommand(ctb_revaluo_anterior_id, ctb_revaluo_anterior_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_REVALUO_ANTERIOR_IDAsDataTable(decimal ctb_revaluo_anterior_id)
		{
			return GetByCTB_REVALUO_ANTERIOR_IDAsDataTable(ctb_revaluo_anterior_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctb_revaluo_anterior_idNull">true if the method ignores the ctb_revaluo_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_REVALUO_ANTERIOR_IDAsDataTable(decimal ctb_revaluo_anterior_id, bool ctb_revaluo_anterior_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_REVALUO_ANTERIOR_IDCommand(ctb_revaluo_anterior_id, ctb_revaluo_anterior_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctb_revaluo_anterior_idNull">true if the method ignores the ctb_revaluo_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_REVALUO_ANTERIOR_IDCommand(decimal ctb_revaluo_anterior_id, bool ctb_revaluo_anterior_idNull)
		{
			string whereSql = "";
			if(ctb_revaluo_anterior_idNull)
				whereSql += "CTB_REVALUO_ANTERIOR_ID IS NULL";
			else
				whereSql += "CTB_REVALUO_ANTERIOR_ID=" + _db.CreateSqlParameterName("CTB_REVALUO_ANTERIOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_revaluo_anterior_idNull)
				AddParameter(cmd, "CTB_REVALUO_ANTERIOR_ID", ctb_revaluo_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_REVALUOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_REVALUOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_REVALUOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_REVALUOS (" +
				"ID, " +
				"ACTIVO_ID, " +
				"FECHA_REVALUO, " +
				"COEFICIENTE, " +
				"CTB_REVALUO_ANTERIOR_ID, " +
				"ESTADO, " +
				"VIDA_UTIL, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"MONTO, " +
				"VALOR_FISCAL_REV, " +
				"VALOR_FISCAL_NET_CIERRE, " +
				"CUOTA_FISCAL_DEPR_ANUAL, " +
				"DEPREC_FISCAL_ACUM, " +
				"VIDA_UTIL_RESTANTE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_REVALUO") + ", " +
				_db.CreateSqlParameterName("COEFICIENTE") + ", " +
				_db.CreateSqlParameterName("CTB_REVALUO_ANTERIOR_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("VIDA_UTIL") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("VALOR_FISCAL_REV") + ", " +
				_db.CreateSqlParameterName("VALOR_FISCAL_NET_CIERRE") + ", " +
				_db.CreateSqlParameterName("CUOTA_FISCAL_DEPR_ANUAL") + ", " +
				_db.CreateSqlParameterName("DEPREC_FISCAL_ACUM") + ", " +
				_db.CreateSqlParameterName("VIDA_UTIL_RESTANTE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ACTIVO_ID", value.ACTIVO_ID);
			AddParameter(cmd, "FECHA_REVALUO", value.FECHA_REVALUO);
			AddParameter(cmd, "COEFICIENTE", value.COEFICIENTE);
			AddParameter(cmd, "CTB_REVALUO_ANTERIOR_ID",
				value.IsCTB_REVALUO_ANTERIOR_IDNull ? DBNull.Value : (object)value.CTB_REVALUO_ANTERIOR_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "VIDA_UTIL", value.VIDA_UTIL);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "VALOR_FISCAL_REV", value.VALOR_FISCAL_REV);
			AddParameter(cmd, "VALOR_FISCAL_NET_CIERRE", value.VALOR_FISCAL_NET_CIERRE);
			AddParameter(cmd, "CUOTA_FISCAL_DEPR_ANUAL", value.CUOTA_FISCAL_DEPR_ANUAL);
			AddParameter(cmd, "DEPREC_FISCAL_ACUM", value.DEPREC_FISCAL_ACUM);
			AddParameter(cmd, "VIDA_UTIL_RESTANTE", value.VIDA_UTIL_RESTANTE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_REVALUOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_REVALUOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_REVALUOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_REVALUOS SET " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"FECHA_REVALUO=" + _db.CreateSqlParameterName("FECHA_REVALUO") + ", " +
				"COEFICIENTE=" + _db.CreateSqlParameterName("COEFICIENTE") + ", " +
				"CTB_REVALUO_ANTERIOR_ID=" + _db.CreateSqlParameterName("CTB_REVALUO_ANTERIOR_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"VIDA_UTIL=" + _db.CreateSqlParameterName("VIDA_UTIL") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"VALOR_FISCAL_REV=" + _db.CreateSqlParameterName("VALOR_FISCAL_REV") + ", " +
				"VALOR_FISCAL_NET_CIERRE=" + _db.CreateSqlParameterName("VALOR_FISCAL_NET_CIERRE") + ", " +
				"CUOTA_FISCAL_DEPR_ANUAL=" + _db.CreateSqlParameterName("CUOTA_FISCAL_DEPR_ANUAL") + ", " +
				"DEPREC_FISCAL_ACUM=" + _db.CreateSqlParameterName("DEPREC_FISCAL_ACUM") + ", " +
				"VIDA_UTIL_RESTANTE=" + _db.CreateSqlParameterName("VIDA_UTIL_RESTANTE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ACTIVO_ID", value.ACTIVO_ID);
			AddParameter(cmd, "FECHA_REVALUO", value.FECHA_REVALUO);
			AddParameter(cmd, "COEFICIENTE", value.COEFICIENTE);
			AddParameter(cmd, "CTB_REVALUO_ANTERIOR_ID",
				value.IsCTB_REVALUO_ANTERIOR_IDNull ? DBNull.Value : (object)value.CTB_REVALUO_ANTERIOR_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "VIDA_UTIL", value.VIDA_UTIL);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "VALOR_FISCAL_REV", value.VALOR_FISCAL_REV);
			AddParameter(cmd, "VALOR_FISCAL_NET_CIERRE", value.VALOR_FISCAL_NET_CIERRE);
			AddParameter(cmd, "CUOTA_FISCAL_DEPR_ANUAL", value.CUOTA_FISCAL_DEPR_ANUAL);
			AddParameter(cmd, "DEPREC_FISCAL_ACUM", value.DEPREC_FISCAL_ACUM);
			AddParameter(cmd, "VIDA_UTIL_RESTANTE", value.VIDA_UTIL_RESTANTE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_REVALUOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_REVALUOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_REVALUOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_REVALUOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_REVALUOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_REVALUOS</c> table using
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
		/// Deletes records from the <c>CTB_REVALUOS</c> table using the 
		/// <c>FK_CTB_REVALUO_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return CreateDeleteByACTIVO_IDCommand(activo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_REVALUO_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_IDCommand(decimal activo_id)
		{
			string whereSql = "";
			whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_REVALUOS</c> table using the 
		/// <c>FK_CTB_REVALUO_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_REVALUO_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>CTB_REVALUOS</c> table using the 
		/// <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_REVALUO_ANTERIOR_ID(decimal ctb_revaluo_anterior_id)
		{
			return DeleteByCTB_REVALUO_ANTERIOR_ID(ctb_revaluo_anterior_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_REVALUOS</c> table using the 
		/// <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctb_revaluo_anterior_idNull">true if the method ignores the ctb_revaluo_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_REVALUO_ANTERIOR_ID(decimal ctb_revaluo_anterior_id, bool ctb_revaluo_anterior_idNull)
		{
			return CreateDeleteByCTB_REVALUO_ANTERIOR_IDCommand(ctb_revaluo_anterior_id, ctb_revaluo_anterior_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_REVALUO_REVALUO_ANT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_revaluo_anterior_id">The <c>CTB_REVALUO_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctb_revaluo_anterior_idNull">true if the method ignores the ctb_revaluo_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_REVALUO_ANTERIOR_IDCommand(decimal ctb_revaluo_anterior_id, bool ctb_revaluo_anterior_idNull)
		{
			string whereSql = "";
			if(ctb_revaluo_anterior_idNull)
				whereSql += "CTB_REVALUO_ANTERIOR_ID IS NULL";
			else
				whereSql += "CTB_REVALUO_ANTERIOR_ID=" + _db.CreateSqlParameterName("CTB_REVALUO_ANTERIOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_revaluo_anterior_idNull)
				AddParameter(cmd, "CTB_REVALUO_ANTERIOR_ID", ctb_revaluo_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_REVALUOS</c> records that match the specified criteria.
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
		/// to delete <c>CTB_REVALUOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_REVALUOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_REVALUOS</c> table.
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
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		protected CTB_REVALUOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		protected CTB_REVALUOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_REVALUOSRow"/> objects.</returns>
		protected virtual CTB_REVALUOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int fecha_revaluoColumnIndex = reader.GetOrdinal("FECHA_REVALUO");
			int coeficienteColumnIndex = reader.GetOrdinal("COEFICIENTE");
			int ctb_revaluo_anterior_idColumnIndex = reader.GetOrdinal("CTB_REVALUO_ANTERIOR_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int vida_utilColumnIndex = reader.GetOrdinal("VIDA_UTIL");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int valor_fiscal_revColumnIndex = reader.GetOrdinal("VALOR_FISCAL_REV");
			int valor_fiscal_net_cierreColumnIndex = reader.GetOrdinal("VALOR_FISCAL_NET_CIERRE");
			int cuota_fiscal_depr_anualColumnIndex = reader.GetOrdinal("CUOTA_FISCAL_DEPR_ANUAL");
			int deprec_fiscal_acumColumnIndex = reader.GetOrdinal("DEPREC_FISCAL_ACUM");
			int vida_util_restanteColumnIndex = reader.GetOrdinal("VIDA_UTIL_RESTANTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_REVALUOSRow record = new CTB_REVALUOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.FECHA_REVALUO = Convert.ToDateTime(reader.GetValue(fecha_revaluoColumnIndex));
					record.COEFICIENTE = Math.Round(Convert.ToDecimal(reader.GetValue(coeficienteColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_revaluo_anterior_idColumnIndex))
						record.CTB_REVALUO_ANTERIOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_revaluo_anterior_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.VIDA_UTIL = Math.Round(Convert.ToDecimal(reader.GetValue(vida_utilColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.VALOR_FISCAL_REV = Math.Round(Convert.ToDecimal(reader.GetValue(valor_fiscal_revColumnIndex)), 9);
					record.VALOR_FISCAL_NET_CIERRE = Math.Round(Convert.ToDecimal(reader.GetValue(valor_fiscal_net_cierreColumnIndex)), 9);
					record.CUOTA_FISCAL_DEPR_ANUAL = Math.Round(Convert.ToDecimal(reader.GetValue(cuota_fiscal_depr_anualColumnIndex)), 9);
					record.DEPREC_FISCAL_ACUM = Math.Round(Convert.ToDecimal(reader.GetValue(deprec_fiscal_acumColumnIndex)), 9);
					record.VIDA_UTIL_RESTANTE = Math.Round(Convert.ToDecimal(reader.GetValue(vida_util_restanteColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_REVALUOSRow[])(recordList.ToArray(typeof(CTB_REVALUOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_REVALUOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_REVALUOSRow"/> object.</returns>
		protected virtual CTB_REVALUOSRow MapRow(DataRow row)
		{
			CTB_REVALUOSRow mappedObject = new CTB_REVALUOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "FECHA_REVALUO"
			dataColumn = dataTable.Columns["FECHA_REVALUO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_REVALUO = (System.DateTime)row[dataColumn];
			// Column "COEFICIENTE"
			dataColumn = dataTable.Columns["COEFICIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COEFICIENTE = (decimal)row[dataColumn];
			// Column "CTB_REVALUO_ANTERIOR_ID"
			dataColumn = dataTable.Columns["CTB_REVALUO_ANTERIOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_REVALUO_ANTERIOR_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "VIDA_UTIL"
			dataColumn = dataTable.Columns["VIDA_UTIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIDA_UTIL = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "VALOR_FISCAL_REV"
			dataColumn = dataTable.Columns["VALOR_FISCAL_REV"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_FISCAL_REV = (decimal)row[dataColumn];
			// Column "VALOR_FISCAL_NET_CIERRE"
			dataColumn = dataTable.Columns["VALOR_FISCAL_NET_CIERRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_FISCAL_NET_CIERRE = (decimal)row[dataColumn];
			// Column "CUOTA_FISCAL_DEPR_ANUAL"
			dataColumn = dataTable.Columns["CUOTA_FISCAL_DEPR_ANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA_FISCAL_DEPR_ANUAL = (decimal)row[dataColumn];
			// Column "DEPREC_FISCAL_ACUM"
			dataColumn = dataTable.Columns["DEPREC_FISCAL_ACUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPREC_FISCAL_ACUM = (decimal)row[dataColumn];
			// Column "VIDA_UTIL_RESTANTE"
			dataColumn = dataTable.Columns["VIDA_UTIL_RESTANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIDA_UTIL_RESTANTE = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_REVALUOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_REVALUOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_REVALUO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COEFICIENTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_REVALUO_ANTERIOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VIDA_UTIL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VALOR_FISCAL_REV", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VALOR_FISCAL_NET_CIERRE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUOTA_FISCAL_DEPR_ANUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPREC_FISCAL_ACUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VIDA_UTIL_RESTANTE", typeof(decimal));
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

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_REVALUO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "COEFICIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_REVALUO_ANTERIOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VIDA_UTIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_FISCAL_REV":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_FISCAL_NET_CIERRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUOTA_FISCAL_DEPR_ANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPREC_FISCAL_ACUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VIDA_UTIL_RESTANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_REVALUOSCollection_Base class
}  // End of namespace
