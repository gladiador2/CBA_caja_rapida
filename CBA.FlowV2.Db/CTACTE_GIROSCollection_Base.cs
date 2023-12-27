// <fileinfo name="CTACTE_GIROSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_GIROSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_GIROSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_GIROSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHAColumnName = "FECHA";
		public const string MONTO_PAGOColumnName = "MONTO_PAGO";
		public const string COMISION_PORCENTAJEColumnName = "COMISION_PORCENTAJE";
		public const string COMISION_MONTO_FIJOColumnName = "COMISION_MONTO_FIJO";
		public const string MOTO_A_COBRARColumnName = "MOTO_A_COBRAR";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string CONDICION_DESEMBOLSO_IDColumnName = "CONDICION_DESEMBOLSO_ID";
		public const string DESEMBOLSO_AUTOMATICOColumnName = "DESEMBOLSO_AUTOMATICO";
		public const string POLITICA_PRIMER_DESEMBOLSOColumnName = "POLITICA_PRIMER_DESEMBOLSO";
		public const string DIAS_DESDE_INICIO_MESColumnName = "DIAS_DESDE_INICIO_MES";
		public const string COMPROBANTEColumnName = "COMPROBANTE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string CTACTE_PLANES_DESEMBOLSO_IDColumnName = "CTACTE_PLANES_DESEMBOLSO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_GIROSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_GIROSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_GIROS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public virtual CTACTE_GIROSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_GIROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_GIROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_GIROSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_GIROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_GIROSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_GIROSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public CTACTE_GIROSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public virtual CTACTE_GIROSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_GIROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_GIROSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_GIROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_GIROSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_GIROSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects 
		/// by the <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public CTACTE_GIROSRow[] GetByCONDICION_DESEMBOLSO_ID(decimal condicion_desembolso_id)
		{
			return GetByCONDICION_DESEMBOLSO_ID(condicion_desembolso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects 
		/// by the <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="condicion_desembolso_idNull">true if the method ignores the condicion_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public virtual CTACTE_GIROSRow[] GetByCONDICION_DESEMBOLSO_ID(decimal condicion_desembolso_id, bool condicion_desembolso_idNull)
		{
			return MapRecords(CreateGetByCONDICION_DESEMBOLSO_IDCommand(condicion_desembolso_id, condicion_desembolso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONDICION_DESEMBOLSO_IDAsDataTable(decimal condicion_desembolso_id)
		{
			return GetByCONDICION_DESEMBOLSO_IDAsDataTable(condicion_desembolso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="condicion_desembolso_idNull">true if the method ignores the condicion_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_DESEMBOLSO_IDAsDataTable(decimal condicion_desembolso_id, bool condicion_desembolso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_DESEMBOLSO_IDCommand(condicion_desembolso_id, condicion_desembolso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="condicion_desembolso_idNull">true if the method ignores the condicion_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_DESEMBOLSO_IDCommand(decimal condicion_desembolso_id, bool condicion_desembolso_idNull)
		{
			string whereSql = "";
			if(condicion_desembolso_idNull)
				whereSql += "CONDICION_DESEMBOLSO_ID IS NULL";
			else
				whereSql += "CONDICION_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!condicion_desembolso_idNull)
				AddParameter(cmd, "CONDICION_DESEMBOLSO_ID", condicion_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects 
		/// by the <c>FK_CTACTE_GIROS_CTACTE_PLA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_planes_desembolso_id">The <c>CTACTE_PLANES_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public virtual CTACTE_GIROSRow[] GetByCTACTE_PLANES_DESEMBOLSO_ID(decimal ctacte_planes_desembolso_id)
		{
			return MapRecords(CreateGetByCTACTE_PLANES_DESEMBOLSO_IDCommand(ctacte_planes_desembolso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GIROS_CTACTE_PLA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_planes_desembolso_id">The <c>CTACTE_PLANES_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PLANES_DESEMBOLSO_IDAsDataTable(decimal ctacte_planes_desembolso_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PLANES_DESEMBOLSO_IDCommand(ctacte_planes_desembolso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_GIROS_CTACTE_PLA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_planes_desembolso_id">The <c>CTACTE_PLANES_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PLANES_DESEMBOLSO_IDCommand(decimal ctacte_planes_desembolso_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PLANES_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CTACTE_PLANES_DESEMBOLSO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_PLANES_DESEMBOLSO_ID", ctacte_planes_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects 
		/// by the <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public CTACTE_GIROSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects 
		/// by the <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public virtual CTACTE_GIROSRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_GIROSRow"/> objects 
		/// by the <c>FK_CTACTE_GIROS_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		public virtual CTACTE_GIROSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GIROS_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_GIROS_PERSONAS</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_GIROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_GIROSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_GIROSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_GIROS (" +
				"ID, " +
				"FECHA, " +
				"MONTO_PAGO, " +
				"COMISION_PORCENTAJE, " +
				"COMISION_MONTO_FIJO, " +
				"MOTO_A_COBRAR, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"PERSONA_ID, " +
				"CONDICION_DESEMBOLSO_ID, " +
				"DESEMBOLSO_AUTOMATICO, " +
				"POLITICA_PRIMER_DESEMBOLSO, " +
				"DIAS_DESDE_INICIO_MES, " +
				"COMPROBANTE, " +
				"OBSERVACIONES, " +
				"CTACTE_PLANES_DESEMBOLSO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MONTO_PAGO") + ", " +
				_db.CreateSqlParameterName("COMISION_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("COMISION_MONTO_FIJO") + ", " +
				_db.CreateSqlParameterName("MOTO_A_COBRAR") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID") + ", " +
				_db.CreateSqlParameterName("DESEMBOLSO_AUTOMATICO") + ", " +
				_db.CreateSqlParameterName("POLITICA_PRIMER_DESEMBOLSO") + ", " +
				_db.CreateSqlParameterName("DIAS_DESDE_INICIO_MES") + ", " +
				_db.CreateSqlParameterName("COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("CTACTE_PLANES_DESEMBOLSO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONTO_PAGO",
				value.IsMONTO_PAGONull ? DBNull.Value : (object)value.MONTO_PAGO);
			AddParameter(cmd, "COMISION_PORCENTAJE",
				value.IsCOMISION_PORCENTAJENull ? DBNull.Value : (object)value.COMISION_PORCENTAJE);
			AddParameter(cmd, "COMISION_MONTO_FIJO",
				value.IsCOMISION_MONTO_FIJONull ? DBNull.Value : (object)value.COMISION_MONTO_FIJO);
			AddParameter(cmd, "MOTO_A_COBRAR",
				value.IsMOTO_A_COBRARNull ? DBNull.Value : (object)value.MOTO_A_COBRAR);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "CONDICION_DESEMBOLSO_ID",
				value.IsCONDICION_DESEMBOLSO_IDNull ? DBNull.Value : (object)value.CONDICION_DESEMBOLSO_ID);
			AddParameter(cmd, "DESEMBOLSO_AUTOMATICO", value.DESEMBOLSO_AUTOMATICO);
			AddParameter(cmd, "POLITICA_PRIMER_DESEMBOLSO",
				value.IsPOLITICA_PRIMER_DESEMBOLSONull ? DBNull.Value : (object)value.POLITICA_PRIMER_DESEMBOLSO);
			AddParameter(cmd, "DIAS_DESDE_INICIO_MES",
				value.IsDIAS_DESDE_INICIO_MESNull ? DBNull.Value : (object)value.DIAS_DESDE_INICIO_MES);
			AddParameter(cmd, "COMPROBANTE", value.COMPROBANTE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CTACTE_PLANES_DESEMBOLSO_ID", value.CTACTE_PLANES_DESEMBOLSO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_GIROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_GIROSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_GIROSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_GIROS SET " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MONTO_PAGO=" + _db.CreateSqlParameterName("MONTO_PAGO") + ", " +
				"COMISION_PORCENTAJE=" + _db.CreateSqlParameterName("COMISION_PORCENTAJE") + ", " +
				"COMISION_MONTO_FIJO=" + _db.CreateSqlParameterName("COMISION_MONTO_FIJO") + ", " +
				"MOTO_A_COBRAR=" + _db.CreateSqlParameterName("MOTO_A_COBRAR") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"CONDICION_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID") + ", " +
				"DESEMBOLSO_AUTOMATICO=" + _db.CreateSqlParameterName("DESEMBOLSO_AUTOMATICO") + ", " +
				"POLITICA_PRIMER_DESEMBOLSO=" + _db.CreateSqlParameterName("POLITICA_PRIMER_DESEMBOLSO") + ", " +
				"DIAS_DESDE_INICIO_MES=" + _db.CreateSqlParameterName("DIAS_DESDE_INICIO_MES") + ", " +
				"COMPROBANTE=" + _db.CreateSqlParameterName("COMPROBANTE") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"CTACTE_PLANES_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CTACTE_PLANES_DESEMBOLSO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONTO_PAGO",
				value.IsMONTO_PAGONull ? DBNull.Value : (object)value.MONTO_PAGO);
			AddParameter(cmd, "COMISION_PORCENTAJE",
				value.IsCOMISION_PORCENTAJENull ? DBNull.Value : (object)value.COMISION_PORCENTAJE);
			AddParameter(cmd, "COMISION_MONTO_FIJO",
				value.IsCOMISION_MONTO_FIJONull ? DBNull.Value : (object)value.COMISION_MONTO_FIJO);
			AddParameter(cmd, "MOTO_A_COBRAR",
				value.IsMOTO_A_COBRARNull ? DBNull.Value : (object)value.MOTO_A_COBRAR);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "CONDICION_DESEMBOLSO_ID",
				value.IsCONDICION_DESEMBOLSO_IDNull ? DBNull.Value : (object)value.CONDICION_DESEMBOLSO_ID);
			AddParameter(cmd, "DESEMBOLSO_AUTOMATICO", value.DESEMBOLSO_AUTOMATICO);
			AddParameter(cmd, "POLITICA_PRIMER_DESEMBOLSO",
				value.IsPOLITICA_PRIMER_DESEMBOLSONull ? DBNull.Value : (object)value.POLITICA_PRIMER_DESEMBOLSO);
			AddParameter(cmd, "DIAS_DESDE_INICIO_MES",
				value.IsDIAS_DESDE_INICIO_MESNull ? DBNull.Value : (object)value.DIAS_DESDE_INICIO_MES);
			AddParameter(cmd, "COMPROBANTE", value.COMPROBANTE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CTACTE_PLANES_DESEMBOLSO_ID", value.CTACTE_PLANES_DESEMBOLSO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_GIROS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_GIROS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_GIROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_GIROSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_GIROSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_GIROS</c> table using
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
		/// Deletes records from the <c>CTACTE_GIROS</c> table using the 
		/// <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_DESEMBOLSO_ID(decimal condicion_desembolso_id)
		{
			return DeleteByCONDICION_DESEMBOLSO_ID(condicion_desembolso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS</c> table using the 
		/// <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="condicion_desembolso_idNull">true if the method ignores the condicion_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_DESEMBOLSO_ID(decimal condicion_desembolso_id, bool condicion_desembolso_idNull)
		{
			return CreateDeleteByCONDICION_DESEMBOLSO_IDCommand(condicion_desembolso_id, condicion_desembolso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_GIROS_CON_DESEMB</c> foreign key.
		/// </summary>
		/// <param name="condicion_desembolso_id">The <c>CONDICION_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="condicion_desembolso_idNull">true if the method ignores the condicion_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_DESEMBOLSO_IDCommand(decimal condicion_desembolso_id, bool condicion_desembolso_idNull)
		{
			string whereSql = "";
			if(condicion_desembolso_idNull)
				whereSql += "CONDICION_DESEMBOLSO_ID IS NULL";
			else
				whereSql += "CONDICION_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CONDICION_DESEMBOLSO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!condicion_desembolso_idNull)
				AddParameter(cmd, "CONDICION_DESEMBOLSO_ID", condicion_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS</c> table using the 
		/// <c>FK_CTACTE_GIROS_CTACTE_PLA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_planes_desembolso_id">The <c>CTACTE_PLANES_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PLANES_DESEMBOLSO_ID(decimal ctacte_planes_desembolso_id)
		{
			return CreateDeleteByCTACTE_PLANES_DESEMBOLSO_IDCommand(ctacte_planes_desembolso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_GIROS_CTACTE_PLA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_planes_desembolso_id">The <c>CTACTE_PLANES_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PLANES_DESEMBOLSO_IDCommand(decimal ctacte_planes_desembolso_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PLANES_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CTACTE_PLANES_DESEMBOLSO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_PLANES_DESEMBOLSO_ID", ctacte_planes_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS</c> table using the 
		/// <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS</c> table using the 
		/// <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_GIROS_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_GIROS</c> table using the 
		/// <c>FK_CTACTE_GIROS_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_GIROS_PERSONAS</c> foreign key.
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
		/// Deletes <c>CTACTE_GIROS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_GIROS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_GIROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_GIROS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		protected CTACTE_GIROSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		protected CTACTE_GIROSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_GIROSRow"/> objects.</returns>
		protected virtual CTACTE_GIROSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int monto_pagoColumnIndex = reader.GetOrdinal("MONTO_PAGO");
			int comision_porcentajeColumnIndex = reader.GetOrdinal("COMISION_PORCENTAJE");
			int comision_monto_fijoColumnIndex = reader.GetOrdinal("COMISION_MONTO_FIJO");
			int moto_a_cobrarColumnIndex = reader.GetOrdinal("MOTO_A_COBRAR");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int condicion_desembolso_idColumnIndex = reader.GetOrdinal("CONDICION_DESEMBOLSO_ID");
			int desembolso_automaticoColumnIndex = reader.GetOrdinal("DESEMBOLSO_AUTOMATICO");
			int politica_primer_desembolsoColumnIndex = reader.GetOrdinal("POLITICA_PRIMER_DESEMBOLSO");
			int dias_desde_inicio_mesColumnIndex = reader.GetOrdinal("DIAS_DESDE_INICIO_MES");
			int comprobanteColumnIndex = reader.GetOrdinal("COMPROBANTE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int ctacte_planes_desembolso_idColumnIndex = reader.GetOrdinal("CTACTE_PLANES_DESEMBOLSO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_GIROSRow record = new CTACTE_GIROSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(monto_pagoColumnIndex))
						record.MONTO_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_pagoColumnIndex)), 9);
					if(!reader.IsDBNull(comision_porcentajeColumnIndex))
						record.COMISION_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(comision_porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(comision_monto_fijoColumnIndex))
						record.COMISION_MONTO_FIJO = Math.Round(Convert.ToDecimal(reader.GetValue(comision_monto_fijoColumnIndex)), 9);
					if(!reader.IsDBNull(moto_a_cobrarColumnIndex))
						record.MOTO_A_COBRAR = Math.Round(Convert.ToDecimal(reader.GetValue(moto_a_cobrarColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_desembolso_idColumnIndex))
						record.CONDICION_DESEMBOLSO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_desembolso_idColumnIndex)), 9);
					if(!reader.IsDBNull(desembolso_automaticoColumnIndex))
						record.DESEMBOLSO_AUTOMATICO = Convert.ToString(reader.GetValue(desembolso_automaticoColumnIndex));
					if(!reader.IsDBNull(politica_primer_desembolsoColumnIndex))
						record.POLITICA_PRIMER_DESEMBOLSO = Math.Round(Convert.ToDecimal(reader.GetValue(politica_primer_desembolsoColumnIndex)), 9);
					if(!reader.IsDBNull(dias_desde_inicio_mesColumnIndex))
						record.DIAS_DESDE_INICIO_MES = Math.Round(Convert.ToDecimal(reader.GetValue(dias_desde_inicio_mesColumnIndex)), 9);
					if(!reader.IsDBNull(comprobanteColumnIndex))
						record.COMPROBANTE = Convert.ToString(reader.GetValue(comprobanteColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					record.CTACTE_PLANES_DESEMBOLSO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_planes_desembolso_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_GIROSRow[])(recordList.ToArray(typeof(CTACTE_GIROSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_GIROSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_GIROSRow"/> object.</returns>
		protected virtual CTACTE_GIROSRow MapRow(DataRow row)
		{
			CTACTE_GIROSRow mappedObject = new CTACTE_GIROSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MONTO_PAGO"
			dataColumn = dataTable.Columns["MONTO_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PAGO = (decimal)row[dataColumn];
			// Column "COMISION_PORCENTAJE"
			dataColumn = dataTable.Columns["COMISION_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_PORCENTAJE = (decimal)row[dataColumn];
			// Column "COMISION_MONTO_FIJO"
			dataColumn = dataTable.Columns["COMISION_MONTO_FIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_MONTO_FIJO = (decimal)row[dataColumn];
			// Column "MOTO_A_COBRAR"
			dataColumn = dataTable.Columns["MOTO_A_COBRAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTO_A_COBRAR = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "CONDICION_DESEMBOLSO_ID"
			dataColumn = dataTable.Columns["CONDICION_DESEMBOLSO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_DESEMBOLSO_ID = (decimal)row[dataColumn];
			// Column "DESEMBOLSO_AUTOMATICO"
			dataColumn = dataTable.Columns["DESEMBOLSO_AUTOMATICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_AUTOMATICO = (string)row[dataColumn];
			// Column "POLITICA_PRIMER_DESEMBOLSO"
			dataColumn = dataTable.Columns["POLITICA_PRIMER_DESEMBOLSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.POLITICA_PRIMER_DESEMBOLSO = (decimal)row[dataColumn];
			// Column "DIAS_DESDE_INICIO_MES"
			dataColumn = dataTable.Columns["DIAS_DESDE_INICIO_MES"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_DESDE_INICIO_MES = (decimal)row[dataColumn];
			// Column "COMPROBANTE"
			dataColumn = dataTable.Columns["COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMPROBANTE = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "CTACTE_PLANES_DESEMBOLSO_ID"
			dataColumn = dataTable.Columns["CTACTE_PLANES_DESEMBOLSO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PLANES_DESEMBOLSO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_GIROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_GIROS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_PAGO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_PORCENTAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_MONTO_FIJO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MOTO_A_COBRAR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONDICION_DESEMBOLSO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_AUTOMATICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("POLITICA_PRIMER_DESEMBOLSO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DIAS_DESDE_INICIO_MES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CTACTE_PLANES_DESEMBOLSO_ID", typeof(decimal));
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

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONTO_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_MONTO_FIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOTO_A_COBRAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_DESEMBOLSO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESEMBOLSO_AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "POLITICA_PRIMER_DESEMBOLSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIAS_DESDE_INICIO_MES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PLANES_DESEMBOLSO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_GIROSCollection_Base class
}  // End of namespace
