// <fileinfo name="SEGUIMIENTOS_DESTINATARIOSCollection_Base.cs">
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
	/// The base class for <see cref="SEGUIMIENTOS_DESTINATARIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="SEGUIMIENTOS_DESTINATARIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class SEGUIMIENTOS_DESTINATARIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string MAILColumnName = "MAIL";
		public const string FECHA_INICIA_SEGUIMIENTOColumnName = "FECHA_INICIA_SEGUIMIENTO";
		public const string FECHA_CANCELA_SEGUIMIENTOColumnName = "FECHA_CANCELA_SEGUIMIENTO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string LOG_CAMPO_IDColumnName = "LOG_CAMPO_ID";
		public const string REGISTRO_IDColumnName = "REGISTRO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="SEGUIMIENTOS_DESTINATARIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public SEGUIMIENTOS_DESTINATARIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public virtual SEGUIMIENTOS_DESTINATARIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public SEGUIMIENTOS_DESTINATARIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			SEGUIMIENTOS_DESTINATARIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public SEGUIMIENTOS_DESTINATARIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public virtual SEGUIMIENTOS_DESTINATARIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.SEGUIMIENTOS_DESTINATARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual SEGUIMIENTOS_DESTINATARIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			SEGUIMIENTOS_DESTINATARIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects 
		/// by the <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public SEGUIMIENTOS_DESTINATARIOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects 
		/// by the <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public virtual SEGUIMIENTOS_DESTINATARIOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id, bool caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects 
		/// by the <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public SEGUIMIENTOS_DESTINATARIOSRow[] GetByLOG_CAMPO_ID(decimal log_campo_id)
		{
			return GetByLOG_CAMPO_ID(log_campo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects 
		/// by the <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public virtual SEGUIMIENTOS_DESTINATARIOSRow[] GetByLOG_CAMPO_ID(decimal log_campo_id, bool log_campo_idNull)
		{
			return MapRecords(CreateGetByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOG_CAMPO_IDAsDataTable(decimal log_campo_id)
		{
			return GetByLOG_CAMPO_IDAsDataTable(log_campo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOG_CAMPO_IDAsDataTable(decimal log_campo_id, bool log_campo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOG_CAMPO_IDCommand(decimal log_campo_id, bool log_campo_idNull)
		{
			string whereSql = "";
			if(log_campo_idNull)
				whereSql += "LOG_CAMPO_ID IS NULL";
			else
				whereSql += "LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!log_campo_idNull)
				AddParameter(cmd, "LOG_CAMPO_ID", log_campo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects 
		/// by the <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public SEGUIMIENTOS_DESTINATARIOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects 
		/// by the <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		public virtual SEGUIMIENTOS_DESTINATARIOSRow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> object to be inserted.</param>
		public virtual void Insert(SEGUIMIENTOS_DESTINATARIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.SEGUIMIENTOS_DESTINATARIOS (" +
				"ID, " +
				"USUARIO_ID, " +
				"MAIL, " +
				"FECHA_INICIA_SEGUIMIENTO, " +
				"FECHA_CANCELA_SEGUIMIENTO, " +
				"CASO_ID, " +
				"LOG_CAMPO_ID, " +
				"REGISTRO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("MAIL") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIA_SEGUIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_CANCELA_SEGUIMIENTO") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("LOG_CAMPO_ID") + ", " +
				_db.CreateSqlParameterName("REGISTRO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "MAIL", value.MAIL);
			AddParameter(cmd, "FECHA_INICIA_SEGUIMIENTO", value.FECHA_INICIA_SEGUIMIENTO);
			AddParameter(cmd, "FECHA_CANCELA_SEGUIMIENTO",
				value.IsFECHA_CANCELA_SEGUIMIENTONull ? DBNull.Value : (object)value.FECHA_CANCELA_SEGUIMIENTO);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "LOG_CAMPO_ID",
				value.IsLOG_CAMPO_IDNull ? DBNull.Value : (object)value.LOG_CAMPO_ID);
			AddParameter(cmd, "REGISTRO_ID",
				value.IsREGISTRO_IDNull ? DBNull.Value : (object)value.REGISTRO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(SEGUIMIENTOS_DESTINATARIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.SEGUIMIENTOS_DESTINATARIOS SET " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"MAIL=" + _db.CreateSqlParameterName("MAIL") + ", " +
				"FECHA_INICIA_SEGUIMIENTO=" + _db.CreateSqlParameterName("FECHA_INICIA_SEGUIMIENTO") + ", " +
				"FECHA_CANCELA_SEGUIMIENTO=" + _db.CreateSqlParameterName("FECHA_CANCELA_SEGUIMIENTO") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID") + ", " +
				"REGISTRO_ID=" + _db.CreateSqlParameterName("REGISTRO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "MAIL", value.MAIL);
			AddParameter(cmd, "FECHA_INICIA_SEGUIMIENTO", value.FECHA_INICIA_SEGUIMIENTO);
			AddParameter(cmd, "FECHA_CANCELA_SEGUIMIENTO",
				value.IsFECHA_CANCELA_SEGUIMIENTONull ? DBNull.Value : (object)value.FECHA_CANCELA_SEGUIMIENTO);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "LOG_CAMPO_ID",
				value.IsLOG_CAMPO_IDNull ? DBNull.Value : (object)value.LOG_CAMPO_ID);
			AddParameter(cmd, "REGISTRO_ID",
				value.IsREGISTRO_IDNull ? DBNull.Value : (object)value.REGISTRO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>SEGUIMIENTOS_DESTINATARIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>SEGUIMIENTOS_DESTINATARIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(SEGUIMIENTOS_DESTINATARIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table using
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
		/// Deletes records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table using the 
		/// <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table using the 
		/// <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return CreateDeleteByCASO_IDCommand(caso_id, caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SEGUIMIENTOS_DEST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table using the 
		/// <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOG_CAMPO_ID(decimal log_campo_id)
		{
			return DeleteByLOG_CAMPO_ID(log_campo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table using the 
		/// <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOG_CAMPO_ID(decimal log_campo_id, bool log_campo_idNull)
		{
			return CreateDeleteByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SEGUIMIENTOS_DEST_LOG</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOG_CAMPO_IDCommand(decimal log_campo_id, bool log_campo_idNull)
		{
			string whereSql = "";
			if(log_campo_idNull)
				whereSql += "LOG_CAMPO_ID IS NULL";
			else
				whereSql += "LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!log_campo_idNull)
				AddParameter(cmd, "LOG_CAMPO_ID", log_campo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table using the 
		/// <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table using the 
		/// <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id, usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SEGUIMIENTOS_DEST_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>SEGUIMIENTOS_DESTINATARIOS</c> records that match the specified criteria.
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
		/// to delete <c>SEGUIMIENTOS_DESTINATARIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.SEGUIMIENTOS_DESTINATARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
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
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		protected SEGUIMIENTOS_DESTINATARIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		protected SEGUIMIENTOS_DESTINATARIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> objects.</returns>
		protected virtual SEGUIMIENTOS_DESTINATARIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int mailColumnIndex = reader.GetOrdinal("MAIL");
			int fecha_inicia_seguimientoColumnIndex = reader.GetOrdinal("FECHA_INICIA_SEGUIMIENTO");
			int fecha_cancela_seguimientoColumnIndex = reader.GetOrdinal("FECHA_CANCELA_SEGUIMIENTO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int log_campo_idColumnIndex = reader.GetOrdinal("LOG_CAMPO_ID");
			int registro_idColumnIndex = reader.GetOrdinal("REGISTRO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					SEGUIMIENTOS_DESTINATARIOSRow record = new SEGUIMIENTOS_DESTINATARIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(mailColumnIndex))
						record.MAIL = Convert.ToString(reader.GetValue(mailColumnIndex));
					record.FECHA_INICIA_SEGUIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_inicia_seguimientoColumnIndex));
					if(!reader.IsDBNull(fecha_cancela_seguimientoColumnIndex))
						record.FECHA_CANCELA_SEGUIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_cancela_seguimientoColumnIndex));
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(log_campo_idColumnIndex))
						record.LOG_CAMPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(log_campo_idColumnIndex)), 9);
					if(!reader.IsDBNull(registro_idColumnIndex))
						record.REGISTRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(registro_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SEGUIMIENTOS_DESTINATARIOSRow[])(recordList.ToArray(typeof(SEGUIMIENTOS_DESTINATARIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="SEGUIMIENTOS_DESTINATARIOSRow"/> object.</returns>
		protected virtual SEGUIMIENTOS_DESTINATARIOSRow MapRow(DataRow row)
		{
			SEGUIMIENTOS_DESTINATARIOSRow mappedObject = new SEGUIMIENTOS_DESTINATARIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "MAIL"
			dataColumn = dataTable.Columns["MAIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAIL = (string)row[dataColumn];
			// Column "FECHA_INICIA_SEGUIMIENTO"
			dataColumn = dataTable.Columns["FECHA_INICIA_SEGUIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIA_SEGUIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_CANCELA_SEGUIMIENTO"
			dataColumn = dataTable.Columns["FECHA_CANCELA_SEGUIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CANCELA_SEGUIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "LOG_CAMPO_ID"
			dataColumn = dataTable.Columns["LOG_CAMPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOG_CAMPO_ID = (decimal)row[dataColumn];
			// Column "REGISTRO_ID"
			dataColumn = dataTable.Columns["REGISTRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>SEGUIMIENTOS_DESTINATARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "SEGUIMIENTOS_DESTINATARIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MAIL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("FECHA_INICIA_SEGUIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CANCELA_SEGUIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOG_CAMPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REGISTRO_ID", typeof(decimal));
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

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MAIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIA_SEGUIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_CANCELA_SEGUIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOG_CAMPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGISTRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of SEGUIMIENTOS_DESTINATARIOSCollection_Base class
}  // End of namespace
