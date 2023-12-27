// <fileinfo name="LINEASCollection_Base.cs">
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
	/// The base class for <see cref="LINEASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="LINEASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LINEASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ESTADOColumnName = "ESTADO";
		public const string AGENCIA_IDColumnName = "AGENCIA_ID";
		public const string EDI_PATHColumnName = "EDI_PATH";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string INFORMARColumnName = "INFORMAR";
		public const string ORDENColumnName = "ORDEN";
		public const string BLOQUEO_ACTIVOColumnName = "BLOQUEO_ACTIVO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="LINEASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public LINEASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>LINEAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public virtual LINEASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>LINEAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>LINEAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="LINEASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="LINEASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public LINEASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			LINEASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public LINEASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects that 
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
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public virtual LINEASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.LINEAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="LINEASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="LINEASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual LINEASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			LINEASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects 
		/// by the <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public LINEASRow[] GetByAGENCIA_ID(decimal agencia_id)
		{
			return GetByAGENCIA_ID(agencia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects 
		/// by the <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public virtual LINEASRow[] GetByAGENCIA_ID(decimal agencia_id, bool agencia_idNull)
		{
			return MapRecords(CreateGetByAGENCIA_IDCommand(agencia_id, agencia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAGENCIA_IDAsDataTable(decimal agencia_id)
		{
			return GetByAGENCIA_IDAsDataTable(agencia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAGENCIA_IDAsDataTable(decimal agencia_id, bool agencia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAGENCIA_IDCommand(agencia_id, agencia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAGENCIA_IDCommand(decimal agencia_id, bool agencia_idNull)
		{
			string whereSql = "";
			if(agencia_idNull)
				whereSql += "AGENCIA_ID IS NULL";
			else
				whereSql += "AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!agencia_idNull)
				AddParameter(cmd, "AGENCIA_ID", agencia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects 
		/// by the <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public LINEASRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects 
		/// by the <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public virtual LINEASRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects 
		/// by the <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public LINEASRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEASRow"/> objects 
		/// by the <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		public virtual LINEASRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>LINEAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LINEASRow"/> object to be inserted.</param>
		public virtual void Insert(LINEASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.LINEAS (" +
				"ID, " +
				"CODIGO, " +
				"NOMBRE, " +
				"ESTADO, " +
				"AGENCIA_ID, " +
				"EDI_PATH, " +
				"PERSONA_ID, " +
				"PROVEEDOR_ID, " +
				"INFORMAR, " +
				"ORDEN, " +
				"BLOQUEO_ACTIVO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("AGENCIA_ID") + ", " +
				_db.CreateSqlParameterName("EDI_PATH") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("INFORMAR") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("BLOQUEO_ACTIVO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "AGENCIA_ID",
				value.IsAGENCIA_IDNull ? DBNull.Value : (object)value.AGENCIA_ID);
			AddParameter(cmd, "EDI_PATH", value.EDI_PATH);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "INFORMAR", value.INFORMAR);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			AddParameter(cmd, "BLOQUEO_ACTIVO", value.BLOQUEO_ACTIVO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>LINEAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LINEASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(LINEASRow value)
		{
			
			string sqlStr = "UPDATE TRC.LINEAS SET " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID") + ", " +
				"EDI_PATH=" + _db.CreateSqlParameterName("EDI_PATH") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"INFORMAR=" + _db.CreateSqlParameterName("INFORMAR") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"BLOQUEO_ACTIVO=" + _db.CreateSqlParameterName("BLOQUEO_ACTIVO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "AGENCIA_ID",
				value.IsAGENCIA_IDNull ? DBNull.Value : (object)value.AGENCIA_ID);
			AddParameter(cmd, "EDI_PATH", value.EDI_PATH);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "INFORMAR", value.INFORMAR);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			AddParameter(cmd, "BLOQUEO_ACTIVO", value.BLOQUEO_ACTIVO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>LINEAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>LINEAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>LINEAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LINEASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(LINEASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>LINEAS</c> table using
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
		/// Deletes records from the <c>LINEAS</c> table using the 
		/// <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAGENCIA_ID(decimal agencia_id)
		{
			return DeleteByAGENCIA_ID(agencia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS</c> table using the 
		/// <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAGENCIA_ID(decimal agencia_id, bool agencia_idNull)
		{
			return CreateDeleteByAGENCIA_IDCommand(agencia_id, agencia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LINEAS_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <param name="agencia_idNull">true if the method ignores the agencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAGENCIA_IDCommand(decimal agencia_id, bool agencia_idNull)
		{
			string whereSql = "";
			if(agencia_idNull)
				whereSql += "AGENCIA_ID IS NULL";
			else
				whereSql += "AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!agencia_idNull)
				AddParameter(cmd, "AGENCIA_ID", agencia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS</c> table using the 
		/// <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS</c> table using the 
		/// <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LINEAS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS</c> table using the 
		/// <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS</c> table using the 
		/// <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LINEAS_PROVEEDOR_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>LINEAS</c> records that match the specified criteria.
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
		/// to delete <c>LINEAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.LINEAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>LINEAS</c> table.
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
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		protected LINEASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		protected LINEASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="LINEASRow"/> objects.</returns>
		protected virtual LINEASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int agencia_idColumnIndex = reader.GetOrdinal("AGENCIA_ID");
			int edi_pathColumnIndex = reader.GetOrdinal("EDI_PATH");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int informarColumnIndex = reader.GetOrdinal("INFORMAR");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int bloqueo_activoColumnIndex = reader.GetOrdinal("BLOQUEO_ACTIVO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					LINEASRow record = new LINEASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(agencia_idColumnIndex))
						record.AGENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(agencia_idColumnIndex)), 9);
					if(!reader.IsDBNull(edi_pathColumnIndex))
						record.EDI_PATH = Convert.ToString(reader.GetValue(edi_pathColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(informarColumnIndex))
						record.INFORMAR = Convert.ToString(reader.GetValue(informarColumnIndex));
					if(!reader.IsDBNull(ordenColumnIndex))
						record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					record.BLOQUEO_ACTIVO = Convert.ToString(reader.GetValue(bloqueo_activoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LINEASRow[])(recordList.ToArray(typeof(LINEASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="LINEASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="LINEASRow"/> object.</returns>
		protected virtual LINEASRow MapRow(DataRow row)
		{
			LINEASRow mappedObject = new LINEASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "AGENCIA_ID"
			dataColumn = dataTable.Columns["AGENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_ID = (decimal)row[dataColumn];
			// Column "EDI_PATH"
			dataColumn = dataTable.Columns["EDI_PATH"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_PATH = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "INFORMAR"
			dataColumn = dataTable.Columns["INFORMAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.INFORMAR = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "BLOQUEO_ACTIVO"
			dataColumn = dataTable.Columns["BLOQUEO_ACTIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEO_ACTIVO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>LINEAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "LINEAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("AGENCIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EDI_PATH", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INFORMAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BLOQUEO_ACTIVO", typeof(string));
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

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AGENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EDI_PATH":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INFORMAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BLOQUEO_ACTIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of LINEASCollection_Base class
}  // End of namespace
