// <fileinfo name="INTERCAMBIO_EQUIPOSCollection_Base.cs">
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
	/// The base class for <see cref="INTERCAMBIO_EQUIPOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INTERCAMBIO_EQUIPOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INTERCAMBIO_EQUIPOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string BUQUE_IDColumnName = "BUQUE_ID";
		public const string MANIFIESTO_IDColumnName = "MANIFIESTO_ID";
		public const string TIPO_EQUIPOColumnName = "TIPO_EQUIPO";
		public const string OPERACIONColumnName = "OPERACION";
		public const string PRE_EMBARQUE_IDColumnName = "PRE_EMBARQUE_ID";
		public const string FECHAColumnName = "FECHA";
		public const string FINALIZADOColumnName = "FINALIZADO";
		public const string MUELLE_IDColumnName = "MUELLE_ID";
		public const string INICIOColumnName = "INICIO";
		public const string FINColumnName = "FIN";
		public const string AMARREColumnName = "AMARRE";
		public const string DESAMARREColumnName = "DESAMARRE";
		public const string REMOVIDOS_BMBColumnName = "REMOVIDOS_BMB";
		public const string REMOVIDOS_BBColumnName = "REMOVIDOS_BB";
		public const string REMOVIDOS_OTROSColumnName = "REMOVIDOS_OTROS";
		public const string NOTIFICADO_CLIENTESColumnName = "NOTIFICADO_CLIENTES";
		public const string NOTIFICADO_LINEASColumnName = "NOTIFICADO_LINEAS";
		public const string NOTIFICADO_ARMADORESColumnName = "NOTIFICADO_ARMADORES";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INTERCAMBIO_EQUIPOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INTERCAMBIO_EQUIPOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INTERCAMBIO_EQUIPOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public virtual INTERCAMBIO_EQUIPOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INTERCAMBIO_EQUIPOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INTERCAMBIO_EQUIPOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INTERCAMBIO_EQUIPOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INTERCAMBIO_EQUIPOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INTERCAMBIO_EQUIPOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INTERCAMBIO_EQUIPOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public INTERCAMBIO_EQUIPOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects that 
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
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public virtual INTERCAMBIO_EQUIPOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INTERCAMBIO_EQUIPOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="INTERCAMBIO_EQUIPOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="INTERCAMBIO_EQUIPOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual INTERCAMBIO_EQUIPOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			INTERCAMBIO_EQUIPOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects 
		/// by the <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public INTERCAMBIO_EQUIPOSRow[] GetByBUQUE_ID(decimal buque_id)
		{
			return GetByBUQUE_ID(buque_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects 
		/// by the <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public virtual INTERCAMBIO_EQUIPOSRow[] GetByBUQUE_ID(decimal buque_id, bool buque_idNull)
		{
			return MapRecords(CreateGetByBUQUE_IDCommand(buque_id, buque_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBUQUE_IDAsDataTable(decimal buque_id)
		{
			return GetByBUQUE_IDAsDataTable(buque_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBUQUE_IDAsDataTable(decimal buque_id, bool buque_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBUQUE_IDCommand(buque_id, buque_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBUQUE_IDCommand(decimal buque_id, bool buque_idNull)
		{
			string whereSql = "";
			if(buque_idNull)
				whereSql += "BUQUE_ID IS NULL";
			else
				whereSql += "BUQUE_ID=" + _db.CreateSqlParameterName("BUQUE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!buque_idNull)
				AddParameter(cmd, "BUQUE_ID", buque_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects 
		/// by the <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public INTERCAMBIO_EQUIPOSRow[] GetByMANIFIESTO_ID(decimal manifiesto_id)
		{
			return GetByMANIFIESTO_ID(manifiesto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects 
		/// by the <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <param name="manifiesto_idNull">true if the method ignores the manifiesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public virtual INTERCAMBIO_EQUIPOSRow[] GetByMANIFIESTO_ID(decimal manifiesto_id, bool manifiesto_idNull)
		{
			return MapRecords(CreateGetByMANIFIESTO_IDCommand(manifiesto_id, manifiesto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMANIFIESTO_IDAsDataTable(decimal manifiesto_id)
		{
			return GetByMANIFIESTO_IDAsDataTable(manifiesto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <param name="manifiesto_idNull">true if the method ignores the manifiesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMANIFIESTO_IDAsDataTable(decimal manifiesto_id, bool manifiesto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMANIFIESTO_IDCommand(manifiesto_id, manifiesto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <param name="manifiesto_idNull">true if the method ignores the manifiesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMANIFIESTO_IDCommand(decimal manifiesto_id, bool manifiesto_idNull)
		{
			string whereSql = "";
			if(manifiesto_idNull)
				whereSql += "MANIFIESTO_ID IS NULL";
			else
				whereSql += "MANIFIESTO_ID=" + _db.CreateSqlParameterName("MANIFIESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!manifiesto_idNull)
				AddParameter(cmd, "MANIFIESTO_ID", manifiesto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects 
		/// by the <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public INTERCAMBIO_EQUIPOSRow[] GetByMUELLE_ID(decimal muelle_id)
		{
			return GetByMUELLE_ID(muelle_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects 
		/// by the <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <param name="muelle_idNull">true if the method ignores the muelle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		public virtual INTERCAMBIO_EQUIPOSRow[] GetByMUELLE_ID(decimal muelle_id, bool muelle_idNull)
		{
			return MapRecords(CreateGetByMUELLE_IDCommand(muelle_id, muelle_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMUELLE_IDAsDataTable(decimal muelle_id)
		{
			return GetByMUELLE_IDAsDataTable(muelle_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <param name="muelle_idNull">true if the method ignores the muelle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMUELLE_IDAsDataTable(decimal muelle_id, bool muelle_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMUELLE_IDCommand(muelle_id, muelle_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <param name="muelle_idNull">true if the method ignores the muelle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMUELLE_IDCommand(decimal muelle_id, bool muelle_idNull)
		{
			string whereSql = "";
			if(muelle_idNull)
				whereSql += "MUELLE_ID IS NULL";
			else
				whereSql += "MUELLE_ID=" + _db.CreateSqlParameterName("MUELLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!muelle_idNull)
				AddParameter(cmd, "MUELLE_ID", muelle_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>INTERCAMBIO_EQUIPOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INTERCAMBIO_EQUIPOSRow"/> object to be inserted.</param>
		public virtual void Insert(INTERCAMBIO_EQUIPOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.INTERCAMBIO_EQUIPOS (" +
				"ID, " +
				"NRO_COMPROBANTE, " +
				"BUQUE_ID, " +
				"MANIFIESTO_ID, " +
				"TIPO_EQUIPO, " +
				"OPERACION, " +
				"PRE_EMBARQUE_ID, " +
				"FECHA, " +
				"FINALIZADO, " +
				"MUELLE_ID, " +
				"INICIO, " +
				"FIN, " +
				"AMARRE, " +
				"DESAMARRE, " +
				"REMOVIDOS_BMB, " +
				"REMOVIDOS_BB, " +
				"REMOVIDOS_OTROS, " +
				"NOTIFICADO_CLIENTES, " +
				"NOTIFICADO_LINEAS, " +
				"NOTIFICADO_ARMADORES" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("BUQUE_ID") + ", " +
				_db.CreateSqlParameterName("MANIFIESTO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_EQUIPO") + ", " +
				_db.CreateSqlParameterName("OPERACION") + ", " +
				_db.CreateSqlParameterName("PRE_EMBARQUE_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("FINALIZADO") + ", " +
				_db.CreateSqlParameterName("MUELLE_ID") + ", " +
				_db.CreateSqlParameterName("INICIO") + ", " +
				_db.CreateSqlParameterName("FIN") + ", " +
				_db.CreateSqlParameterName("AMARRE") + ", " +
				_db.CreateSqlParameterName("DESAMARRE") + ", " +
				_db.CreateSqlParameterName("REMOVIDOS_BMB") + ", " +
				_db.CreateSqlParameterName("REMOVIDOS_BB") + ", " +
				_db.CreateSqlParameterName("REMOVIDOS_OTROS") + ", " +
				_db.CreateSqlParameterName("NOTIFICADO_CLIENTES") + ", " +
				_db.CreateSqlParameterName("NOTIFICADO_LINEAS") + ", " +
				_db.CreateSqlParameterName("NOTIFICADO_ARMADORES") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "BUQUE_ID",
				value.IsBUQUE_IDNull ? DBNull.Value : (object)value.BUQUE_ID);
			AddParameter(cmd, "MANIFIESTO_ID",
				value.IsMANIFIESTO_IDNull ? DBNull.Value : (object)value.MANIFIESTO_ID);
			AddParameter(cmd, "TIPO_EQUIPO", value.TIPO_EQUIPO);
			AddParameter(cmd, "OPERACION", value.OPERACION);
			AddParameter(cmd, "PRE_EMBARQUE_ID",
				value.IsPRE_EMBARQUE_IDNull ? DBNull.Value : (object)value.PRE_EMBARQUE_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "FINALIZADO", value.FINALIZADO);
			AddParameter(cmd, "MUELLE_ID",
				value.IsMUELLE_IDNull ? DBNull.Value : (object)value.MUELLE_ID);
			AddParameter(cmd, "INICIO",
				value.IsINICIONull ? DBNull.Value : (object)value.INICIO);
			AddParameter(cmd, "FIN",
				value.IsFINNull ? DBNull.Value : (object)value.FIN);
			AddParameter(cmd, "AMARRE",
				value.IsAMARRENull ? DBNull.Value : (object)value.AMARRE);
			AddParameter(cmd, "DESAMARRE",
				value.IsDESAMARRENull ? DBNull.Value : (object)value.DESAMARRE);
			AddParameter(cmd, "REMOVIDOS_BMB",
				value.IsREMOVIDOS_BMBNull ? DBNull.Value : (object)value.REMOVIDOS_BMB);
			AddParameter(cmd, "REMOVIDOS_BB",
				value.IsREMOVIDOS_BBNull ? DBNull.Value : (object)value.REMOVIDOS_BB);
			AddParameter(cmd, "REMOVIDOS_OTROS",
				value.IsREMOVIDOS_OTROSNull ? DBNull.Value : (object)value.REMOVIDOS_OTROS);
			AddParameter(cmd, "NOTIFICADO_CLIENTES", value.NOTIFICADO_CLIENTES);
			AddParameter(cmd, "NOTIFICADO_LINEAS", value.NOTIFICADO_LINEAS);
			AddParameter(cmd, "NOTIFICADO_ARMADORES", value.NOTIFICADO_ARMADORES);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>INTERCAMBIO_EQUIPOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INTERCAMBIO_EQUIPOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(INTERCAMBIO_EQUIPOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.INTERCAMBIO_EQUIPOS SET " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"BUQUE_ID=" + _db.CreateSqlParameterName("BUQUE_ID") + ", " +
				"MANIFIESTO_ID=" + _db.CreateSqlParameterName("MANIFIESTO_ID") + ", " +
				"TIPO_EQUIPO=" + _db.CreateSqlParameterName("TIPO_EQUIPO") + ", " +
				"OPERACION=" + _db.CreateSqlParameterName("OPERACION") + ", " +
				"PRE_EMBARQUE_ID=" + _db.CreateSqlParameterName("PRE_EMBARQUE_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"FINALIZADO=" + _db.CreateSqlParameterName("FINALIZADO") + ", " +
				"MUELLE_ID=" + _db.CreateSqlParameterName("MUELLE_ID") + ", " +
				"INICIO=" + _db.CreateSqlParameterName("INICIO") + ", " +
				"FIN=" + _db.CreateSqlParameterName("FIN") + ", " +
				"AMARRE=" + _db.CreateSqlParameterName("AMARRE") + ", " +
				"DESAMARRE=" + _db.CreateSqlParameterName("DESAMARRE") + ", " +
				"REMOVIDOS_BMB=" + _db.CreateSqlParameterName("REMOVIDOS_BMB") + ", " +
				"REMOVIDOS_BB=" + _db.CreateSqlParameterName("REMOVIDOS_BB") + ", " +
				"REMOVIDOS_OTROS=" + _db.CreateSqlParameterName("REMOVIDOS_OTROS") + ", " +
				"NOTIFICADO_CLIENTES=" + _db.CreateSqlParameterName("NOTIFICADO_CLIENTES") + ", " +
				"NOTIFICADO_LINEAS=" + _db.CreateSqlParameterName("NOTIFICADO_LINEAS") + ", " +
				"NOTIFICADO_ARMADORES=" + _db.CreateSqlParameterName("NOTIFICADO_ARMADORES") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "BUQUE_ID",
				value.IsBUQUE_IDNull ? DBNull.Value : (object)value.BUQUE_ID);
			AddParameter(cmd, "MANIFIESTO_ID",
				value.IsMANIFIESTO_IDNull ? DBNull.Value : (object)value.MANIFIESTO_ID);
			AddParameter(cmd, "TIPO_EQUIPO", value.TIPO_EQUIPO);
			AddParameter(cmd, "OPERACION", value.OPERACION);
			AddParameter(cmd, "PRE_EMBARQUE_ID",
				value.IsPRE_EMBARQUE_IDNull ? DBNull.Value : (object)value.PRE_EMBARQUE_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "FINALIZADO", value.FINALIZADO);
			AddParameter(cmd, "MUELLE_ID",
				value.IsMUELLE_IDNull ? DBNull.Value : (object)value.MUELLE_ID);
			AddParameter(cmd, "INICIO",
				value.IsINICIONull ? DBNull.Value : (object)value.INICIO);
			AddParameter(cmd, "FIN",
				value.IsFINNull ? DBNull.Value : (object)value.FIN);
			AddParameter(cmd, "AMARRE",
				value.IsAMARRENull ? DBNull.Value : (object)value.AMARRE);
			AddParameter(cmd, "DESAMARRE",
				value.IsDESAMARRENull ? DBNull.Value : (object)value.DESAMARRE);
			AddParameter(cmd, "REMOVIDOS_BMB",
				value.IsREMOVIDOS_BMBNull ? DBNull.Value : (object)value.REMOVIDOS_BMB);
			AddParameter(cmd, "REMOVIDOS_BB",
				value.IsREMOVIDOS_BBNull ? DBNull.Value : (object)value.REMOVIDOS_BB);
			AddParameter(cmd, "REMOVIDOS_OTROS",
				value.IsREMOVIDOS_OTROSNull ? DBNull.Value : (object)value.REMOVIDOS_OTROS);
			AddParameter(cmd, "NOTIFICADO_CLIENTES", value.NOTIFICADO_CLIENTES);
			AddParameter(cmd, "NOTIFICADO_LINEAS", value.NOTIFICADO_LINEAS);
			AddParameter(cmd, "NOTIFICADO_ARMADORES", value.NOTIFICADO_ARMADORES);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>INTERCAMBIO_EQUIPOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>INTERCAMBIO_EQUIPOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>INTERCAMBIO_EQUIPOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INTERCAMBIO_EQUIPOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(INTERCAMBIO_EQUIPOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>INTERCAMBIO_EQUIPOS</c> table using
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
		/// Deletes records from the <c>INTERCAMBIO_EQUIPOS</c> table using the 
		/// <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBUQUE_ID(decimal buque_id)
		{
			return DeleteByBUQUE_ID(buque_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INTERCAMBIO_EQUIPOS</c> table using the 
		/// <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBUQUE_ID(decimal buque_id, bool buque_idNull)
		{
			return CreateDeleteByBUQUE_IDCommand(buque_id, buque_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INTERCAMBIO_EQUIPO_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBUQUE_IDCommand(decimal buque_id, bool buque_idNull)
		{
			string whereSql = "";
			if(buque_idNull)
				whereSql += "BUQUE_ID IS NULL";
			else
				whereSql += "BUQUE_ID=" + _db.CreateSqlParameterName("BUQUE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!buque_idNull)
				AddParameter(cmd, "BUQUE_ID", buque_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INTERCAMBIO_EQUIPOS</c> table using the 
		/// <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMANIFIESTO_ID(decimal manifiesto_id)
		{
			return DeleteByMANIFIESTO_ID(manifiesto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INTERCAMBIO_EQUIPOS</c> table using the 
		/// <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <param name="manifiesto_idNull">true if the method ignores the manifiesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMANIFIESTO_ID(decimal manifiesto_id, bool manifiesto_idNull)
		{
			return CreateDeleteByMANIFIESTO_IDCommand(manifiesto_id, manifiesto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INTERCAMBIO_MANIFIESTO_ID</c> foreign key.
		/// </summary>
		/// <param name="manifiesto_id">The <c>MANIFIESTO_ID</c> column value.</param>
		/// <param name="manifiesto_idNull">true if the method ignores the manifiesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMANIFIESTO_IDCommand(decimal manifiesto_id, bool manifiesto_idNull)
		{
			string whereSql = "";
			if(manifiesto_idNull)
				whereSql += "MANIFIESTO_ID IS NULL";
			else
				whereSql += "MANIFIESTO_ID=" + _db.CreateSqlParameterName("MANIFIESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!manifiesto_idNull)
				AddParameter(cmd, "MANIFIESTO_ID", manifiesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INTERCAMBIO_EQUIPOS</c> table using the 
		/// <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMUELLE_ID(decimal muelle_id)
		{
			return DeleteByMUELLE_ID(muelle_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INTERCAMBIO_EQUIPOS</c> table using the 
		/// <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <param name="muelle_idNull">true if the method ignores the muelle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMUELLE_ID(decimal muelle_id, bool muelle_idNull)
		{
			return CreateDeleteByMUELLE_IDCommand(muelle_id, muelle_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INTERCAMBIO_MUELLE_ID</c> foreign key.
		/// </summary>
		/// <param name="muelle_id">The <c>MUELLE_ID</c> column value.</param>
		/// <param name="muelle_idNull">true if the method ignores the muelle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMUELLE_IDCommand(decimal muelle_id, bool muelle_idNull)
		{
			string whereSql = "";
			if(muelle_idNull)
				whereSql += "MUELLE_ID IS NULL";
			else
				whereSql += "MUELLE_ID=" + _db.CreateSqlParameterName("MUELLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!muelle_idNull)
				AddParameter(cmd, "MUELLE_ID", muelle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>INTERCAMBIO_EQUIPOS</c> records that match the specified criteria.
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
		/// to delete <c>INTERCAMBIO_EQUIPOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.INTERCAMBIO_EQUIPOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>INTERCAMBIO_EQUIPOS</c> table.
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
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		protected INTERCAMBIO_EQUIPOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		protected INTERCAMBIO_EQUIPOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INTERCAMBIO_EQUIPOSRow"/> objects.</returns>
		protected virtual INTERCAMBIO_EQUIPOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int buque_idColumnIndex = reader.GetOrdinal("BUQUE_ID");
			int manifiesto_idColumnIndex = reader.GetOrdinal("MANIFIESTO_ID");
			int tipo_equipoColumnIndex = reader.GetOrdinal("TIPO_EQUIPO");
			int operacionColumnIndex = reader.GetOrdinal("OPERACION");
			int pre_embarque_idColumnIndex = reader.GetOrdinal("PRE_EMBARQUE_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int finalizadoColumnIndex = reader.GetOrdinal("FINALIZADO");
			int muelle_idColumnIndex = reader.GetOrdinal("MUELLE_ID");
			int inicioColumnIndex = reader.GetOrdinal("INICIO");
			int finColumnIndex = reader.GetOrdinal("FIN");
			int amarreColumnIndex = reader.GetOrdinal("AMARRE");
			int desamarreColumnIndex = reader.GetOrdinal("DESAMARRE");
			int removidos_bmbColumnIndex = reader.GetOrdinal("REMOVIDOS_BMB");
			int removidos_bbColumnIndex = reader.GetOrdinal("REMOVIDOS_BB");
			int removidos_otrosColumnIndex = reader.GetOrdinal("REMOVIDOS_OTROS");
			int notificado_clientesColumnIndex = reader.GetOrdinal("NOTIFICADO_CLIENTES");
			int notificado_lineasColumnIndex = reader.GetOrdinal("NOTIFICADO_LINEAS");
			int notificado_armadoresColumnIndex = reader.GetOrdinal("NOTIFICADO_ARMADORES");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INTERCAMBIO_EQUIPOSRow record = new INTERCAMBIO_EQUIPOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(buque_idColumnIndex))
						record.BUQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(buque_idColumnIndex)), 9);
					if(!reader.IsDBNull(manifiesto_idColumnIndex))
						record.MANIFIESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(manifiesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_equipoColumnIndex))
						record.TIPO_EQUIPO = Convert.ToString(reader.GetValue(tipo_equipoColumnIndex));
					if(!reader.IsDBNull(operacionColumnIndex))
						record.OPERACION = Convert.ToString(reader.GetValue(operacionColumnIndex));
					if(!reader.IsDBNull(pre_embarque_idColumnIndex))
						record.PRE_EMBARQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pre_embarque_idColumnIndex)), 9);
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.FINALIZADO = Convert.ToString(reader.GetValue(finalizadoColumnIndex));
					if(!reader.IsDBNull(muelle_idColumnIndex))
						record.MUELLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(muelle_idColumnIndex)), 9);
					if(!reader.IsDBNull(inicioColumnIndex))
						record.INICIO = Convert.ToDateTime(reader.GetValue(inicioColumnIndex));
					if(!reader.IsDBNull(finColumnIndex))
						record.FIN = Convert.ToDateTime(reader.GetValue(finColumnIndex));
					if(!reader.IsDBNull(amarreColumnIndex))
						record.AMARRE = Convert.ToDateTime(reader.GetValue(amarreColumnIndex));
					if(!reader.IsDBNull(desamarreColumnIndex))
						record.DESAMARRE = Convert.ToDateTime(reader.GetValue(desamarreColumnIndex));
					if(!reader.IsDBNull(removidos_bmbColumnIndex))
						record.REMOVIDOS_BMB = Math.Round(Convert.ToDecimal(reader.GetValue(removidos_bmbColumnIndex)), 9);
					if(!reader.IsDBNull(removidos_bbColumnIndex))
						record.REMOVIDOS_BB = Math.Round(Convert.ToDecimal(reader.GetValue(removidos_bbColumnIndex)), 9);
					if(!reader.IsDBNull(removidos_otrosColumnIndex))
						record.REMOVIDOS_OTROS = Math.Round(Convert.ToDecimal(reader.GetValue(removidos_otrosColumnIndex)), 9);
					if(!reader.IsDBNull(notificado_clientesColumnIndex))
						record.NOTIFICADO_CLIENTES = Convert.ToString(reader.GetValue(notificado_clientesColumnIndex));
					if(!reader.IsDBNull(notificado_lineasColumnIndex))
						record.NOTIFICADO_LINEAS = Convert.ToString(reader.GetValue(notificado_lineasColumnIndex));
					if(!reader.IsDBNull(notificado_armadoresColumnIndex))
						record.NOTIFICADO_ARMADORES = Convert.ToString(reader.GetValue(notificado_armadoresColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INTERCAMBIO_EQUIPOSRow[])(recordList.ToArray(typeof(INTERCAMBIO_EQUIPOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INTERCAMBIO_EQUIPOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INTERCAMBIO_EQUIPOSRow"/> object.</returns>
		protected virtual INTERCAMBIO_EQUIPOSRow MapRow(DataRow row)
		{
			INTERCAMBIO_EQUIPOSRow mappedObject = new INTERCAMBIO_EQUIPOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "BUQUE_ID"
			dataColumn = dataTable.Columns["BUQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE_ID = (decimal)row[dataColumn];
			// Column "MANIFIESTO_ID"
			dataColumn = dataTable.Columns["MANIFIESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MANIFIESTO_ID = (decimal)row[dataColumn];
			// Column "TIPO_EQUIPO"
			dataColumn = dataTable.Columns["TIPO_EQUIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EQUIPO = (string)row[dataColumn];
			// Column "OPERACION"
			dataColumn = dataTable.Columns["OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERACION = (string)row[dataColumn];
			// Column "PRE_EMBARQUE_ID"
			dataColumn = dataTable.Columns["PRE_EMBARQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRE_EMBARQUE_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FINALIZADO"
			dataColumn = dataTable.Columns["FINALIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FINALIZADO = (string)row[dataColumn];
			// Column "MUELLE_ID"
			dataColumn = dataTable.Columns["MUELLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MUELLE_ID = (decimal)row[dataColumn];
			// Column "INICIO"
			dataColumn = dataTable.Columns["INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INICIO = (System.DateTime)row[dataColumn];
			// Column "FIN"
			dataColumn = dataTable.Columns["FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FIN = (System.DateTime)row[dataColumn];
			// Column "AMARRE"
			dataColumn = dataTable.Columns["AMARRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AMARRE = (System.DateTime)row[dataColumn];
			// Column "DESAMARRE"
			dataColumn = dataTable.Columns["DESAMARRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESAMARRE = (System.DateTime)row[dataColumn];
			// Column "REMOVIDOS_BMB"
			dataColumn = dataTable.Columns["REMOVIDOS_BMB"];
			if(!row.IsNull(dataColumn))
				mappedObject.REMOVIDOS_BMB = (decimal)row[dataColumn];
			// Column "REMOVIDOS_BB"
			dataColumn = dataTable.Columns["REMOVIDOS_BB"];
			if(!row.IsNull(dataColumn))
				mappedObject.REMOVIDOS_BB = (decimal)row[dataColumn];
			// Column "REMOVIDOS_OTROS"
			dataColumn = dataTable.Columns["REMOVIDOS_OTROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.REMOVIDOS_OTROS = (decimal)row[dataColumn];
			// Column "NOTIFICADO_CLIENTES"
			dataColumn = dataTable.Columns["NOTIFICADO_CLIENTES"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTIFICADO_CLIENTES = (string)row[dataColumn];
			// Column "NOTIFICADO_LINEAS"
			dataColumn = dataTable.Columns["NOTIFICADO_LINEAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTIFICADO_LINEAS = (string)row[dataColumn];
			// Column "NOTIFICADO_ARMADORES"
			dataColumn = dataTable.Columns["NOTIFICADO_ARMADORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTIFICADO_ARMADORES = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INTERCAMBIO_EQUIPOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INTERCAMBIO_EQUIPOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("BUQUE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MANIFIESTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_EQUIPO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("OPERACION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PRE_EMBARQUE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FINALIZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MUELLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("AMARRE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("DESAMARRE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("REMOVIDOS_BMB", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REMOVIDOS_BB", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REMOVIDOS_OTROS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOTIFICADO_CLIENTES", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NOTIFICADO_LINEAS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NOTIFICADO_ARMADORES", typeof(string));
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

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BUQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MANIFIESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_EQUIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRE_EMBARQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FINALIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MUELLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AMARRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESAMARRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "REMOVIDOS_BMB":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REMOVIDOS_BB":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REMOVIDOS_OTROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTIFICADO_CLIENTES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOTIFICADO_LINEAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOTIFICADO_ARMADORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INTERCAMBIO_EQUIPOSCollection_Base class
}  // End of namespace
