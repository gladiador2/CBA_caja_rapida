// <fileinfo name="CTACTE_CAJA_COMPOSICION_DETCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJA_COMPOSICION_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CAJA_COMPOSICION_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJA_COMPOSICION_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_CAJA_COMPOSICION_IDColumnName = "CTACTE_CAJA_COMPOSICION_ID";
		public const string MONEDAS_DENOMINACIONES_IDColumnName = "MONEDAS_DENOMINACIONES_ID";
		public const string GRUPOColumnName = "GRUPO";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string FECHA_SISTEMAColumnName = "FECHA_SISTEMA";
		public const string FECHA_MANUALColumnName = "FECHA_MANUAL";
		public const string SALDO_CAJAColumnName = "SALDO_CAJA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string MONTOColumnName = "MONTO";
		public const string COMENTARIOColumnName = "COMENTARIO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJA_COMPOSICION_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CAJA_COMPOSICION_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public virtual CTACTE_CAJA_COMPOSICION_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CAJA_COMPOSICION_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CAJA_COMPOSICION_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public CTACTE_CAJA_COMPOSICION_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public virtual CTACTE_CAJA_COMPOSICION_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CAJA_COMPOSICION_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CAJA_COMPOSICION_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CAJA_COMPOSICION_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_CAJ_COM</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_composicion_id">The <c>CTACTE_CAJA_COMPOSICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public virtual CTACTE_CAJA_COMPOSICION_DETRow[] GetByCTACTE_CAJA_COMPOSICION_ID(decimal ctacte_caja_composicion_id)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_COMPOSICION_IDCommand(ctacte_caja_composicion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_CAJ_COM</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_composicion_id">The <c>CTACTE_CAJA_COMPOSICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_COMPOSICION_IDAsDataTable(decimal ctacte_caja_composicion_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_COMPOSICION_IDCommand(ctacte_caja_composicion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJ_COMP_DET_CAJ_COM</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_composicion_id">The <c>CTACTE_CAJA_COMPOSICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_COMPOSICION_IDCommand(decimal ctacte_caja_composicion_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_COMPOSICION_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_COMPOSICION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CAJA_COMPOSICION_ID", ctacte_caja_composicion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public CTACTE_CAJA_COMPOSICION_DETRow[] GetByMONEDAS_DENOMINACIONES_ID(decimal monedas_denominaciones_id)
		{
			return GetByMONEDAS_DENOMINACIONES_ID(monedas_denominaciones_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <param name="monedas_denominaciones_idNull">true if the method ignores the monedas_denominaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public virtual CTACTE_CAJA_COMPOSICION_DETRow[] GetByMONEDAS_DENOMINACIONES_ID(decimal monedas_denominaciones_id, bool monedas_denominaciones_idNull)
		{
			return MapRecords(CreateGetByMONEDAS_DENOMINACIONES_IDCommand(monedas_denominaciones_id, monedas_denominaciones_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDAS_DENOMINACIONES_IDAsDataTable(decimal monedas_denominaciones_id)
		{
			return GetByMONEDAS_DENOMINACIONES_IDAsDataTable(monedas_denominaciones_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <param name="monedas_denominaciones_idNull">true if the method ignores the monedas_denominaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDAS_DENOMINACIONES_IDAsDataTable(decimal monedas_denominaciones_id, bool monedas_denominaciones_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDAS_DENOMINACIONES_IDCommand(monedas_denominaciones_id, monedas_denominaciones_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <param name="monedas_denominaciones_idNull">true if the method ignores the monedas_denominaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDAS_DENOMINACIONES_IDCommand(decimal monedas_denominaciones_id, bool monedas_denominaciones_idNull)
		{
			string whereSql = "";
			if(monedas_denominaciones_idNull)
				whereSql += "MONEDAS_DENOMINACIONES_ID IS NULL";
			else
				whereSql += "MONEDAS_DENOMINACIONES_ID=" + _db.CreateSqlParameterName("MONEDAS_DENOMINACIONES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!monedas_denominaciones_idNull)
				AddParameter(cmd, "MONEDAS_DENOMINACIONES_ID", monedas_denominaciones_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public virtual CTACTE_CAJA_COMPOSICION_DETRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJ_COMP_DET_MONEDAS</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public CTACTE_CAJA_COMPOSICION_DETRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		public virtual CTACTE_CAJA_COMPOSICION_DETRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CAJA_COMPOSICION_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CAJA_COMPOSICION_DET (" +
				"ID, " +
				"CTACTE_CAJA_COMPOSICION_ID, " +
				"MONEDAS_DENOMINACIONES_ID, " +
				"GRUPO, " +
				"CANTIDAD, " +
				"FECHA_SISTEMA, " +
				"FECHA_MANUAL, " +
				"SALDO_CAJA, " +
				"MONEDA_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"MONTO, " +
				"COMENTARIO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_COMPOSICION_ID") + ", " +
				_db.CreateSqlParameterName("MONEDAS_DENOMINACIONES_ID") + ", " +
				_db.CreateSqlParameterName("GRUPO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("FECHA_SISTEMA") + ", " +
				_db.CreateSqlParameterName("FECHA_MANUAL") + ", " +
				_db.CreateSqlParameterName("SALDO_CAJA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("COMENTARIO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_CAJA_COMPOSICION_ID", value.CTACTE_CAJA_COMPOSICION_ID);
			AddParameter(cmd, "MONEDAS_DENOMINACIONES_ID",
				value.IsMONEDAS_DENOMINACIONES_IDNull ? DBNull.Value : (object)value.MONEDAS_DENOMINACIONES_ID);
			AddParameter(cmd, "GRUPO",
				value.IsGRUPONull ? DBNull.Value : (object)value.GRUPO);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "FECHA_SISTEMA",
				value.IsFECHA_SISTEMANull ? DBNull.Value : (object)value.FECHA_SISTEMA);
			AddParameter(cmd, "FECHA_MANUAL",
				value.IsFECHA_MANUALNull ? DBNull.Value : (object)value.FECHA_MANUAL);
			AddParameter(cmd, "SALDO_CAJA",
				value.IsSALDO_CAJANull ? DBNull.Value : (object)value.SALDO_CAJA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CAJA_COMPOSICION_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CAJA_COMPOSICION_DET SET " +
				"CTACTE_CAJA_COMPOSICION_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_COMPOSICION_ID") + ", " +
				"MONEDAS_DENOMINACIONES_ID=" + _db.CreateSqlParameterName("MONEDAS_DENOMINACIONES_ID") + ", " +
				"GRUPO=" + _db.CreateSqlParameterName("GRUPO") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"FECHA_SISTEMA=" + _db.CreateSqlParameterName("FECHA_SISTEMA") + ", " +
				"FECHA_MANUAL=" + _db.CreateSqlParameterName("FECHA_MANUAL") + ", " +
				"SALDO_CAJA=" + _db.CreateSqlParameterName("SALDO_CAJA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"COMENTARIO=" + _db.CreateSqlParameterName("COMENTARIO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_CAJA_COMPOSICION_ID", value.CTACTE_CAJA_COMPOSICION_ID);
			AddParameter(cmd, "MONEDAS_DENOMINACIONES_ID",
				value.IsMONEDAS_DENOMINACIONES_IDNull ? DBNull.Value : (object)value.MONEDAS_DENOMINACIONES_ID);
			AddParameter(cmd, "GRUPO",
				value.IsGRUPONull ? DBNull.Value : (object)value.GRUPO);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "FECHA_SISTEMA",
				value.IsFECHA_SISTEMANull ? DBNull.Value : (object)value.FECHA_SISTEMA);
			AddParameter(cmd, "FECHA_MANUAL",
				value.IsFECHA_MANUALNull ? DBNull.Value : (object)value.FECHA_MANUAL);
			AddParameter(cmd, "SALDO_CAJA",
				value.IsSALDO_CAJANull ? DBNull.Value : (object)value.SALDO_CAJA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJA_COMPOSICION_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJA_COMPOSICION_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CAJA_COMPOSICION_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table using
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
		/// Deletes records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table using the 
		/// <c>FK_CTACTE_CAJ_COMP_DET_CAJ_COM</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_composicion_id">The <c>CTACTE_CAJA_COMPOSICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_COMPOSICION_ID(decimal ctacte_caja_composicion_id)
		{
			return CreateDeleteByCTACTE_CAJA_COMPOSICION_IDCommand(ctacte_caja_composicion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJ_COMP_DET_CAJ_COM</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_composicion_id">The <c>CTACTE_CAJA_COMPOSICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_COMPOSICION_IDCommand(decimal ctacte_caja_composicion_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_COMPOSICION_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_COMPOSICION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CAJA_COMPOSICION_ID", ctacte_caja_composicion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table using the 
		/// <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDAS_DENOMINACIONES_ID(decimal monedas_denominaciones_id)
		{
			return DeleteByMONEDAS_DENOMINACIONES_ID(monedas_denominaciones_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table using the 
		/// <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <param name="monedas_denominaciones_idNull">true if the method ignores the monedas_denominaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDAS_DENOMINACIONES_ID(decimal monedas_denominaciones_id, bool monedas_denominaciones_idNull)
		{
			return CreateDeleteByMONEDAS_DENOMINACIONES_IDCommand(monedas_denominaciones_id, monedas_denominaciones_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJ_COMP_DET_MON_DEN</c> foreign key.
		/// </summary>
		/// <param name="monedas_denominaciones_id">The <c>MONEDAS_DENOMINACIONES_ID</c> column value.</param>
		/// <param name="monedas_denominaciones_idNull">true if the method ignores the monedas_denominaciones_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDAS_DENOMINACIONES_IDCommand(decimal monedas_denominaciones_id, bool monedas_denominaciones_idNull)
		{
			string whereSql = "";
			if(monedas_denominaciones_idNull)
				whereSql += "MONEDAS_DENOMINACIONES_ID IS NULL";
			else
				whereSql += "MONEDAS_DENOMINACIONES_ID=" + _db.CreateSqlParameterName("MONEDAS_DENOMINACIONES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!monedas_denominaciones_idNull)
				AddParameter(cmd, "MONEDAS_DENOMINACIONES_ID", monedas_denominaciones_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table using the 
		/// <c>FK_CTACTE_CAJ_COMP_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJ_COMP_DET_MONEDAS</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table using the 
		/// <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table using the 
		/// <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJ_COMP_DET_TEX_PRE</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_CAJA_COMPOSICION_DET</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CAJA_COMPOSICION_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CAJA_COMPOSICION_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		protected CTACTE_CAJA_COMPOSICION_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		protected CTACTE_CAJA_COMPOSICION_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> objects.</returns>
		protected virtual CTACTE_CAJA_COMPOSICION_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_caja_composicion_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_COMPOSICION_ID");
			int monedas_denominaciones_idColumnIndex = reader.GetOrdinal("MONEDAS_DENOMINACIONES_ID");
			int grupoColumnIndex = reader.GetOrdinal("GRUPO");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int fecha_sistemaColumnIndex = reader.GetOrdinal("FECHA_SISTEMA");
			int fecha_manualColumnIndex = reader.GetOrdinal("FECHA_MANUAL");
			int saldo_cajaColumnIndex = reader.GetOrdinal("SALDO_CAJA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int comentarioColumnIndex = reader.GetOrdinal("COMENTARIO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CAJA_COMPOSICION_DETRow record = new CTACTE_CAJA_COMPOSICION_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_CAJA_COMPOSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_composicion_idColumnIndex)), 9);
					if(!reader.IsDBNull(monedas_denominaciones_idColumnIndex))
						record.MONEDAS_DENOMINACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(monedas_denominaciones_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupoColumnIndex))
						record.GRUPO = Math.Round(Convert.ToDecimal(reader.GetValue(grupoColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_sistemaColumnIndex))
						record.FECHA_SISTEMA = Convert.ToDateTime(reader.GetValue(fecha_sistemaColumnIndex));
					if(!reader.IsDBNull(fecha_manualColumnIndex))
						record.FECHA_MANUAL = Convert.ToDateTime(reader.GetValue(fecha_manualColumnIndex));
					if(!reader.IsDBNull(saldo_cajaColumnIndex))
						record.SALDO_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_cajaColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(comentarioColumnIndex))
						record.COMENTARIO = Convert.ToString(reader.GetValue(comentarioColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CAJA_COMPOSICION_DETRow[])(recordList.ToArray(typeof(CTACTE_CAJA_COMPOSICION_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CAJA_COMPOSICION_DETRow"/> object.</returns>
		protected virtual CTACTE_CAJA_COMPOSICION_DETRow MapRow(DataRow row)
		{
			CTACTE_CAJA_COMPOSICION_DETRow mappedObject = new CTACTE_CAJA_COMPOSICION_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_COMPOSICION_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_COMPOSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_COMPOSICION_ID = (decimal)row[dataColumn];
			// Column "MONEDAS_DENOMINACIONES_ID"
			dataColumn = dataTable.Columns["MONEDAS_DENOMINACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_DENOMINACIONES_ID = (decimal)row[dataColumn];
			// Column "GRUPO"
			dataColumn = dataTable.Columns["GRUPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "FECHA_SISTEMA"
			dataColumn = dataTable.Columns["FECHA_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SISTEMA = (System.DateTime)row[dataColumn];
			// Column "FECHA_MANUAL"
			dataColumn = dataTable.Columns["FECHA_MANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MANUAL = (System.DateTime)row[dataColumn];
			// Column "SALDO_CAJA"
			dataColumn = dataTable.Columns["SALDO_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_CAJA = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "COMENTARIO"
			dataColumn = dataTable.Columns["COMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMENTARIO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CAJA_COMPOSICION_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CAJA_COMPOSICION_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_COMPOSICION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDAS_DENOMINACIONES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GRUPO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_SISTEMA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_MANUAL", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("SALDO_CAJA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMENTARIO", typeof(string));
			dataColumn.MaxLength = 500;
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

				case "CTACTE_CAJA_COMPOSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDAS_DENOMINACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_MANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SALDO_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CAJA_COMPOSICION_DETCollection_Base class
}  // End of namespace
