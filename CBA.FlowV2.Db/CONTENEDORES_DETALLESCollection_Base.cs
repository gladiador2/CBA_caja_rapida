// <fileinfo name="CONTENEDORES_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTENEDORES_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CONOCIMIENTO_DETALLE_IDColumnName = "CONOCIMIENTO_DETALLE_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string CONOCIMIENTOS_CONTENIDOS_IDColumnName = "CONOCIMIENTOS_CONTENIDOS_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTENEDORES_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual CONTENEDORES_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTENEDORES_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTENEDORES_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTENEDORES_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		public CONTENEDORES_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual CONTENEDORES_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTENEDORES_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONTENEDORES_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONTENEDORES_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONTENEDORES_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		public CONTENEDORES_DETALLESRow[] GetByCONOCIMIENTOS_CONTENIDOS_ID(decimal conocimientos_contenidos_id)
		{
			return GetByCONOCIMIENTOS_CONTENIDOS_ID(conocimientos_contenidos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <param name="conocimientos_contenidos_idNull">true if the method ignores the conocimientos_contenidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual CONTENEDORES_DETALLESRow[] GetByCONOCIMIENTOS_CONTENIDOS_ID(decimal conocimientos_contenidos_id, bool conocimientos_contenidos_idNull)
		{
			return MapRecords(CreateGetByCONOCIMIENTOS_CONTENIDOS_IDCommand(conocimientos_contenidos_id, conocimientos_contenidos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONOCIMIENTOS_CONTENIDOS_IDAsDataTable(decimal conocimientos_contenidos_id)
		{
			return GetByCONOCIMIENTOS_CONTENIDOS_IDAsDataTable(conocimientos_contenidos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <param name="conocimientos_contenidos_idNull">true if the method ignores the conocimientos_contenidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONOCIMIENTOS_CONTENIDOS_IDAsDataTable(decimal conocimientos_contenidos_id, bool conocimientos_contenidos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONOCIMIENTOS_CONTENIDOS_IDCommand(conocimientos_contenidos_id, conocimientos_contenidos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <param name="conocimientos_contenidos_idNull">true if the method ignores the conocimientos_contenidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONOCIMIENTOS_CONTENIDOS_IDCommand(decimal conocimientos_contenidos_id, bool conocimientos_contenidos_idNull)
		{
			string whereSql = "";
			if(conocimientos_contenidos_idNull)
				whereSql += "CONOCIMIENTOS_CONTENIDOS_ID IS NULL";
			else
				whereSql += "CONOCIMIENTOS_CONTENIDOS_ID=" + _db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!conocimientos_contenidos_idNull)
				AddParameter(cmd, "CONOCIMIENTOS_CONTENIDOS_ID", conocimientos_contenidos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		public CONTENEDORES_DETALLESRow[] GetByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id)
		{
			return GetByCONOCIMIENTO_DETALLE_ID(conocimiento_detalle_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_DETALLESRow"/> objects 
		/// by the <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		public virtual CONTENEDORES_DETALLESRow[] GetByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			return MapRecords(CreateGetByCONOCIMIENTO_DETALLE_IDCommand(conocimiento_detalle_id, conocimiento_detalle_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONOCIMIENTO_DETALLE_IDAsDataTable(decimal conocimiento_detalle_id)
		{
			return GetByCONOCIMIENTO_DETALLE_IDAsDataTable(conocimiento_detalle_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONOCIMIENTO_DETALLE_IDAsDataTable(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONOCIMIENTO_DETALLE_IDCommand(conocimiento_detalle_id, conocimiento_detalle_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONOCIMIENTO_DETALLE_IDCommand(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			string whereSql = "";
			if(conocimiento_detalle_idNull)
				whereSql += "CONOCIMIENTO_DETALLE_ID IS NULL";
			else
				whereSql += "CONOCIMIENTO_DETALLE_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!conocimiento_detalle_idNull)
				AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID", conocimiento_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(CONTENEDORES_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONTENEDORES_DETALLES (" +
				"ID, " +
				"CONOCIMIENTO_DETALLE_ID, " +
				"CANTIDAD, " +
				"CONOCIMIENTOS_CONTENIDOS_ID, " +
				"OBSERVACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDOS_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID",
				value.IsCONOCIMIENTO_DETALLE_IDNull ? DBNull.Value : (object)value.CONOCIMIENTO_DETALLE_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "CONOCIMIENTOS_CONTENIDOS_ID",
				value.IsCONOCIMIENTOS_CONTENIDOS_IDNull ? DBNull.Value : (object)value.CONOCIMIENTOS_CONTENIDOS_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONTENEDORES_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONTENEDORES_DETALLES SET " +
				"CONOCIMIENTO_DETALLE_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"CONOCIMIENTOS_CONTENIDOS_ID=" + _db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDOS_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID",
				value.IsCONOCIMIENTO_DETALLE_IDNull ? DBNull.Value : (object)value.CONOCIMIENTO_DETALLE_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "CONOCIMIENTOS_CONTENIDOS_ID",
				value.IsCONOCIMIENTOS_CONTENIDOS_IDNull ? DBNull.Value : (object)value.CONOCIMIENTOS_CONTENIDOS_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONTENEDORES_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONTENEDORES_DETALLES</c> table using
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
		/// Deletes records from the <c>CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTOS_CONTENIDOS_ID(decimal conocimientos_contenidos_id)
		{
			return DeleteByCONOCIMIENTOS_CONTENIDOS_ID(conocimientos_contenidos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <param name="conocimientos_contenidos_idNull">true if the method ignores the conocimientos_contenidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTOS_CONTENIDOS_ID(decimal conocimientos_contenidos_id, bool conocimientos_contenidos_idNull)
		{
			return CreateDeleteByCONOCIMIENTOS_CONTENIDOS_IDCommand(conocimientos_contenidos_id, conocimientos_contenidos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONT_DET_CONOC_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimientos_contenidos_id">The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</param>
		/// <param name="conocimientos_contenidos_idNull">true if the method ignores the conocimientos_contenidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONOCIMIENTOS_CONTENIDOS_IDCommand(decimal conocimientos_contenidos_id, bool conocimientos_contenidos_idNull)
		{
			string whereSql = "";
			if(conocimientos_contenidos_idNull)
				whereSql += "CONOCIMIENTOS_CONTENIDOS_ID IS NULL";
			else
				whereSql += "CONOCIMIENTOS_CONTENIDOS_ID=" + _db.CreateSqlParameterName("CONOCIMIENTOS_CONTENIDOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!conocimientos_contenidos_idNull)
				AddParameter(cmd, "CONOCIMIENTOS_CONTENIDOS_ID", conocimientos_contenidos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id)
		{
			return DeleteByCONOCIMIENTO_DETALLE_ID(conocimiento_detalle_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_DETALLES</c> table using the 
		/// <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONOCIMIENTO_DETALLE_ID(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			return CreateDeleteByCONOCIMIENTO_DETALLE_IDCommand(conocimiento_detalle_id, conocimiento_detalle_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONT_DET_CONOC_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="conocimiento_detalle_id">The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</param>
		/// <param name="conocimiento_detalle_idNull">true if the method ignores the conocimiento_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONOCIMIENTO_DETALLE_IDCommand(decimal conocimiento_detalle_id, bool conocimiento_detalle_idNull)
		{
			string whereSql = "";
			if(conocimiento_detalle_idNull)
				whereSql += "CONOCIMIENTO_DETALLE_ID IS NULL";
			else
				whereSql += "CONOCIMIENTO_DETALLE_ID=" + _db.CreateSqlParameterName("CONOCIMIENTO_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!conocimiento_detalle_idNull)
				AddParameter(cmd, "CONOCIMIENTO_DETALLE_ID", conocimiento_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CONTENEDORES_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>CONTENEDORES_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONTENEDORES_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONTENEDORES_DETALLES</c> table.
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
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		protected CONTENEDORES_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		protected CONTENEDORES_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTENEDORES_DETALLESRow"/> objects.</returns>
		protected virtual CONTENEDORES_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int conocimiento_detalle_idColumnIndex = reader.GetOrdinal("CONOCIMIENTO_DETALLE_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int conocimientos_contenidos_idColumnIndex = reader.GetOrdinal("CONOCIMIENTOS_CONTENIDOS_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTENEDORES_DETALLESRow record = new CONTENEDORES_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(conocimiento_detalle_idColumnIndex))
						record.CONOCIMIENTO_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimiento_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(conocimientos_contenidos_idColumnIndex))
						record.CONOCIMIENTOS_CONTENIDOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimientos_contenidos_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTENEDORES_DETALLESRow[])(recordList.ToArray(typeof(CONTENEDORES_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTENEDORES_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTENEDORES_DETALLESRow"/> object.</returns>
		protected virtual CONTENEDORES_DETALLESRow MapRow(DataRow row)
		{
			CONTENEDORES_DETALLESRow mappedObject = new CONTENEDORES_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CONOCIMIENTO_DETALLE_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTO_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO_DETALLE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "CONOCIMIENTOS_CONTENIDOS_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTOS_CONTENIDOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTOS_CONTENIDOS_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTENEDORES_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTENEDORES_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO_DETALLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONOCIMIENTOS_CONTENIDOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
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

				case "CONOCIMIENTO_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONOCIMIENTOS_CONTENIDOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTENEDORES_DETALLESCollection_Base class
}  // End of namespace
