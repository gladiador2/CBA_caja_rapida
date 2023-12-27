// <fileinfo name="PRE_EMBARQUECollection_Base.cs">
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
	/// The base class for <see cref="PRE_EMBARQUECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRE_EMBARQUECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRE_EMBARQUECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NRO_REGISTRO_SALIDAColumnName = "NRO_REGISTRO_SALIDA";
		public const string BUQUE_IDColumnName = "BUQUE_ID";
		public const string NRO_VIAJEColumnName = "NRO_VIAJE";
		public const string FECHAColumnName = "FECHA";
		public const string NRO_VIAJE_CMAColumnName = "NRO_VIAJE_CMA";
		public const string NRO_CARPETAColumnName = "NRO_CARPETA";
		public const string FECHA_POSIBLE_CARGAColumnName = "FECHA_POSIBLE_CARGA";
		public const string ESTADOColumnName = "ESTADO";
		public const string PUERTO_IDColumnName = "PUERTO_ID";
		public const string ARMADOR_IDColumnName = "ARMADOR_ID";
		public const string NRO_VIAJE_MAERSKColumnName = "NRO_VIAJE_MAERSK";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRE_EMBARQUECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRE_EMBARQUECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRE_EMBARQUE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public virtual PRE_EMBARQUERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRE_EMBARQUE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRE_EMBARQUE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRE_EMBARQUERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRE_EMBARQUERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRE_EMBARQUERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRE_EMBARQUERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public PRE_EMBARQUERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects that 
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
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public virtual PRE_EMBARQUERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRE_EMBARQUE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PRE_EMBARQUERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PRE_EMBARQUERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PRE_EMBARQUERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PRE_EMBARQUERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public PRE_EMBARQUERow[] GetByARMADOR_ID(decimal armador_id)
		{
			return GetByARMADOR_ID(armador_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <param name="armador_idNull">true if the method ignores the armador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public virtual PRE_EMBARQUERow[] GetByARMADOR_ID(decimal armador_id, bool armador_idNull)
		{
			return MapRecords(CreateGetByARMADOR_IDCommand(armador_id, armador_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARMADOR_IDAsDataTable(decimal armador_id)
		{
			return GetByARMADOR_IDAsDataTable(armador_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <param name="armador_idNull">true if the method ignores the armador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARMADOR_IDAsDataTable(decimal armador_id, bool armador_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARMADOR_IDCommand(armador_id, armador_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <param name="armador_idNull">true if the method ignores the armador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARMADOR_IDCommand(decimal armador_id, bool armador_idNull)
		{
			string whereSql = "";
			if(armador_idNull)
				whereSql += "ARMADOR_ID IS NULL";
			else
				whereSql += "ARMADOR_ID=" + _db.CreateSqlParameterName("ARMADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!armador_idNull)
				AddParameter(cmd, "ARMADOR_ID", armador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public PRE_EMBARQUERow[] GetByBUQUE_ID(decimal buque_id)
		{
			return GetByBUQUE_ID(buque_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <param name="buque_idNull">true if the method ignores the buque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public virtual PRE_EMBARQUERow[] GetByBUQUE_ID(decimal buque_id, bool buque_idNull)
		{
			return MapRecords(CreateGetByBUQUE_IDCommand(buque_id, buque_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBUQUE_IDAsDataTable(decimal buque_id)
		{
			return GetByBUQUE_IDAsDataTable(buque_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
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
		/// return records by the <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public PRE_EMBARQUERow[] GetByPUERTO_ID(decimal puerto_id)
		{
			return GetByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUERow"/> objects 
		/// by the <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		public virtual PRE_EMBARQUERow[] GetByPUERTO_ID(decimal puerto_id, bool puerto_idNull)
		{
			return MapRecords(CreateGetByPUERTO_IDCommand(puerto_id, puerto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_IDAsDataTable(decimal puerto_id)
		{
			return GetByPUERTO_IDAsDataTable(puerto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPUERTO_IDAsDataTable(decimal puerto_id, bool puerto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPUERTO_IDCommand(puerto_id, puerto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPUERTO_IDCommand(decimal puerto_id, bool puerto_idNull)
		{
			string whereSql = "";
			if(puerto_idNull)
				whereSql += "PUERTO_ID IS NULL";
			else
				whereSql += "PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!puerto_idNull)
				AddParameter(cmd, "PUERTO_ID", puerto_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PRE_EMBARQUE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRE_EMBARQUERow"/> object to be inserted.</param>
		public virtual void Insert(PRE_EMBARQUERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PRE_EMBARQUE (" +
				"ID, " +
				"NRO_REGISTRO_SALIDA, " +
				"BUQUE_ID, " +
				"NRO_VIAJE, " +
				"FECHA, " +
				"NRO_VIAJE_CMA, " +
				"NRO_CARPETA, " +
				"FECHA_POSIBLE_CARGA, " +
				"ESTADO, " +
				"PUERTO_ID, " +
				"ARMADOR_ID, " +
				"NRO_VIAJE_MAERSK" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NRO_REGISTRO_SALIDA") + ", " +
				_db.CreateSqlParameterName("BUQUE_ID") + ", " +
				_db.CreateSqlParameterName("NRO_VIAJE") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("NRO_VIAJE_CMA") + ", " +
				_db.CreateSqlParameterName("NRO_CARPETA") + ", " +
				_db.CreateSqlParameterName("FECHA_POSIBLE_CARGA") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("PUERTO_ID") + ", " +
				_db.CreateSqlParameterName("ARMADOR_ID") + ", " +
				_db.CreateSqlParameterName("NRO_VIAJE_MAERSK") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NRO_REGISTRO_SALIDA", value.NRO_REGISTRO_SALIDA);
			AddParameter(cmd, "BUQUE_ID",
				value.IsBUQUE_IDNull ? DBNull.Value : (object)value.BUQUE_ID);
			AddParameter(cmd, "NRO_VIAJE", value.NRO_VIAJE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "NRO_VIAJE_CMA", value.NRO_VIAJE_CMA);
			AddParameter(cmd, "NRO_CARPETA", value.NRO_CARPETA);
			AddParameter(cmd, "FECHA_POSIBLE_CARGA",
				value.IsFECHA_POSIBLE_CARGANull ? DBNull.Value : (object)value.FECHA_POSIBLE_CARGA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "ARMADOR_ID",
				value.IsARMADOR_IDNull ? DBNull.Value : (object)value.ARMADOR_ID);
			AddParameter(cmd, "NRO_VIAJE_MAERSK", value.NRO_VIAJE_MAERSK);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PRE_EMBARQUE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRE_EMBARQUERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PRE_EMBARQUERow value)
		{
			
			string sqlStr = "UPDATE TRC.PRE_EMBARQUE SET " +
				"NRO_REGISTRO_SALIDA=" + _db.CreateSqlParameterName("NRO_REGISTRO_SALIDA") + ", " +
				"BUQUE_ID=" + _db.CreateSqlParameterName("BUQUE_ID") + ", " +
				"NRO_VIAJE=" + _db.CreateSqlParameterName("NRO_VIAJE") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"NRO_VIAJE_CMA=" + _db.CreateSqlParameterName("NRO_VIAJE_CMA") + ", " +
				"NRO_CARPETA=" + _db.CreateSqlParameterName("NRO_CARPETA") + ", " +
				"FECHA_POSIBLE_CARGA=" + _db.CreateSqlParameterName("FECHA_POSIBLE_CARGA") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID") + ", " +
				"ARMADOR_ID=" + _db.CreateSqlParameterName("ARMADOR_ID") + ", " +
				"NRO_VIAJE_MAERSK=" + _db.CreateSqlParameterName("NRO_VIAJE_MAERSK") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NRO_REGISTRO_SALIDA", value.NRO_REGISTRO_SALIDA);
			AddParameter(cmd, "BUQUE_ID",
				value.IsBUQUE_IDNull ? DBNull.Value : (object)value.BUQUE_ID);
			AddParameter(cmd, "NRO_VIAJE", value.NRO_VIAJE);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "NRO_VIAJE_CMA", value.NRO_VIAJE_CMA);
			AddParameter(cmd, "NRO_CARPETA", value.NRO_CARPETA);
			AddParameter(cmd, "FECHA_POSIBLE_CARGA",
				value.IsFECHA_POSIBLE_CARGANull ? DBNull.Value : (object)value.FECHA_POSIBLE_CARGA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PUERTO_ID",
				value.IsPUERTO_IDNull ? DBNull.Value : (object)value.PUERTO_ID);
			AddParameter(cmd, "ARMADOR_ID",
				value.IsARMADOR_IDNull ? DBNull.Value : (object)value.ARMADOR_ID);
			AddParameter(cmd, "NRO_VIAJE_MAERSK", value.NRO_VIAJE_MAERSK);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PRE_EMBARQUE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PRE_EMBARQUE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PRE_EMBARQUE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRE_EMBARQUERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PRE_EMBARQUERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PRE_EMBARQUE</c> table using
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
		/// Deletes records from the <c>PRE_EMBARQUE</c> table using the 
		/// <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARMADOR_ID(decimal armador_id)
		{
			return DeleteByARMADOR_ID(armador_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE</c> table using the 
		/// <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <param name="armador_idNull">true if the method ignores the armador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARMADOR_ID(decimal armador_id, bool armador_idNull)
		{
			return CreateDeleteByARMADOR_IDCommand(armador_id, armador_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRE_EMBARQUE_ARMADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="armador_id">The <c>ARMADOR_ID</c> column value.</param>
		/// <param name="armador_idNull">true if the method ignores the armador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARMADOR_IDCommand(decimal armador_id, bool armador_idNull)
		{
			string whereSql = "";
			if(armador_idNull)
				whereSql += "ARMADOR_ID IS NULL";
			else
				whereSql += "ARMADOR_ID=" + _db.CreateSqlParameterName("ARMADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!armador_idNull)
				AddParameter(cmd, "ARMADOR_ID", armador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE</c> table using the 
		/// <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
		/// </summary>
		/// <param name="buque_id">The <c>BUQUE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBUQUE_ID(decimal buque_id)
		{
			return DeleteByBUQUE_ID(buque_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE</c> table using the 
		/// <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
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
		/// delete records using the <c>FK_PRE_EMBARQUE_BUQUE_ID</c> foreign key.
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
		/// Deletes records from the <c>PRE_EMBARQUE</c> table using the 
		/// <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_ID(decimal puerto_id)
		{
			return DeleteByPUERTO_ID(puerto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRE_EMBARQUE</c> table using the 
		/// <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_ID(decimal puerto_id, bool puerto_idNull)
		{
			return CreateDeleteByPUERTO_IDCommand(puerto_id, puerto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRE_EMBARQUE_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_id">The <c>PUERTO_ID</c> column value.</param>
		/// <param name="puerto_idNull">true if the method ignores the puerto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPUERTO_IDCommand(decimal puerto_id, bool puerto_idNull)
		{
			string whereSql = "";
			if(puerto_idNull)
				whereSql += "PUERTO_ID IS NULL";
			else
				whereSql += "PUERTO_ID=" + _db.CreateSqlParameterName("PUERTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!puerto_idNull)
				AddParameter(cmd, "PUERTO_ID", puerto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PRE_EMBARQUE</c> records that match the specified criteria.
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
		/// to delete <c>PRE_EMBARQUE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PRE_EMBARQUE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PRE_EMBARQUE</c> table.
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
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		protected PRE_EMBARQUERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		protected PRE_EMBARQUERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRE_EMBARQUERow"/> objects.</returns>
		protected virtual PRE_EMBARQUERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nro_registro_salidaColumnIndex = reader.GetOrdinal("NRO_REGISTRO_SALIDA");
			int buque_idColumnIndex = reader.GetOrdinal("BUQUE_ID");
			int nro_viajeColumnIndex = reader.GetOrdinal("NRO_VIAJE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int nro_viaje_cmaColumnIndex = reader.GetOrdinal("NRO_VIAJE_CMA");
			int nro_carpetaColumnIndex = reader.GetOrdinal("NRO_CARPETA");
			int fecha_posible_cargaColumnIndex = reader.GetOrdinal("FECHA_POSIBLE_CARGA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int puerto_idColumnIndex = reader.GetOrdinal("PUERTO_ID");
			int armador_idColumnIndex = reader.GetOrdinal("ARMADOR_ID");
			int nro_viaje_maerskColumnIndex = reader.GetOrdinal("NRO_VIAJE_MAERSK");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRE_EMBARQUERow record = new PRE_EMBARQUERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_registro_salidaColumnIndex))
						record.NRO_REGISTRO_SALIDA = Convert.ToString(reader.GetValue(nro_registro_salidaColumnIndex));
					if(!reader.IsDBNull(buque_idColumnIndex))
						record.BUQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(buque_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_viajeColumnIndex))
						record.NRO_VIAJE = Convert.ToString(reader.GetValue(nro_viajeColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(nro_viaje_cmaColumnIndex))
						record.NRO_VIAJE_CMA = Convert.ToString(reader.GetValue(nro_viaje_cmaColumnIndex));
					if(!reader.IsDBNull(nro_carpetaColumnIndex))
						record.NRO_CARPETA = Convert.ToString(reader.GetValue(nro_carpetaColumnIndex));
					if(!reader.IsDBNull(fecha_posible_cargaColumnIndex))
						record.FECHA_POSIBLE_CARGA = Convert.ToDateTime(reader.GetValue(fecha_posible_cargaColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(puerto_idColumnIndex))
						record.PUERTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_idColumnIndex)), 9);
					if(!reader.IsDBNull(armador_idColumnIndex))
						record.ARMADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(armador_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_viaje_maerskColumnIndex))
						record.NRO_VIAJE_MAERSK = Convert.ToString(reader.GetValue(nro_viaje_maerskColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRE_EMBARQUERow[])(recordList.ToArray(typeof(PRE_EMBARQUERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRE_EMBARQUERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRE_EMBARQUERow"/> object.</returns>
		protected virtual PRE_EMBARQUERow MapRow(DataRow row)
		{
			PRE_EMBARQUERow mappedObject = new PRE_EMBARQUERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NRO_REGISTRO_SALIDA"
			dataColumn = dataTable.Columns["NRO_REGISTRO_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_REGISTRO_SALIDA = (string)row[dataColumn];
			// Column "BUQUE_ID"
			dataColumn = dataTable.Columns["BUQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE_ID = (decimal)row[dataColumn];
			// Column "NRO_VIAJE"
			dataColumn = dataTable.Columns["NRO_VIAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_VIAJE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "NRO_VIAJE_CMA"
			dataColumn = dataTable.Columns["NRO_VIAJE_CMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_VIAJE_CMA = (string)row[dataColumn];
			// Column "NRO_CARPETA"
			dataColumn = dataTable.Columns["NRO_CARPETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CARPETA = (string)row[dataColumn];
			// Column "FECHA_POSIBLE_CARGA"
			dataColumn = dataTable.Columns["FECHA_POSIBLE_CARGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSIBLE_CARGA = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PUERTO_ID"
			dataColumn = dataTable.Columns["PUERTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ID = (decimal)row[dataColumn];
			// Column "ARMADOR_ID"
			dataColumn = dataTable.Columns["ARMADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARMADOR_ID = (decimal)row[dataColumn];
			// Column "NRO_VIAJE_MAERSK"
			dataColumn = dataTable.Columns["NRO_VIAJE_MAERSK"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_VIAJE_MAERSK = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRE_EMBARQUE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRE_EMBARQUE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_REGISTRO_SALIDA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("BUQUE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_VIAJE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_VIAJE_CMA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("NRO_CARPETA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("FECHA_POSIBLE_CARGA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PUERTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARMADOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_VIAJE_MAERSK", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "NRO_REGISTRO_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BUQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_VIAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_VIAJE_CMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_CARPETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_POSIBLE_CARGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PUERTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARMADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_VIAJE_MAERSK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRE_EMBARQUECollection_Base class
}  // End of namespace
