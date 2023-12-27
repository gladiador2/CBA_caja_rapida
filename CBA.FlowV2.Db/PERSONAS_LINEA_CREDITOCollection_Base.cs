// <fileinfo name="PERSONAS_LINEA_CREDITOCollection_Base.cs">
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
	/// The base class for <see cref="PERSONAS_LINEA_CREDITOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PERSONAS_LINEA_CREDITOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_LINEA_CREDITOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string MONTO_LINEA_CREDITOColumnName = "MONTO_LINEA_CREDITO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string FECHA_ASIGNACIONColumnName = "FECHA_ASIGNACION";
		public const string USUARIO_ASIGNACIONColumnName = "USUARIO_ASIGNACION";
		public const string TEMPORALColumnName = "TEMPORAL";
		public const string APROBADOColumnName = "APROBADO";
		public const string UTILIZADOColumnName = "UTILIZADO";
		public const string USUARIO_APROBACIONColumnName = "USUARIO_APROBACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_LINEA_CREDITOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PERSONAS_LINEA_CREDITOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PERSONAS_LINEA_CREDITO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PERSONAS_LINEA_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PERSONAS_LINEA_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PERSONAS_LINEA_CREDITORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PERSONAS_LINEA_CREDITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PERSONAS_LINEA_CREDITORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PERSONAS_LINEA_CREDITORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public PERSONAS_LINEA_CREDITORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects that 
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PERSONAS_LINEA_CREDITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PERSONAS_LINEA_CREDITORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PERSONAS_LINEA_CREDITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PERSONAS_LINEA_CREDITORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PERSONAS_LINEA_CREDITORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects 
		/// by the <c>FK_PERS_LINEA_CREDITO_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITORow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_LINEA_CREDITO_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_LINEA_CREDITO_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects 
		/// by the <c>FK_PERS_LINEA_CREDITO_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITORow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_LINEA_CREDITO_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_LINEA_CREDITO_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects 
		/// by the <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public PERSONAS_LINEA_CREDITORow[] GetByUSUARIO_APROBACION(decimal usuario_aprobacion)
		{
			return GetByUSUARIO_APROBACION(usuario_aprobacion, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects 
		/// by the <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <param name="usuario_aprobacionNull">true if the method ignores the usuario_aprobacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITORow[] GetByUSUARIO_APROBACION(decimal usuario_aprobacion, bool usuario_aprobacionNull)
		{
			return MapRecords(CreateGetByUSUARIO_APROBACIONCommand(usuario_aprobacion, usuario_aprobacionNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_APROBACIONAsDataTable(decimal usuario_aprobacion)
		{
			return GetByUSUARIO_APROBACIONAsDataTable(usuario_aprobacion, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <param name="usuario_aprobacionNull">true if the method ignores the usuario_aprobacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_APROBACIONAsDataTable(decimal usuario_aprobacion, bool usuario_aprobacionNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_APROBACIONCommand(usuario_aprobacion, usuario_aprobacionNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <param name="usuario_aprobacionNull">true if the method ignores the usuario_aprobacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_APROBACIONCommand(decimal usuario_aprobacion, bool usuario_aprobacionNull)
		{
			string whereSql = "";
			if(usuario_aprobacionNull)
				whereSql += "USUARIO_APROBACION IS NULL";
			else
				whereSql += "USUARIO_APROBACION=" + _db.CreateSqlParameterName("USUARIO_APROBACION");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_aprobacionNull)
				AddParameter(cmd, "USUARIO_APROBACION", usuario_aprobacion);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects 
		/// by the <c>FK_PERS_LINEA_CREDITO_USR_ASIG</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion">The <c>USUARIO_ASIGNACION</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITORow[] GetByUSUARIO_ASIGNACION(decimal usuario_asignacion)
		{
			return MapRecords(CreateGetByUSUARIO_ASIGNACIONCommand(usuario_asignacion));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_LINEA_CREDITO_USR_ASIG</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion">The <c>USUARIO_ASIGNACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ASIGNACIONAsDataTable(decimal usuario_asignacion)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ASIGNACIONCommand(usuario_asignacion));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_LINEA_CREDITO_USR_ASIG</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion">The <c>USUARIO_ASIGNACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ASIGNACIONCommand(decimal usuario_asignacion)
		{
			string whereSql = "";
			whereSql += "USUARIO_ASIGNACION=" + _db.CreateSqlParameterName("USUARIO_ASIGNACION");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ASIGNACION", usuario_asignacion);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PERSONAS_LINEA_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_LINEA_CREDITORow"/> object to be inserted.</param>
		public virtual void Insert(PERSONAS_LINEA_CREDITORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PERSONAS_LINEA_CREDITO (" +
				"ID, " +
				"PERSONA_ID, " +
				"MONTO_LINEA_CREDITO, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"FECHA_ASIGNACION, " +
				"USUARIO_ASIGNACION, " +
				"TEMPORAL, " +
				"APROBADO, " +
				"UTILIZADO, " +
				"USUARIO_APROBACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_LINEA_CREDITO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("FECHA_ASIGNACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_ASIGNACION") + ", " +
				_db.CreateSqlParameterName("TEMPORAL") + ", " +
				_db.CreateSqlParameterName("APROBADO") + ", " +
				_db.CreateSqlParameterName("UTILIZADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_APROBACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "MONTO_LINEA_CREDITO", value.MONTO_LINEA_CREDITO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "FECHA_ASIGNACION", value.FECHA_ASIGNACION);
			AddParameter(cmd, "USUARIO_ASIGNACION", value.USUARIO_ASIGNACION);
			AddParameter(cmd, "TEMPORAL", value.TEMPORAL);
			AddParameter(cmd, "APROBADO", value.APROBADO);
			AddParameter(cmd, "UTILIZADO", value.UTILIZADO);
			AddParameter(cmd, "USUARIO_APROBACION",
				value.IsUSUARIO_APROBACIONNull ? DBNull.Value : (object)value.USUARIO_APROBACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PERSONAS_LINEA_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_LINEA_CREDITORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PERSONAS_LINEA_CREDITORow value)
		{
			
			string sqlStr = "UPDATE TRC.PERSONAS_LINEA_CREDITO SET " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"MONTO_LINEA_CREDITO=" + _db.CreateSqlParameterName("MONTO_LINEA_CREDITO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"FECHA_ASIGNACION=" + _db.CreateSqlParameterName("FECHA_ASIGNACION") + ", " +
				"USUARIO_ASIGNACION=" + _db.CreateSqlParameterName("USUARIO_ASIGNACION") + ", " +
				"TEMPORAL=" + _db.CreateSqlParameterName("TEMPORAL") + ", " +
				"APROBADO=" + _db.CreateSqlParameterName("APROBADO") + ", " +
				"UTILIZADO=" + _db.CreateSqlParameterName("UTILIZADO") + ", " +
				"USUARIO_APROBACION=" + _db.CreateSqlParameterName("USUARIO_APROBACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "MONTO_LINEA_CREDITO", value.MONTO_LINEA_CREDITO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "FECHA_ASIGNACION", value.FECHA_ASIGNACION);
			AddParameter(cmd, "USUARIO_ASIGNACION", value.USUARIO_ASIGNACION);
			AddParameter(cmd, "TEMPORAL", value.TEMPORAL);
			AddParameter(cmd, "APROBADO", value.APROBADO);
			AddParameter(cmd, "UTILIZADO", value.UTILIZADO);
			AddParameter(cmd, "USUARIO_APROBACION",
				value.IsUSUARIO_APROBACIONNull ? DBNull.Value : (object)value.USUARIO_APROBACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PERSONAS_LINEA_CREDITO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PERSONAS_LINEA_CREDITO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PERSONAS_LINEA_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_LINEA_CREDITORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PERSONAS_LINEA_CREDITORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PERSONAS_LINEA_CREDITO</c> table using
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
		/// Deletes records from the <c>PERSONAS_LINEA_CREDITO</c> table using the 
		/// <c>FK_PERS_LINEA_CREDITO_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_LINEA_CREDITO_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>PERSONAS_LINEA_CREDITO</c> table using the 
		/// <c>FK_PERS_LINEA_CREDITO_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_LINEA_CREDITO_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_LINEA_CREDITO</c> table using the 
		/// <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION(decimal usuario_aprobacion)
		{
			return DeleteByUSUARIO_APROBACION(usuario_aprobacion, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_LINEA_CREDITO</c> table using the 
		/// <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <param name="usuario_aprobacionNull">true if the method ignores the usuario_aprobacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION(decimal usuario_aprobacion, bool usuario_aprobacionNull)
		{
			return CreateDeleteByUSUARIO_APROBACIONCommand(usuario_aprobacion, usuario_aprobacionNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_LINEA_CREDITO_USR_APRO</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion">The <c>USUARIO_APROBACION</c> column value.</param>
		/// <param name="usuario_aprobacionNull">true if the method ignores the usuario_aprobacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_APROBACIONCommand(decimal usuario_aprobacion, bool usuario_aprobacionNull)
		{
			string whereSql = "";
			if(usuario_aprobacionNull)
				whereSql += "USUARIO_APROBACION IS NULL";
			else
				whereSql += "USUARIO_APROBACION=" + _db.CreateSqlParameterName("USUARIO_APROBACION");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_aprobacionNull)
				AddParameter(cmd, "USUARIO_APROBACION", usuario_aprobacion);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_LINEA_CREDITO</c> table using the 
		/// <c>FK_PERS_LINEA_CREDITO_USR_ASIG</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion">The <c>USUARIO_ASIGNACION</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ASIGNACION(decimal usuario_asignacion)
		{
			return CreateDeleteByUSUARIO_ASIGNACIONCommand(usuario_asignacion).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_LINEA_CREDITO_USR_ASIG</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion">The <c>USUARIO_ASIGNACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ASIGNACIONCommand(decimal usuario_asignacion)
		{
			string whereSql = "";
			whereSql += "USUARIO_ASIGNACION=" + _db.CreateSqlParameterName("USUARIO_ASIGNACION");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ASIGNACION", usuario_asignacion);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PERSONAS_LINEA_CREDITO</c> records that match the specified criteria.
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
		/// to delete <c>PERSONAS_LINEA_CREDITO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PERSONAS_LINEA_CREDITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PERSONAS_LINEA_CREDITO</c> table.
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		protected PERSONAS_LINEA_CREDITORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		protected PERSONAS_LINEA_CREDITORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITORow"/> objects.</returns>
		protected virtual PERSONAS_LINEA_CREDITORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int monto_linea_creditoColumnIndex = reader.GetOrdinal("MONTO_LINEA_CREDITO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int fecha_asignacionColumnIndex = reader.GetOrdinal("FECHA_ASIGNACION");
			int usuario_asignacionColumnIndex = reader.GetOrdinal("USUARIO_ASIGNACION");
			int temporalColumnIndex = reader.GetOrdinal("TEMPORAL");
			int aprobadoColumnIndex = reader.GetOrdinal("APROBADO");
			int utilizadoColumnIndex = reader.GetOrdinal("UTILIZADO");
			int usuario_aprobacionColumnIndex = reader.GetOrdinal("USUARIO_APROBACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PERSONAS_LINEA_CREDITORow record = new PERSONAS_LINEA_CREDITORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.MONTO_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_linea_creditoColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.FECHA_ASIGNACION = Convert.ToDateTime(reader.GetValue(fecha_asignacionColumnIndex));
					record.USUARIO_ASIGNACION = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_asignacionColumnIndex)), 9);
					record.TEMPORAL = Convert.ToString(reader.GetValue(temporalColumnIndex));
					if(!reader.IsDBNull(aprobadoColumnIndex))
						record.APROBADO = Convert.ToString(reader.GetValue(aprobadoColumnIndex));
					if(!reader.IsDBNull(utilizadoColumnIndex))
						record.UTILIZADO = Convert.ToString(reader.GetValue(utilizadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacionColumnIndex))
						record.USUARIO_APROBACION = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PERSONAS_LINEA_CREDITORow[])(recordList.ToArray(typeof(PERSONAS_LINEA_CREDITORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PERSONAS_LINEA_CREDITORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PERSONAS_LINEA_CREDITORow"/> object.</returns>
		protected virtual PERSONAS_LINEA_CREDITORow MapRow(DataRow row)
		{
			PERSONAS_LINEA_CREDITORow mappedObject = new PERSONAS_LINEA_CREDITORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "MONTO_LINEA_CREDITO"
			dataColumn = dataTable.Columns["MONTO_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_LINEA_CREDITO = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "FECHA_ASIGNACION"
			dataColumn = dataTable.Columns["FECHA_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ASIGNACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ASIGNACION"
			dataColumn = dataTable.Columns["USUARIO_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ASIGNACION = (decimal)row[dataColumn];
			// Column "TEMPORAL"
			dataColumn = dataTable.Columns["TEMPORAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPORAL = (string)row[dataColumn];
			// Column "APROBADO"
			dataColumn = dataTable.Columns["APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBADO = (string)row[dataColumn];
			// Column "UTILIZADO"
			dataColumn = dataTable.Columns["UTILIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.UTILIZADO = (string)row[dataColumn];
			// Column "USUARIO_APROBACION"
			dataColumn = dataTable.Columns["USUARIO_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PERSONAS_LINEA_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PERSONAS_LINEA_CREDITO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_LINEA_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ASIGNACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ASIGNACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEMPORAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("UTILIZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION", typeof(decimal));
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEMPORAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "UTILIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PERSONAS_LINEA_CREDITOCollection_Base class
}  // End of namespace
