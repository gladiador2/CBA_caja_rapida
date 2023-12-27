// <fileinfo name="RECORDATORIOSCollection_Base.cs">
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
	/// The base class for <see cref="RECORDATORIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="RECORDATORIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RECORDATORIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_ULTIMA_EDICION_IDColumnName = "USUARIO_ULTIMA_EDICION_ID";
		public const string FECHA_ULTIMA_EDICIONColumnName = "FECHA_ULTIMA_EDICION";
		public const string USUARIO_BORRADO_IDColumnName = "USUARIO_BORRADO_ID";
		public const string FECHA_BORRADOColumnName = "FECHA_BORRADO";
		public const string MOTIVO_BORRADOColumnName = "MOTIVO_BORRADO";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string REGISTROColumnName = "REGISTRO";
		public const string FECHA_RECORDATORIOColumnName = "FECHA_RECORDATORIO";
		public const string USUARIOS_RECORDATORIOColumnName = "USUARIOS_RECORDATORIO";
		public const string MAIL_RECORDATORIOColumnName = "MAIL_RECORDATORIO";
		public const string ESTADOColumnName = "ESTADO";
		public const string TIPOColumnName = "TIPO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="RECORDATORIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public RECORDATORIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>RECORDATORIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public virtual RECORDATORIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>RECORDATORIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>RECORDATORIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="RECORDATORIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="RECORDATORIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public RECORDATORIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			RECORDATORIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public RECORDATORIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public virtual RECORDATORIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.RECORDATORIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="RECORDATORIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="RECORDATORIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual RECORDATORIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			RECORDATORIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects 
		/// by the <c>FK_RECORDATORIOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public virtual RECORDATORIOSRow[] GetByTABLA_ID(string tabla_id)
		{
			return MapRecords(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RECORDATORIOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_IDAsDataTable(string tabla_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_IDCommand(tabla_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_RECORDATORIOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects 
		/// by the <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public RECORDATORIOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects 
		/// by the <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public virtual RECORDATORIOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_IDAsDataTable(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
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
		/// return records by the <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
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
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects 
		/// by the <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public RECORDATORIOSRow[] GetByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id)
		{
			return GetByUSUARIO_ULTIMA_EDICION_ID(usuario_ultima_edicion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects 
		/// by the <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public virtual RECORDATORIOSRow[] GetByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_ULTIMA_EDICION_IDCommand(usuario_ultima_edicion_id, usuario_ultima_edicion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_ULTIMA_EDICION_IDAsDataTable(decimal usuario_ultima_edicion_id)
		{
			return GetByUSUARIO_ULTIMA_EDICION_IDAsDataTable(usuario_ultima_edicion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ULTIMA_EDICION_IDAsDataTable(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ULTIMA_EDICION_IDCommand(usuario_ultima_edicion_id, usuario_ultima_edicion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ULTIMA_EDICION_IDCommand(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			string whereSql = "";
			if(usuario_ultima_edicion_idNull)
				whereSql += "USUARIO_ULTIMA_EDICION_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMA_EDICION_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_ultima_edicion_idNull)
				AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID", usuario_ultima_edicion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="RECORDATORIOSRow"/> objects 
		/// by the <c>FK_RECORDATORIOS_USRIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		public virtual RECORDATORIOSRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_RECORDATORIOS_USRIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_RECORDATORIOS_USRIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>RECORDATORIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RECORDATORIOSRow"/> object to be inserted.</param>
		public virtual void Insert(RECORDATORIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.RECORDATORIOS (" +
				"ID, " +
				"USUARIO_CREACION_ID, " +
				"FECHA_CREACION, " +
				"USUARIO_ULTIMA_EDICION_ID, " +
				"FECHA_ULTIMA_EDICION, " +
				"USUARIO_BORRADO_ID, " +
				"FECHA_BORRADO, " +
				"MOTIVO_BORRADO, " +
				"TABLA_ID, " +
				"REGISTRO, " +
				"FECHA_RECORDATORIO, " +
				"USUARIOS_RECORDATORIO, " +
				"MAIL_RECORDATORIO, " +
				"ESTADO, " +
				"TIPO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMA_EDICION") + ", " +
				_db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				_db.CreateSqlParameterName("MOTIVO_BORRADO") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("REGISTRO") + ", " +
				_db.CreateSqlParameterName("FECHA_RECORDATORIO") + ", " +
				_db.CreateSqlParameterName("USUARIOS_RECORDATORIO") + ", " +
				_db.CreateSqlParameterName("MAIL_RECORDATORIO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("TIPO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID",
				value.IsUSUARIO_ULTIMA_EDICION_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMA_EDICION_ID);
			AddParameter(cmd, "FECHA_ULTIMA_EDICION",
				value.IsFECHA_ULTIMA_EDICIONNull ? DBNull.Value : (object)value.FECHA_ULTIMA_EDICION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "MOTIVO_BORRADO", value.MOTIVO_BORRADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "REGISTRO", value.REGISTRO);
			AddParameter(cmd, "FECHA_RECORDATORIO", value.FECHA_RECORDATORIO);
			AddParameter(cmd, "USUARIOS_RECORDATORIO", value.USUARIOS_RECORDATORIO);
			AddParameter(cmd, "MAIL_RECORDATORIO", value.MAIL_RECORDATORIO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO", value.TIPO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>RECORDATORIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RECORDATORIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(RECORDATORIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.RECORDATORIOS SET " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_ULTIMA_EDICION_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID") + ", " +
				"FECHA_ULTIMA_EDICION=" + _db.CreateSqlParameterName("FECHA_ULTIMA_EDICION") + ", " +
				"USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				"FECHA_BORRADO=" + _db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				"MOTIVO_BORRADO=" + _db.CreateSqlParameterName("MOTIVO_BORRADO") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"REGISTRO=" + _db.CreateSqlParameterName("REGISTRO") + ", " +
				"FECHA_RECORDATORIO=" + _db.CreateSqlParameterName("FECHA_RECORDATORIO") + ", " +
				"USUARIOS_RECORDATORIO=" + _db.CreateSqlParameterName("USUARIOS_RECORDATORIO") + ", " +
				"MAIL_RECORDATORIO=" + _db.CreateSqlParameterName("MAIL_RECORDATORIO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"TIPO=" + _db.CreateSqlParameterName("TIPO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID",
				value.IsUSUARIO_ULTIMA_EDICION_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMA_EDICION_ID);
			AddParameter(cmd, "FECHA_ULTIMA_EDICION",
				value.IsFECHA_ULTIMA_EDICIONNull ? DBNull.Value : (object)value.FECHA_ULTIMA_EDICION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "MOTIVO_BORRADO", value.MOTIVO_BORRADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "REGISTRO", value.REGISTRO);
			AddParameter(cmd, "FECHA_RECORDATORIO", value.FECHA_RECORDATORIO);
			AddParameter(cmd, "USUARIOS_RECORDATORIO", value.USUARIOS_RECORDATORIO);
			AddParameter(cmd, "MAIL_RECORDATORIO", value.MAIL_RECORDATORIO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>RECORDATORIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>RECORDATORIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>RECORDATORIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="RECORDATORIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(RECORDATORIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>RECORDATORIOS</c> table using
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
		/// Deletes records from the <c>RECORDATORIOS</c> table using the 
		/// <c>FK_RECORDATORIOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_ID(string tabla_id)
		{
			return CreateDeleteByTABLA_IDCommand(tabla_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_RECORDATORIOS_TABLA</c> foreign key.
		/// </summary>
		/// <param name="tabla_id">The <c>TABLA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTABLA_IDCommand(string tabla_id)
		{
			string whereSql = "";
			whereSql += "TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TABLA_ID", tabla_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>RECORDATORIOS</c> table using the 
		/// <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return DeleteByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>RECORDATORIOS</c> table using the 
		/// <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
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
		/// delete records using the <c>FK_RECORDATORIOS_USR_BORRADO</c> foreign key.
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
		/// Deletes records from the <c>RECORDATORIOS</c> table using the 
		/// <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id)
		{
			return DeleteByUSUARIO_ULTIMA_EDICION_ID(usuario_ultima_edicion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>RECORDATORIOS</c> table using the 
		/// <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMA_EDICION_ID(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			return CreateDeleteByUSUARIO_ULTIMA_EDICION_IDCommand(usuario_ultima_edicion_id, usuario_ultima_edicion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_RECORDATORIOS_USR_ULT_EDI</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultima_edicion_id">The <c>USUARIO_ULTIMA_EDICION_ID</c> column value.</param>
		/// <param name="usuario_ultima_edicion_idNull">true if the method ignores the usuario_ultima_edicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ULTIMA_EDICION_IDCommand(decimal usuario_ultima_edicion_id, bool usuario_ultima_edicion_idNull)
		{
			string whereSql = "";
			if(usuario_ultima_edicion_idNull)
				whereSql += "USUARIO_ULTIMA_EDICION_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMA_EDICION_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMA_EDICION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_ultima_edicion_idNull)
				AddParameter(cmd, "USUARIO_ULTIMA_EDICION_ID", usuario_ultima_edicion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>RECORDATORIOS</c> table using the 
		/// <c>FK_RECORDATORIOS_USRIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_RECORDATORIOS_USRIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>RECORDATORIOS</c> records that match the specified criteria.
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
		/// to delete <c>RECORDATORIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.RECORDATORIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>RECORDATORIOS</c> table.
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
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		protected RECORDATORIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		protected RECORDATORIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="RECORDATORIOSRow"/> objects.</returns>
		protected virtual RECORDATORIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_ultima_edicion_idColumnIndex = reader.GetOrdinal("USUARIO_ULTIMA_EDICION_ID");
			int fecha_ultima_edicionColumnIndex = reader.GetOrdinal("FECHA_ULTIMA_EDICION");
			int usuario_borrado_idColumnIndex = reader.GetOrdinal("USUARIO_BORRADO_ID");
			int fecha_borradoColumnIndex = reader.GetOrdinal("FECHA_BORRADO");
			int motivo_borradoColumnIndex = reader.GetOrdinal("MOTIVO_BORRADO");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int registroColumnIndex = reader.GetOrdinal("REGISTRO");
			int fecha_recordatorioColumnIndex = reader.GetOrdinal("FECHA_RECORDATORIO");
			int usuarios_recordatorioColumnIndex = reader.GetOrdinal("USUARIOS_RECORDATORIO");
			int mail_recordatorioColumnIndex = reader.GetOrdinal("MAIL_RECORDATORIO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					RECORDATORIOSRow record = new RECORDATORIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(usuario_ultima_edicion_idColumnIndex))
						record.USUARIO_ULTIMA_EDICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_ultima_edicion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultima_edicionColumnIndex))
						record.FECHA_ULTIMA_EDICION = Convert.ToDateTime(reader.GetValue(fecha_ultima_edicionColumnIndex));
					if(!reader.IsDBNull(usuario_borrado_idColumnIndex))
						record.USUARIO_BORRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_borrado_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_borradoColumnIndex))
						record.FECHA_BORRADO = Convert.ToDateTime(reader.GetValue(fecha_borradoColumnIndex));
					if(!reader.IsDBNull(motivo_borradoColumnIndex))
						record.MOTIVO_BORRADO = Convert.ToString(reader.GetValue(motivo_borradoColumnIndex));
					record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					record.REGISTRO = Math.Round(Convert.ToDecimal(reader.GetValue(registroColumnIndex)), 9);
					record.FECHA_RECORDATORIO = Convert.ToDateTime(reader.GetValue(fecha_recordatorioColumnIndex));
					record.USUARIOS_RECORDATORIO = Convert.ToString(reader.GetValue(usuarios_recordatorioColumnIndex));
					record.MAIL_RECORDATORIO = Convert.ToString(reader.GetValue(mail_recordatorioColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Convert.ToString(reader.GetValue(tipoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (RECORDATORIOSRow[])(recordList.ToArray(typeof(RECORDATORIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="RECORDATORIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="RECORDATORIOSRow"/> object.</returns>
		protected virtual RECORDATORIOSRow MapRow(DataRow row)
		{
			RECORDATORIOSRow mappedObject = new RECORDATORIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ULTIMA_EDICION_ID"
			dataColumn = dataTable.Columns["USUARIO_ULTIMA_EDICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ULTIMA_EDICION_ID = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMA_EDICION"
			dataColumn = dataTable.Columns["FECHA_ULTIMA_EDICION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMA_EDICION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_BORRADO_ID"
			dataColumn = dataTable.Columns["USUARIO_BORRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_BORRADO_ID = (decimal)row[dataColumn];
			// Column "FECHA_BORRADO"
			dataColumn = dataTable.Columns["FECHA_BORRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_BORRADO = (System.DateTime)row[dataColumn];
			// Column "MOTIVO_BORRADO"
			dataColumn = dataTable.Columns["MOTIVO_BORRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_BORRADO = (string)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "REGISTRO"
			dataColumn = dataTable.Columns["REGISTRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO = (decimal)row[dataColumn];
			// Column "FECHA_RECORDATORIO"
			dataColumn = dataTable.Columns["FECHA_RECORDATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECORDATORIO = (System.DateTime)row[dataColumn];
			// Column "USUARIOS_RECORDATORIO"
			dataColumn = dataTable.Columns["USUARIOS_RECORDATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIOS_RECORDATORIO = (string)row[dataColumn];
			// Column "MAIL_RECORDATORIO"
			dataColumn = dataTable.Columns["MAIL_RECORDATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAIL_RECORDATORIO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>RECORDATORIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "RECORDATORIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ULTIMA_EDICION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMA_EDICION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_BORRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_BORRADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MOTIVO_BORRADO", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGISTRO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_RECORDATORIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIOS_RECORDATORIO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MAIL_RECORDATORIO", typeof(string));
			dataColumn.MaxLength = 700;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ULTIMA_EDICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMA_EDICION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_BORRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_BORRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MOTIVO_BORRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGISTRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_RECORDATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIOS_RECORDATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MAIL_RECORDATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of RECORDATORIOSCollection_Base class
}  // End of namespace
