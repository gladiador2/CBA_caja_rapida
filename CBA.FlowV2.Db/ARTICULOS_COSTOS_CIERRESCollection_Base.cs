// <fileinfo name="ARTICULOS_COSTOS_CIERRESCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COSTOS_CIERRESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_COSTOS_CIERRESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COSTOS_CIERRESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string FECHA_CIERREColumnName = "FECHA_CIERRE";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string ART_COSTO_CIERRE_ANTERIOR_IDColumnName = "ART_COSTO_CIERRE_ANTERIOR_ID";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COSTOS_CIERRESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_COSTOS_CIERRESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_COSTOS_CIERRES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_COSTOS_CIERRES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_COSTOS_CIERRES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_COSTOS_CIERRESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_COSTOS_CIERRESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public ARTICULOS_COSTOS_CIERRESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_COSTOS_CIERRES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_COSTOS_CIERRESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_COSTOS_CIERRESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_COSTOS_CIERRESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects 
		/// by the <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public ARTICULOS_COSTOS_CIERRESRow[] GetByART_COSTO_CIERRE_ANTERIOR_ID(decimal art_costo_cierre_anterior_id)
		{
			return GetByART_COSTO_CIERRE_ANTERIOR_ID(art_costo_cierre_anterior_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects 
		/// by the <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <param name="art_costo_cierre_anterior_idNull">true if the method ignores the art_costo_cierre_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRESRow[] GetByART_COSTO_CIERRE_ANTERIOR_ID(decimal art_costo_cierre_anterior_id, bool art_costo_cierre_anterior_idNull)
		{
			return MapRecords(CreateGetByART_COSTO_CIERRE_ANTERIOR_IDCommand(art_costo_cierre_anterior_id, art_costo_cierre_anterior_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByART_COSTO_CIERRE_ANTERIOR_IDAsDataTable(decimal art_costo_cierre_anterior_id)
		{
			return GetByART_COSTO_CIERRE_ANTERIOR_IDAsDataTable(art_costo_cierre_anterior_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <param name="art_costo_cierre_anterior_idNull">true if the method ignores the art_costo_cierre_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByART_COSTO_CIERRE_ANTERIOR_IDAsDataTable(decimal art_costo_cierre_anterior_id, bool art_costo_cierre_anterior_idNull)
		{
			return MapRecordsToDataTable(CreateGetByART_COSTO_CIERRE_ANTERIOR_IDCommand(art_costo_cierre_anterior_id, art_costo_cierre_anterior_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <param name="art_costo_cierre_anterior_idNull">true if the method ignores the art_costo_cierre_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByART_COSTO_CIERRE_ANTERIOR_IDCommand(decimal art_costo_cierre_anterior_id, bool art_costo_cierre_anterior_idNull)
		{
			string whereSql = "";
			if(art_costo_cierre_anterior_idNull)
				whereSql += "ART_COSTO_CIERRE_ANTERIOR_ID IS NULL";
			else
				whereSql += "ART_COSTO_CIERRE_ANTERIOR_ID=" + _db.CreateSqlParameterName("ART_COSTO_CIERRE_ANTERIOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!art_costo_cierre_anterior_idNull)
				AddParameter(cmd, "ART_COSTO_CIERRE_ANTERIOR_ID", art_costo_cierre_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects 
		/// by the <c>FK_ART_COST_CIER_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIER_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_COST_CIER_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects 
		/// by the <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public ARTICULOS_COSTOS_CIERRESRow[] GetByREGION_ID(decimal region_id)
		{
			return GetByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects 
		/// by the <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRESRow[] GetByREGION_ID(decimal region_id, bool region_idNull)
		{
			return MapRecords(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREGION_IDAsDataTable(decimal region_id)
		{
			return GetByREGION_IDAsDataTable(region_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREGION_IDAsDataTable(decimal region_id, bool region_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects 
		/// by the <c>FK_ART_COST_CIER_USUARIO_CREAC</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRESRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIER_USUARIO_CREAC</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_COST_CIER_USUARIO_CREAC</c> foreign key.
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
		/// Adds a new record into the <c>ARTICULOS_COSTOS_CIERRES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COSTOS_CIERRESRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_COSTOS_CIERRESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_COSTOS_CIERRES (" +
				"ID, " +
				"REGION_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"FECHA_CIERRE, " +
				"FECHA_CREACION, " +
				"USUARIO_CREACION_ID, " +
				"ART_COSTO_CIERRE_ANTERIOR_ID, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("REGION_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("FECHA_CIERRE") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("ART_COSTO_CIERRE_ANTERIOR_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "FECHA_CIERRE", value.FECHA_CIERRE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "ART_COSTO_CIERRE_ANTERIOR_ID",
				value.IsART_COSTO_CIERRE_ANTERIOR_IDNull ? DBNull.Value : (object)value.ART_COSTO_CIERRE_ANTERIOR_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_COSTOS_CIERRES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COSTOS_CIERRESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_COSTOS_CIERRESRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_COSTOS_CIERRES SET " +
				"REGION_ID=" + _db.CreateSqlParameterName("REGION_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"FECHA_CIERRE=" + _db.CreateSqlParameterName("FECHA_CIERRE") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"ART_COSTO_CIERRE_ANTERIOR_ID=" + _db.CreateSqlParameterName("ART_COSTO_CIERRE_ANTERIOR_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "FECHA_CIERRE", value.FECHA_CIERRE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "ART_COSTO_CIERRE_ANTERIOR_ID",
				value.IsART_COSTO_CIERRE_ANTERIOR_IDNull ? DBNull.Value : (object)value.ART_COSTO_CIERRE_ANTERIOR_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_COSTOS_CIERRES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_COSTOS_CIERRES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_COSTOS_CIERRES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COSTOS_CIERRESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_COSTOS_CIERRESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_COSTOS_CIERRES</c> table using
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
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES</c> table using the 
		/// <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByART_COSTO_CIERRE_ANTERIOR_ID(decimal art_costo_cierre_anterior_id)
		{
			return DeleteByART_COSTO_CIERRE_ANTERIOR_ID(art_costo_cierre_anterior_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES</c> table using the 
		/// <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <param name="art_costo_cierre_anterior_idNull">true if the method ignores the art_costo_cierre_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByART_COSTO_CIERRE_ANTERIOR_ID(decimal art_costo_cierre_anterior_id, bool art_costo_cierre_anterior_idNull)
		{
			return CreateDeleteByART_COSTO_CIERRE_ANTERIOR_IDCommand(art_costo_cierre_anterior_id, art_costo_cierre_anterior_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_COST_CIER_CIERRE_ANT</c> foreign key.
		/// </summary>
		/// <param name="art_costo_cierre_anterior_id">The <c>ART_COSTO_CIERRE_ANTERIOR_ID</c> column value.</param>
		/// <param name="art_costo_cierre_anterior_idNull">true if the method ignores the art_costo_cierre_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByART_COSTO_CIERRE_ANTERIOR_IDCommand(decimal art_costo_cierre_anterior_id, bool art_costo_cierre_anterior_idNull)
		{
			string whereSql = "";
			if(art_costo_cierre_anterior_idNull)
				whereSql += "ART_COSTO_CIERRE_ANTERIOR_ID IS NULL";
			else
				whereSql += "ART_COSTO_CIERRE_ANTERIOR_ID=" + _db.CreateSqlParameterName("ART_COSTO_CIERRE_ANTERIOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!art_costo_cierre_anterior_idNull)
				AddParameter(cmd, "ART_COSTO_CIERRE_ANTERIOR_ID", art_costo_cierre_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES</c> table using the 
		/// <c>FK_ART_COST_CIER_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_COST_CIER_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES</c> table using the 
		/// <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id)
		{
			return DeleteByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES</c> table using the 
		/// <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id, bool region_idNull)
		{
			return CreateDeleteByREGION_IDCommand(region_id, region_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_COST_CIER_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES</c> table using the 
		/// <c>FK_ART_COST_CIER_USUARIO_CREAC</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_COST_CIER_USUARIO_CREAC</c> foreign key.
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
		/// Deletes <c>ARTICULOS_COSTOS_CIERRES</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_COSTOS_CIERRES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_COSTOS_CIERRES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_COSTOS_CIERRES</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		protected ARTICULOS_COSTOS_CIERRESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		protected ARTICULOS_COSTOS_CIERRESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRESRow"/> objects.</returns>
		protected virtual ARTICULOS_COSTOS_CIERRESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int fecha_cierreColumnIndex = reader.GetOrdinal("FECHA_CIERRE");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int art_costo_cierre_anterior_idColumnIndex = reader.GetOrdinal("ART_COSTO_CIERRE_ANTERIOR_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_COSTOS_CIERRESRow record = new ARTICULOS_COSTOS_CIERRESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.FECHA_CIERRE = Convert.ToDateTime(reader.GetValue(fecha_cierreColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(art_costo_cierre_anterior_idColumnIndex))
						record.ART_COSTO_CIERRE_ANTERIOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(art_costo_cierre_anterior_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_COSTOS_CIERRESRow[])(recordList.ToArray(typeof(ARTICULOS_COSTOS_CIERRESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_COSTOS_CIERRESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_COSTOS_CIERRESRow"/> object.</returns>
		protected virtual ARTICULOS_COSTOS_CIERRESRow MapRow(DataRow row)
		{
			ARTICULOS_COSTOS_CIERRESRow mappedObject = new ARTICULOS_COSTOS_CIERRESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "FECHA_CIERRE"
			dataColumn = dataTable.Columns["FECHA_CIERRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CIERRE = (System.DateTime)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "ART_COSTO_CIERRE_ANTERIOR_ID"
			dataColumn = dataTable.Columns["ART_COSTO_CIERRE_ANTERIOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ART_COSTO_CIERRE_ANTERIOR_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_COSTOS_CIERRES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_COSTOS_CIERRES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CIERRE", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ART_COSTO_CIERRE_ANTERIOR_ID", typeof(decimal));
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

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CIERRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ART_COSTO_CIERRE_ANTERIOR_ID":
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
	} // End of ARTICULOS_COSTOS_CIERRESCollection_Base class
}  // End of namespace
