// <fileinfo name="EDICollection_Base.cs">
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
	/// The base class for <see cref="EDICollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EDICollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EDICollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_OPERACIONColumnName = "FECHA_OPERACION";
		public const string CAMPOSColumnName = "CAMPOS";
		public const string ESTRUCTURAColumnName = "ESTRUCTURA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string RESULTADO_EXPORTACIONColumnName = "RESULTADO_EXPORTACION";
		public const string PATHColumnName = "PATH";
		public const string CONTENEDOR_MOVIMIENTO_IDColumnName = "CONTENEDOR_MOVIMIENTO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EDICollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EDICollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EDI</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public virtual EDIRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EDI</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EDI</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EDIRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EDIRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EDIRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EDIRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EDIRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public EDIRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EDIRow"/> objects that 
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
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public virtual EDIRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EDI";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EDIRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EDIRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EDIRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EDIRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EDIRow"/> objects 
		/// by the <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public EDIRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EDIRow"/> objects 
		/// by the <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public virtual EDIRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTENEDOR_IDCommand(decimal contenedor_id, bool contenedor_idNull)
		{
			string whereSql = "";
			if(contenedor_idNull)
				whereSql += "CONTENEDOR_ID IS NULL";
			else
				whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!contenedor_idNull)
				AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EDIRow"/> objects 
		/// by the <c>FK_EDI_CONTENEDOR_MOV</c> foreign key.
		/// </summary>
		/// <param name="contenedor_movimiento_id">The <c>CONTENEDOR_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public virtual EDIRow[] GetByCONTENEDOR_MOVIMIENTO_ID(decimal contenedor_movimiento_id)
		{
			return MapRecords(CreateGetByCONTENEDOR_MOVIMIENTO_IDCommand(contenedor_movimiento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EDI_CONTENEDOR_MOV</c> foreign key.
		/// </summary>
		/// <param name="contenedor_movimiento_id">The <c>CONTENEDOR_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTENEDOR_MOVIMIENTO_IDAsDataTable(decimal contenedor_movimiento_id)
		{
			return MapRecordsToDataTable(CreateGetByCONTENEDOR_MOVIMIENTO_IDCommand(contenedor_movimiento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EDI_CONTENEDOR_MOV</c> foreign key.
		/// </summary>
		/// <param name="contenedor_movimiento_id">The <c>CONTENEDOR_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTENEDOR_MOVIMIENTO_IDCommand(decimal contenedor_movimiento_id)
		{
			string whereSql = "";
			whereSql += "CONTENEDOR_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("CONTENEDOR_MOVIMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONTENEDOR_MOVIMIENTO_ID", contenedor_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EDIRow"/> objects 
		/// by the <c>FK_EDI_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public virtual EDIRow[] GetByLINEA_ID(decimal linea_id)
		{
			return MapRecords(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EDI_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLINEA_IDAsDataTable(decimal linea_id)
		{
			return MapRecordsToDataTable(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EDI_LINEA</c> foreign key.
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
		/// Gets an array of <see cref="EDIRow"/> objects 
		/// by the <c>FK_EDI_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		public virtual EDIRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EDI_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EDI_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>EDI</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EDIRow"/> object to be inserted.</param>
		public virtual void Insert(EDIRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EDI (" +
				"ID, " +
				"LINEA_ID, " +
				"CONTENEDOR_ID, " +
				"FECHA_CREACION, " +
				"FECHA_OPERACION, " +
				"CAMPOS, " +
				"ESTRUCTURA, " +
				"USUARIO_ID, " +
				"ESTADO, " +
				"RESULTADO_EXPORTACION, " +
				"PATH, " +
				"CONTENEDOR_MOVIMIENTO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("LINEA_ID") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("FECHA_OPERACION") + ", " +
				_db.CreateSqlParameterName("CAMPOS") + ", " +
				_db.CreateSqlParameterName("ESTRUCTURA") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("RESULTADO_EXPORTACION") + ", " +
				_db.CreateSqlParameterName("PATH") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_MOVIMIENTO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_OPERACION",
				value.IsFECHA_OPERACIONNull ? DBNull.Value : (object)value.FECHA_OPERACION);
			AddParameter(cmd, "CAMPOS", value.CAMPOS);
			AddParameter(cmd, "ESTRUCTURA", value.ESTRUCTURA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RESULTADO_EXPORTACION", value.RESULTADO_EXPORTACION);
			AddParameter(cmd, "PATH", value.PATH);
			AddParameter(cmd, "CONTENEDOR_MOVIMIENTO_ID", value.CONTENEDOR_MOVIMIENTO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EDI</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EDIRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EDIRow value)
		{
			
			string sqlStr = "UPDATE TRC.EDI SET " +
				"LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"FECHA_OPERACION=" + _db.CreateSqlParameterName("FECHA_OPERACION") + ", " +
				"CAMPOS=" + _db.CreateSqlParameterName("CAMPOS") + ", " +
				"ESTRUCTURA=" + _db.CreateSqlParameterName("ESTRUCTURA") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"RESULTADO_EXPORTACION=" + _db.CreateSqlParameterName("RESULTADO_EXPORTACION") + ", " +
				"PATH=" + _db.CreateSqlParameterName("PATH") + ", " +
				"CONTENEDOR_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("CONTENEDOR_MOVIMIENTO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_OPERACION",
				value.IsFECHA_OPERACIONNull ? DBNull.Value : (object)value.FECHA_OPERACION);
			AddParameter(cmd, "CAMPOS", value.CAMPOS);
			AddParameter(cmd, "ESTRUCTURA", value.ESTRUCTURA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RESULTADO_EXPORTACION", value.RESULTADO_EXPORTACION);
			AddParameter(cmd, "PATH", value.PATH);
			AddParameter(cmd, "CONTENEDOR_MOVIMIENTO_ID", value.CONTENEDOR_MOVIMIENTO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EDI</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EDI</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EDI</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EDIRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EDIRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EDI</c> table using
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
		/// Deletes records from the <c>EDI</c> table using the 
		/// <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EDI</c> table using the 
		/// <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return CreateDeleteByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EDI_CONTENEDOR</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTENEDOR_IDCommand(decimal contenedor_id, bool contenedor_idNull)
		{
			string whereSql = "";
			if(contenedor_idNull)
				whereSql += "CONTENEDOR_ID IS NULL";
			else
				whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!contenedor_idNull)
				AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EDI</c> table using the 
		/// <c>FK_EDI_CONTENEDOR_MOV</c> foreign key.
		/// </summary>
		/// <param name="contenedor_movimiento_id">The <c>CONTENEDOR_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_MOVIMIENTO_ID(decimal contenedor_movimiento_id)
		{
			return CreateDeleteByCONTENEDOR_MOVIMIENTO_IDCommand(contenedor_movimiento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EDI_CONTENEDOR_MOV</c> foreign key.
		/// </summary>
		/// <param name="contenedor_movimiento_id">The <c>CONTENEDOR_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTENEDOR_MOVIMIENTO_IDCommand(decimal contenedor_movimiento_id)
		{
			string whereSql = "";
			whereSql += "CONTENEDOR_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("CONTENEDOR_MOVIMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONTENEDOR_MOVIMIENTO_ID", contenedor_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EDI</c> table using the 
		/// <c>FK_EDI_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id)
		{
			return CreateDeleteByLINEA_IDCommand(linea_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EDI_LINEA</c> foreign key.
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
		/// Deletes records from the <c>EDI</c> table using the 
		/// <c>FK_EDI_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EDI_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>EDI</c> records that match the specified criteria.
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
		/// to delete <c>EDI</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EDI";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EDI</c> table.
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
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		protected EDIRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		protected EDIRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EDIRow"/> objects.</returns>
		protected virtual EDIRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_operacionColumnIndex = reader.GetOrdinal("FECHA_OPERACION");
			int camposColumnIndex = reader.GetOrdinal("CAMPOS");
			int estructuraColumnIndex = reader.GetOrdinal("ESTRUCTURA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int resultado_exportacionColumnIndex = reader.GetOrdinal("RESULTADO_EXPORTACION");
			int pathColumnIndex = reader.GetOrdinal("PATH");
			int contenedor_movimiento_idColumnIndex = reader.GetOrdinal("CONTENEDOR_MOVIMIENTO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EDIRow record = new EDIRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(fecha_operacionColumnIndex))
						record.FECHA_OPERACION = Convert.ToDateTime(reader.GetValue(fecha_operacionColumnIndex));
					if(!reader.IsDBNull(camposColumnIndex))
						record.CAMPOS = Convert.ToString(reader.GetValue(camposColumnIndex));
					if(!reader.IsDBNull(estructuraColumnIndex))
						record.ESTRUCTURA = Convert.ToString(reader.GetValue(estructuraColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(resultado_exportacionColumnIndex))
						record.RESULTADO_EXPORTACION = Convert.ToString(reader.GetValue(resultado_exportacionColumnIndex));
					if(!reader.IsDBNull(pathColumnIndex))
						record.PATH = Convert.ToString(reader.GetValue(pathColumnIndex));
					record.CONTENEDOR_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_movimiento_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EDIRow[])(recordList.ToArray(typeof(EDIRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EDIRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EDIRow"/> object.</returns>
		protected virtual EDIRow MapRow(DataRow row)
		{
			EDIRow mappedObject = new EDIRow();
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
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_OPERACION"
			dataColumn = dataTable.Columns["FECHA_OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_OPERACION = (System.DateTime)row[dataColumn];
			// Column "CAMPOS"
			dataColumn = dataTable.Columns["CAMPOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAMPOS = (string)row[dataColumn];
			// Column "ESTRUCTURA"
			dataColumn = dataTable.Columns["ESTRUCTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTRUCTURA = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "RESULTADO_EXPORTACION"
			dataColumn = dataTable.Columns["RESULTADO_EXPORTACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESULTADO_EXPORTACION = (string)row[dataColumn];
			// Column "PATH"
			dataColumn = dataTable.Columns["PATH"];
			if(!row.IsNull(dataColumn))
				mappedObject.PATH = (string)row[dataColumn];
			// Column "CONTENEDOR_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_MOVIMIENTO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EDI</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EDI";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_OPERACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CAMPOS", typeof(string));
			dataColumn.MaxLength = 600;
			dataColumn = dataTable.Columns.Add("ESTRUCTURA", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RESULTADO_EXPORTACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("PATH", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_MOVIMIENTO_ID", typeof(decimal));
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

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CAMPOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTRUCTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RESULTADO_EXPORTACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PATH":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EDICollection_Base class
}  // End of namespace
