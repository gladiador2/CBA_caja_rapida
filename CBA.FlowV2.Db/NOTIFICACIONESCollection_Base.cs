// <fileinfo name="NOTIFICACIONESCollection_Base.cs">
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
	/// The base class for <see cref="NOTIFICACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="NOTIFICACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTIFICACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ACCION_CREACIONColumnName = "ACCION_CREACION";
		public const string ACCION_EDICIONColumnName = "ACCION_EDICION";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string TRANSICION_IDColumnName = "TRANSICION_ID";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string LOG_CAMPO_IDColumnName = "LOG_CAMPO_ID";
		public const string CONDICION_VALORColumnName = "CONDICION_VALOR";
		public const string CONDICION_SQLColumnName = "CONDICION_SQL";
		public const string ESTADOColumnName = "ESTADO";
		public const string PLANTILLA_LARGAColumnName = "PLANTILLA_LARGA";
		public const string PLANTILLA_CORTAColumnName = "PLANTILLA_CORTA";
		public const string PLANTILLA_ASUNTOColumnName = "PLANTILLA_ASUNTO";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTIFICACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public NOTIFICACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>NOTIFICACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public virtual NOTIFICACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>NOTIFICACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>NOTIFICACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="NOTIFICACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="NOTIFICACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public NOTIFICACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			NOTIFICACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public NOTIFICACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public virtual NOTIFICACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.NOTIFICACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="NOTIFICACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="NOTIFICACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual NOTIFICACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			NOTIFICACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects 
		/// by the <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public NOTIFICACIONESRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return GetByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects 
		/// by the <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public virtual NOTIFICACIONESRow[] GetByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return GetByFLUJO_IDAsDataTable(flujo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects 
		/// by the <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public NOTIFICACIONESRow[] GetByLOG_CAMPO_ID(decimal log_campo_id)
		{
			return GetByLOG_CAMPO_ID(log_campo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects 
		/// by the <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public virtual NOTIFICACIONESRow[] GetByLOG_CAMPO_ID(decimal log_campo_id, bool log_campo_idNull)
		{
			return MapRecords(CreateGetByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOG_CAMPO_IDAsDataTable(decimal log_campo_id)
		{
			return GetByLOG_CAMPO_IDAsDataTable(log_campo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOG_CAMPO_IDAsDataTable(decimal log_campo_id, bool log_campo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOG_CAMPO_IDCommand(decimal log_campo_id, bool log_campo_idNull)
		{
			string whereSql = "";
			if(log_campo_idNull)
				whereSql += "LOG_CAMPO_ID IS NULL";
			else
				whereSql += "LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!log_campo_idNull)
				AddParameter(cmd, "LOG_CAMPO_ID", log_campo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects 
		/// by the <c>FK_NOTIFICACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public virtual NOTIFICACIONESRow[] GetByTABLA_ID(string tabla_id)
		{
			return MapRecords(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOTIFICACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_IDAsDataTable(string tabla_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOTIFICACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			if(null == tabla_id)
				whereSql += "TABLA_ID IS NULL";
			else
				whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tabla_id)
				AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects 
		/// by the <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public NOTIFICACIONESRow[] GetByTRANSICION_ID(decimal transicion_id)
		{
			return GetByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTIFICACIONESRow"/> objects 
		/// by the <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		public virtual NOTIFICACIONESRow[] GetByTRANSICION_ID(decimal transicion_id, bool transicion_idNull)
		{
			return MapRecords(CreateGetByTRANSICION_IDCommand(transicion_id, transicion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSICION_IDAsDataTable(decimal transicion_id)
		{
			return GetByTRANSICION_IDAsDataTable(transicion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSICION_IDAsDataTable(decimal transicion_id, bool transicion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSICION_IDCommand(transicion_id, transicion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSICION_IDCommand(decimal transicion_id, bool transicion_idNull)
		{
			string whereSql = "";
			if(transicion_idNull)
				whereSql += "TRANSICION_ID IS NULL";
			else
				whereSql += "TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transicion_idNull)
				AddParameter(cmd, "TRANSICION_ID", transicion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>NOTIFICACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOTIFICACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(NOTIFICACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.NOTIFICACIONES (" +
				"ID, " +
				"ACCION_CREACION, " +
				"ACCION_EDICION, " +
				"FLUJO_ID, " +
				"TRANSICION_ID, " +
				"TABLA_ID, " +
				"LOG_CAMPO_ID, " +
				"CONDICION_VALOR, " +
				"CONDICION_SQL, " +
				"ESTADO, " +
				"PLANTILLA_LARGA, " +
				"PLANTILLA_CORTA, " +
				"PLANTILLA_ASUNTO, " +
				"DESCRIPCION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ACCION_CREACION") + ", " +
				_db.CreateSqlParameterName("ACCION_EDICION") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("LOG_CAMPO_ID") + ", " +
				_db.CreateSqlParameterName("CONDICION_VALOR") + ", " +
				_db.CreateSqlParameterName("CONDICION_SQL") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("PLANTILLA_LARGA") + ", " +
				_db.CreateSqlParameterName("PLANTILLA_CORTA") + ", " +
				_db.CreateSqlParameterName("PLANTILLA_ASUNTO") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ACCION_CREACION", value.ACCION_CREACION);
			AddParameter(cmd, "ACCION_EDICION", value.ACCION_EDICION);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "LOG_CAMPO_ID",
				value.IsLOG_CAMPO_IDNull ? DBNull.Value : (object)value.LOG_CAMPO_ID);
			AddParameter(cmd, "CONDICION_VALOR", value.CONDICION_VALOR);
			AddParameter(cmd, "CONDICION_SQL", value.CONDICION_SQL);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PLANTILLA_LARGA", value.PLANTILLA_LARGA);
			AddParameter(cmd, "PLANTILLA_CORTA", value.PLANTILLA_CORTA);
			AddParameter(cmd, "PLANTILLA_ASUNTO", value.PLANTILLA_ASUNTO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>NOTIFICACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOTIFICACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(NOTIFICACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.NOTIFICACIONES SET " +
				"ACCION_CREACION=" + _db.CreateSqlParameterName("ACCION_CREACION") + ", " +
				"ACCION_EDICION=" + _db.CreateSqlParameterName("ACCION_EDICION") + ", " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + ", " +
				"TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID") + ", " +
				"CONDICION_VALOR=" + _db.CreateSqlParameterName("CONDICION_VALOR") + ", " +
				"CONDICION_SQL=" + _db.CreateSqlParameterName("CONDICION_SQL") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"PLANTILLA_LARGA=" + _db.CreateSqlParameterName("PLANTILLA_LARGA") + ", " +
				"PLANTILLA_CORTA=" + _db.CreateSqlParameterName("PLANTILLA_CORTA") + ", " +
				"PLANTILLA_ASUNTO=" + _db.CreateSqlParameterName("PLANTILLA_ASUNTO") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ACCION_CREACION", value.ACCION_CREACION);
			AddParameter(cmd, "ACCION_EDICION", value.ACCION_EDICION);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "LOG_CAMPO_ID",
				value.IsLOG_CAMPO_IDNull ? DBNull.Value : (object)value.LOG_CAMPO_ID);
			AddParameter(cmd, "CONDICION_VALOR", value.CONDICION_VALOR);
			AddParameter(cmd, "CONDICION_SQL", value.CONDICION_SQL);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PLANTILLA_LARGA", value.PLANTILLA_LARGA);
			AddParameter(cmd, "PLANTILLA_CORTA", value.PLANTILLA_CORTA);
			AddParameter(cmd, "PLANTILLA_ASUNTO", value.PLANTILLA_ASUNTO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>NOTIFICACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>NOTIFICACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>NOTIFICACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOTIFICACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(NOTIFICACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>NOTIFICACIONES</c> table using
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
		/// Deletes records from the <c>NOTIFICACIONES</c> table using the 
		/// <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return DeleteByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOTIFICACIONES</c> table using the 
		/// <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id, flujo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOTIFICACIONES_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOTIFICACIONES</c> table using the 
		/// <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOG_CAMPO_ID(decimal log_campo_id)
		{
			return DeleteByLOG_CAMPO_ID(log_campo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOTIFICACIONES</c> table using the 
		/// <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOG_CAMPO_ID(decimal log_campo_id, bool log_campo_idNull)
		{
			return CreateDeleteByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOTIFICACIONES_LOG_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOG_CAMPO_IDCommand(decimal log_campo_id, bool log_campo_idNull)
		{
			string whereSql = "";
			if(log_campo_idNull)
				whereSql += "LOG_CAMPO_ID IS NULL";
			else
				whereSql += "LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!log_campo_idNull)
				AddParameter(cmd, "LOG_CAMPO_ID", log_campo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOTIFICACIONES</c> table using the 
		/// <c>FK_NOTIFICACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_ID(string tabla_id)
		{
			return CreateDeleteByTABLA_IDCommand(tabla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOTIFICACIONES_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			if(null == tabla_id)
				whereSql += "TABLA_ID IS NULL";
			else
				whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tabla_id)
				AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOTIFICACIONES</c> table using the 
		/// <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_ID(decimal transicion_id)
		{
			return DeleteByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOTIFICACIONES</c> table using the 
		/// <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_ID(decimal transicion_id, bool transicion_idNull)
		{
			return CreateDeleteByTRANSICION_IDCommand(transicion_id, transicion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOTIFICACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSICION_IDCommand(decimal transicion_id, bool transicion_idNull)
		{
			string whereSql = "";
			if(transicion_idNull)
				whereSql += "TRANSICION_ID IS NULL";
			else
				whereSql += "TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transicion_idNull)
				AddParameter(cmd, "TRANSICION_ID", transicion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>NOTIFICACIONES</c> records that match the specified criteria.
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
		/// to delete <c>NOTIFICACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.NOTIFICACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>NOTIFICACIONES</c> table.
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
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		protected NOTIFICACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		protected NOTIFICACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="NOTIFICACIONESRow"/> objects.</returns>
		protected virtual NOTIFICACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int accion_creacionColumnIndex = reader.GetOrdinal("ACCION_CREACION");
			int accion_edicionColumnIndex = reader.GetOrdinal("ACCION_EDICION");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int transicion_idColumnIndex = reader.GetOrdinal("TRANSICION_ID");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int log_campo_idColumnIndex = reader.GetOrdinal("LOG_CAMPO_ID");
			int condicion_valorColumnIndex = reader.GetOrdinal("CONDICION_VALOR");
			int condicion_sqlColumnIndex = reader.GetOrdinal("CONDICION_SQL");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int plantilla_largaColumnIndex = reader.GetOrdinal("PLANTILLA_LARGA");
			int plantilla_cortaColumnIndex = reader.GetOrdinal("PLANTILLA_CORTA");
			int plantilla_asuntoColumnIndex = reader.GetOrdinal("PLANTILLA_ASUNTO");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					NOTIFICACIONESRow record = new NOTIFICACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ACCION_CREACION = Convert.ToString(reader.GetValue(accion_creacionColumnIndex));
					record.ACCION_EDICION = Convert.ToString(reader.GetValue(accion_edicionColumnIndex));
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(transicion_idColumnIndex))
						record.TRANSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tabla_idColumnIndex))
						record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					if(!reader.IsDBNull(log_campo_idColumnIndex))
						record.LOG_CAMPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(log_campo_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_valorColumnIndex))
						record.CONDICION_VALOR = Convert.ToString(reader.GetValue(condicion_valorColumnIndex));
					if(!reader.IsDBNull(condicion_sqlColumnIndex))
						record.CONDICION_SQL = Convert.ToString(reader.GetValue(condicion_sqlColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(plantilla_largaColumnIndex))
						record.PLANTILLA_LARGA = Convert.ToString(reader.GetValue(plantilla_largaColumnIndex));
					if(!reader.IsDBNull(plantilla_cortaColumnIndex))
						record.PLANTILLA_CORTA = Convert.ToString(reader.GetValue(plantilla_cortaColumnIndex));
					if(!reader.IsDBNull(plantilla_asuntoColumnIndex))
						record.PLANTILLA_ASUNTO = Convert.ToString(reader.GetValue(plantilla_asuntoColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NOTIFICACIONESRow[])(recordList.ToArray(typeof(NOTIFICACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="NOTIFICACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="NOTIFICACIONESRow"/> object.</returns>
		protected virtual NOTIFICACIONESRow MapRow(DataRow row)
		{
			NOTIFICACIONESRow mappedObject = new NOTIFICACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ACCION_CREACION"
			dataColumn = dataTable.Columns["ACCION_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACCION_CREACION = (string)row[dataColumn];
			// Column "ACCION_EDICION"
			dataColumn = dataTable.Columns["ACCION_EDICION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACCION_EDICION = (string)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "TRANSICION_ID"
			dataColumn = dataTable.Columns["TRANSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_ID = (decimal)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "LOG_CAMPO_ID"
			dataColumn = dataTable.Columns["LOG_CAMPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOG_CAMPO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_VALOR"
			dataColumn = dataTable.Columns["CONDICION_VALOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_VALOR = (string)row[dataColumn];
			// Column "CONDICION_SQL"
			dataColumn = dataTable.Columns["CONDICION_SQL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_SQL = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PLANTILLA_LARGA"
			dataColumn = dataTable.Columns["PLANTILLA_LARGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANTILLA_LARGA = (string)row[dataColumn];
			// Column "PLANTILLA_CORTA"
			dataColumn = dataTable.Columns["PLANTILLA_CORTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANTILLA_CORTA = (string)row[dataColumn];
			// Column "PLANTILLA_ASUNTO"
			dataColumn = dataTable.Columns["PLANTILLA_ASUNTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANTILLA_ASUNTO = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>NOTIFICACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "NOTIFICACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ACCION_CREACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ACCION_EDICION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSICION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("LOG_CAMPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONDICION_VALOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CONDICION_SQL", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLANTILLA_LARGA", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("PLANTILLA_CORTA", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("PLANTILLA_ASUNTO", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
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

				case "ACCION_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ACCION_EDICION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOG_CAMPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_VALOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONDICION_SQL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PLANTILLA_LARGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PLANTILLA_CORTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PLANTILLA_ASUNTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of NOTIFICACIONESCollection_Base class
}  // End of namespace
