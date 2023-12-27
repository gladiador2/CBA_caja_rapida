// <fileinfo name="CTACTE_PLANES_DESEMBOLSOCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PLANES_DESEMBOLSOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PLANES_DESEMBOLSOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PLANES_DESEMBOLSOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_PROCESADORA_IDColumnName = "CTACTE_PROCESADORA_ID";
		public const string CTACTE_RED_PAGO_IDColumnName = "CTACTE_RED_PAGO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string USAR_VALIDEZColumnName = "USAR_VALIDEZ";
		public const string VALIDEZ_DESDEColumnName = "VALIDEZ_DESDE";
		public const string VALIDEZ_HASTAColumnName = "VALIDEZ_HASTA";
		public const string CONDICION_DESEMBOLSO_IDColumnName = "CONDICION_DESEMBOLSO_ID";
		public const string POLITICA_PRIMER_DESEMBOLSOColumnName = "POLITICA_PRIMER_DESEMBOLSO";
		public const string DIAS_DESDE_INICIO_MESColumnName = "DIAS_DESDE_INICIO_MES";
		public const string DESEMBOLSO_AUTOMATICOColumnName = "DESEMBOLSO_AUTOMATICO";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PLANES_DESEMBOLSOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PLANES_DESEMBOLSOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public virtual CTACTE_PLANES_DESEMBOLSORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PLANES_DESEMBOLSORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PLANES_DESEMBOLSORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public CTACTE_PLANES_DESEMBOLSORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public virtual CTACTE_PLANES_DESEMBOLSORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PLANES_DESEMBOLSO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PLANES_DESEMBOLSORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PLANES_DESEMBOLSORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PLANES_DESEMBOLSORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects 
		/// by the <c>FK_CTACTE_COND_DESEMBOLSO</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public virtual CTACTE_PLANES_DESEMBOLSORow[] GetByCONDICION_DESEMBOLSO_ID(decimal condicion_desembolso_id)
		{
			return MapRecords(CreateGetByCONDICION_DESEMBOLSO_IDCommand(condicion_desembolso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_COND_DESEMBOLSO</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_DESEMBOLSO_IDAsDataTable(decimal condicion_desembolso_id)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_DESEMBOLSO_IDCommand(condicion_desembolso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_COND_DESEMBOLSO</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_DESEMBOLSO_IDCommand(decimal condicion_desembolso_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONDICION_DESEMBOLSO_ID", condicion_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects 
		/// by the <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public CTACTE_PLANES_DESEMBOLSORow[] GetByCTACTE_PROCESADORA_ID(decimal ctacte_procesadora_id)
		{
			return GetByCTACTE_PROCESADORA_ID(ctacte_procesadora_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects 
		/// by the <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_idNull">true if the method ignores the ctacte_procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public virtual CTACTE_PLANES_DESEMBOLSORow[] GetByCTACTE_PROCESADORA_ID(decimal ctacte_procesadora_id, bool ctacte_procesadora_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROCESADORA_IDCommand(ctacte_procesadora_id, ctacte_procesadora_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROCESADORA_IDAsDataTable(decimal ctacte_procesadora_id)
		{
			return GetByCTACTE_PROCESADORA_IDAsDataTable(ctacte_procesadora_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_idNull">true if the method ignores the ctacte_procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROCESADORA_IDAsDataTable(decimal ctacte_procesadora_id, bool ctacte_procesadora_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROCESADORA_IDCommand(ctacte_procesadora_id, ctacte_procesadora_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_idNull">true if the method ignores the ctacte_procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROCESADORA_IDCommand(decimal ctacte_procesadora_id, bool ctacte_procesadora_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_idNull)
				whereSql += "CTACTE_PROCESADORA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_procesadora_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_ID", ctacte_procesadora_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects 
		/// by the <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public CTACTE_PLANES_DESEMBOLSORow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects 
		/// by the <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		public virtual CTACTE_PLANES_DESEMBOLSORow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RED_PAGO_IDAsDataTable(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_IDAsDataTable(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RED_PAGO_IDAsDataTable(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RED_PAGO_IDCommand(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			string whereSql = "";
			if(ctacte_red_pago_idNull)
				whereSql += "CTACTE_RED_PAGO_ID IS NULL";
			else
				whereSql += "CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_red_pago_idNull)
				AddParameter(cmd, "CTACTE_RED_PAGO_ID", ctacte_red_pago_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PLANES_DESEMBOLSORow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PLANES_DESEMBOLSORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PLANES_DESEMBOLSO (" +
				"ID, " +
				"CTACTE_PROCESADORA_ID, " +
				"CTACTE_RED_PAGO_ID, " +
				"NOMBRE, " +
				"USAR_VALIDEZ, " +
				"VALIDEZ_DESDE, " +
				"VALIDEZ_HASTA, " +
				"CONDICION_DESEMBOLSO_ID, " +
				"POLITICA_PRIMER_DESEMBOLSO, " +
				"DIAS_DESDE_INICIO_MES, " +
				"DESEMBOLSO_AUTOMATICO, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROCESADORA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("USAR_VALIDEZ") + ", " +
				_db.CreateSqlParameterName("VALIDEZ_DESDE") + ", " +
				_db.CreateSqlParameterName("VALIDEZ_HASTA") + ", " +
				_db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID") + ", " +
				_db.CreateSqlParameterName("POLITICA_PRIMER_DESEMBOLSO") + ", " +
				_db.CreateSqlParameterName("DIAS_DESDE_INICIO_MES") + ", " +
				_db.CreateSqlParameterName("DESEMBOLSO_AUTOMATICO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_ID",
				value.IsCTACTE_PROCESADORA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "USAR_VALIDEZ", value.USAR_VALIDEZ);
			AddParameter(cmd, "VALIDEZ_DESDE",
				value.IsVALIDEZ_DESDENull ? DBNull.Value : (object)value.VALIDEZ_DESDE);
			AddParameter(cmd, "VALIDEZ_HASTA",
				value.IsVALIDEZ_HASTANull ? DBNull.Value : (object)value.VALIDEZ_HASTA);
			AddParameter(cmd, "CONDICION_DESEMBOLSO_ID", value.CONDICION_DESEMBOLSO_ID);
			AddParameter(cmd, "POLITICA_PRIMER_DESEMBOLSO", value.POLITICA_PRIMER_DESEMBOLSO);
			AddParameter(cmd, "DIAS_DESDE_INICIO_MES", value.DIAS_DESDE_INICIO_MES);
			AddParameter(cmd, "DESEMBOLSO_AUTOMATICO", value.DESEMBOLSO_AUTOMATICO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PLANES_DESEMBOLSORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PLANES_DESEMBOLSORow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PLANES_DESEMBOLSO SET " +
				"CTACTE_PROCESADORA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_ID") + ", " +
				"CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"USAR_VALIDEZ=" + _db.CreateSqlParameterName("USAR_VALIDEZ") + ", " +
				"VALIDEZ_DESDE=" + _db.CreateSqlParameterName("VALIDEZ_DESDE") + ", " +
				"VALIDEZ_HASTA=" + _db.CreateSqlParameterName("VALIDEZ_HASTA") + ", " +
				"CONDICION_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID") + ", " +
				"POLITICA_PRIMER_DESEMBOLSO=" + _db.CreateSqlParameterName("POLITICA_PRIMER_DESEMBOLSO") + ", " +
				"DIAS_DESDE_INICIO_MES=" + _db.CreateSqlParameterName("DIAS_DESDE_INICIO_MES") + ", " +
				"DESEMBOLSO_AUTOMATICO=" + _db.CreateSqlParameterName("DESEMBOLSO_AUTOMATICO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_PROCESADORA_ID",
				value.IsCTACTE_PROCESADORA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "USAR_VALIDEZ", value.USAR_VALIDEZ);
			AddParameter(cmd, "VALIDEZ_DESDE",
				value.IsVALIDEZ_DESDENull ? DBNull.Value : (object)value.VALIDEZ_DESDE);
			AddParameter(cmd, "VALIDEZ_HASTA",
				value.IsVALIDEZ_HASTANull ? DBNull.Value : (object)value.VALIDEZ_HASTA);
			AddParameter(cmd, "CONDICION_DESEMBOLSO_ID", value.CONDICION_DESEMBOLSO_ID);
			AddParameter(cmd, "POLITICA_PRIMER_DESEMBOLSO", value.POLITICA_PRIMER_DESEMBOLSO);
			AddParameter(cmd, "DIAS_DESDE_INICIO_MES", value.DIAS_DESDE_INICIO_MES);
			AddParameter(cmd, "DESEMBOLSO_AUTOMATICO", value.DESEMBOLSO_AUTOMATICO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PLANES_DESEMBOLSO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PLANES_DESEMBOLSO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PLANES_DESEMBOLSORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PLANES_DESEMBOLSORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PLANES_DESEMBOLSO</c> table using
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
		/// Deletes records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table using the 
		/// <c>FK_CTACTE_COND_DESEMBOLSO</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_DESEMBOLSO_ID(decimal condicion_desembolso_id)
		{
			return CreateDeleteByCONDICION_DESEMBOLSO_IDCommand(condicion_desembolso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_COND_DESEMBOLSO</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_DESEMBOLSO_IDCommand(decimal condicion_desembolso_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONDICION_DESEMBOLSO_ID", condicion_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table using the 
		/// <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_ID(decimal ctacte_procesadora_id)
		{
			return DeleteByCTACTE_PROCESADORA_ID(ctacte_procesadora_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table using the 
		/// <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_idNull">true if the method ignores the ctacte_procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_ID(decimal ctacte_procesadora_id, bool ctacte_procesadora_idNull)
		{
			return CreateDeleteByCTACTE_PROCESADORA_IDCommand(ctacte_procesadora_id, ctacte_procesadora_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROCESADORAS_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_id">The <c>CTACTE_PROCESADORA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_idNull">true if the method ignores the ctacte_procesadora_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROCESADORA_IDCommand(decimal ctacte_procesadora_id, bool ctacte_procesadora_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_idNull)
				whereSql += "CTACTE_PROCESADORA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_procesadora_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_ID", ctacte_procesadora_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table using the 
		/// <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return DeleteByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table using the 
		/// <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return CreateDeleteByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_REDES_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RED_PAGO_IDCommand(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			string whereSql = "";
			if(ctacte_red_pago_idNull)
				whereSql += "CTACTE_RED_PAGO_ID IS NULL";
			else
				whereSql += "CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_red_pago_idNull)
				AddParameter(cmd, "CTACTE_RED_PAGO_ID", ctacte_red_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_PLANES_DESEMBOLSO</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PLANES_DESEMBOLSO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PLANES_DESEMBOLSO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		protected CTACTE_PLANES_DESEMBOLSORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		protected CTACTE_PLANES_DESEMBOLSORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMBOLSORow"/> objects.</returns>
		protected virtual CTACTE_PLANES_DESEMBOLSORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_procesadora_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_ID");
			int ctacte_red_pago_idColumnIndex = reader.GetOrdinal("CTACTE_RED_PAGO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int usar_validezColumnIndex = reader.GetOrdinal("USAR_VALIDEZ");
			int validez_desdeColumnIndex = reader.GetOrdinal("VALIDEZ_DESDE");
			int validez_hastaColumnIndex = reader.GetOrdinal("VALIDEZ_HASTA");
			int condicion_desembolso_idColumnIndex = reader.GetOrdinal("CONDICION_DESEMBOLSO_ID");
			int politica_primer_desembolsoColumnIndex = reader.GetOrdinal("POLITICA_PRIMER_DESEMBOLSO");
			int dias_desde_inicio_mesColumnIndex = reader.GetOrdinal("DIAS_DESDE_INICIO_MES");
			int desembolso_automaticoColumnIndex = reader.GetOrdinal("DESEMBOLSO_AUTOMATICO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PLANES_DESEMBOLSORow record = new CTACTE_PLANES_DESEMBOLSORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadora_idColumnIndex))
						record.CTACTE_PROCESADORA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_red_pago_idColumnIndex))
						record.CTACTE_RED_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_red_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.USAR_VALIDEZ = Convert.ToString(reader.GetValue(usar_validezColumnIndex));
					if(!reader.IsDBNull(validez_desdeColumnIndex))
						record.VALIDEZ_DESDE = Convert.ToDateTime(reader.GetValue(validez_desdeColumnIndex));
					if(!reader.IsDBNull(validez_hastaColumnIndex))
						record.VALIDEZ_HASTA = Convert.ToDateTime(reader.GetValue(validez_hastaColumnIndex));
					record.CONDICION_DESEMBOLSO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_desembolso_idColumnIndex)), 9);
					record.POLITICA_PRIMER_DESEMBOLSO = Math.Round(Convert.ToDecimal(reader.GetValue(politica_primer_desembolsoColumnIndex)), 9);
					record.DIAS_DESDE_INICIO_MES = Math.Round(Convert.ToDecimal(reader.GetValue(dias_desde_inicio_mesColumnIndex)), 9);
					if(!reader.IsDBNull(desembolso_automaticoColumnIndex))
						record.DESEMBOLSO_AUTOMATICO = Convert.ToString(reader.GetValue(desembolso_automaticoColumnIndex));
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PLANES_DESEMBOLSORow[])(recordList.ToArray(typeof(CTACTE_PLANES_DESEMBOLSORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PLANES_DESEMBOLSORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PLANES_DESEMBOLSORow"/> object.</returns>
		protected virtual CTACTE_PLANES_DESEMBOLSORow MapRow(DataRow row)
		{
			CTACTE_PLANES_DESEMBOLSORow mappedObject = new CTACTE_PLANES_DESEMBOLSORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RED_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RED_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RED_PAGO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "USAR_VALIDEZ"
			dataColumn = dataTable.Columns["USAR_VALIDEZ"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_VALIDEZ = (string)row[dataColumn];
			// Column "VALIDEZ_DESDE"
			dataColumn = dataTable.Columns["VALIDEZ_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALIDEZ_DESDE = (System.DateTime)row[dataColumn];
			// Column "VALIDEZ_HASTA"
			dataColumn = dataTable.Columns["VALIDEZ_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALIDEZ_HASTA = (System.DateTime)row[dataColumn];
			// Column "CONDICION_DESEMBOLSO_ID"
			dataColumn = dataTable.Columns["CONDICION_DESEMBOLSO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_DESEMBOLSO_ID = (decimal)row[dataColumn];
			// Column "POLITICA_PRIMER_DESEMBOLSO"
			dataColumn = dataTable.Columns["POLITICA_PRIMER_DESEMBOLSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.POLITICA_PRIMER_DESEMBOLSO = (decimal)row[dataColumn];
			// Column "DIAS_DESDE_INICIO_MES"
			dataColumn = dataTable.Columns["DIAS_DESDE_INICIO_MES"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_DESDE_INICIO_MES = (decimal)row[dataColumn];
			// Column "DESEMBOLSO_AUTOMATICO"
			dataColumn = dataTable.Columns["DESEMBOLSO_AUTOMATICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_AUTOMATICO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PLANES_DESEMBOLSO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PLANES_DESEMBOLSO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RED_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("USAR_VALIDEZ", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VALIDEZ_DESDE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("VALIDEZ_HASTA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CONDICION_DESEMBOLSO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("POLITICA_PRIMER_DESEMBOLSO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIAS_DESDE_INICIO_MES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_AUTOMATICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "CTACTE_PROCESADORA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RED_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USAR_VALIDEZ":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VALIDEZ_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VALIDEZ_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONDICION_DESEMBOLSO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "POLITICA_PRIMER_DESEMBOLSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIAS_DESDE_INICIO_MES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESEMBOLSO_AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PLANES_DESEMBOLSOCollection_Base class
}  // End of namespace
