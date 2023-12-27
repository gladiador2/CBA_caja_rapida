// <fileinfo name="LINEAS_MOVIMIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="LINEAS_MOVIMIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="LINEAS_MOVIMIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LINEAS_MOVIMIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string EDI_PATHColumnName = "EDI_PATH";
		public const string EDI_ESTRUCTURAColumnName = "EDI_ESTRUCTURA";
		public const string MOVIMIENTOColumnName = "MOVIMIENTO";
		public const string EDI_NOMBREColumnName = "EDI_NOMBRE";
		public const string TIPO_CONTENEDOR_IDColumnName = "TIPO_CONTENEDOR_ID";
		public const string LINEA_MOVIMIENTO_SIGUIENTE_IDColumnName = "LINEA_MOVIMIENTO_SIGUIENTE_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="LINEAS_MOVIMIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public LINEAS_MOVIMIENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>LINEAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual LINEAS_MOVIMIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>LINEAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>LINEAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="LINEAS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="LINEAS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public LINEAS_MOVIMIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			LINEAS_MOVIMIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public LINEAS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual LINEAS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.LINEAS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="LINEAS_MOVIMIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="LINEAS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual LINEAS_MOVIMIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			LINEAS_MOVIMIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public LINEAS_MOVIMIENTOSRow[] GetByLINEA_MOVIMIENTO_SIGUIENTE_ID(decimal linea_movimiento_siguiente_id)
		{
			return GetByLINEA_MOVIMIENTO_SIGUIENTE_ID(linea_movimiento_siguiente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <param name="linea_movimiento_siguiente_idNull">true if the method ignores the linea_movimiento_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual LINEAS_MOVIMIENTOSRow[] GetByLINEA_MOVIMIENTO_SIGUIENTE_ID(decimal linea_movimiento_siguiente_id, bool linea_movimiento_siguiente_idNull)
		{
			return MapRecords(CreateGetByLINEA_MOVIMIENTO_SIGUIENTE_IDCommand(linea_movimiento_siguiente_id, linea_movimiento_siguiente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLINEA_MOVIMIENTO_SIGUIENTE_IDAsDataTable(decimal linea_movimiento_siguiente_id)
		{
			return GetByLINEA_MOVIMIENTO_SIGUIENTE_IDAsDataTable(linea_movimiento_siguiente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <param name="linea_movimiento_siguiente_idNull">true if the method ignores the linea_movimiento_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLINEA_MOVIMIENTO_SIGUIENTE_IDAsDataTable(decimal linea_movimiento_siguiente_id, bool linea_movimiento_siguiente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLINEA_MOVIMIENTO_SIGUIENTE_IDCommand(linea_movimiento_siguiente_id, linea_movimiento_siguiente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <param name="linea_movimiento_siguiente_idNull">true if the method ignores the linea_movimiento_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLINEA_MOVIMIENTO_SIGUIENTE_IDCommand(decimal linea_movimiento_siguiente_id, bool linea_movimiento_siguiente_idNull)
		{
			string whereSql = "";
			if(linea_movimiento_siguiente_idNull)
				whereSql += "LINEA_MOVIMIENTO_SIGUIENTE_ID IS NULL";
			else
				whereSql += "LINEA_MOVIMIENTO_SIGUIENTE_ID=" + _db.CreateSqlParameterName("LINEA_MOVIMIENTO_SIGUIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!linea_movimiento_siguiente_idNull)
				AddParameter(cmd, "LINEA_MOVIMIENTO_SIGUIENTE_ID", linea_movimiento_siguiente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual LINEAS_MOVIMIENTOSRow[] GetByLINEA_ID(decimal linea_id)
		{
			return MapRecords(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLINEA_IDAsDataTable(decimal linea_id)
		{
			return MapRecordsToDataTable(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LINEAS_MOVIMIENTOS_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLINEA_IDCommand(decimal linea_id)
		{
			string whereSql = "";
			whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public LINEAS_MOVIMIENTOSRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return GetByTIPO_CONTENEDOR_ID(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual LINEAS_MOVIMIENTOSRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return MapRecords(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id)
		{
			return GetByTIPO_CONTENEDOR_IDAsDataTable(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			string whereSql = "";
			if(tipo_contenedor_idNull)
				whereSql += "TIPO_CONTENEDOR_ID IS NULL";
			else
				whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_contenedor_idNull)
				AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>LINEAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LINEAS_MOVIMIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(LINEAS_MOVIMIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.LINEAS_MOVIMIENTOS (" +
				"ID, " +
				"LINEA_ID, " +
				"EDI_PATH, " +
				"EDI_ESTRUCTURA, " +
				"MOVIMIENTO, " +
				"EDI_NOMBRE, " +
				"TIPO_CONTENEDOR_ID, " +
				"LINEA_MOVIMIENTO_SIGUIENTE_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("LINEA_ID") + ", " +
				_db.CreateSqlParameterName("EDI_PATH") + ", " +
				_db.CreateSqlParameterName("EDI_ESTRUCTURA") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("EDI_NOMBRE") + ", " +
				_db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("LINEA_MOVIMIENTO_SIGUIENTE_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "EDI_PATH", value.EDI_PATH);
			AddParameter(cmd, "EDI_ESTRUCTURA", value.EDI_ESTRUCTURA);
			AddParameter(cmd, "MOVIMIENTO", value.MOVIMIENTO);
			AddParameter(cmd, "EDI_NOMBRE", value.EDI_NOMBRE);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID",
				value.IsTIPO_CONTENEDOR_IDNull ? DBNull.Value : (object)value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "LINEA_MOVIMIENTO_SIGUIENTE_ID",
				value.IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull ? DBNull.Value : (object)value.LINEA_MOVIMIENTO_SIGUIENTE_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>LINEAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LINEAS_MOVIMIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(LINEAS_MOVIMIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.LINEAS_MOVIMIENTOS SET " +
				"LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID") + ", " +
				"EDI_PATH=" + _db.CreateSqlParameterName("EDI_PATH") + ", " +
				"EDI_ESTRUCTURA=" + _db.CreateSqlParameterName("EDI_ESTRUCTURA") + ", " +
				"MOVIMIENTO=" + _db.CreateSqlParameterName("MOVIMIENTO") + ", " +
				"EDI_NOMBRE=" + _db.CreateSqlParameterName("EDI_NOMBRE") + ", " +
				"TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				"LINEA_MOVIMIENTO_SIGUIENTE_ID=" + _db.CreateSqlParameterName("LINEA_MOVIMIENTO_SIGUIENTE_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "EDI_PATH", value.EDI_PATH);
			AddParameter(cmd, "EDI_ESTRUCTURA", value.EDI_ESTRUCTURA);
			AddParameter(cmd, "MOVIMIENTO", value.MOVIMIENTO);
			AddParameter(cmd, "EDI_NOMBRE", value.EDI_NOMBRE);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID",
				value.IsTIPO_CONTENEDOR_IDNull ? DBNull.Value : (object)value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "LINEA_MOVIMIENTO_SIGUIENTE_ID",
				value.IsLINEA_MOVIMIENTO_SIGUIENTE_IDNull ? DBNull.Value : (object)value.LINEA_MOVIMIENTO_SIGUIENTE_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>LINEAS_MOVIMIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>LINEAS_MOVIMIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>LINEAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LINEAS_MOVIMIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(LINEAS_MOVIMIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>LINEAS_MOVIMIENTOS</c> table using
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
		/// Deletes records from the <c>LINEAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_MOVIMIENTO_SIGUIENTE_ID(decimal linea_movimiento_siguiente_id)
		{
			return DeleteByLINEA_MOVIMIENTO_SIGUIENTE_ID(linea_movimiento_siguiente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <param name="linea_movimiento_siguiente_idNull">true if the method ignores the linea_movimiento_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_MOVIMIENTO_SIGUIENTE_ID(decimal linea_movimiento_siguiente_id, bool linea_movimiento_siguiente_idNull)
		{
			return CreateDeleteByLINEA_MOVIMIENTO_SIGUIENTE_IDCommand(linea_movimiento_siguiente_id, linea_movimiento_siguiente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LINEAS_MOVIMIENTOS_LIN_MO_S</c> foreign key.
		/// </summary>
		/// <param name="linea_movimiento_siguiente_id">The <c>LINEA_MOVIMIENTO_SIGUIENTE_ID</c> column value.</param>
		/// <param name="linea_movimiento_siguiente_idNull">true if the method ignores the linea_movimiento_siguiente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLINEA_MOVIMIENTO_SIGUIENTE_IDCommand(decimal linea_movimiento_siguiente_id, bool linea_movimiento_siguiente_idNull)
		{
			string whereSql = "";
			if(linea_movimiento_siguiente_idNull)
				whereSql += "LINEA_MOVIMIENTO_SIGUIENTE_ID IS NULL";
			else
				whereSql += "LINEA_MOVIMIENTO_SIGUIENTE_ID=" + _db.CreateSqlParameterName("LINEA_MOVIMIENTO_SIGUIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!linea_movimiento_siguiente_idNull)
				AddParameter(cmd, "LINEA_MOVIMIENTO_SIGUIENTE_ID", linea_movimiento_siguiente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_LINEAS_MOVIMIENTOS_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id)
		{
			return CreateDeleteByLINEA_IDCommand(linea_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LINEAS_MOVIMIENTOS_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLINEA_IDCommand(decimal linea_id)
		{
			string whereSql = "";
			whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return DeleteByTIPO_CONTENEDOR_ID(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>LINEAS_MOVIMIENTOS</c> table using the 
		/// <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return CreateDeleteByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LINEAS_MOVIMIENTOS_TIPO_CON</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			string whereSql = "";
			if(tipo_contenedor_idNull)
				whereSql += "TIPO_CONTENEDOR_ID IS NULL";
			else
				whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_contenedor_idNull)
				AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>LINEAS_MOVIMIENTOS</c> records that match the specified criteria.
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
		/// to delete <c>LINEAS_MOVIMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.LINEAS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>LINEAS_MOVIMIENTOS</c> table.
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
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		protected LINEAS_MOVIMIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		protected LINEAS_MOVIMIENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="LINEAS_MOVIMIENTOSRow"/> objects.</returns>
		protected virtual LINEAS_MOVIMIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int edi_pathColumnIndex = reader.GetOrdinal("EDI_PATH");
			int edi_estructuraColumnIndex = reader.GetOrdinal("EDI_ESTRUCTURA");
			int movimientoColumnIndex = reader.GetOrdinal("MOVIMIENTO");
			int edi_nombreColumnIndex = reader.GetOrdinal("EDI_NOMBRE");
			int tipo_contenedor_idColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_ID");
			int linea_movimiento_siguiente_idColumnIndex = reader.GetOrdinal("LINEA_MOVIMIENTO_SIGUIENTE_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					LINEAS_MOVIMIENTOSRow record = new LINEAS_MOVIMIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(edi_pathColumnIndex))
						record.EDI_PATH = Convert.ToString(reader.GetValue(edi_pathColumnIndex));
					if(!reader.IsDBNull(edi_estructuraColumnIndex))
						record.EDI_ESTRUCTURA = Convert.ToString(reader.GetValue(edi_estructuraColumnIndex));
					if(!reader.IsDBNull(movimientoColumnIndex))
						record.MOVIMIENTO = Convert.ToString(reader.GetValue(movimientoColumnIndex));
					if(!reader.IsDBNull(edi_nombreColumnIndex))
						record.EDI_NOMBRE = Convert.ToString(reader.GetValue(edi_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_contenedor_idColumnIndex))
						record.TIPO_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(linea_movimiento_siguiente_idColumnIndex))
						record.LINEA_MOVIMIENTO_SIGUIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_movimiento_siguiente_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LINEAS_MOVIMIENTOSRow[])(recordList.ToArray(typeof(LINEAS_MOVIMIENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="LINEAS_MOVIMIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="LINEAS_MOVIMIENTOSRow"/> object.</returns>
		protected virtual LINEAS_MOVIMIENTOSRow MapRow(DataRow row)
		{
			LINEAS_MOVIMIENTOSRow mappedObject = new LINEAS_MOVIMIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "EDI_PATH"
			dataColumn = dataTable.Columns["EDI_PATH"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_PATH = (string)row[dataColumn];
			// Column "EDI_ESTRUCTURA"
			dataColumn = dataTable.Columns["EDI_ESTRUCTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_ESTRUCTURA = (string)row[dataColumn];
			// Column "MOVIMIENTO"
			dataColumn = dataTable.Columns["MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO = (string)row[dataColumn];
			// Column "EDI_NOMBRE"
			dataColumn = dataTable.Columns["EDI_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "LINEA_MOVIMIENTO_SIGUIENTE_ID"
			dataColumn = dataTable.Columns["LINEA_MOVIMIENTO_SIGUIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_MOVIMIENTO_SIGUIENTE_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>LINEAS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "LINEAS_MOVIMIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EDI_PATH", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("EDI_ESTRUCTURA", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("EDI_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LINEA_MOVIMIENTO_SIGUIENTE_ID", typeof(decimal));
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

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EDI_PATH":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EDI_ESTRUCTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EDI_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LINEA_MOVIMIENTO_SIGUIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of LINEAS_MOVIMIENTOSCollection_Base class
}  // End of namespace
