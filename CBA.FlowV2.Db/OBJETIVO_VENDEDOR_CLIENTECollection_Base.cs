// <fileinfo name="OBJETIVO_VENDEDOR_CLIENTECollection_Base.cs">
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
	/// The base class for <see cref="OBJETIVO_VENDEDOR_CLIENTECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="OBJETIVO_VENDEDOR_CLIENTECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJETIVO_VENDEDOR_CLIENTECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TEMPORADA_IDColumnName = "TEMPORADA_ID";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_MODIFICADOR_IDColumnName = "USUARIO_MODIFICADOR_ID";
		public const string FECHA_MODIFICACIONColumnName = "FECHA_MODIFICACION";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string ANHOColumnName = "ANHO";
		public const string PORCENTAJEColumnName = "PORCENTAJE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJETIVO_VENDEDOR_CLIENTECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public OBJETIVO_VENDEDOR_CLIENTECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_CLIENTERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public OBJETIVO_VENDEDOR_CLIENTERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			OBJETIVO_VENDEDOR_CLIENTERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public OBJETIVO_VENDEDOR_CLIENTERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects that 
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_CLIENTERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.OBJETIVO_VENDEDOR_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual OBJETIVO_VENDEDOR_CLIENTERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			OBJETIVO_VENDEDOR_CLIENTERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public OBJETIVO_VENDEDOR_CLIENTERow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_CLIENTERow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
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
		/// return records by the <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
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
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_TEMP</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_CLIENTERow[] GetByTEMPORADA_ID(decimal temporada_id)
		{
			return MapRecords(CreateGetByTEMPORADA_IDCommand(temporada_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_TEMP</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEMPORADA_IDAsDataTable(decimal temporada_id)
		{
			return MapRecordsToDataTable(CreateGetByTEMPORADA_IDCommand(temporada_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_CLI_TEMP</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEMPORADA_IDCommand(decimal temporada_id)
		{
			string whereSql = "";
			whereSql += "TEMPORADA_ID=" + _db.CreateSqlParameterName("TEMPORADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TEMPORADA_ID", temporada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_CLIENTERow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_CLI_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public OBJETIVO_VENDEDOR_CLIENTERow[] GetByUSUARIO_MODIFICADOR_ID(decimal usuario_modificador_id)
		{
			return GetByUSUARIO_MODIFICADOR_ID(usuario_modificador_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects 
		/// by the <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <param name="usuario_modificador_idNull">true if the method ignores the usuario_modificador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_CLIENTERow[] GetByUSUARIO_MODIFICADOR_ID(decimal usuario_modificador_id, bool usuario_modificador_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_MODIFICADOR_IDCommand(usuario_modificador_id, usuario_modificador_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_MODIFICADOR_IDAsDataTable(decimal usuario_modificador_id)
		{
			return GetByUSUARIO_MODIFICADOR_IDAsDataTable(usuario_modificador_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <param name="usuario_modificador_idNull">true if the method ignores the usuario_modificador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_MODIFICADOR_IDAsDataTable(decimal usuario_modificador_id, bool usuario_modificador_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_MODIFICADOR_IDCommand(usuario_modificador_id, usuario_modificador_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <param name="usuario_modificador_idNull">true if the method ignores the usuario_modificador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_MODIFICADOR_IDCommand(decimal usuario_modificador_id, bool usuario_modificador_idNull)
		{
			string whereSql = "";
			if(usuario_modificador_idNull)
				whereSql += "USUARIO_MODIFICADOR_ID IS NULL";
			else
				whereSql += "USUARIO_MODIFICADOR_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_modificador_idNull)
				AddParameter(cmd, "USUARIO_MODIFICADOR_ID", usuario_modificador_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> object to be inserted.</param>
		public virtual void Insert(OBJETIVO_VENDEDOR_CLIENTERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.OBJETIVO_VENDEDOR_CLIENTE (" +
				"ID, " +
				"TEMPORADA_ID, " +
				"USUARIO_CREADOR_ID, " +
				"FECHA_CREACION, " +
				"USUARIO_MODIFICADOR_ID, " +
				"FECHA_MODIFICACION, " +
				"MONEDA_ID, " +
				"ANHO, " +
				"PORCENTAJE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TEMPORADA_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_MODIFICADOR_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_MODIFICACION") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("ANHO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TEMPORADA_ID", value.TEMPORADA_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID", value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_MODIFICADOR_ID",
				value.IsUSUARIO_MODIFICADOR_IDNull ? DBNull.Value : (object)value.USUARIO_MODIFICADOR_ID);
			AddParameter(cmd, "FECHA_MODIFICACION",
				value.IsFECHA_MODIFICACIONNull ? DBNull.Value : (object)value.FECHA_MODIFICACION);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "ANHO",
				value.IsANHONull ? DBNull.Value : (object)value.ANHO);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(OBJETIVO_VENDEDOR_CLIENTERow value)
		{
			
			string sqlStr = "UPDATE TRC.OBJETIVO_VENDEDOR_CLIENTE SET " +
				"TEMPORADA_ID=" + _db.CreateSqlParameterName("TEMPORADA_ID") + ", " +
				"USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_MODIFICADOR_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICADOR_ID") + ", " +
				"FECHA_MODIFICACION=" + _db.CreateSqlParameterName("FECHA_MODIFICACION") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"ANHO=" + _db.CreateSqlParameterName("ANHO") + ", " +
				"PORCENTAJE=" + _db.CreateSqlParameterName("PORCENTAJE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TEMPORADA_ID", value.TEMPORADA_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID", value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_MODIFICADOR_ID",
				value.IsUSUARIO_MODIFICADOR_IDNull ? DBNull.Value : (object)value.USUARIO_MODIFICADOR_ID);
			AddParameter(cmd, "FECHA_MODIFICACION",
				value.IsFECHA_MODIFICACIONNull ? DBNull.Value : (object)value.FECHA_MODIFICACION);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "ANHO",
				value.IsANHONull ? DBNull.Value : (object)value.ANHO);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(OBJETIVO_VENDEDOR_CLIENTERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table using
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
		/// Deletes records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
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
		/// delete records using the <c>FK_OBJ_VEND_CLI_MON</c> foreign key.
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
		/// Deletes records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_TEMP</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEMPORADA_ID(decimal temporada_id)
		{
			return CreateDeleteByTEMPORADA_IDCommand(temporada_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_CLI_TEMP</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEMPORADA_IDCommand(decimal temporada_id)
		{
			string whereSql = "";
			whereSql += "TEMPORADA_ID=" + _db.CreateSqlParameterName("TEMPORADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TEMPORADA_ID", temporada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return CreateDeleteByUSUARIO_CREADOR_IDCommand(usuario_creador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_CLI_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICADOR_ID(decimal usuario_modificador_id)
		{
			return DeleteByUSUARIO_MODIFICADOR_ID(usuario_modificador_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table using the 
		/// <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <param name="usuario_modificador_idNull">true if the method ignores the usuario_modificador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICADOR_ID(decimal usuario_modificador_id, bool usuario_modificador_idNull)
		{
			return CreateDeleteByUSUARIO_MODIFICADOR_IDCommand(usuario_modificador_id, usuario_modificador_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_CLI_USR_M</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificador_id">The <c>USUARIO_MODIFICADOR_ID</c> column value.</param>
		/// <param name="usuario_modificador_idNull">true if the method ignores the usuario_modificador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_MODIFICADOR_IDCommand(decimal usuario_modificador_id, bool usuario_modificador_idNull)
		{
			string whereSql = "";
			if(usuario_modificador_idNull)
				whereSql += "USUARIO_MODIFICADOR_ID IS NULL";
			else
				whereSql += "USUARIO_MODIFICADOR_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_modificador_idNull)
				AddParameter(cmd, "USUARIO_MODIFICADOR_ID", usuario_modificador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>OBJETIVO_VENDEDOR_CLIENTE</c> records that match the specified criteria.
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
		/// to delete <c>OBJETIVO_VENDEDOR_CLIENTE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.OBJETIVO_VENDEDOR_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		protected OBJETIVO_VENDEDOR_CLIENTERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		protected OBJETIVO_VENDEDOR_CLIENTERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> objects.</returns>
		protected virtual OBJETIVO_VENDEDOR_CLIENTERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int temporada_idColumnIndex = reader.GetOrdinal("TEMPORADA_ID");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_modificador_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICADOR_ID");
			int fecha_modificacionColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int anhoColumnIndex = reader.GetOrdinal("ANHO");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					OBJETIVO_VENDEDOR_CLIENTERow record = new OBJETIVO_VENDEDOR_CLIENTERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TEMPORADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(temporada_idColumnIndex)), 9);
					record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(usuario_modificador_idColumnIndex))
						record.USUARIO_MODIFICADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificador_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_modificacionColumnIndex))
						record.FECHA_MODIFICACION = Convert.ToDateTime(reader.GetValue(fecha_modificacionColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(anhoColumnIndex))
						record.ANHO = Math.Round(Convert.ToDecimal(reader.GetValue(anhoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentajeColumnIndex))
						record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OBJETIVO_VENDEDOR_CLIENTERow[])(recordList.ToArray(typeof(OBJETIVO_VENDEDOR_CLIENTERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="OBJETIVO_VENDEDOR_CLIENTERow"/> object.</returns>
		protected virtual OBJETIVO_VENDEDOR_CLIENTERow MapRow(DataRow row)
		{
			OBJETIVO_VENDEDOR_CLIENTERow mappedObject = new OBJETIVO_VENDEDOR_CLIENTERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TEMPORADA_ID"
			dataColumn = dataTable.Columns["TEMPORADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPORADA_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_MODIFICADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICADOR_ID = (decimal)row[dataColumn];
			// Column "FECHA_MODIFICACION"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "ANHO"
			dataColumn = dataTable.Columns["ANHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANHO = (decimal)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>OBJETIVO_VENDEDOR_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "OBJETIVO_VENDEDOR_CLIENTE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEMPORADA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICADOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANHO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
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

				case "TEMPORADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_MODIFICADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_MODIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of OBJETIVO_VENDEDOR_CLIENTECollection_Base class
}  // End of namespace
