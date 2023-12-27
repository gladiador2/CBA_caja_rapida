// <fileinfo name="CONFIGURACIONES_VALORESCollection_Base.cs">
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
	/// The base class for <see cref="CONFIGURACIONES_VALORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONFIGURACIONES_VALORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONFIGURACIONES_VALORESCollection_Base
	{
		// Constants
		public const string CONFIGURACION_IDColumnName = "CONFIGURACION_ID";
		public const string ROL_IDColumnName = "ROL_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string JSONColumnName = "JSON";
		public const string IDColumnName = "ID";
		public const string REPORTE_IDColumnName = "REPORTE_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONFIGURACIONES_VALORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONFIGURACIONES_VALORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONFIGURACIONES_VALORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public virtual CONFIGURACIONES_VALORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONFIGURACIONES_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONFIGURACIONES_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONFIGURACIONES_VALORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONFIGURACIONES_VALORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONFIGURACIONES_VALORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONFIGURACIONES_VALORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public CONFIGURACIONES_VALORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects that 
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
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public virtual CONFIGURACIONES_VALORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONFIGURACIONES_VALORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONFIGURACIONES_VALORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONFIGURACIONES_VALORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONFIGURACIONES_VALORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONFIGURACIONES_VALORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects 
		/// by the <c>FK_CONF_VALOR_CONF</c> foreign key.
		/// </summary>
		/// <param name="configuracion_id">The <c>CONFIGURACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public virtual CONFIGURACIONES_VALORESRow[] GetByCONFIGURACION_ID(decimal configuracion_id)
		{
			return MapRecords(CreateGetByCONFIGURACION_IDCommand(configuracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONF_VALOR_CONF</c> foreign key.
		/// </summary>
		/// <param name="configuracion_id">The <c>CONFIGURACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONFIGURACION_IDAsDataTable(decimal configuracion_id)
		{
			return MapRecordsToDataTable(CreateGetByCONFIGURACION_IDCommand(configuracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONF_VALOR_CONF</c> foreign key.
		/// </summary>
		/// <param name="configuracion_id">The <c>CONFIGURACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONFIGURACION_IDCommand(decimal configuracion_id)
		{
			string whereSql = "";
			whereSql += "CONFIGURACION_ID=" + _db.CreateSqlParameterName("CONFIGURACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONFIGURACION_ID", configuracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects 
		/// by the <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public CONFIGURACIONES_VALORESRow[] GetByREPORTE_ID(decimal reporte_id)
		{
			return GetByREPORTE_ID(reporte_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects 
		/// by the <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <param name="reporte_idNull">true if the method ignores the reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public virtual CONFIGURACIONES_VALORESRow[] GetByREPORTE_ID(decimal reporte_id, bool reporte_idNull)
		{
			return MapRecords(CreateGetByREPORTE_IDCommand(reporte_id, reporte_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREPORTE_IDAsDataTable(decimal reporte_id)
		{
			return GetByREPORTE_IDAsDataTable(reporte_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <param name="reporte_idNull">true if the method ignores the reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREPORTE_IDAsDataTable(decimal reporte_id, bool reporte_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREPORTE_IDCommand(reporte_id, reporte_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <param name="reporte_idNull">true if the method ignores the reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREPORTE_IDCommand(decimal reporte_id, bool reporte_idNull)
		{
			string whereSql = "";
			if(reporte_idNull)
				whereSql += "REPORTE_ID IS NULL";
			else
				whereSql += "REPORTE_ID=" + _db.CreateSqlParameterName("REPORTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!reporte_idNull)
				AddParameter(cmd, "REPORTE_ID", reporte_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects 
		/// by the <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public CONFIGURACIONES_VALORESRow[] GetByROL_ID(decimal rol_id)
		{
			return GetByROL_ID(rol_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects 
		/// by the <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public virtual CONFIGURACIONES_VALORESRow[] GetByROL_ID(decimal rol_id, bool rol_idNull)
		{
			return MapRecords(CreateGetByROL_IDCommand(rol_id, rol_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_IDAsDataTable(decimal rol_id)
		{
			return GetByROL_IDAsDataTable(rol_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_IDAsDataTable(decimal rol_id, bool rol_idNull)
		{
			return MapRecordsToDataTable(CreateGetByROL_IDCommand(rol_id, rol_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_IDCommand(decimal rol_id, bool rol_idNull)
		{
			string whereSql = "";
			if(rol_idNull)
				whereSql += "ROL_ID IS NULL";
			else
				whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_idNull)
				AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects 
		/// by the <c>FK_CONF_VALOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public CONFIGURACIONES_VALORESRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONFIGURACIONES_VALORESRow"/> objects 
		/// by the <c>FK_CONF_VALOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		public virtual CONFIGURACIONES_VALORESRow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONF_VALOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONF_VALOR_USUARIO</c> foreign key.
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
		/// return records by the <c>FK_CONF_VALOR_USUARIO</c> foreign key.
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
		/// Adds a new record into the <c>CONFIGURACIONES_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONFIGURACIONES_VALORESRow"/> object to be inserted.</param>
		public virtual void Insert(CONFIGURACIONES_VALORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONFIGURACIONES_VALORES (" +
				"CONFIGURACION_ID, " +
				"ROL_ID, " +
				"USUARIO_ID, " +
				"JSON, " +
				"ID, " +
				"REPORTE_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("CONFIGURACION_ID") + ", " +
				_db.CreateSqlParameterName("ROL_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("JSON") + ", " +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("REPORTE_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CONFIGURACION_ID", value.CONFIGURACION_ID);
			AddParameter(cmd, "ROL_ID",
				value.IsROL_IDNull ? DBNull.Value : (object)value.ROL_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "JSON", value.JSON);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "REPORTE_ID",
				value.IsREPORTE_IDNull ? DBNull.Value : (object)value.REPORTE_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONFIGURACIONES_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONFIGURACIONES_VALORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONFIGURACIONES_VALORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONFIGURACIONES_VALORES SET " +
				"CONFIGURACION_ID=" + _db.CreateSqlParameterName("CONFIGURACION_ID") + ", " +
				"ROL_ID=" + _db.CreateSqlParameterName("ROL_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"JSON=" + _db.CreateSqlParameterName("JSON") + ", " +
				"REPORTE_ID=" + _db.CreateSqlParameterName("REPORTE_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CONFIGURACION_ID", value.CONFIGURACION_ID);
			AddParameter(cmd, "ROL_ID",
				value.IsROL_IDNull ? DBNull.Value : (object)value.ROL_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "JSON", value.JSON);
			AddParameter(cmd, "REPORTE_ID",
				value.IsREPORTE_IDNull ? DBNull.Value : (object)value.REPORTE_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONFIGURACIONES_VALORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONFIGURACIONES_VALORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONFIGURACIONES_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONFIGURACIONES_VALORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONFIGURACIONES_VALORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONFIGURACIONES_VALORES</c> table using
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
		/// Deletes records from the <c>CONFIGURACIONES_VALORES</c> table using the 
		/// <c>FK_CONF_VALOR_CONF</c> foreign key.
		/// </summary>
		/// <param name="configuracion_id">The <c>CONFIGURACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONFIGURACION_ID(decimal configuracion_id)
		{
			return CreateDeleteByCONFIGURACION_IDCommand(configuracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONF_VALOR_CONF</c> foreign key.
		/// </summary>
		/// <param name="configuracion_id">The <c>CONFIGURACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONFIGURACION_IDCommand(decimal configuracion_id)
		{
			string whereSql = "";
			whereSql += "CONFIGURACION_ID=" + _db.CreateSqlParameterName("CONFIGURACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONFIGURACION_ID", configuracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONFIGURACIONES_VALORES</c> table using the 
		/// <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREPORTE_ID(decimal reporte_id)
		{
			return DeleteByREPORTE_ID(reporte_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONFIGURACIONES_VALORES</c> table using the 
		/// <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <param name="reporte_idNull">true if the method ignores the reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREPORTE_ID(decimal reporte_id, bool reporte_idNull)
		{
			return CreateDeleteByREPORTE_IDCommand(reporte_id, reporte_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONF_VALOR_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="reporte_id">The <c>REPORTE_ID</c> column value.</param>
		/// <param name="reporte_idNull">true if the method ignores the reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREPORTE_IDCommand(decimal reporte_id, bool reporte_idNull)
		{
			string whereSql = "";
			if(reporte_idNull)
				whereSql += "REPORTE_ID IS NULL";
			else
				whereSql += "REPORTE_ID=" + _db.CreateSqlParameterName("REPORTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!reporte_idNull)
				AddParameter(cmd, "REPORTE_ID", reporte_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONFIGURACIONES_VALORES</c> table using the 
		/// <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id)
		{
			return DeleteByROL_ID(rol_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONFIGURACIONES_VALORES</c> table using the 
		/// <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id, bool rol_idNull)
		{
			return CreateDeleteByROL_IDCommand(rol_id, rol_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONF_VALOR_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_IDCommand(decimal rol_id, bool rol_idNull)
		{
			string whereSql = "";
			if(rol_idNull)
				whereSql += "ROL_ID IS NULL";
			else
				whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_idNull)
				AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONFIGURACIONES_VALORES</c> table using the 
		/// <c>FK_CONF_VALOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONFIGURACIONES_VALORES</c> table using the 
		/// <c>FK_CONF_VALOR_USUARIO</c> foreign key.
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
		/// delete records using the <c>FK_CONF_VALOR_USUARIO</c> foreign key.
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
		/// Deletes <c>CONFIGURACIONES_VALORES</c> records that match the specified criteria.
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
		/// to delete <c>CONFIGURACIONES_VALORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONFIGURACIONES_VALORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONFIGURACIONES_VALORES</c> table.
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
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		protected CONFIGURACIONES_VALORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		protected CONFIGURACIONES_VALORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONFIGURACIONES_VALORESRow"/> objects.</returns>
		protected virtual CONFIGURACIONES_VALORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int configuracion_idColumnIndex = reader.GetOrdinal("CONFIGURACION_ID");
			int rol_idColumnIndex = reader.GetOrdinal("ROL_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int jsonColumnIndex = reader.GetOrdinal("JSON");
			int idColumnIndex = reader.GetOrdinal("ID");
			int reporte_idColumnIndex = reader.GetOrdinal("REPORTE_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONFIGURACIONES_VALORESRow record = new CONFIGURACIONES_VALORESRow();
					recordList.Add(record);

					record.CONFIGURACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(configuracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(rol_idColumnIndex))
						record.ROL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rol_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(jsonColumnIndex))
						record.JSON = Convert.ToString(reader.GetValue(jsonColumnIndex));
					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(reporte_idColumnIndex))
						record.REPORTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reporte_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONFIGURACIONES_VALORESRow[])(recordList.ToArray(typeof(CONFIGURACIONES_VALORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONFIGURACIONES_VALORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONFIGURACIONES_VALORESRow"/> object.</returns>
		protected virtual CONFIGURACIONES_VALORESRow MapRow(DataRow row)
		{
			CONFIGURACIONES_VALORESRow mappedObject = new CONFIGURACIONES_VALORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "CONFIGURACION_ID"
			dataColumn = dataTable.Columns["CONFIGURACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONFIGURACION_ID = (decimal)row[dataColumn];
			// Column "ROL_ID"
			dataColumn = dataTable.Columns["ROL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "JSON"
			dataColumn = dataTable.Columns["JSON"];
			if(!row.IsNull(dataColumn))
				mappedObject.JSON = (string)row[dataColumn];
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "REPORTE_ID"
			dataColumn = dataTable.Columns["REPORTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REPORTE_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONFIGURACIONES_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONFIGURACIONES_VALORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CONFIGURACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ROL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("JSON", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REPORTE_ID", typeof(decimal));
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
				case "CONFIGURACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "JSON":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REPORTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONFIGURACIONES_VALORESCollection_Base class
}  // End of namespace
