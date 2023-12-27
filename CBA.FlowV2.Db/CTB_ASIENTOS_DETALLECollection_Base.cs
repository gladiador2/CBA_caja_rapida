// <fileinfo name="CTB_ASIENTOS_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_ASIENTO_IDColumnName = "CTB_ASIENTO_ID";
		public const string CTB_CUENTA_IDColumnName = "CTB_CUENTA_ID";
		public const string DEBEColumnName = "DEBE";
		public const string HABERColumnName = "HABER";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string ORDENColumnName = "ORDEN";
		public const string DEBE_ORIGENColumnName = "DEBE_ORIGEN";
		public const string HABER_ORIGENColumnName = "HABER_ORIGEN";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string OBSERVACION_SISTEMAColumnName = "OBSERVACION_SISTEMA";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public CTB_ASIENTOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_ASIENTOS_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_ASIENTOS_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_ASIENTOS_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_ASIENT</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_id">The <c>CTB_ASIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLERow[] GetByCTB_ASIENTO_ID(decimal ctb_asiento_id)
		{
			return MapRecords(CreateGetByCTB_ASIENTO_IDCommand(ctb_asiento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_ASIENT</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_id">The <c>CTB_ASIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_ASIENTO_IDAsDataTable(decimal ctb_asiento_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_ASIENTO_IDCommand(ctb_asiento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_DETALLE_ASIENT</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_id">The <c>CTB_ASIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_ASIENTO_IDCommand(decimal ctb_asiento_id)
		{
			string whereSql = "";
			whereSql += "CTB_ASIENTO_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_ASIENTO_ID", ctb_asiento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLERow[] GetByCTB_CUENTA_ID(decimal ctb_cuenta_id)
		{
			return MapRecords(CreateGetByCTB_CUENTA_IDCommand(ctb_cuenta_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_CUENTA_IDAsDataTable(decimal ctb_cuenta_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_CUENTA_IDCommand(ctb_cuenta_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_DETALLE_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_CUENTA_IDCommand(decimal ctb_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_CUENTA_ID", ctb_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public CTB_ASIENTOS_DETALLERow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLERow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_IDAsDataTable(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			string whereSql = "";
			if(moneda_origen_idNull)
				whereSql += "MONEDA_ORIGEN_ID IS NULL";
			else
				whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_origen_idNull)
				AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLERow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_DETALLE_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DETALLERow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_DETALLE_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_DETALLE_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_ASIENTOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(CTB_ASIENTOS_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_ASIENTOS_DETALLE (" +
				"ID, " +
				"CTB_ASIENTO_ID, " +
				"CTB_CUENTA_ID, " +
				"DEBE, " +
				"HABER, " +
				"OBSERVACION, " +
				"FECHA, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"ORDEN, " +
				"DEBE_ORIGEN, " +
				"HABER_ORIGEN, " +
				"MONEDA_ORIGEN_ID, " +
				"COTIZACION_MONEDA_ORIGEN, " +
				"OBSERVACION_SISTEMA, " +
				"USUARIO_CREACION_ID, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_ASIENTO_ID") + ", " +
				_db.CreateSqlParameterName("CTB_CUENTA_ID") + ", " +
				_db.CreateSqlParameterName("DEBE") + ", " +
				_db.CreateSqlParameterName("HABER") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("DEBE_ORIGEN") + ", " +
				_db.CreateSqlParameterName("HABER_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_SISTEMA") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_ASIENTO_ID", value.CTB_ASIENTO_ID);
			AddParameter(cmd, "CTB_CUENTA_ID", value.CTB_CUENTA_ID);
			AddParameter(cmd, "DEBE", value.DEBE);
			AddParameter(cmd, "HABER", value.HABER);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			AddParameter(cmd, "DEBE_ORIGEN",
				value.IsDEBE_ORIGENNull ? DBNull.Value : (object)value.DEBE_ORIGEN);
			AddParameter(cmd, "HABER_ORIGEN",
				value.IsHABER_ORIGENNull ? DBNull.Value : (object)value.HABER_ORIGEN);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN",
				value.IsCOTIZACION_MONEDA_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "OBSERVACION_SISTEMA", value.OBSERVACION_SISTEMA);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_ASIENTOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_ASIENTOS_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_ASIENTOS_DETALLE SET " +
				"CTB_ASIENTO_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_ID") + ", " +
				"CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID") + ", " +
				"DEBE=" + _db.CreateSqlParameterName("DEBE") + ", " +
				"HABER=" + _db.CreateSqlParameterName("HABER") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"DEBE_ORIGEN=" + _db.CreateSqlParameterName("DEBE_ORIGEN") + ", " +
				"HABER_ORIGEN=" + _db.CreateSqlParameterName("HABER_ORIGEN") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"COTIZACION_MONEDA_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				"OBSERVACION_SISTEMA=" + _db.CreateSqlParameterName("OBSERVACION_SISTEMA") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_ASIENTO_ID", value.CTB_ASIENTO_ID);
			AddParameter(cmd, "CTB_CUENTA_ID", value.CTB_CUENTA_ID);
			AddParameter(cmd, "DEBE", value.DEBE);
			AddParameter(cmd, "HABER", value.HABER);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			AddParameter(cmd, "DEBE_ORIGEN",
				value.IsDEBE_ORIGENNull ? DBNull.Value : (object)value.DEBE_ORIGEN);
			AddParameter(cmd, "HABER_ORIGEN",
				value.IsHABER_ORIGENNull ? DBNull.Value : (object)value.HABER_ORIGEN);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN",
				value.IsCOTIZACION_MONEDA_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "OBSERVACION_SISTEMA", value.OBSERVACION_SISTEMA);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_ASIENTOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_ASIENTOS_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_ASIENTOS_DETALLE</c> table using
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
		/// Deletes records from the <c>CTB_ASIENTOS_DETALLE</c> table using the 
		/// <c>FK_CTB_ASIENTOS_DETALLE_ASIENT</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_id">The <c>CTB_ASIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_ASIENTO_ID(decimal ctb_asiento_id)
		{
			return CreateDeleteByCTB_ASIENTO_IDCommand(ctb_asiento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_DETALLE_ASIENT</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_id">The <c>CTB_ASIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_ASIENTO_IDCommand(decimal ctb_asiento_id)
		{
			string whereSql = "";
			whereSql += "CTB_ASIENTO_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_ASIENTO_ID", ctb_asiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_DETALLE</c> table using the 
		/// <c>FK_CTB_ASIENTOS_DETALLE_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA_ID(decimal ctb_cuenta_id)
		{
			return CreateDeleteByCTB_CUENTA_IDCommand(ctb_cuenta_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_DETALLE_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta_id">The <c>CTB_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_CUENTA_IDCommand(decimal ctb_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_CUENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_CUENTA_ID", ctb_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_DETALLE</c> table using the 
		/// <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return DeleteByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_DETALLE</c> table using the 
		/// <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_DETALLE_MON_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			string whereSql = "";
			if(moneda_origen_idNull)
				whereSql += "MONEDA_ORIGEN_ID IS NULL";
			else
				whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_origen_idNull)
				AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_DETALLE</c> table using the 
		/// <c>FK_CTB_ASIENTOS_DETALLE_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_DETALLE_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_DETALLE</c> table using the 
		/// <c>FK_CTB_ASIENTOS_DETALLE_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_DETALLE_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_ASIENTOS_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>CTB_ASIENTOS_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_ASIENTOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_ASIENTOS_DETALLE</c> table.
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		protected CTB_ASIENTOS_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		protected CTB_ASIENTOS_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DETALLERow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_asiento_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_ID");
			int ctb_cuenta_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_ID");
			int debeColumnIndex = reader.GetOrdinal("DEBE");
			int haberColumnIndex = reader.GetOrdinal("HABER");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int debe_origenColumnIndex = reader.GetOrdinal("DEBE_ORIGEN");
			int haber_origenColumnIndex = reader.GetOrdinal("HABER_ORIGEN");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int observacion_sistemaColumnIndex = reader.GetOrdinal("OBSERVACION_SISTEMA");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_DETALLERow record = new CTB_ASIENTOS_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_ASIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_idColumnIndex)), 9);
					record.CTB_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_idColumnIndex)), 9);
					record.DEBE = Math.Round(Convert.ToDecimal(reader.GetValue(debeColumnIndex)), 9);
					record.HABER = Math.Round(Convert.ToDecimal(reader.GetValue(haberColumnIndex)), 9);
					record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(ordenColumnIndex))
						record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(debe_origenColumnIndex))
						record.DEBE_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(debe_origenColumnIndex)), 9);
					if(!reader.IsDBNull(haber_origenColumnIndex))
						record.HABER_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(haber_origenColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_moneda_origenColumnIndex))
						record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_sistemaColumnIndex))
						record.OBSERVACION_SISTEMA = Convert.ToString(reader.GetValue(observacion_sistemaColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_DETALLERow[])(recordList.ToArray(typeof(CTB_ASIENTOS_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_DETALLERow"/> object.</returns>
		protected virtual CTB_ASIENTOS_DETALLERow MapRow(DataRow row)
		{
			CTB_ASIENTOS_DETALLERow mappedObject = new CTB_ASIENTOS_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_ASIENTO_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_ID = (decimal)row[dataColumn];
			// Column "DEBE"
			dataColumn = dataTable.Columns["DEBE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBE = (decimal)row[dataColumn];
			// Column "HABER"
			dataColumn = dataTable.Columns["HABER"];
			if(!row.IsNull(dataColumn))
				mappedObject.HABER = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "DEBE_ORIGEN"
			dataColumn = dataTable.Columns["DEBE_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBE_ORIGEN = (decimal)row[dataColumn];
			// Column "HABER_ORIGEN"
			dataColumn = dataTable.Columns["HABER_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.HABER_ORIGEN = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "OBSERVACION_SISTEMA"
			dataColumn = dataTable.Columns["OBSERVACION_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_SISTEMA = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEBE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HABER", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEBE_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("HABER_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION_SISTEMA", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "CTB_ASIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HABER":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBE_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HABER_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_DETALLECollection_Base class
}  // End of namespace
