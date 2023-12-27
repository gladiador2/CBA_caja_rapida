// <fileinfo name="COMENTARIOS_CASOSCollection_Base.cs">
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
	/// The base class for <see cref="COMENTARIOS_CASOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="COMENTARIOS_CASOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COMENTARIOS_CASOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string TABLA_REGISTRO_IDColumnName = "TABLA_REGISTRO_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string ES_PRIVADOColumnName = "ES_PRIVADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string USUARIO_BORRADO_IDColumnName = "USUARIO_BORRADO_ID";
		public const string FECHA_BORRADOColumnName = "FECHA_BORRADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string RECORDATORIOColumnName = "RECORDATORIO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="COMENTARIOS_CASOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public COMENTARIOS_CASOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>COMENTARIOS_CASOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public virtual COMENTARIOS_CASOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>COMENTARIOS_CASOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>COMENTARIOS_CASOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="COMENTARIOS_CASOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="COMENTARIOS_CASOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public COMENTARIOS_CASOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			COMENTARIOS_CASOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public COMENTARIOS_CASOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects that 
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
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public virtual COMENTARIOS_CASOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.COMENTARIOS_CASOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="COMENTARIOS_CASOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="COMENTARIOS_CASOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual COMENTARIOS_CASOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			COMENTARIOS_CASOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects 
		/// by the <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public COMENTARIOS_CASOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects 
		/// by the <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public virtual COMENTARIOS_CASOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id, bool caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects 
		/// by the <c>FK_COMENTARIOS_CASOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public virtual COMENTARIOS_CASOSRow[] GetByTABLA_ID(string tabla_id)
		{
			return MapRecords(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_CASOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_IDAsDataTable(string tabla_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COMENTARIOS_CASOS_TABLA</c> foreign key.
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
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects 
		/// by the <c>FK_COMENTARIOS_CASOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public virtual COMENTARIOS_CASOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_CASOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COMENTARIOS_CASOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects 
		/// by the <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public COMENTARIOS_CASOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_CASOSRow"/> objects 
		/// by the <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		public virtual COMENTARIOS_CASOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_IDAsDataTable(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>COMENTARIOS_CASOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COMENTARIOS_CASOSRow"/> object to be inserted.</param>
		public virtual void Insert(COMENTARIOS_CASOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.COMENTARIOS_CASOS (" +
				"ID, " +
				"CASO_ID, " +
				"TABLA_ID, " +
				"TABLA_REGISTRO_ID, " +
				"USUARIO_ID, " +
				"FECHA, " +
				"ES_PRIVADO, " +
				"OBSERVACION, " +
				"USUARIO_BORRADO_ID, " +
				"FECHA_BORRADO, " +
				"ESTADO, " +
				"RECORDATORIO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("TABLA_REGISTRO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("ES_PRIVADO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("RECORDATORIO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "TABLA_REGISTRO_ID",
				value.IsTABLA_REGISTRO_IDNull ? DBNull.Value : (object)value.TABLA_REGISTRO_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "ES_PRIVADO", value.ES_PRIVADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RECORDATORIO", value.RECORDATORIO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>COMENTARIOS_CASOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COMENTARIOS_CASOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(COMENTARIOS_CASOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.COMENTARIOS_CASOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"TABLA_REGISTRO_ID=" + _db.CreateSqlParameterName("TABLA_REGISTRO_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"ES_PRIVADO=" + _db.CreateSqlParameterName("ES_PRIVADO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				"FECHA_BORRADO=" + _db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"RECORDATORIO=" + _db.CreateSqlParameterName("RECORDATORIO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "TABLA_REGISTRO_ID",
				value.IsTABLA_REGISTRO_IDNull ? DBNull.Value : (object)value.TABLA_REGISTRO_ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "ES_PRIVADO", value.ES_PRIVADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RECORDATORIO", value.RECORDATORIO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>COMENTARIOS_CASOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>COMENTARIOS_CASOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>COMENTARIOS_CASOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COMENTARIOS_CASOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(COMENTARIOS_CASOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>COMENTARIOS_CASOS</c> table using
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
		/// Deletes records from the <c>COMENTARIOS_CASOS</c> table using the 
		/// <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>COMENTARIOS_CASOS</c> table using the 
		/// <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return CreateDeleteByCASO_IDCommand(caso_id, caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COMENTARIOS_CASOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>COMENTARIOS_CASOS</c> table using the 
		/// <c>FK_COMENTARIOS_CASOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_ID(string tabla_id)
		{
			return CreateDeleteByTABLA_IDCommand(tabla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COMENTARIOS_CASOS_TABLA</c> foreign key.
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
		/// Deletes records from the <c>COMENTARIOS_CASOS</c> table using the 
		/// <c>FK_COMENTARIOS_CASOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COMENTARIOS_CASOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>COMENTARIOS_CASOS</c> table using the 
		/// <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return DeleteByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>COMENTARIOS_CASOS</c> table using the 
		/// <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return CreateDeleteByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COMENTARIOS_CASOS_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>COMENTARIOS_CASOS</c> records that match the specified criteria.
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
		/// to delete <c>COMENTARIOS_CASOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.COMENTARIOS_CASOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>COMENTARIOS_CASOS</c> table.
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
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		protected COMENTARIOS_CASOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		protected COMENTARIOS_CASOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="COMENTARIOS_CASOSRow"/> objects.</returns>
		protected virtual COMENTARIOS_CASOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int tabla_registro_idColumnIndex = reader.GetOrdinal("TABLA_REGISTRO_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int es_privadoColumnIndex = reader.GetOrdinal("ES_PRIVADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int usuario_borrado_idColumnIndex = reader.GetOrdinal("USUARIO_BORRADO_ID");
			int fecha_borradoColumnIndex = reader.GetOrdinal("FECHA_BORRADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int recordatorioColumnIndex = reader.GetOrdinal("RECORDATORIO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					COMENTARIOS_CASOSRow record = new COMENTARIOS_CASOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(tabla_idColumnIndex))
						record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					if(!reader.IsDBNull(tabla_registro_idColumnIndex))
						record.TABLA_REGISTRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tabla_registro_idColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.ES_PRIVADO = Convert.ToString(reader.GetValue(es_privadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(usuario_borrado_idColumnIndex))
						record.USUARIO_BORRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_borrado_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_borradoColumnIndex))
						record.FECHA_BORRADO = Convert.ToDateTime(reader.GetValue(fecha_borradoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.RECORDATORIO = Convert.ToString(reader.GetValue(recordatorioColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (COMENTARIOS_CASOSRow[])(recordList.ToArray(typeof(COMENTARIOS_CASOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="COMENTARIOS_CASOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="COMENTARIOS_CASOSRow"/> object.</returns>
		protected virtual COMENTARIOS_CASOSRow MapRow(DataRow row)
		{
			COMENTARIOS_CASOSRow mappedObject = new COMENTARIOS_CASOSRow();
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
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "TABLA_REGISTRO_ID"
			dataColumn = dataTable.Columns["TABLA_REGISTRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_REGISTRO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "ES_PRIVADO"
			dataColumn = dataTable.Columns["ES_PRIVADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_PRIVADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "USUARIO_BORRADO_ID"
			dataColumn = dataTable.Columns["USUARIO_BORRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_BORRADO_ID = (decimal)row[dataColumn];
			// Column "FECHA_BORRADO"
			dataColumn = dataTable.Columns["FECHA_BORRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_BORRADO = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "RECORDATORIO"
			dataColumn = dataTable.Columns["RECORDATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECORDATORIO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>COMENTARIOS_CASOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "COMENTARIOS_CASOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TABLA_REGISTRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_PRIVADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("USUARIO_BORRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_BORRADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RECORDATORIO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TABLA_REGISTRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ES_PRIVADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_BORRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_BORRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RECORDATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of COMENTARIOS_CASOSCollection_Base class
}  // End of namespace
