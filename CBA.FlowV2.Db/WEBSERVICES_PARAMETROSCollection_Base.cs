// <fileinfo name="WEBSERVICES_PARAMETROSCollection_Base.cs">
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
	/// The base class for <see cref="WEBSERVICES_PARAMETROSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="WEBSERVICES_PARAMETROSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class WEBSERVICES_PARAMETROSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string HASHColumnName = "HASH";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string PARAMETROSColumnName = "PARAMETROS";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string IPColumnName = "IP";
		public const string WEBSERVICE_IDColumnName = "WEBSERVICE_ID";
		public const string UTILIZADOColumnName = "UTILIZADO";
		public const string FINALIZADOColumnName = "FINALIZADO";
		public const string RESULTADOColumnName = "RESULTADO";
		public const string WEBMETHODColumnName = "WEBMETHOD";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="WEBSERVICES_PARAMETROSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public WEBSERVICES_PARAMETROSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>WEBSERVICES_PARAMETROS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		public virtual WEBSERVICES_PARAMETROSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>WEBSERVICES_PARAMETROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>WEBSERVICES_PARAMETROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="WEBSERVICES_PARAMETROSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="WEBSERVICES_PARAMETROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public WEBSERVICES_PARAMETROSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			WEBSERVICES_PARAMETROSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		public WEBSERVICES_PARAMETROSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects that 
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
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		public virtual WEBSERVICES_PARAMETROSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.WEBSERVICES_PARAMETROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="WEBSERVICES_PARAMETROSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="WEBSERVICES_PARAMETROSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual WEBSERVICES_PARAMETROSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			WEBSERVICES_PARAMETROSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		public WEBSERVICES_PARAMETROSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		public virtual WEBSERVICES_PARAMETROSRow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
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
		/// return records by the <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
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
		/// Gets an array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		public WEBSERVICES_PARAMETROSRow[] GetByWEBSERVICE_ID(decimal webservice_id)
		{
			return GetByWEBSERVICE_ID(webservice_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <param name="webservice_idNull">true if the method ignores the webservice_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		public virtual WEBSERVICES_PARAMETROSRow[] GetByWEBSERVICE_ID(decimal webservice_id, bool webservice_idNull)
		{
			return MapRecords(CreateGetByWEBSERVICE_IDCommand(webservice_id, webservice_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByWEBSERVICE_IDAsDataTable(decimal webservice_id)
		{
			return GetByWEBSERVICE_IDAsDataTable(webservice_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <param name="webservice_idNull">true if the method ignores the webservice_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByWEBSERVICE_IDAsDataTable(decimal webservice_id, bool webservice_idNull)
		{
			return MapRecordsToDataTable(CreateGetByWEBSERVICE_IDCommand(webservice_id, webservice_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <param name="webservice_idNull">true if the method ignores the webservice_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByWEBSERVICE_IDCommand(decimal webservice_id, bool webservice_idNull)
		{
			string whereSql = "";
			if(webservice_idNull)
				whereSql += "WEBSERVICE_ID IS NULL";
			else
				whereSql += "WEBSERVICE_ID=" + _db.CreateSqlParameterName("WEBSERVICE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!webservice_idNull)
				AddParameter(cmd, "WEBSERVICE_ID", webservice_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>WEBSERVICES_PARAMETROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="WEBSERVICES_PARAMETROSRow"/> object to be inserted.</param>
		public virtual void Insert(WEBSERVICES_PARAMETROSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.WEBSERVICES_PARAMETROS (" +
				"ID, " +
				"HASH, " +
				"USUARIO_ID, " +
				"PARAMETROS, " +
				"FECHA_CREACION, " +
				"IP, " +
				"WEBSERVICE_ID, " +
				"UTILIZADO, " +
				"FINALIZADO, " +
				"RESULTADO, " +
				"WEBMETHOD" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("HASH") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("PARAMETROS") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("IP") + ", " +
				_db.CreateSqlParameterName("WEBSERVICE_ID") + ", " +
				_db.CreateSqlParameterName("UTILIZADO") + ", " +
				_db.CreateSqlParameterName("FINALIZADO") + ", " +
				_db.CreateSqlParameterName("RESULTADO") + ", " +
				_db.CreateSqlParameterName("WEBMETHOD") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "HASH", value.HASH);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "PARAMETROS", value.PARAMETROS);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "IP", value.IP);
			AddParameter(cmd, "WEBSERVICE_ID",
				value.IsWEBSERVICE_IDNull ? DBNull.Value : (object)value.WEBSERVICE_ID);
			AddParameter(cmd, "UTILIZADO", value.UTILIZADO);
			AddParameter(cmd, "FINALIZADO", value.FINALIZADO);
			AddParameter(cmd, "RESULTADO", value.RESULTADO);
			AddParameter(cmd, "WEBMETHOD", value.WEBMETHOD);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>WEBSERVICES_PARAMETROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="WEBSERVICES_PARAMETROSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(WEBSERVICES_PARAMETROSRow value)
		{
			
			string sqlStr = "UPDATE TRC.WEBSERVICES_PARAMETROS SET " +
				"HASH=" + _db.CreateSqlParameterName("HASH") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"PARAMETROS=" + _db.CreateSqlParameterName("PARAMETROS") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"IP=" + _db.CreateSqlParameterName("IP") + ", " +
				"WEBSERVICE_ID=" + _db.CreateSqlParameterName("WEBSERVICE_ID") + ", " +
				"UTILIZADO=" + _db.CreateSqlParameterName("UTILIZADO") + ", " +
				"FINALIZADO=" + _db.CreateSqlParameterName("FINALIZADO") + ", " +
				"RESULTADO=" + _db.CreateSqlParameterName("RESULTADO") + ", " +
				"WEBMETHOD=" + _db.CreateSqlParameterName("WEBMETHOD") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "HASH", value.HASH);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "PARAMETROS", value.PARAMETROS);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "IP", value.IP);
			AddParameter(cmd, "WEBSERVICE_ID",
				value.IsWEBSERVICE_IDNull ? DBNull.Value : (object)value.WEBSERVICE_ID);
			AddParameter(cmd, "UTILIZADO", value.UTILIZADO);
			AddParameter(cmd, "FINALIZADO", value.FINALIZADO);
			AddParameter(cmd, "RESULTADO", value.RESULTADO);
			AddParameter(cmd, "WEBMETHOD", value.WEBMETHOD);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>WEBSERVICES_PARAMETROS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>WEBSERVICES_PARAMETROS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>WEBSERVICES_PARAMETROS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="WEBSERVICES_PARAMETROSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(WEBSERVICES_PARAMETROSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>WEBSERVICES_PARAMETROS</c> table using
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
		/// Deletes records from the <c>WEBSERVICES_PARAMETROS</c> table using the 
		/// <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>WEBSERVICES_PARAMETROS</c> table using the 
		/// <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
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
		/// delete records using the <c>FK_WEBSERVICES_PARAMETROS_USR</c> foreign key.
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
		/// Deletes records from the <c>WEBSERVICES_PARAMETROS</c> table using the 
		/// <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByWEBSERVICE_ID(decimal webservice_id)
		{
			return DeleteByWEBSERVICE_ID(webservice_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>WEBSERVICES_PARAMETROS</c> table using the 
		/// <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <param name="webservice_idNull">true if the method ignores the webservice_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByWEBSERVICE_ID(decimal webservice_id, bool webservice_idNull)
		{
			return CreateDeleteByWEBSERVICE_IDCommand(webservice_id, webservice_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_WEBSERVICES_PARAMETROS_WEB</c> foreign key.
		/// </summary>
		/// <param name="webservice_id">The <c>WEBSERVICE_ID</c> column value.</param>
		/// <param name="webservice_idNull">true if the method ignores the webservice_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByWEBSERVICE_IDCommand(decimal webservice_id, bool webservice_idNull)
		{
			string whereSql = "";
			if(webservice_idNull)
				whereSql += "WEBSERVICE_ID IS NULL";
			else
				whereSql += "WEBSERVICE_ID=" + _db.CreateSqlParameterName("WEBSERVICE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!webservice_idNull)
				AddParameter(cmd, "WEBSERVICE_ID", webservice_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>WEBSERVICES_PARAMETROS</c> records that match the specified criteria.
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
		/// to delete <c>WEBSERVICES_PARAMETROS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.WEBSERVICES_PARAMETROS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>WEBSERVICES_PARAMETROS</c> table.
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
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		protected WEBSERVICES_PARAMETROSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		protected WEBSERVICES_PARAMETROSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="WEBSERVICES_PARAMETROSRow"/> objects.</returns>
		protected virtual WEBSERVICES_PARAMETROSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int hashColumnIndex = reader.GetOrdinal("HASH");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int parametrosColumnIndex = reader.GetOrdinal("PARAMETROS");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int ipColumnIndex = reader.GetOrdinal("IP");
			int webservice_idColumnIndex = reader.GetOrdinal("WEBSERVICE_ID");
			int utilizadoColumnIndex = reader.GetOrdinal("UTILIZADO");
			int finalizadoColumnIndex = reader.GetOrdinal("FINALIZADO");
			int resultadoColumnIndex = reader.GetOrdinal("RESULTADO");
			int webmethodColumnIndex = reader.GetOrdinal("WEBMETHOD");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					WEBSERVICES_PARAMETROSRow record = new WEBSERVICES_PARAMETROSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(hashColumnIndex))
						record.HASH = Convert.ToString(reader.GetValue(hashColumnIndex));
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(parametrosColumnIndex))
						record.PARAMETROS = Convert.ToString(reader.GetValue(parametrosColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(ipColumnIndex))
						record.IP = Convert.ToString(reader.GetValue(ipColumnIndex));
					if(!reader.IsDBNull(webservice_idColumnIndex))
						record.WEBSERVICE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(webservice_idColumnIndex)), 9);
					record.UTILIZADO = Convert.ToString(reader.GetValue(utilizadoColumnIndex));
					record.FINALIZADO = Convert.ToString(reader.GetValue(finalizadoColumnIndex));
					if(!reader.IsDBNull(resultadoColumnIndex))
						record.RESULTADO = Convert.ToString(reader.GetValue(resultadoColumnIndex));
					if(!reader.IsDBNull(webmethodColumnIndex))
						record.WEBMETHOD = Convert.ToString(reader.GetValue(webmethodColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (WEBSERVICES_PARAMETROSRow[])(recordList.ToArray(typeof(WEBSERVICES_PARAMETROSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="WEBSERVICES_PARAMETROSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="WEBSERVICES_PARAMETROSRow"/> object.</returns>
		protected virtual WEBSERVICES_PARAMETROSRow MapRow(DataRow row)
		{
			WEBSERVICES_PARAMETROSRow mappedObject = new WEBSERVICES_PARAMETROSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "HASH"
			dataColumn = dataTable.Columns["HASH"];
			if(!row.IsNull(dataColumn))
				mappedObject.HASH = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "PARAMETROS"
			dataColumn = dataTable.Columns["PARAMETROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARAMETROS = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "IP"
			dataColumn = dataTable.Columns["IP"];
			if(!row.IsNull(dataColumn))
				mappedObject.IP = (string)row[dataColumn];
			// Column "WEBSERVICE_ID"
			dataColumn = dataTable.Columns["WEBSERVICE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.WEBSERVICE_ID = (decimal)row[dataColumn];
			// Column "UTILIZADO"
			dataColumn = dataTable.Columns["UTILIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.UTILIZADO = (string)row[dataColumn];
			// Column "FINALIZADO"
			dataColumn = dataTable.Columns["FINALIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FINALIZADO = (string)row[dataColumn];
			// Column "RESULTADO"
			dataColumn = dataTable.Columns["RESULTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESULTADO = (string)row[dataColumn];
			// Column "WEBMETHOD"
			dataColumn = dataTable.Columns["WEBMETHOD"];
			if(!row.IsNull(dataColumn))
				mappedObject.WEBMETHOD = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>WEBSERVICES_PARAMETROS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "WEBSERVICES_PARAMETROS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HASH", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PARAMETROS", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IP", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("WEBSERVICE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UTILIZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FINALIZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RESULTADO", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("WEBMETHOD", typeof(string));
			dataColumn.MaxLength = 100;
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

				case "HASH":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PARAMETROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "IP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "WEBSERVICE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UTILIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FINALIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RESULTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "WEBMETHOD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of WEBSERVICES_PARAMETROSCollection_Base class
}  // End of namespace
