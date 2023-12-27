// <fileinfo name="CTACTE_CHEQUES_REC_ABOGADOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_REC_ABOGADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CHEQUES_REC_ABOGADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_REC_ABOGADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string ABOGADO_IDColumnName = "ABOGADO_ID";
		public const string FECHA_ASIGNACIONColumnName = "FECHA_ASIGNACION";
		public const string FECHA_DESASIGNACIONColumnName = "FECHA_DESASIGNACION";
		public const string OBSERVACION_ASIGNACIONColumnName = "OBSERVACION_ASIGNACION";
		public const string USUARIO_ASIGNACION_IDColumnName = "USUARIO_ASIGNACION_ID";
		public const string USUARIO_ASIGNACION_FECHAColumnName = "USUARIO_ASIGNACION_FECHA";
		public const string USUARIO_DESASIGNACION_IDColumnName = "USUARIO_DESASIGNACION_ID";
		public const string USUARIO_DESASIGNACION_FECHAColumnName = "USUARIO_DESASIGNACION_FECHA";
		public const string OBSERVACION_DESASIGNACIONColumnName = "OBSERVACION_DESASIGNACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_REC_ABOGADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CHEQUES_REC_ABOGADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOGADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CHEQUES_REC_ABOGADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CHEQUES_REC_ABOGADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_REC_ABOGADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOGADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CHEQUES_REC_ABOGADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOGADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CHEQUES_REC_ABOGADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_ABO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOGADOSRow[] GetByABOGADO_ID(decimal abogado_id)
		{
			return MapRecords(CreateGetByABOGADO_IDCommand(abogado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_ABO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByABOGADO_IDAsDataTable(decimal abogado_id)
		{
			return MapRecordsToDataTable(CreateGetByABOGADO_IDCommand(abogado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_REC_ABOG_ABO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByABOGADO_IDCommand(decimal abogado_id)
		{
			string whereSql = "";
			whereSql += "ABOGADO_ID=" + _db.CreateSqlParameterName("ABOGADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ABOGADO_ID", abogado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_CHQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOGADOSRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_CHQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_REC_ABOG_CHQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion_id">The <c>USUARIO_ASIGNACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOGADOSRow[] GetByUSUARIO_ASIGNACION_ID(decimal usuario_asignacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_ASIGNACION_IDCommand(usuario_asignacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion_id">The <c>USUARIO_ASIGNACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ASIGNACION_IDAsDataTable(decimal usuario_asignacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ASIGNACION_IDCommand(usuario_asignacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion_id">The <c>USUARIO_ASIGNACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ASIGNACION_IDCommand(decimal usuario_asignacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ASIGNACION_ID=" + _db.CreateSqlParameterName("USUARIO_ASIGNACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ASIGNACION_ID", usuario_asignacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_REC_ABOGADOSRow[] GetByUSUARIO_DESASIGNACION_ID(decimal usuario_desasignacion_id)
		{
			return GetByUSUARIO_DESASIGNACION_ID(usuario_desasignacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <param name="usuario_desasignacion_idNull">true if the method ignores the usuario_desasignacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOGADOSRow[] GetByUSUARIO_DESASIGNACION_ID(decimal usuario_desasignacion_id, bool usuario_desasignacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_DESASIGNACION_IDCommand(usuario_desasignacion_id, usuario_desasignacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_DESASIGNACION_IDAsDataTable(decimal usuario_desasignacion_id)
		{
			return GetByUSUARIO_DESASIGNACION_IDAsDataTable(usuario_desasignacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <param name="usuario_desasignacion_idNull">true if the method ignores the usuario_desasignacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_DESASIGNACION_IDAsDataTable(decimal usuario_desasignacion_id, bool usuario_desasignacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_DESASIGNACION_IDCommand(usuario_desasignacion_id, usuario_desasignacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <param name="usuario_desasignacion_idNull">true if the method ignores the usuario_desasignacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_DESASIGNACION_IDCommand(decimal usuario_desasignacion_id, bool usuario_desasignacion_idNull)
		{
			string whereSql = "";
			if(usuario_desasignacion_idNull)
				whereSql += "USUARIO_DESASIGNACION_ID IS NULL";
			else
				whereSql += "USUARIO_DESASIGNACION_ID=" + _db.CreateSqlParameterName("USUARIO_DESASIGNACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_desasignacion_idNull)
				AddParameter(cmd, "USUARIO_DESASIGNACION_ID", usuario_desasignacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CHEQUES_REC_ABOGADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CHEQUES_REC_ABOGADOS (" +
				"ID, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"ABOGADO_ID, " +
				"FECHA_ASIGNACION, " +
				"FECHA_DESASIGNACION, " +
				"OBSERVACION_ASIGNACION, " +
				"USUARIO_ASIGNACION_ID, " +
				"USUARIO_ASIGNACION_FECHA, " +
				"USUARIO_DESASIGNACION_ID, " +
				"USUARIO_DESASIGNACION_FECHA, " +
				"OBSERVACION_DESASIGNACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("ABOGADO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ASIGNACION") + ", " +
				_db.CreateSqlParameterName("FECHA_DESASIGNACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_ASIGNACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_ASIGNACION_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ASIGNACION_FECHA") + ", " +
				_db.CreateSqlParameterName("USUARIO_DESASIGNACION_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_DESASIGNACION_FECHA") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_DESASIGNACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "ABOGADO_ID", value.ABOGADO_ID);
			AddParameter(cmd, "FECHA_ASIGNACION", value.FECHA_ASIGNACION);
			AddParameter(cmd, "FECHA_DESASIGNACION",
				value.IsFECHA_DESASIGNACIONNull ? DBNull.Value : (object)value.FECHA_DESASIGNACION);
			AddParameter(cmd, "OBSERVACION_ASIGNACION", value.OBSERVACION_ASIGNACION);
			AddParameter(cmd, "USUARIO_ASIGNACION_ID", value.USUARIO_ASIGNACION_ID);
			AddParameter(cmd, "USUARIO_ASIGNACION_FECHA", value.USUARIO_ASIGNACION_FECHA);
			AddParameter(cmd, "USUARIO_DESASIGNACION_ID",
				value.IsUSUARIO_DESASIGNACION_IDNull ? DBNull.Value : (object)value.USUARIO_DESASIGNACION_ID);
			AddParameter(cmd, "USUARIO_DESASIGNACION_FECHA",
				value.IsUSUARIO_DESASIGNACION_FECHANull ? DBNull.Value : (object)value.USUARIO_DESASIGNACION_FECHA);
			AddParameter(cmd, "OBSERVACION_DESASIGNACION", value.OBSERVACION_DESASIGNACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CHEQUES_REC_ABOGADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CHEQUES_REC_ABOGADOS SET " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"ABOGADO_ID=" + _db.CreateSqlParameterName("ABOGADO_ID") + ", " +
				"FECHA_ASIGNACION=" + _db.CreateSqlParameterName("FECHA_ASIGNACION") + ", " +
				"FECHA_DESASIGNACION=" + _db.CreateSqlParameterName("FECHA_DESASIGNACION") + ", " +
				"OBSERVACION_ASIGNACION=" + _db.CreateSqlParameterName("OBSERVACION_ASIGNACION") + ", " +
				"USUARIO_ASIGNACION_ID=" + _db.CreateSqlParameterName("USUARIO_ASIGNACION_ID") + ", " +
				"USUARIO_ASIGNACION_FECHA=" + _db.CreateSqlParameterName("USUARIO_ASIGNACION_FECHA") + ", " +
				"USUARIO_DESASIGNACION_ID=" + _db.CreateSqlParameterName("USUARIO_DESASIGNACION_ID") + ", " +
				"USUARIO_DESASIGNACION_FECHA=" + _db.CreateSqlParameterName("USUARIO_DESASIGNACION_FECHA") + ", " +
				"OBSERVACION_DESASIGNACION=" + _db.CreateSqlParameterName("OBSERVACION_DESASIGNACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "ABOGADO_ID", value.ABOGADO_ID);
			AddParameter(cmd, "FECHA_ASIGNACION", value.FECHA_ASIGNACION);
			AddParameter(cmd, "FECHA_DESASIGNACION",
				value.IsFECHA_DESASIGNACIONNull ? DBNull.Value : (object)value.FECHA_DESASIGNACION);
			AddParameter(cmd, "OBSERVACION_ASIGNACION", value.OBSERVACION_ASIGNACION);
			AddParameter(cmd, "USUARIO_ASIGNACION_ID", value.USUARIO_ASIGNACION_ID);
			AddParameter(cmd, "USUARIO_ASIGNACION_FECHA", value.USUARIO_ASIGNACION_FECHA);
			AddParameter(cmd, "USUARIO_DESASIGNACION_ID",
				value.IsUSUARIO_DESASIGNACION_IDNull ? DBNull.Value : (object)value.USUARIO_DESASIGNACION_ID);
			AddParameter(cmd, "USUARIO_DESASIGNACION_FECHA",
				value.IsUSUARIO_DESASIGNACION_FECHANull ? DBNull.Value : (object)value.USUARIO_DESASIGNACION_FECHA);
			AddParameter(cmd, "OBSERVACION_DESASIGNACION", value.OBSERVACION_DESASIGNACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CHEQUES_REC_ABOGADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table using
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
		/// Deletes records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_REC_ABOG_ABO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByABOGADO_ID(decimal abogado_id)
		{
			return CreateDeleteByABOGADO_IDCommand(abogado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_REC_ABOG_ABO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByABOGADO_IDCommand(decimal abogado_id)
		{
			string whereSql = "";
			whereSql += "ABOGADO_ID=" + _db.CreateSqlParameterName("ABOGADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ABOGADO_ID", abogado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_REC_ABOG_CHQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_REC_ABOG_CHQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_REC_ABOG_U_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion_id">The <c>USUARIO_ASIGNACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ASIGNACION_ID(decimal usuario_asignacion_id)
		{
			return CreateDeleteByUSUARIO_ASIGNACION_IDCommand(usuario_asignacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_asignacion_id">The <c>USUARIO_ASIGNACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ASIGNACION_IDCommand(decimal usuario_asignacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ASIGNACION_ID=" + _db.CreateSqlParameterName("USUARIO_ASIGNACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ASIGNACION_ID", usuario_asignacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESASIGNACION_ID(decimal usuario_desasignacion_id)
		{
			return DeleteByUSUARIO_DESASIGNACION_ID(usuario_desasignacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <param name="usuario_desasignacion_idNull">true if the method ignores the usuario_desasignacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESASIGNACION_ID(decimal usuario_desasignacion_id, bool usuario_desasignacion_idNull)
		{
			return CreateDeleteByUSUARIO_DESASIGNACION_IDCommand(usuario_desasignacion_id, usuario_desasignacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_REC_ABOG_U_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_desasignacion_id">The <c>USUARIO_DESASIGNACION_ID</c> column value.</param>
		/// <param name="usuario_desasignacion_idNull">true if the method ignores the usuario_desasignacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_DESASIGNACION_IDCommand(decimal usuario_desasignacion_id, bool usuario_desasignacion_idNull)
		{
			string whereSql = "";
			if(usuario_desasignacion_idNull)
				whereSql += "USUARIO_DESASIGNACION_ID IS NULL";
			else
				whereSql += "USUARIO_DESASIGNACION_ID=" + _db.CreateSqlParameterName("USUARIO_DESASIGNACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_desasignacion_idNull)
				AddParameter(cmd, "USUARIO_DESASIGNACION_ID", usuario_desasignacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_CHEQUES_REC_ABOGADOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CHEQUES_REC_ABOGADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CHEQUES_REC_ABOGADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_REC_ABOGADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_REC_ABOGADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> objects.</returns>
		protected virtual CTACTE_CHEQUES_REC_ABOGADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int abogado_idColumnIndex = reader.GetOrdinal("ABOGADO_ID");
			int fecha_asignacionColumnIndex = reader.GetOrdinal("FECHA_ASIGNACION");
			int fecha_desasignacionColumnIndex = reader.GetOrdinal("FECHA_DESASIGNACION");
			int observacion_asignacionColumnIndex = reader.GetOrdinal("OBSERVACION_ASIGNACION");
			int usuario_asignacion_idColumnIndex = reader.GetOrdinal("USUARIO_ASIGNACION_ID");
			int usuario_asignacion_fechaColumnIndex = reader.GetOrdinal("USUARIO_ASIGNACION_FECHA");
			int usuario_desasignacion_idColumnIndex = reader.GetOrdinal("USUARIO_DESASIGNACION_ID");
			int usuario_desasignacion_fechaColumnIndex = reader.GetOrdinal("USUARIO_DESASIGNACION_FECHA");
			int observacion_desasignacionColumnIndex = reader.GetOrdinal("OBSERVACION_DESASIGNACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CHEQUES_REC_ABOGADOSRow record = new CTACTE_CHEQUES_REC_ABOGADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					record.ABOGADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(abogado_idColumnIndex)), 9);
					record.FECHA_ASIGNACION = Convert.ToDateTime(reader.GetValue(fecha_asignacionColumnIndex));
					if(!reader.IsDBNull(fecha_desasignacionColumnIndex))
						record.FECHA_DESASIGNACION = Convert.ToDateTime(reader.GetValue(fecha_desasignacionColumnIndex));
					if(!reader.IsDBNull(observacion_asignacionColumnIndex))
						record.OBSERVACION_ASIGNACION = Convert.ToString(reader.GetValue(observacion_asignacionColumnIndex));
					record.USUARIO_ASIGNACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_asignacion_idColumnIndex)), 9);
					record.USUARIO_ASIGNACION_FECHA = Convert.ToDateTime(reader.GetValue(usuario_asignacion_fechaColumnIndex));
					if(!reader.IsDBNull(usuario_desasignacion_idColumnIndex))
						record.USUARIO_DESASIGNACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_desasignacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_desasignacion_fechaColumnIndex))
						record.USUARIO_DESASIGNACION_FECHA = Convert.ToDateTime(reader.GetValue(usuario_desasignacion_fechaColumnIndex));
					if(!reader.IsDBNull(observacion_desasignacionColumnIndex))
						record.OBSERVACION_DESASIGNACION = Convert.ToString(reader.GetValue(observacion_desasignacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CHEQUES_REC_ABOGADOSRow[])(recordList.ToArray(typeof(CTACTE_CHEQUES_REC_ABOGADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CHEQUES_REC_ABOGADOSRow"/> object.</returns>
		protected virtual CTACTE_CHEQUES_REC_ABOGADOSRow MapRow(DataRow row)
		{
			CTACTE_CHEQUES_REC_ABOGADOSRow mappedObject = new CTACTE_CHEQUES_REC_ABOGADOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "ABOGADO_ID"
			dataColumn = dataTable.Columns["ABOGADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABOGADO_ID = (decimal)row[dataColumn];
			// Column "FECHA_ASIGNACION"
			dataColumn = dataTable.Columns["FECHA_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ASIGNACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_DESASIGNACION"
			dataColumn = dataTable.Columns["FECHA_DESASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESASIGNACION = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION_ASIGNACION"
			dataColumn = dataTable.Columns["OBSERVACION_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_ASIGNACION = (string)row[dataColumn];
			// Column "USUARIO_ASIGNACION_ID"
			dataColumn = dataTable.Columns["USUARIO_ASIGNACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ASIGNACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ASIGNACION_FECHA"
			dataColumn = dataTable.Columns["USUARIO_ASIGNACION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ASIGNACION_FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_DESASIGNACION_ID"
			dataColumn = dataTable.Columns["USUARIO_DESASIGNACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_DESASIGNACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_DESASIGNACION_FECHA"
			dataColumn = dataTable.Columns["USUARIO_DESASIGNACION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_DESASIGNACION_FECHA = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION_DESASIGNACION"
			dataColumn = dataTable.Columns["OBSERVACION_DESASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_DESASIGNACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CHEQUES_REC_ABOGADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CHEQUES_REC_ABOGADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABOGADO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ASIGNACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_DESASIGNACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("OBSERVACION_ASIGNACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("USUARIO_ASIGNACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ASIGNACION_FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_DESASIGNACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_DESASIGNACION_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("OBSERVACION_DESASIGNACION", typeof(string));
			dataColumn.MaxLength = 300;
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

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ABOGADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DESASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ASIGNACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ASIGNACION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_DESASIGNACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_DESASIGNACION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION_DESASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CHEQUES_REC_ABOGADOSCollection_Base class
}  // End of namespace
