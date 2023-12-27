// <fileinfo name="PLANILLA_LIQUIDACIONES_DETCollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_LIQUIDACIONES_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_LIQUIDACIONES_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_LIQUIDACIONES_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLANILLA_IDColumnName = "PLANILLA_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string TOTAL_SALARIOColumnName = "TOTAL_SALARIO";
		public const string TOTAL_BONIFICACIONColumnName = "TOTAL_BONIFICACION";
		public const string TOTAL_DESCUENTOColumnName = "TOTAL_DESCUENTO";
		public const string TOTAL_A_COBRARColumnName = "TOTAL_A_COBRAR";
		public const string LIQUIDACION_IDColumnName = "LIQUIDACION_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string TOTAL_APORTES_EMPRESAColumnName = "TOTAL_APORTES_EMPRESA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_LIQUIDACIONES_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_LIQUIDACIONES_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public virtual PLANILLA_LIQUIDACIONES_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_LIQUIDACIONES_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_LIQUIDACIONES_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public PLANILLA_LIQUIDACIONES_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public virtual PLANILLA_LIQUIDACIONES_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_LIQUIDACIONES_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANILLA_LIQUIDACIONES_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANILLA_LIQUIDACIONES_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects 
		/// by the <c>FK_PLA_LIQ_DET_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public virtual PLANILLA_LIQUIDACIONES_DETRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLA_LIQ_DET_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLA_LIQ_DET_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects 
		/// by the <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public PLANILLA_LIQUIDACIONES_DETRow[] GetByLIQUIDACION_ID(decimal liquidacion_id)
		{
			return GetByLIQUIDACION_ID(liquidacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects 
		/// by the <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public virtual PLANILLA_LIQUIDACIONES_DETRow[] GetByLIQUIDACION_ID(decimal liquidacion_id, bool liquidacion_idNull)
		{
			return MapRecords(CreateGetByLIQUIDACION_IDCommand(liquidacion_id, liquidacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLIQUIDACION_IDAsDataTable(decimal liquidacion_id)
		{
			return GetByLIQUIDACION_IDAsDataTable(liquidacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLIQUIDACION_IDAsDataTable(decimal liquidacion_id, bool liquidacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLIQUIDACION_IDCommand(liquidacion_id, liquidacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLIQUIDACION_IDCommand(decimal liquidacion_id, bool liquidacion_idNull)
		{
			string whereSql = "";
			if(liquidacion_idNull)
				whereSql += "LIQUIDACION_ID IS NULL";
			else
				whereSql += "LIQUIDACION_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!liquidacion_idNull)
				AddParameter(cmd, "LIQUIDACION_ID", liquidacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects 
		/// by the <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public PLANILLA_LIQUIDACIONES_DETRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects 
		/// by the <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public virtual PLANILLA_LIQUIDACIONES_DETRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
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
		/// return records by the <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
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
		/// Gets an array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects 
		/// by the <c>FK_PLA_LIQ_DET_PLA_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_id">The <c>PLANILLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		public virtual PLANILLA_LIQUIDACIONES_DETRow[] GetByPLANILLA_ID(decimal planilla_id)
		{
			return MapRecords(CreateGetByPLANILLA_IDCommand(planilla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLA_LIQ_DET_PLA_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_id">The <c>PLANILLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLANILLA_IDAsDataTable(decimal planilla_id)
		{
			return MapRecordsToDataTable(CreateGetByPLANILLA_IDCommand(planilla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLA_LIQ_DET_PLA_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_id">The <c>PLANILLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLANILLA_IDCommand(decimal planilla_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_ID=" + _db.CreateSqlParameterName("PLANILLA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PLANILLA_ID", planilla_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> object to be inserted.</param>
		public virtual void Insert(PLANILLA_LIQUIDACIONES_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANILLA_LIQUIDACIONES_DET (" +
				"ID, " +
				"PLANILLA_ID, " +
				"FUNCIONARIO_ID, " +
				"TOTAL_SALARIO, " +
				"TOTAL_BONIFICACION, " +
				"TOTAL_DESCUENTO, " +
				"TOTAL_A_COBRAR, " +
				"LIQUIDACION_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"TOTAL_APORTES_EMPRESA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PLANILLA_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("TOTAL_SALARIO") + ", " +
				_db.CreateSqlParameterName("TOTAL_BONIFICACION") + ", " +
				_db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_A_COBRAR") + ", " +
				_db.CreateSqlParameterName("LIQUIDACION_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("TOTAL_APORTES_EMPRESA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PLANILLA_ID", value.PLANILLA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "TOTAL_SALARIO", value.TOTAL_SALARIO);
			AddParameter(cmd, "TOTAL_BONIFICACION", value.TOTAL_BONIFICACION);
			AddParameter(cmd, "TOTAL_DESCUENTO", value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_A_COBRAR", value.TOTAL_A_COBRAR);
			AddParameter(cmd, "LIQUIDACION_ID",
				value.IsLIQUIDACION_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "TOTAL_APORTES_EMPRESA", value.TOTAL_APORTES_EMPRESA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_LIQUIDACIONES_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANILLA_LIQUIDACIONES_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANILLA_LIQUIDACIONES_DET SET " +
				"PLANILLA_ID=" + _db.CreateSqlParameterName("PLANILLA_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"TOTAL_SALARIO=" + _db.CreateSqlParameterName("TOTAL_SALARIO") + ", " +
				"TOTAL_BONIFICACION=" + _db.CreateSqlParameterName("TOTAL_BONIFICACION") + ", " +
				"TOTAL_DESCUENTO=" + _db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				"TOTAL_A_COBRAR=" + _db.CreateSqlParameterName("TOTAL_A_COBRAR") + ", " +
				"LIQUIDACION_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"TOTAL_APORTES_EMPRESA=" + _db.CreateSqlParameterName("TOTAL_APORTES_EMPRESA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PLANILLA_ID", value.PLANILLA_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "TOTAL_SALARIO", value.TOTAL_SALARIO);
			AddParameter(cmd, "TOTAL_BONIFICACION", value.TOTAL_BONIFICACION);
			AddParameter(cmd, "TOTAL_DESCUENTO", value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_A_COBRAR", value.TOTAL_A_COBRAR);
			AddParameter(cmd, "LIQUIDACION_ID",
				value.IsLIQUIDACION_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "TOTAL_APORTES_EMPRESA", value.TOTAL_APORTES_EMPRESA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANILLA_LIQUIDACIONES_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANILLA_LIQUIDACIONES_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANILLA_LIQUIDACIONES_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANILLA_LIQUIDACIONES_DET</c> table using
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
		/// Deletes records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table using the 
		/// <c>FK_PLA_LIQ_DET_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLA_LIQ_DET_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table using the 
		/// <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLIQUIDACION_ID(decimal liquidacion_id)
		{
			return DeleteByLIQUIDACION_ID(liquidacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table using the 
		/// <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLIQUIDACION_ID(decimal liquidacion_id, bool liquidacion_idNull)
		{
			return CreateDeleteByLIQUIDACION_IDCommand(liquidacion_id, liquidacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLA_LIQ_DET_LIQUI_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLIQUIDACION_IDCommand(decimal liquidacion_id, bool liquidacion_idNull)
		{
			string whereSql = "";
			if(liquidacion_idNull)
				whereSql += "LIQUIDACION_ID IS NULL";
			else
				whereSql += "LIQUIDACION_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!liquidacion_idNull)
				AddParameter(cmd, "LIQUIDACION_ID", liquidacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table using the 
		/// <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table using the 
		/// <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
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
		/// delete records using the <c>FK_PLA_LIQ_DET_MON_ID</c> foreign key.
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
		/// Deletes records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table using the 
		/// <c>FK_PLA_LIQ_DET_PLA_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_id">The <c>PLANILLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_ID(decimal planilla_id)
		{
			return CreateDeleteByPLANILLA_IDCommand(planilla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLA_LIQ_DET_PLA_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_id">The <c>PLANILLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLANILLA_IDCommand(decimal planilla_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_ID=" + _db.CreateSqlParameterName("PLANILLA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PLANILLA_ID", planilla_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PLANILLA_LIQUIDACIONES_DET</c> records that match the specified criteria.
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
		/// to delete <c>PLANILLA_LIQUIDACIONES_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANILLA_LIQUIDACIONES_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
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
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		protected PLANILLA_LIQUIDACIONES_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		protected PLANILLA_LIQUIDACIONES_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> objects.</returns>
		protected virtual PLANILLA_LIQUIDACIONES_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int planilla_idColumnIndex = reader.GetOrdinal("PLANILLA_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int total_salarioColumnIndex = reader.GetOrdinal("TOTAL_SALARIO");
			int total_bonificacionColumnIndex = reader.GetOrdinal("TOTAL_BONIFICACION");
			int total_descuentoColumnIndex = reader.GetOrdinal("TOTAL_DESCUENTO");
			int total_a_cobrarColumnIndex = reader.GetOrdinal("TOTAL_A_COBRAR");
			int liquidacion_idColumnIndex = reader.GetOrdinal("LIQUIDACION_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int total_aportes_empresaColumnIndex = reader.GetOrdinal("TOTAL_APORTES_EMPRESA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_LIQUIDACIONES_DETRow record = new PLANILLA_LIQUIDACIONES_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLANILLA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.TOTAL_SALARIO = Math.Round(Convert.ToDecimal(reader.GetValue(total_salarioColumnIndex)), 9);
					record.TOTAL_BONIFICACION = Math.Round(Convert.ToDecimal(reader.GetValue(total_bonificacionColumnIndex)), 9);
					record.TOTAL_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_descuentoColumnIndex)), 9);
					record.TOTAL_A_COBRAR = Math.Round(Convert.ToDecimal(reader.GetValue(total_a_cobrarColumnIndex)), 9);
					if(!reader.IsDBNull(liquidacion_idColumnIndex))
						record.LIQUIDACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(liquidacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.TOTAL_APORTES_EMPRESA = Math.Round(Convert.ToDecimal(reader.GetValue(total_aportes_empresaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_LIQUIDACIONES_DETRow[])(recordList.ToArray(typeof(PLANILLA_LIQUIDACIONES_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_LIQUIDACIONES_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_LIQUIDACIONES_DETRow"/> object.</returns>
		protected virtual PLANILLA_LIQUIDACIONES_DETRow MapRow(DataRow row)
		{
			PLANILLA_LIQUIDACIONES_DETRow mappedObject = new PLANILLA_LIQUIDACIONES_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLANILLA_ID"
			dataColumn = dataTable.Columns["PLANILLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "TOTAL_SALARIO"
			dataColumn = dataTable.Columns["TOTAL_SALARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_SALARIO = (decimal)row[dataColumn];
			// Column "TOTAL_BONIFICACION"
			dataColumn = dataTable.Columns["TOTAL_BONIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BONIFICACION = (decimal)row[dataColumn];
			// Column "TOTAL_DESCUENTO"
			dataColumn = dataTable.Columns["TOTAL_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DESCUENTO = (decimal)row[dataColumn];
			// Column "TOTAL_A_COBRAR"
			dataColumn = dataTable.Columns["TOTAL_A_COBRAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_A_COBRAR = (decimal)row[dataColumn];
			// Column "LIQUIDACION_ID"
			dataColumn = dataTable.Columns["LIQUIDACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIQUIDACION_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "TOTAL_APORTES_EMPRESA"
			dataColumn = dataTable.Columns["TOTAL_APORTES_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_APORTES_EMPRESA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_LIQUIDACIONES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_LIQUIDACIONES_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLANILLA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_SALARIO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_BONIFICACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_A_COBRAR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIQUIDACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_APORTES_EMPRESA", typeof(decimal));
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

				case "PLANILLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_SALARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BONIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_A_COBRAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIQUIDACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_APORTES_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_LIQUIDACIONES_DETCollection_Base class
}  // End of namespace
