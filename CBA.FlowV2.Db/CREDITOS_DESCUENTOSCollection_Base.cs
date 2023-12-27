// <fileinfo name="CREDITOS_DESCUENTOSCollection_Base.cs">
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
	/// The base class for <see cref="CREDITOS_DESCUENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CREDITOS_DESCUENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOS_DESCUENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CREDITO_IDColumnName = "CREDITO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONTOColumnName = "MONTO";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string CTACTE_PERSONA_IDColumnName = "CTACTE_PERSONA_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CASO_CREADO_IDColumnName = "CASO_CREADO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOS_DESCUENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CREDITOS_DESCUENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CREDITOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public virtual CREDITOS_DESCUENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CREDITOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CREDITOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CREDITOS_DESCUENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CREDITOS_DESCUENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CREDITOS_DESCUENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CREDITOS_DESCUENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public CREDITOS_DESCUENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public virtual CREDITOS_DESCUENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CREDITOS_DESCUENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CREDITOS_DESCUENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CREDITOS_DESCUENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CREDITOS_DESCUENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CREDITOS_DESCUENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public CREDITOS_DESCUENTOSRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public virtual CREDITOS_DESCUENTOSRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_IDAsDataTable(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public CREDITOS_DESCUENTOSRow[] GetByCASO_CREADO_ID(decimal caso_creado_id)
		{
			return GetByCASO_CREADO_ID(caso_creado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <param name="caso_creado_idNull">true if the method ignores the caso_creado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public virtual CREDITOS_DESCUENTOSRow[] GetByCASO_CREADO_ID(decimal caso_creado_id, bool caso_creado_idNull)
		{
			return MapRecords(CreateGetByCASO_CREADO_IDCommand(caso_creado_id, caso_creado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_CREADO_IDAsDataTable(decimal caso_creado_id)
		{
			return GetByCASO_CREADO_IDAsDataTable(caso_creado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <param name="caso_creado_idNull">true if the method ignores the caso_creado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_CREADO_IDAsDataTable(decimal caso_creado_id, bool caso_creado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_CREADO_IDCommand(caso_creado_id, caso_creado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <param name="caso_creado_idNull">true if the method ignores the caso_creado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_CREADO_IDCommand(decimal caso_creado_id, bool caso_creado_idNull)
		{
			string whereSql = "";
			if(caso_creado_idNull)
				whereSql += "CASO_CREADO_ID IS NULL";
			else
				whereSql += "CASO_CREADO_ID=" + _db.CreateSqlParameterName("CASO_CREADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_creado_idNull)
				AddParameter(cmd, "CASO_CREADO_ID", caso_creado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_CREDITOS_DESCUENTOS_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public virtual CREDITOS_DESCUENTOSRow[] GetByCREDITO_ID(decimal credito_id)
		{
			return MapRecords(CreateGetByCREDITO_IDCommand(credito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_DESCUENTOS_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCREDITO_IDAsDataTable(decimal credito_id)
		{
			return MapRecordsToDataTable(CreateGetByCREDITO_IDCommand(credito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_DESCUENTOS_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCREDITO_IDCommand(decimal credito_id)
		{
			string whereSql = "";
			whereSql += "CREDITO_ID=" + _db.CreateSqlParameterName("CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CREDITO_ID", credito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_CREDITOS_DESCUENTOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public virtual CREDITOS_DESCUENTOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_DESCUENTOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_DESCUENTOS_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CREDITOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_CREDITOS_DESCUENTOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		public virtual CREDITOS_DESCUENTOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_DESCUENTOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_DESCUENTOS_PERSONA</c> foreign key.
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
		/// Adds a new record into the <c>CREDITOS_DESCUENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_DESCUENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(CREDITOS_DESCUENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CREDITOS_DESCUENTOS (" +
				"ID, " +
				"CREDITO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"MONTO, " +
				"PERSONA_ID, " +
				"CTACTE_PERSONA_ID, " +
				"ESTADO, " +
				"OBSERVACION, " +
				"CASO_CREADO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CASO_CREADO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CREDITO_ID", value.CREDITO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CASO_CREADO_ID",
				value.IsCASO_CREADO_IDNull ? DBNull.Value : (object)value.CASO_CREADO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CREDITOS_DESCUENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_DESCUENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CREDITOS_DESCUENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CREDITOS_DESCUENTOS SET " +
				"CREDITO_ID=" + _db.CreateSqlParameterName("CREDITO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CASO_CREADO_ID=" + _db.CreateSqlParameterName("CASO_CREADO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CREDITO_ID", value.CREDITO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CASO_CREADO_ID",
				value.IsCASO_CREADO_IDNull ? DBNull.Value : (object)value.CASO_CREADO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CREDITOS_DESCUENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CREDITOS_DESCUENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CREDITOS_DESCUENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOS_DESCUENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CREDITOS_DESCUENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CREDITOS_DESCUENTOS</c> table using
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
		/// Deletes records from the <c>CREDITOS_DESCUENTOS</c> table using the 
		/// <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return DeleteByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_DESCUENTOS</c> table using the 
		/// <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return CreateDeleteByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_DESCUEN_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_DESCUENTOS</c> table using the 
		/// <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_CREADO_ID(decimal caso_creado_id)
		{
			return DeleteByCASO_CREADO_ID(caso_creado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_DESCUENTOS</c> table using the 
		/// <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <param name="caso_creado_idNull">true if the method ignores the caso_creado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_CREADO_ID(decimal caso_creado_id, bool caso_creado_idNull)
		{
			return CreateDeleteByCASO_CREADO_IDCommand(caso_creado_id, caso_creado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_DESCUENTOS_CASO_CR</c> foreign key.
		/// </summary>
		/// <param name="caso_creado_id">The <c>CASO_CREADO_ID</c> column value.</param>
		/// <param name="caso_creado_idNull">true if the method ignores the caso_creado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_CREADO_IDCommand(decimal caso_creado_id, bool caso_creado_idNull)
		{
			string whereSql = "";
			if(caso_creado_idNull)
				whereSql += "CASO_CREADO_ID IS NULL";
			else
				whereSql += "CASO_CREADO_ID=" + _db.CreateSqlParameterName("CASO_CREADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_creado_idNull)
				AddParameter(cmd, "CASO_CREADO_ID", caso_creado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_DESCUENTOS</c> table using the 
		/// <c>FK_CREDITOS_DESCUENTOS_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCREDITO_ID(decimal credito_id)
		{
			return CreateDeleteByCREDITO_IDCommand(credito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_DESCUENTOS_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCREDITO_IDCommand(decimal credito_id)
		{
			string whereSql = "";
			whereSql += "CREDITO_ID=" + _db.CreateSqlParameterName("CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CREDITO_ID", credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS_DESCUENTOS</c> table using the 
		/// <c>FK_CREDITOS_DESCUENTOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_DESCUENTOS_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CREDITOS_DESCUENTOS</c> table using the 
		/// <c>FK_CREDITOS_DESCUENTOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_DESCUENTOS_PERSONA</c> foreign key.
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
		/// Deletes <c>CREDITOS_DESCUENTOS</c> records that match the specified criteria.
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
		/// to delete <c>CREDITOS_DESCUENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CREDITOS_DESCUENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CREDITOS_DESCUENTOS</c> table.
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
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		protected CREDITOS_DESCUENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		protected CREDITOS_DESCUENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CREDITOS_DESCUENTOSRow"/> objects.</returns>
		protected virtual CREDITOS_DESCUENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int credito_idColumnIndex = reader.GetOrdinal("CREDITO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int ctacte_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int caso_creado_idColumnIndex = reader.GetOrdinal("CASO_CREADO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CREDITOS_DESCUENTOSRow record = new CREDITOS_DESCUENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(credito_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_persona_idColumnIndex))
						record.CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(caso_creado_idColumnIndex))
						record.CASO_CREADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_creado_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CREDITOS_DESCUENTOSRow[])(recordList.ToArray(typeof(CREDITOS_DESCUENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CREDITOS_DESCUENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CREDITOS_DESCUENTOSRow"/> object.</returns>
		protected virtual CREDITOS_DESCUENTOSRow MapRow(DataRow row)
		{
			CREDITOS_DESCUENTOSRow mappedObject = new CREDITOS_DESCUENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CREDITO_ID"
			dataColumn = dataTable.Columns["CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO_ID = (decimal)row[dataColumn];
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
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CASO_CREADO_ID"
			dataColumn = dataTable.Columns["CASO_CREADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_CREADO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CREDITOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CREDITOS_DESCUENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CASO_CREADO_ID", typeof(decimal));
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

				case "CREDITO_ID":
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_CREADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CREDITOS_DESCUENTOSCollection_Base class
}  // End of namespace
