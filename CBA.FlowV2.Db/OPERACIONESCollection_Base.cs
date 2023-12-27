// <fileinfo name="OPERACIONESCollection_Base.cs">
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
	/// The base class for <see cref="OPERACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="OPERACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OPERACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string TIPO_OPERACION_IDColumnName = "TIPO_OPERACION_ID";
		public const string FECHAColumnName = "FECHA";
		public const string ESTADO_ORIGINAL_IDColumnName = "ESTADO_ORIGINAL_ID";
		public const string ESTADO_RESULTANTE_IDColumnName = "ESTADO_RESULTANTE_ID";
		public const string COMENTARIOColumnName = "COMENTARIO";
		public const string IPColumnName = "IP";
		public const string TRANSICION_IDColumnName = "TRANSICION_ID";
		public const string FECHA_FORMATO_NUMEROColumnName = "FECHA_FORMATO_NUMERO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="OPERACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public OPERACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>OPERACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>OPERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>OPERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="OPERACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="OPERACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public OPERACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			OPERACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public OPERACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.OPERACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="OPERACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="OPERACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual OPERACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			OPERACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OPERACIONES_CASOS</c> foreign key.
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
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_ESTADO_OR</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetByESTADO_ORIGINAL_ID(string estado_original_id)
		{
			return MapRecords(CreateGetByESTADO_ORIGINAL_IDCommand(estado_original_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_ESTADO_OR</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_ORIGINAL_IDAsDataTable(string estado_original_id)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_ORIGINAL_IDCommand(estado_original_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OPERACIONES_ESTADO_OR</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_ORIGINAL_IDCommand(string estado_original_id)
		{
			string whereSql = "";
			if(null == estado_original_id)
				whereSql += "ESTADO_ORIGINAL_ID IS NULL";
			else
				whereSql += "ESTADO_ORIGINAL_ID=" + _db.CreateSqlParameterName("ESTADO_ORIGINAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != estado_original_id)
				AddParameter(cmd, "ESTADO_ORIGINAL_ID", estado_original_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_ESTADO_RES</c> foreign key.
		/// </summary>
		/// <param name="estado_resultante_id">The <c>ESTADO_RESULTANTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetByESTADO_RESULTANTE_ID(string estado_resultante_id)
		{
			return MapRecords(CreateGetByESTADO_RESULTANTE_IDCommand(estado_resultante_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_ESTADO_RES</c> foreign key.
		/// </summary>
		/// <param name="estado_resultante_id">The <c>ESTADO_RESULTANTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_RESULTANTE_IDAsDataTable(string estado_resultante_id)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_RESULTANTE_IDCommand(estado_resultante_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OPERACIONES_ESTADO_RES</c> foreign key.
		/// </summary>
		/// <param name="estado_resultante_id">The <c>ESTADO_RESULTANTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_RESULTANTE_IDCommand(string estado_resultante_id)
		{
			string whereSql = "";
			if(null == estado_resultante_id)
				whereSql += "ESTADO_RESULTANTE_ID IS NULL";
			else
				whereSql += "ESTADO_RESULTANTE_ID=" + _db.CreateSqlParameterName("ESTADO_RESULTANTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != estado_resultante_id)
				AddParameter(cmd, "ESTADO_RESULTANTE_ID", estado_resultante_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_operacion_id">The <c>TIPO_OPERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetByTIPO_OPERACION_ID(decimal tipo_operacion_id)
		{
			return MapRecords(CreateGetByTIPO_OPERACION_IDCommand(tipo_operacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_operacion_id">The <c>TIPO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_OPERACION_IDAsDataTable(decimal tipo_operacion_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_OPERACION_IDCommand(tipo_operacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OPERACIONES_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_operacion_id">The <c>TIPO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_OPERACION_IDCommand(decimal tipo_operacion_id)
		{
			string whereSql = "";
			whereSql += "TIPO_OPERACION_ID=" + _db.CreateSqlParameterName("TIPO_OPERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_OPERACION_ID", tipo_operacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public OPERACIONESRow[] GetByTRANSICION_ID(decimal transicion_id)
		{
			return GetByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetByTRANSICION_ID(decimal transicion_id, bool transicion_idNull)
		{
			return MapRecords(CreateGetByTRANSICION_IDCommand(transicion_id, transicion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSICION_IDAsDataTable(decimal transicion_id)
		{
			return GetByTRANSICION_IDAsDataTable(transicion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_TRANSICION</c> foreign key.
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
		/// return records by the <c>FK_OPERACIONES_TRANSICION</c> foreign key.
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
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public OPERACIONESRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OPERACIONESRow"/> objects 
		/// by the <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		public virtual OPERACIONESRow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>OPERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OPERACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(OPERACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.OPERACIONES (" +
				"ID, " +
				"CASO_ID, " +
				"USUARIO_ID, " +
				"TIPO_OPERACION_ID, " +
				"FECHA, " +
				"ESTADO_ORIGINAL_ID, " +
				"ESTADO_RESULTANTE_ID, " +
				"COMENTARIO, " +
				"IP, " +
				"TRANSICION_ID, " +
				"FECHA_FORMATO_NUMERO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_OPERACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("ESTADO_ORIGINAL_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_RESULTANTE_ID") + ", " +
				_db.CreateSqlParameterName("COMENTARIO") + ", " +
				_db.CreateSqlParameterName("IP") + ", " +
				_db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_FORMATO_NUMERO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "TIPO_OPERACION_ID", value.TIPO_OPERACION_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "ESTADO_ORIGINAL_ID", value.ESTADO_ORIGINAL_ID);
			AddParameter(cmd, "ESTADO_RESULTANTE_ID", value.ESTADO_RESULTANTE_ID);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			AddParameter(cmd, "IP", value.IP);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "FECHA_FORMATO_NUMERO", value.FECHA_FORMATO_NUMERO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>OPERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OPERACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(OPERACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.OPERACIONES SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"TIPO_OPERACION_ID=" + _db.CreateSqlParameterName("TIPO_OPERACION_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"ESTADO_ORIGINAL_ID=" + _db.CreateSqlParameterName("ESTADO_ORIGINAL_ID") + ", " +
				"ESTADO_RESULTANTE_ID=" + _db.CreateSqlParameterName("ESTADO_RESULTANTE_ID") + ", " +
				"COMENTARIO=" + _db.CreateSqlParameterName("COMENTARIO") + ", " +
				"IP=" + _db.CreateSqlParameterName("IP") + ", " +
				"TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				"FECHA_FORMATO_NUMERO=" + _db.CreateSqlParameterName("FECHA_FORMATO_NUMERO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "TIPO_OPERACION_ID", value.TIPO_OPERACION_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "ESTADO_ORIGINAL_ID", value.ESTADO_ORIGINAL_ID);
			AddParameter(cmd, "ESTADO_RESULTANTE_ID", value.ESTADO_RESULTANTE_ID);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			AddParameter(cmd, "IP", value.IP);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "FECHA_FORMATO_NUMERO", value.FECHA_FORMATO_NUMERO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>OPERACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>OPERACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>OPERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OPERACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(OPERACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>OPERACIONES</c> table using
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
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_CASOS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OPERACIONES_CASOS</c> foreign key.
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
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_ESTADO_OR</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_ORIGINAL_ID(string estado_original_id)
		{
			return CreateDeleteByESTADO_ORIGINAL_IDCommand(estado_original_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OPERACIONES_ESTADO_OR</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_ORIGINAL_IDCommand(string estado_original_id)
		{
			string whereSql = "";
			if(null == estado_original_id)
				whereSql += "ESTADO_ORIGINAL_ID IS NULL";
			else
				whereSql += "ESTADO_ORIGINAL_ID=" + _db.CreateSqlParameterName("ESTADO_ORIGINAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != estado_original_id)
				AddParameter(cmd, "ESTADO_ORIGINAL_ID", estado_original_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_ESTADO_RES</c> foreign key.
		/// </summary>
		/// <param name="estado_resultante_id">The <c>ESTADO_RESULTANTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_RESULTANTE_ID(string estado_resultante_id)
		{
			return CreateDeleteByESTADO_RESULTANTE_IDCommand(estado_resultante_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OPERACIONES_ESTADO_RES</c> foreign key.
		/// </summary>
		/// <param name="estado_resultante_id">The <c>ESTADO_RESULTANTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_RESULTANTE_IDCommand(string estado_resultante_id)
		{
			string whereSql = "";
			if(null == estado_resultante_id)
				whereSql += "ESTADO_RESULTANTE_ID IS NULL";
			else
				whereSql += "ESTADO_RESULTANTE_ID=" + _db.CreateSqlParameterName("ESTADO_RESULTANTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != estado_resultante_id)
				AddParameter(cmd, "ESTADO_RESULTANTE_ID", estado_resultante_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_operacion_id">The <c>TIPO_OPERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_OPERACION_ID(decimal tipo_operacion_id)
		{
			return CreateDeleteByTIPO_OPERACION_IDCommand(tipo_operacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OPERACIONES_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_operacion_id">The <c>TIPO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_OPERACION_IDCommand(decimal tipo_operacion_id)
		{
			string whereSql = "";
			whereSql += "TIPO_OPERACION_ID=" + _db.CreateSqlParameterName("TIPO_OPERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_OPERACION_ID", tipo_operacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_ID(decimal transicion_id)
		{
			return DeleteByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_TRANSICION</c> foreign key.
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
		/// delete records using the <c>FK_OPERACIONES_TRANSICION</c> foreign key.
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
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OPERACIONES</c> table using the 
		/// <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id, usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OPERACIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>OPERACIONES</c> records that match the specified criteria.
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
		/// to delete <c>OPERACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.OPERACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>OPERACIONES</c> table.
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
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		protected OPERACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		protected OPERACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="OPERACIONESRow"/> objects.</returns>
		protected virtual OPERACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int tipo_operacion_idColumnIndex = reader.GetOrdinal("TIPO_OPERACION_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int estado_original_idColumnIndex = reader.GetOrdinal("ESTADO_ORIGINAL_ID");
			int estado_resultante_idColumnIndex = reader.GetOrdinal("ESTADO_RESULTANTE_ID");
			int comentarioColumnIndex = reader.GetOrdinal("COMENTARIO");
			int ipColumnIndex = reader.GetOrdinal("IP");
			int transicion_idColumnIndex = reader.GetOrdinal("TRANSICION_ID");
			int fecha_formato_numeroColumnIndex = reader.GetOrdinal("FECHA_FORMATO_NUMERO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					OPERACIONESRow record = new OPERACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.TIPO_OPERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_operacion_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(estado_original_idColumnIndex))
						record.ESTADO_ORIGINAL_ID = Convert.ToString(reader.GetValue(estado_original_idColumnIndex));
					if(!reader.IsDBNull(estado_resultante_idColumnIndex))
						record.ESTADO_RESULTANTE_ID = Convert.ToString(reader.GetValue(estado_resultante_idColumnIndex));
					if(!reader.IsDBNull(comentarioColumnIndex))
						record.COMENTARIO = Convert.ToString(reader.GetValue(comentarioColumnIndex));
					if(!reader.IsDBNull(ipColumnIndex))
						record.IP = Convert.ToString(reader.GetValue(ipColumnIndex));
					if(!reader.IsDBNull(transicion_idColumnIndex))
						record.TRANSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_idColumnIndex)), 9);
					record.FECHA_FORMATO_NUMERO = Math.Round(Convert.ToDecimal(reader.GetValue(fecha_formato_numeroColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OPERACIONESRow[])(recordList.ToArray(typeof(OPERACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="OPERACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="OPERACIONESRow"/> object.</returns>
		protected virtual OPERACIONESRow MapRow(DataRow row)
		{
			OPERACIONESRow mappedObject = new OPERACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "TIPO_OPERACION_ID"
			dataColumn = dataTable.Columns["TIPO_OPERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_OPERACION_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "ESTADO_ORIGINAL_ID"
			dataColumn = dataTable.Columns["ESTADO_ORIGINAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ORIGINAL_ID = (string)row[dataColumn];
			// Column "ESTADO_RESULTANTE_ID"
			dataColumn = dataTable.Columns["ESTADO_RESULTANTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_RESULTANTE_ID = (string)row[dataColumn];
			// Column "COMENTARIO"
			dataColumn = dataTable.Columns["COMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMENTARIO = (string)row[dataColumn];
			// Column "IP"
			dataColumn = dataTable.Columns["IP"];
			if(!row.IsNull(dataColumn))
				mappedObject.IP = (string)row[dataColumn];
			// Column "TRANSICION_ID"
			dataColumn = dataTable.Columns["TRANSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_ID = (decimal)row[dataColumn];
			// Column "FECHA_FORMATO_NUMERO"
			dataColumn = dataTable.Columns["FECHA_FORMATO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FORMATO_NUMERO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>OPERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "OPERACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_OPERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO_ORIGINAL_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("ESTADO_RESULTANTE_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("COMENTARIO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("IP", typeof(string));
			dataColumn.MaxLength = 16;
			dataColumn = dataTable.Columns.Add("TRANSICION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_FORMATO_NUMERO", typeof(decimal));
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_OPERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO_ORIGINAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_RESULTANTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_FORMATO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of OPERACIONESCollection_Base class
}  // End of namespace
