// <fileinfo name="CALENDARIO_PAGOS_CR_PERSONASCollection_Base.cs">
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
	/// The base class for <see cref="CALENDARIO_PAGOS_CR_PERSONASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CALENDARIO_PAGOS_CR_PERSONASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CALENDARIO_PAGOS_CR_PERSONASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CREDITO_IDColumnName = "CREDITO_ID";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string MONTO_CAPITALColumnName = "MONTO_CAPITAL";
		public const string MONTO_INTERES_A_DEVENGARColumnName = "MONTO_INTERES_A_DEVENGAR";
		public const string NUMERO_CUOTAColumnName = "NUMERO_CUOTA";
		public const string ESTADOColumnName = "ESTADO";
		public const string MONTO_INTERES_DEVENGADOSColumnName = "MONTO_INTERES_DEVENGADOS";
		public const string MONTO_INTERES_EN_SUSPENSOColumnName = "MONTO_INTERES_EN_SUSPENSO";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string MONTO_IMPUESTOColumnName = "MONTO_IMPUESTO";
		public const string DEVENGAMIENTO_CAPITAL_A_COBRARColumnName = "DEVENGAMIENTO_CAPITAL_A_COBRAR";
		public const string DEVENGAMIENTO_INTERES_A_COBRARColumnName = "DEVENGAMIENTO_INTERES_A_COBRAR";
		public const string CTB_DEVENGAMIENTO_PRIMERO_IDColumnName = "CTB_DEVENGAMIENTO_PRIMERO_ID";
		public const string CANCELACION_ANTICIPADAColumnName = "CANCELACION_ANTICIPADA";
		public const string MONTO_MORA_MANUALColumnName = "MONTO_MORA_MANUAL";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CALENDARIO_PAGOS_CR_PERSONASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CALENDARIO_PAGOS_CR_PERSONASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_CR_PERSONASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CALENDARIO_PAGOS_CR_PERSONASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CALENDARIO_PAGOS_CR_PERSONASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public CALENDARIO_PAGOS_CR_PERSONASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects that 
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_CR_PERSONASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CALENDARIO_PAGOS_CR_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CALENDARIO_PAGOS_CR_PERSONASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CALENDARIO_PAGOS_CR_PERSONASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public CALENDARIO_PAGOS_CR_PERSONASRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_CR_PERSONASRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public CALENDARIO_PAGOS_CR_PERSONASRow[] GetByCTB_DEVENGAMIENTO_PRIMERO_ID(decimal ctb_devengamiento_primero_id)
		{
			return GetByCTB_DEVENGAMIENTO_PRIMERO_ID(ctb_devengamiento_primero_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <param name="ctb_devengamiento_primero_idNull">true if the method ignores the ctb_devengamiento_primero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_CR_PERSONASRow[] GetByCTB_DEVENGAMIENTO_PRIMERO_ID(decimal ctb_devengamiento_primero_id, bool ctb_devengamiento_primero_idNull)
		{
			return MapRecords(CreateGetByCTB_DEVENGAMIENTO_PRIMERO_IDCommand(ctb_devengamiento_primero_id, ctb_devengamiento_primero_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_DEVENGAMIENTO_PRIMERO_IDAsDataTable(decimal ctb_devengamiento_primero_id)
		{
			return GetByCTB_DEVENGAMIENTO_PRIMERO_IDAsDataTable(ctb_devengamiento_primero_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <param name="ctb_devengamiento_primero_idNull">true if the method ignores the ctb_devengamiento_primero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_DEVENGAMIENTO_PRIMERO_IDAsDataTable(decimal ctb_devengamiento_primero_id, bool ctb_devengamiento_primero_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_DEVENGAMIENTO_PRIMERO_IDCommand(ctb_devengamiento_primero_id, ctb_devengamiento_primero_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <param name="ctb_devengamiento_primero_idNull">true if the method ignores the ctb_devengamiento_primero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_DEVENGAMIENTO_PRIMERO_IDCommand(decimal ctb_devengamiento_primero_id, bool ctb_devengamiento_primero_idNull)
		{
			string whereSql = "";
			if(ctb_devengamiento_primero_idNull)
				whereSql += "CTB_DEVENGAMIENTO_PRIMERO_ID IS NULL";
			else
				whereSql += "CTB_DEVENGAMIENTO_PRIMERO_ID=" + _db.CreateSqlParameterName("CTB_DEVENGAMIENTO_PRIMERO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_devengamiento_primero_idNull)
				AddParameter(cmd, "CTB_DEVENGAMIENTO_PRIMERO_ID", ctb_devengamiento_primero_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_PERS_ID</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_CR_PERSONASRow[] GetByCREDITO_ID(decimal credito_id)
		{
			return MapRecords(CreateGetByCREDITO_IDCommand(credito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CALENDARIO_PAGOS_CR_PERS_ID</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCREDITO_IDAsDataTable(decimal credito_id)
		{
			return MapRecordsToDataTable(CreateGetByCREDITO_IDCommand(credito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CALENDARIO_PAGOS_CR_PERS_ID</c> foreign key.
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
		/// Adds a new record into the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> object to be inserted.</param>
		public virtual void Insert(CALENDARIO_PAGOS_CR_PERSONASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CALENDARIO_PAGOS_CR_PERSONAS (" +
				"ID, " +
				"CREDITO_ID, " +
				"FECHA_VENCIMIENTO, " +
				"MONTO_CAPITAL, " +
				"MONTO_INTERES_A_DEVENGAR, " +
				"NUMERO_CUOTA, " +
				"ESTADO, " +
				"MONTO_INTERES_DEVENGADOS, " +
				"MONTO_INTERES_EN_SUSPENSO, " +
				"CASO_ASOCIADO_ID, " +
				"MONTO_IMPUESTO, " +
				"DEVENGAMIENTO_CAPITAL_A_COBRAR, " +
				"DEVENGAMIENTO_INTERES_A_COBRAR, " +
				"CTB_DEVENGAMIENTO_PRIMERO_ID, " +
				"CANCELACION_ANTICIPADA, " +
				"MONTO_MORA_MANUAL" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERES_A_DEVENGAR") + ", " +
				_db.CreateSqlParameterName("NUMERO_CUOTA") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERES_DEVENGADOS") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERES_EN_SUSPENSO") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("DEVENGAMIENTO_CAPITAL_A_COBRAR") + ", " +
				_db.CreateSqlParameterName("DEVENGAMIENTO_INTERES_A_COBRAR") + ", " +
				_db.CreateSqlParameterName("CTB_DEVENGAMIENTO_PRIMERO_ID") + ", " +
				_db.CreateSqlParameterName("CANCELACION_ANTICIPADA") + ", " +
				_db.CreateSqlParameterName("MONTO_MORA_MANUAL") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CREDITO_ID", value.CREDITO_ID);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERES_A_DEVENGAR", value.MONTO_INTERES_A_DEVENGAR);
			AddParameter(cmd, "NUMERO_CUOTA", value.NUMERO_CUOTA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "MONTO_INTERES_DEVENGADOS", value.MONTO_INTERES_DEVENGADOS);
			AddParameter(cmd, "MONTO_INTERES_EN_SUSPENSO", value.MONTO_INTERES_EN_SUSPENSO);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "MONTO_IMPUESTO", value.MONTO_IMPUESTO);
			AddParameter(cmd, "DEVENGAMIENTO_CAPITAL_A_COBRAR", value.DEVENGAMIENTO_CAPITAL_A_COBRAR);
			AddParameter(cmd, "DEVENGAMIENTO_INTERES_A_COBRAR", value.DEVENGAMIENTO_INTERES_A_COBRAR);
			AddParameter(cmd, "CTB_DEVENGAMIENTO_PRIMERO_ID",
				value.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull ? DBNull.Value : (object)value.CTB_DEVENGAMIENTO_PRIMERO_ID);
			AddParameter(cmd, "CANCELACION_ANTICIPADA", value.CANCELACION_ANTICIPADA);
			AddParameter(cmd, "MONTO_MORA_MANUAL",
				value.IsMONTO_MORA_MANUALNull ? DBNull.Value : (object)value.MONTO_MORA_MANUAL);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CALENDARIO_PAGOS_CR_PERSONASRow value)
		{
			
			string sqlStr = "UPDATE TRC.CALENDARIO_PAGOS_CR_PERSONAS SET " +
				"CREDITO_ID=" + _db.CreateSqlParameterName("CREDITO_ID") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"MONTO_CAPITAL=" + _db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				"MONTO_INTERES_A_DEVENGAR=" + _db.CreateSqlParameterName("MONTO_INTERES_A_DEVENGAR") + ", " +
				"NUMERO_CUOTA=" + _db.CreateSqlParameterName("NUMERO_CUOTA") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"MONTO_INTERES_DEVENGADOS=" + _db.CreateSqlParameterName("MONTO_INTERES_DEVENGADOS") + ", " +
				"MONTO_INTERES_EN_SUSPENSO=" + _db.CreateSqlParameterName("MONTO_INTERES_EN_SUSPENSO") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"MONTO_IMPUESTO=" + _db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				"DEVENGAMIENTO_CAPITAL_A_COBRAR=" + _db.CreateSqlParameterName("DEVENGAMIENTO_CAPITAL_A_COBRAR") + ", " +
				"DEVENGAMIENTO_INTERES_A_COBRAR=" + _db.CreateSqlParameterName("DEVENGAMIENTO_INTERES_A_COBRAR") + ", " +
				"CTB_DEVENGAMIENTO_PRIMERO_ID=" + _db.CreateSqlParameterName("CTB_DEVENGAMIENTO_PRIMERO_ID") + ", " +
				"CANCELACION_ANTICIPADA=" + _db.CreateSqlParameterName("CANCELACION_ANTICIPADA") + ", " +
				"MONTO_MORA_MANUAL=" + _db.CreateSqlParameterName("MONTO_MORA_MANUAL") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CREDITO_ID", value.CREDITO_ID);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERES_A_DEVENGAR", value.MONTO_INTERES_A_DEVENGAR);
			AddParameter(cmd, "NUMERO_CUOTA", value.NUMERO_CUOTA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "MONTO_INTERES_DEVENGADOS", value.MONTO_INTERES_DEVENGADOS);
			AddParameter(cmd, "MONTO_INTERES_EN_SUSPENSO", value.MONTO_INTERES_EN_SUSPENSO);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "MONTO_IMPUESTO", value.MONTO_IMPUESTO);
			AddParameter(cmd, "DEVENGAMIENTO_CAPITAL_A_COBRAR", value.DEVENGAMIENTO_CAPITAL_A_COBRAR);
			AddParameter(cmd, "DEVENGAMIENTO_INTERES_A_COBRAR", value.DEVENGAMIENTO_INTERES_A_COBRAR);
			AddParameter(cmd, "CTB_DEVENGAMIENTO_PRIMERO_ID",
				value.IsCTB_DEVENGAMIENTO_PRIMERO_IDNull ? DBNull.Value : (object)value.CTB_DEVENGAMIENTO_PRIMERO_ID);
			AddParameter(cmd, "CANCELACION_ANTICIPADA", value.CANCELACION_ANTICIPADA);
			AddParameter(cmd, "MONTO_MORA_MANUAL",
				value.IsMONTO_MORA_MANUALNull ? DBNull.Value : (object)value.MONTO_MORA_MANUAL);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CALENDARIO_PAGOS_CR_PERSONASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table using
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
		/// Deletes records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table using the 
		/// <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table using the 
		/// <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CALENDARIO_PAGOS_CR_CASO_AS</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table using the 
		/// <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_DEVENGAMIENTO_PRIMERO_ID(decimal ctb_devengamiento_primero_id)
		{
			return DeleteByCTB_DEVENGAMIENTO_PRIMERO_ID(ctb_devengamiento_primero_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table using the 
		/// <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <param name="ctb_devengamiento_primero_idNull">true if the method ignores the ctb_devengamiento_primero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_DEVENGAMIENTO_PRIMERO_ID(decimal ctb_devengamiento_primero_id, bool ctb_devengamiento_primero_idNull)
		{
			return CreateDeleteByCTB_DEVENGAMIENTO_PRIMERO_IDCommand(ctb_devengamiento_primero_id, ctb_devengamiento_primero_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CALENDARIO_PAGOS_CR_DEVENG</c> foreign key.
		/// </summary>
		/// <param name="ctb_devengamiento_primero_id">The <c>CTB_DEVENGAMIENTO_PRIMERO_ID</c> column value.</param>
		/// <param name="ctb_devengamiento_primero_idNull">true if the method ignores the ctb_devengamiento_primero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_DEVENGAMIENTO_PRIMERO_IDCommand(decimal ctb_devengamiento_primero_id, bool ctb_devengamiento_primero_idNull)
		{
			string whereSql = "";
			if(ctb_devengamiento_primero_idNull)
				whereSql += "CTB_DEVENGAMIENTO_PRIMERO_ID IS NULL";
			else
				whereSql += "CTB_DEVENGAMIENTO_PRIMERO_ID=" + _db.CreateSqlParameterName("CTB_DEVENGAMIENTO_PRIMERO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_devengamiento_primero_idNull)
				AddParameter(cmd, "CTB_DEVENGAMIENTO_PRIMERO_ID", ctb_devengamiento_primero_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table using the 
		/// <c>FK_CALENDARIO_PAGOS_CR_PERS_ID</c> foreign key.
		/// </summary>
		/// <param name="credito_id">The <c>CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCREDITO_ID(decimal credito_id)
		{
			return CreateDeleteByCREDITO_IDCommand(credito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CALENDARIO_PAGOS_CR_PERS_ID</c> foreign key.
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
		/// Deletes <c>CALENDARIO_PAGOS_CR_PERSONAS</c> records that match the specified criteria.
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
		/// to delete <c>CALENDARIO_PAGOS_CR_PERSONAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CALENDARIO_PAGOS_CR_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		protected CALENDARIO_PAGOS_CR_PERSONASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		protected CALENDARIO_PAGOS_CR_PERSONASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> objects.</returns>
		protected virtual CALENDARIO_PAGOS_CR_PERSONASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int credito_idColumnIndex = reader.GetOrdinal("CREDITO_ID");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int monto_capitalColumnIndex = reader.GetOrdinal("MONTO_CAPITAL");
			int monto_interes_a_devengarColumnIndex = reader.GetOrdinal("MONTO_INTERES_A_DEVENGAR");
			int numero_cuotaColumnIndex = reader.GetOrdinal("NUMERO_CUOTA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int monto_interes_devengadosColumnIndex = reader.GetOrdinal("MONTO_INTERES_DEVENGADOS");
			int monto_interes_en_suspensoColumnIndex = reader.GetOrdinal("MONTO_INTERES_EN_SUSPENSO");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int monto_impuestoColumnIndex = reader.GetOrdinal("MONTO_IMPUESTO");
			int devengamiento_capital_a_cobrarColumnIndex = reader.GetOrdinal("DEVENGAMIENTO_CAPITAL_A_COBRAR");
			int devengamiento_interes_a_cobrarColumnIndex = reader.GetOrdinal("DEVENGAMIENTO_INTERES_A_COBRAR");
			int ctb_devengamiento_primero_idColumnIndex = reader.GetOrdinal("CTB_DEVENGAMIENTO_PRIMERO_ID");
			int cancelacion_anticipadaColumnIndex = reader.GetOrdinal("CANCELACION_ANTICIPADA");
			int monto_mora_manualColumnIndex = reader.GetOrdinal("MONTO_MORA_MANUAL");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CALENDARIO_PAGOS_CR_PERSONASRow record = new CALENDARIO_PAGOS_CR_PERSONASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(credito_idColumnIndex)), 9);
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					record.MONTO_CAPITAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capitalColumnIndex)), 9);
					record.MONTO_INTERES_A_DEVENGAR = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interes_a_devengarColumnIndex)), 9);
					record.NUMERO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(numero_cuotaColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.MONTO_INTERES_DEVENGADOS = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interes_devengadosColumnIndex)), 9);
					record.MONTO_INTERES_EN_SUSPENSO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interes_en_suspensoColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					record.MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_impuestoColumnIndex)), 9);
					record.DEVENGAMIENTO_CAPITAL_A_COBRAR = Math.Round(Convert.ToDecimal(reader.GetValue(devengamiento_capital_a_cobrarColumnIndex)), 9);
					record.DEVENGAMIENTO_INTERES_A_COBRAR = Math.Round(Convert.ToDecimal(reader.GetValue(devengamiento_interes_a_cobrarColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_devengamiento_primero_idColumnIndex))
						record.CTB_DEVENGAMIENTO_PRIMERO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_devengamiento_primero_idColumnIndex)), 9);
					record.CANCELACION_ANTICIPADA = Convert.ToString(reader.GetValue(cancelacion_anticipadaColumnIndex));
					if(!reader.IsDBNull(monto_mora_manualColumnIndex))
						record.MONTO_MORA_MANUAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_mora_manualColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CALENDARIO_PAGOS_CR_PERSONASRow[])(recordList.ToArray(typeof(CALENDARIO_PAGOS_CR_PERSONASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CALENDARIO_PAGOS_CR_PERSONASRow"/> object.</returns>
		protected virtual CALENDARIO_PAGOS_CR_PERSONASRow MapRow(DataRow row)
		{
			CALENDARIO_PAGOS_CR_PERSONASRow mappedObject = new CALENDARIO_PAGOS_CR_PERSONASRow();
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
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "MONTO_CAPITAL"
			dataColumn = dataTable.Columns["MONTO_CAPITAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL = (decimal)row[dataColumn];
			// Column "MONTO_INTERES_A_DEVENGAR"
			dataColumn = dataTable.Columns["MONTO_INTERES_A_DEVENGAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERES_A_DEVENGAR = (decimal)row[dataColumn];
			// Column "NUMERO_CUOTA"
			dataColumn = dataTable.Columns["NUMERO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUOTA = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "MONTO_INTERES_DEVENGADOS"
			dataColumn = dataTable.Columns["MONTO_INTERES_DEVENGADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERES_DEVENGADOS = (decimal)row[dataColumn];
			// Column "MONTO_INTERES_EN_SUSPENSO"
			dataColumn = dataTable.Columns["MONTO_INTERES_EN_SUSPENSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERES_EN_SUSPENSO = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "DEVENGAMIENTO_CAPITAL_A_COBRAR"
			dataColumn = dataTable.Columns["DEVENGAMIENTO_CAPITAL_A_COBRAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEVENGAMIENTO_CAPITAL_A_COBRAR = (decimal)row[dataColumn];
			// Column "DEVENGAMIENTO_INTERES_A_COBRAR"
			dataColumn = dataTable.Columns["DEVENGAMIENTO_INTERES_A_COBRAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEVENGAMIENTO_INTERES_A_COBRAR = (decimal)row[dataColumn];
			// Column "CTB_DEVENGAMIENTO_PRIMERO_ID"
			dataColumn = dataTable.Columns["CTB_DEVENGAMIENTO_PRIMERO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_DEVENGAMIENTO_PRIMERO_ID = (decimal)row[dataColumn];
			// Column "CANCELACION_ANTICIPADA"
			dataColumn = dataTable.Columns["CANCELACION_ANTICIPADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANCELACION_ANTICIPADA = (string)row[dataColumn];
			// Column "MONTO_MORA_MANUAL"
			dataColumn = dataTable.Columns["MONTO_MORA_MANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_MORA_MANUAL = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CALENDARIO_PAGOS_CR_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CALENDARIO_PAGOS_CR_PERSONAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INTERES_A_DEVENGAR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INTERES_DEVENGADOS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INTERES_EN_SUSPENSO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEVENGAMIENTO_CAPITAL_A_COBRAR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEVENGAMIENTO_INTERES_A_COBRAR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_DEVENGAMIENTO_PRIMERO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANCELACION_ANTICIPADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_MORA_MANUAL", typeof(decimal));
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

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONTO_CAPITAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INTERES_A_DEVENGAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_INTERES_DEVENGADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INTERES_EN_SUSPENSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEVENGAMIENTO_CAPITAL_A_COBRAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEVENGAMIENTO_INTERES_A_COBRAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_DEVENGAMIENTO_PRIMERO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANCELACION_ANTICIPADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_MORA_MANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CALENDARIO_PAGOS_CR_PERSONASCollection_Base class
}  // End of namespace
