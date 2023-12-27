// <fileinfo name="ADENDASCollection_Base.cs">
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
	/// The base class for <see cref="ADENDASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ADENDASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ADENDASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CONTRATO_IDColumnName = "CONTRATO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string TEXTOColumnName = "TEXTO";
		public const string APROBADOColumnName = "APROBADO";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string USUARIO_ANULACION_IDColumnName = "USUARIO_ANULACION_ID";
		public const string FECHA_ANULACIONColumnName = "FECHA_ANULACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ADENDASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ADENDASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ADENDAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public virtual ADENDASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ADENDAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ADENDAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ADENDASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ADENDASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ADENDASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ADENDASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public ADENDASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects that 
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
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public virtual ADENDASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ADENDAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ADENDASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ADENDASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ADENDASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ADENDASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects 
		/// by the <c>FK_ADENDAS_CONTRA_ID</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public virtual ADENDASRow[] GetByCONTRATO_ID(decimal contrato_id)
		{
			return MapRecords(CreateGetByCONTRATO_IDCommand(contrato_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADENDAS_CONTRA_ID</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTRATO_IDAsDataTable(decimal contrato_id)
		{
			return MapRecordsToDataTable(CreateGetByCONTRATO_IDCommand(contrato_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADENDAS_CONTRA_ID</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTRATO_IDCommand(decimal contrato_id)
		{
			string whereSql = "";
			whereSql += "CONTRATO_ID=" + _db.CreateSqlParameterName("CONTRATO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONTRATO_ID", contrato_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects 
		/// by the <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public ADENDASRow[] GetByUSUARIO_ANULACION_ID(decimal usuario_anulacion_id)
		{
			return GetByUSUARIO_ANULACION_ID(usuario_anulacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects 
		/// by the <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <param name="usuario_anulacion_idNull">true if the method ignores the usuario_anulacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public virtual ADENDASRow[] GetByUSUARIO_ANULACION_ID(decimal usuario_anulacion_id, bool usuario_anulacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_ANULACION_IDCommand(usuario_anulacion_id, usuario_anulacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_ANULACION_IDAsDataTable(decimal usuario_anulacion_id)
		{
			return GetByUSUARIO_ANULACION_IDAsDataTable(usuario_anulacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <param name="usuario_anulacion_idNull">true if the method ignores the usuario_anulacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ANULACION_IDAsDataTable(decimal usuario_anulacion_id, bool usuario_anulacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ANULACION_IDCommand(usuario_anulacion_id, usuario_anulacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <param name="usuario_anulacion_idNull">true if the method ignores the usuario_anulacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ANULACION_IDCommand(decimal usuario_anulacion_id, bool usuario_anulacion_idNull)
		{
			string whereSql = "";
			if(usuario_anulacion_idNull)
				whereSql += "USUARIO_ANULACION_ID IS NULL";
			else
				whereSql += "USUARIO_ANULACION_ID=" + _db.CreateSqlParameterName("USUARIO_ANULACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_anulacion_idNull)
				AddParameter(cmd, "USUARIO_ANULACION_ID", usuario_anulacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects 
		/// by the <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public ADENDASRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects 
		/// by the <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public virtual ADENDASRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_IDAsDataTable(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ADENDASRow"/> objects 
		/// by the <c>FK_ADENDAS_USR_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		public virtual ADENDASRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ADENDAS_USR_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ADENDAS_USR_CREADOR_ID</c> foreign key.
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
		/// Adds a new record into the <c>ADENDAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ADENDASRow"/> object to be inserted.</param>
		public virtual void Insert(ADENDASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ADENDAS (" +
				"ID, " +
				"CONTRATO_ID, " +
				"FECHA, " +
				"TEXTO, " +
				"APROBADO, " +
				"USUARIO_CREACION_ID, " +
				"USUARIO_APROBACION_ID, " +
				"FECHA_APROBACION, " +
				"ESTADO, " +
				"USUARIO_ANULACION_ID, " +
				"FECHA_ANULACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CONTRATO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("TEXTO") + ", " +
				_db.CreateSqlParameterName("APROBADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_ANULACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ANULACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CONTRATO_ID", value.CONTRATO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "TEXTO", value.TEXTO);
			AddParameter(cmd, "APROBADO", value.APROBADO);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_ANULACION_ID",
				value.IsUSUARIO_ANULACION_IDNull ? DBNull.Value : (object)value.USUARIO_ANULACION_ID);
			AddParameter(cmd, "FECHA_ANULACION",
				value.IsFECHA_ANULACIONNull ? DBNull.Value : (object)value.FECHA_ANULACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ADENDAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ADENDASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ADENDASRow value)
		{
			
			string sqlStr = "UPDATE TRC.ADENDAS SET " +
				"CONTRATO_ID=" + _db.CreateSqlParameterName("CONTRATO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"TEXTO=" + _db.CreateSqlParameterName("TEXTO") + ", " +
				"APROBADO=" + _db.CreateSqlParameterName("APROBADO") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"USUARIO_ANULACION_ID=" + _db.CreateSqlParameterName("USUARIO_ANULACION_ID") + ", " +
				"FECHA_ANULACION=" + _db.CreateSqlParameterName("FECHA_ANULACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CONTRATO_ID", value.CONTRATO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "TEXTO", value.TEXTO);
			AddParameter(cmd, "APROBADO", value.APROBADO);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_ANULACION_ID",
				value.IsUSUARIO_ANULACION_IDNull ? DBNull.Value : (object)value.USUARIO_ANULACION_ID);
			AddParameter(cmd, "FECHA_ANULACION",
				value.IsFECHA_ANULACIONNull ? DBNull.Value : (object)value.FECHA_ANULACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ADENDAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ADENDAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ADENDAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ADENDASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ADENDASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ADENDAS</c> table using
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
		/// Deletes records from the <c>ADENDAS</c> table using the 
		/// <c>FK_ADENDAS_CONTRA_ID</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTRATO_ID(decimal contrato_id)
		{
			return CreateDeleteByCONTRATO_IDCommand(contrato_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADENDAS_CONTRA_ID</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTRATO_IDCommand(decimal contrato_id)
		{
			string whereSql = "";
			whereSql += "CONTRATO_ID=" + _db.CreateSqlParameterName("CONTRATO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONTRATO_ID", contrato_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADENDAS</c> table using the 
		/// <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ANULACION_ID(decimal usuario_anulacion_id)
		{
			return DeleteByUSUARIO_ANULACION_ID(usuario_anulacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ADENDAS</c> table using the 
		/// <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <param name="usuario_anulacion_idNull">true if the method ignores the usuario_anulacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ANULACION_ID(decimal usuario_anulacion_id, bool usuario_anulacion_idNull)
		{
			return CreateDeleteByUSUARIO_ANULACION_IDCommand(usuario_anulacion_id, usuario_anulacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADENDAS_USR_ANULADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_anulacion_id">The <c>USUARIO_ANULACION_ID</c> column value.</param>
		/// <param name="usuario_anulacion_idNull">true if the method ignores the usuario_anulacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ANULACION_IDCommand(decimal usuario_anulacion_id, bool usuario_anulacion_idNull)
		{
			string whereSql = "";
			if(usuario_anulacion_idNull)
				whereSql += "USUARIO_ANULACION_ID IS NULL";
			else
				whereSql += "USUARIO_ANULACION_ID=" + _db.CreateSqlParameterName("USUARIO_ANULACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_anulacion_idNull)
				AddParameter(cmd, "USUARIO_ANULACION_ID", usuario_anulacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADENDAS</c> table using the 
		/// <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return DeleteByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ADENDAS</c> table using the 
		/// <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return CreateDeleteByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADENDAS_USR_APROBADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ADENDAS</c> table using the 
		/// <c>FK_ADENDAS_USR_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ADENDAS_USR_CREADOR_ID</c> foreign key.
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
		/// Deletes <c>ADENDAS</c> records that match the specified criteria.
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
		/// to delete <c>ADENDAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ADENDAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ADENDAS</c> table.
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
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		protected ADENDASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		protected ADENDASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ADENDASRow"/> objects.</returns>
		protected virtual ADENDASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int contrato_idColumnIndex = reader.GetOrdinal("CONTRATO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int textoColumnIndex = reader.GetOrdinal("TEXTO");
			int aprobadoColumnIndex = reader.GetOrdinal("APROBADO");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int usuario_anulacion_idColumnIndex = reader.GetOrdinal("USUARIO_ANULACION_ID");
			int fecha_anulacionColumnIndex = reader.GetOrdinal("FECHA_ANULACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ADENDASRow record = new ADENDASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CONTRATO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contrato_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.TEXTO = Convert.ToString(reader.GetValue(textoColumnIndex));
					record.APROBADO = Convert.ToString(reader.GetValue(aprobadoColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(usuario_anulacion_idColumnIndex))
						record.USUARIO_ANULACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_anulacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_anulacionColumnIndex))
						record.FECHA_ANULACION = Convert.ToDateTime(reader.GetValue(fecha_anulacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ADENDASRow[])(recordList.ToArray(typeof(ADENDASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ADENDASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ADENDASRow"/> object.</returns>
		protected virtual ADENDASRow MapRow(DataRow row)
		{
			ADENDASRow mappedObject = new ADENDASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CONTRATO_ID"
			dataColumn = dataTable.Columns["CONTRATO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTRATO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "TEXTO"
			dataColumn = dataTable.Columns["TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO = (string)row[dataColumn];
			// Column "APROBADO"
			dataColumn = dataTable.Columns["APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBADO = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_APROBACION_ID"
			dataColumn = dataTable.Columns["USUARIO_APROBACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "USUARIO_ANULACION_ID"
			dataColumn = dataTable.Columns["USUARIO_ANULACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ANULACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_ANULACION"
			dataColumn = dataTable.Columns["FECHA_ANULACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ANULACION = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ADENDAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ADENDAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTRATO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ANULACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ANULACION", typeof(System.DateTime));
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

				case "CONTRATO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_APROBACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_ANULACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ANULACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ADENDASCollection_Base class
}  // End of namespace
