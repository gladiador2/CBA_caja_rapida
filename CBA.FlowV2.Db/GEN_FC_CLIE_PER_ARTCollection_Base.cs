// <fileinfo name="GEN_FC_CLIE_PER_ARTCollection_Base.cs">
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
	/// The base class for <see cref="GEN_FC_CLIE_PER_ARTCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="GEN_FC_CLIE_PER_ARTCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GEN_FC_CLIE_PER_ARTCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string GEN_FC_CLIE_ART_IDColumnName = "GEN_FC_CLIE_ART_ID";
		public const string GEN_FC_CLIE_PER_IDColumnName = "GEN_FC_CLIE_PER_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string PRECIO_UNITARIOColumnName = "PRECIO_UNITARIO";
		public const string TOTALColumnName = "TOTAL";
		public const string INCLUIRColumnName = "INCLUIR";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string PORCENTAJE_DTOColumnName = "PORCENTAJE_DTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="GEN_FC_CLIE_PER_ARTCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public GEN_FC_CLIE_PER_ARTCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>GEN_FC_CLIE_PER_ART</c> table.
		/// </summary>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public virtual GEN_FC_CLIE_PER_ARTRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>GEN_FC_CLIE_PER_ART</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>GEN_FC_CLIE_PER_ART</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="GEN_FC_CLIE_PER_ARTRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public GEN_FC_CLIE_PER_ARTRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			GEN_FC_CLIE_PER_ARTRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public GEN_FC_CLIE_PER_ARTRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects that 
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public virtual GEN_FC_CLIE_PER_ARTRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.GEN_FC_CLIE_PER_ART";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="GEN_FC_CLIE_PER_ARTRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="GEN_FC_CLIE_PER_ARTRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual GEN_FC_CLIE_PER_ARTRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			GEN_FC_CLIE_PER_ARTRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_art_id">The <c>GEN_FC_CLIE_ART_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public virtual GEN_FC_CLIE_PER_ARTRow[] GetByGEN_FC_CLIE_ART_ID(decimal gen_fc_clie_art_id)
		{
			return MapRecords(CreateGetByGEN_FC_CLIE_ART_IDCommand(gen_fc_clie_art_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_art_id">The <c>GEN_FC_CLIE_ART_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByGEN_FC_CLIE_ART_IDAsDataTable(decimal gen_fc_clie_art_id)
		{
			return MapRecordsToDataTable(CreateGetByGEN_FC_CLIE_ART_IDCommand(gen_fc_clie_art_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GEN_FC_CLIE_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_art_id">The <c>GEN_FC_CLIE_ART_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByGEN_FC_CLIE_ART_IDCommand(decimal gen_fc_clie_art_id)
		{
			string whereSql = "";
			whereSql += "GEN_FC_CLIE_ART_ID=" + _db.CreateSqlParameterName("GEN_FC_CLIE_ART_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "GEN_FC_CLIE_ART_ID", gen_fc_clie_art_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects 
		/// by the <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public GEN_FC_CLIE_PER_ARTRow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return GetByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects 
		/// by the <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public virtual GEN_FC_CLIE_PER_ARTRow[] GetByIMPUESTO_ID(decimal impuesto_id, bool impuesto_idNull)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return GetByIMPUESTO_IDAsDataTable(impuesto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id, bool impuesto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPUESTO_IDCommand(decimal impuesto_id, bool impuesto_idNull)
		{
			string whereSql = "";
			if(impuesto_idNull)
				whereSql += "IMPUESTO_ID IS NULL";
			else
				whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!impuesto_idNull)
				AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects 
		/// by the <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public GEN_FC_CLIE_PER_ARTRow[] GetByGEN_FC_CLIE_PER_ID(decimal gen_fc_clie_per_id)
		{
			return GetByGEN_FC_CLIE_PER_ID(gen_fc_clie_per_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects 
		/// by the <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <param name="gen_fc_clie_per_idNull">true if the method ignores the gen_fc_clie_per_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		public virtual GEN_FC_CLIE_PER_ARTRow[] GetByGEN_FC_CLIE_PER_ID(decimal gen_fc_clie_per_id, bool gen_fc_clie_per_idNull)
		{
			return MapRecords(CreateGetByGEN_FC_CLIE_PER_IDCommand(gen_fc_clie_per_id, gen_fc_clie_per_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByGEN_FC_CLIE_PER_IDAsDataTable(decimal gen_fc_clie_per_id)
		{
			return GetByGEN_FC_CLIE_PER_IDAsDataTable(gen_fc_clie_per_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <param name="gen_fc_clie_per_idNull">true if the method ignores the gen_fc_clie_per_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByGEN_FC_CLIE_PER_IDAsDataTable(decimal gen_fc_clie_per_id, bool gen_fc_clie_per_idNull)
		{
			return MapRecordsToDataTable(CreateGetByGEN_FC_CLIE_PER_IDCommand(gen_fc_clie_per_id, gen_fc_clie_per_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <param name="gen_fc_clie_per_idNull">true if the method ignores the gen_fc_clie_per_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByGEN_FC_CLIE_PER_IDCommand(decimal gen_fc_clie_per_id, bool gen_fc_clie_per_idNull)
		{
			string whereSql = "";
			if(gen_fc_clie_per_idNull)
				whereSql += "GEN_FC_CLIE_PER_ID IS NULL";
			else
				whereSql += "GEN_FC_CLIE_PER_ID=" + _db.CreateSqlParameterName("GEN_FC_CLIE_PER_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!gen_fc_clie_per_idNull)
				AddParameter(cmd, "GEN_FC_CLIE_PER_ID", gen_fc_clie_per_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>GEN_FC_CLIE_PER_ART</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GEN_FC_CLIE_PER_ARTRow"/> object to be inserted.</param>
		public virtual void Insert(GEN_FC_CLIE_PER_ARTRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.GEN_FC_CLIE_PER_ART (" +
				"ID, " +
				"GEN_FC_CLIE_ART_ID, " +
				"GEN_FC_CLIE_PER_ID, " +
				"CANTIDAD, " +
				"PRECIO_UNITARIO, " +
				"TOTAL, " +
				"INCLUIR, " +
				"OBSERVACION, " +
				"IMPUESTO_ID, " +
				"PORCENTAJE_DTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("GEN_FC_CLIE_ART_ID") + ", " +
				_db.CreateSqlParameterName("GEN_FC_CLIE_PER_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("PRECIO_UNITARIO") + ", " +
				_db.CreateSqlParameterName("TOTAL") + ", " +
				_db.CreateSqlParameterName("INCLUIR") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "GEN_FC_CLIE_ART_ID", value.GEN_FC_CLIE_ART_ID);
			AddParameter(cmd, "GEN_FC_CLIE_PER_ID",
				value.IsGEN_FC_CLIE_PER_IDNull ? DBNull.Value : (object)value.GEN_FC_CLIE_PER_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "PRECIO_UNITARIO",
				value.IsPRECIO_UNITARIONull ? DBNull.Value : (object)value.PRECIO_UNITARIO);
			AddParameter(cmd, "TOTAL",
				value.IsTOTALNull ? DBNull.Value : (object)value.TOTAL);
			AddParameter(cmd, "INCLUIR", value.INCLUIR);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "PORCENTAJE_DTO",
				value.IsPORCENTAJE_DTONull ? DBNull.Value : (object)value.PORCENTAJE_DTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>GEN_FC_CLIE_PER_ART</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GEN_FC_CLIE_PER_ARTRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(GEN_FC_CLIE_PER_ARTRow value)
		{
			
			string sqlStr = "UPDATE TRC.GEN_FC_CLIE_PER_ART SET " +
				"GEN_FC_CLIE_ART_ID=" + _db.CreateSqlParameterName("GEN_FC_CLIE_ART_ID") + ", " +
				"GEN_FC_CLIE_PER_ID=" + _db.CreateSqlParameterName("GEN_FC_CLIE_PER_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"PRECIO_UNITARIO=" + _db.CreateSqlParameterName("PRECIO_UNITARIO") + ", " +
				"TOTAL=" + _db.CreateSqlParameterName("TOTAL") + ", " +
				"INCLUIR=" + _db.CreateSqlParameterName("INCLUIR") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"PORCENTAJE_DTO=" + _db.CreateSqlParameterName("PORCENTAJE_DTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "GEN_FC_CLIE_ART_ID", value.GEN_FC_CLIE_ART_ID);
			AddParameter(cmd, "GEN_FC_CLIE_PER_ID",
				value.IsGEN_FC_CLIE_PER_IDNull ? DBNull.Value : (object)value.GEN_FC_CLIE_PER_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "PRECIO_UNITARIO",
				value.IsPRECIO_UNITARIONull ? DBNull.Value : (object)value.PRECIO_UNITARIO);
			AddParameter(cmd, "TOTAL",
				value.IsTOTALNull ? DBNull.Value : (object)value.TOTAL);
			AddParameter(cmd, "INCLUIR", value.INCLUIR);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "PORCENTAJE_DTO",
				value.IsPORCENTAJE_DTONull ? DBNull.Value : (object)value.PORCENTAJE_DTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>GEN_FC_CLIE_PER_ART</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>GEN_FC_CLIE_PER_ART</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>GEN_FC_CLIE_PER_ART</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GEN_FC_CLIE_PER_ARTRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(GEN_FC_CLIE_PER_ARTRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>GEN_FC_CLIE_PER_ART</c> table using
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
		/// Deletes records from the <c>GEN_FC_CLIE_PER_ART</c> table using the 
		/// <c>FK_GEN_FC_CLIE_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_art_id">The <c>GEN_FC_CLIE_ART_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGEN_FC_CLIE_ART_ID(decimal gen_fc_clie_art_id)
		{
			return CreateDeleteByGEN_FC_CLIE_ART_IDCommand(gen_fc_clie_art_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GEN_FC_CLIE_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_art_id">The <c>GEN_FC_CLIE_ART_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByGEN_FC_CLIE_ART_IDCommand(decimal gen_fc_clie_art_id)
		{
			string whereSql = "";
			whereSql += "GEN_FC_CLIE_ART_ID=" + _db.CreateSqlParameterName("GEN_FC_CLIE_ART_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "GEN_FC_CLIE_ART_ID", gen_fc_clie_art_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIE_PER_ART</c> table using the 
		/// <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return DeleteByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIE_PER_ART</c> table using the 
		/// <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id, bool impuesto_idNull)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENFCCLIEPERART_IMP_ID</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPUESTO_IDCommand(decimal impuesto_id, bool impuesto_idNull)
		{
			string whereSql = "";
			if(impuesto_idNull)
				whereSql += "IMPUESTO_ID IS NULL";
			else
				whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!impuesto_idNull)
				AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIE_PER_ART</c> table using the 
		/// <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGEN_FC_CLIE_PER_ID(decimal gen_fc_clie_per_id)
		{
			return DeleteByGEN_FC_CLIE_PER_ID(gen_fc_clie_per_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIE_PER_ART</c> table using the 
		/// <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <param name="gen_fc_clie_per_idNull">true if the method ignores the gen_fc_clie_per_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGEN_FC_CLIE_PER_ID(decimal gen_fc_clie_per_id, bool gen_fc_clie_per_idNull)
		{
			return CreateDeleteByGEN_FC_CLIE_PER_IDCommand(gen_fc_clie_per_id, gen_fc_clie_per_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>GEN_FC_CLIE_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="gen_fc_clie_per_id">The <c>GEN_FC_CLIE_PER_ID</c> column value.</param>
		/// <param name="gen_fc_clie_per_idNull">true if the method ignores the gen_fc_clie_per_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByGEN_FC_CLIE_PER_IDCommand(decimal gen_fc_clie_per_id, bool gen_fc_clie_per_idNull)
		{
			string whereSql = "";
			if(gen_fc_clie_per_idNull)
				whereSql += "GEN_FC_CLIE_PER_ID IS NULL";
			else
				whereSql += "GEN_FC_CLIE_PER_ID=" + _db.CreateSqlParameterName("GEN_FC_CLIE_PER_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!gen_fc_clie_per_idNull)
				AddParameter(cmd, "GEN_FC_CLIE_PER_ID", gen_fc_clie_per_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>GEN_FC_CLIE_PER_ART</c> records that match the specified criteria.
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
		/// to delete <c>GEN_FC_CLIE_PER_ART</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.GEN_FC_CLIE_PER_ART";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>GEN_FC_CLIE_PER_ART</c> table.
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		protected GEN_FC_CLIE_PER_ARTRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		protected GEN_FC_CLIE_PER_ARTRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PER_ARTRow"/> objects.</returns>
		protected virtual GEN_FC_CLIE_PER_ARTRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int gen_fc_clie_art_idColumnIndex = reader.GetOrdinal("GEN_FC_CLIE_ART_ID");
			int gen_fc_clie_per_idColumnIndex = reader.GetOrdinal("GEN_FC_CLIE_PER_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int precio_unitarioColumnIndex = reader.GetOrdinal("PRECIO_UNITARIO");
			int totalColumnIndex = reader.GetOrdinal("TOTAL");
			int incluirColumnIndex = reader.GetOrdinal("INCLUIR");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int porcentaje_dtoColumnIndex = reader.GetOrdinal("PORCENTAJE_DTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					GEN_FC_CLIE_PER_ARTRow record = new GEN_FC_CLIE_PER_ARTRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.GEN_FC_CLIE_ART_ID = Math.Round(Convert.ToDecimal(reader.GetValue(gen_fc_clie_art_idColumnIndex)), 9);
					if(!reader.IsDBNull(gen_fc_clie_per_idColumnIndex))
						record.GEN_FC_CLIE_PER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(gen_fc_clie_per_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(precio_unitarioColumnIndex))
						record.PRECIO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(totalColumnIndex))
						record.TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(totalColumnIndex)), 9);
					if(!reader.IsDBNull(incluirColumnIndex))
						record.INCLUIR = Convert.ToString(reader.GetValue(incluirColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_dtoColumnIndex))
						record.PORCENTAJE_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_dtoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (GEN_FC_CLIE_PER_ARTRow[])(recordList.ToArray(typeof(GEN_FC_CLIE_PER_ARTRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="GEN_FC_CLIE_PER_ARTRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="GEN_FC_CLIE_PER_ARTRow"/> object.</returns>
		protected virtual GEN_FC_CLIE_PER_ARTRow MapRow(DataRow row)
		{
			GEN_FC_CLIE_PER_ARTRow mappedObject = new GEN_FC_CLIE_PER_ARTRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "GEN_FC_CLIE_ART_ID"
			dataColumn = dataTable.Columns["GEN_FC_CLIE_ART_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GEN_FC_CLIE_ART_ID = (decimal)row[dataColumn];
			// Column "GEN_FC_CLIE_PER_ID"
			dataColumn = dataTable.Columns["GEN_FC_CLIE_PER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GEN_FC_CLIE_PER_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "PRECIO_UNITARIO"
			dataColumn = dataTable.Columns["PRECIO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_UNITARIO = (decimal)row[dataColumn];
			// Column "TOTAL"
			dataColumn = dataTable.Columns["TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL = (decimal)row[dataColumn];
			// Column "INCLUIR"
			dataColumn = dataTable.Columns["INCLUIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUIR = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DTO"
			dataColumn = dataTable.Columns["PORCENTAJE_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DTO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>GEN_FC_CLIE_PER_ART</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "GEN_FC_CLIE_PER_ART";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GEN_FC_CLIE_ART_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GEN_FC_CLIE_PER_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECIO_UNITARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INCLUIR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DTO", typeof(decimal));
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

				case "GEN_FC_CLIE_ART_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GEN_FC_CLIE_PER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INCLUIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of GEN_FC_CLIE_PER_ARTCollection_Base class
}  // End of namespace
