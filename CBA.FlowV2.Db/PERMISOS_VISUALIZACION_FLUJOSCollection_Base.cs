// <fileinfo name="PERMISOS_VISUALIZACION_FLUJOSCollection_Base.cs">
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
	/// The base class for <see cref="PERMISOS_VISUALIZACION_FLUJOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PERMISOS_VISUALIZACION_FLUJOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERMISOS_VISUALIZACION_FLUJOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string ESTADO_IDColumnName = "ESTADO_ID";
		public const string TIPO_ESPECIFICOColumnName = "TIPO_ESPECIFICO";
		public const string ROL_IDColumnName = "ROL_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERMISOS_VISUALIZACION_FLUJOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PERMISOS_VISUALIZACION_FLUJOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		public virtual PERMISOS_VISUALIZACION_FLUJOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PERMISOS_VISUALIZACION_FLUJOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PERMISOS_VISUALIZACION_FLUJOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		public PERMISOS_VISUALIZACION_FLUJOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects that 
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
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		public virtual PERMISOS_VISUALIZACION_FLUJOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PERMISOS_VISUALIZACION_FLUJOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PERMISOS_VISUALIZACION_FLUJOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PERMISOS_VISUALIZACION_FLUJOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects 
		/// by the <c>FK_PERMISOS_VISUAL_FLU_EST</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		public virtual PERMISOS_VISUALIZACION_FLUJOSRow[] GetByESTADO_ID(string estado_id)
		{
			return MapRecords(CreateGetByESTADO_IDCommand(estado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERMISOS_VISUAL_FLU_EST</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_IDAsDataTable(string estado_id)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_IDCommand(estado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERMISOS_VISUAL_FLU_EST</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_IDCommand(string estado_id)
		{
			string whereSql = "";
			if(null == estado_id)
				whereSql += "ESTADO_ID IS NULL";
			else
				whereSql += "ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != estado_id)
				AddParameter(cmd, "ESTADO_ID", estado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects 
		/// by the <c>FK_PERMISOS_VISUAL_FLU_FLU</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		public virtual PERMISOS_VISUALIZACION_FLUJOSRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERMISOS_VISUAL_FLU_FLU</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERMISOS_VISUAL_FLU_FLU</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects 
		/// by the <c>FK_PERMISOS_VISUAL_FLU_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		public virtual PERMISOS_VISUALIZACION_FLUJOSRow[] GetByROL_ID(decimal rol_id)
		{
			return MapRecords(CreateGetByROL_IDCommand(rol_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERMISOS_VISUAL_FLU_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_IDAsDataTable(decimal rol_id)
		{
			return MapRecordsToDataTable(CreateGetByROL_IDCommand(rol_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERMISOS_VISUAL_FLU_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_IDCommand(decimal rol_id)
		{
			string whereSql = "";
			whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> object to be inserted.</param>
		public virtual void Insert(PERMISOS_VISUALIZACION_FLUJOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PERMISOS_VISUALIZACION_FLUJOS (" +
				"ID, " +
				"FLUJO_ID, " +
				"ESTADO_ID, " +
				"TIPO_ESPECIFICO, " +
				"ROL_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_ESPECIFICO") + ", " +
				_db.CreateSqlParameterName("ROL_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "ESTADO_ID", value.ESTADO_ID);
			AddParameter(cmd, "TIPO_ESPECIFICO", value.TIPO_ESPECIFICO);
			AddParameter(cmd, "ROL_ID", value.ROL_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PERMISOS_VISUALIZACION_FLUJOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.PERMISOS_VISUALIZACION_FLUJOS SET " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + ", " +
				"ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID") + ", " +
				"TIPO_ESPECIFICO=" + _db.CreateSqlParameterName("TIPO_ESPECIFICO") + ", " +
				"ROL_ID=" + _db.CreateSqlParameterName("ROL_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "ESTADO_ID", value.ESTADO_ID);
			AddParameter(cmd, "TIPO_ESPECIFICO", value.TIPO_ESPECIFICO);
			AddParameter(cmd, "ROL_ID", value.ROL_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PERMISOS_VISUALIZACION_FLUJOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table using
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
		/// Deletes records from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table using the 
		/// <c>FK_PERMISOS_VISUAL_FLU_EST</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_ID(string estado_id)
		{
			return CreateDeleteByESTADO_IDCommand(estado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERMISOS_VISUAL_FLU_EST</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_IDCommand(string estado_id)
		{
			string whereSql = "";
			if(null == estado_id)
				whereSql += "ESTADO_ID IS NULL";
			else
				whereSql += "ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != estado_id)
				AddParameter(cmd, "ESTADO_ID", estado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table using the 
		/// <c>FK_PERMISOS_VISUAL_FLU_FLU</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERMISOS_VISUAL_FLU_FLU</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table using the 
		/// <c>FK_PERMISOS_VISUAL_FLU_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id)
		{
			return CreateDeleteByROL_IDCommand(rol_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERMISOS_VISUAL_FLU_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_IDCommand(decimal rol_id)
		{
			string whereSql = "";
			whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PERMISOS_VISUALIZACION_FLUJOS</c> records that match the specified criteria.
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
		/// to delete <c>PERMISOS_VISUALIZACION_FLUJOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PERMISOS_VISUALIZACION_FLUJOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
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
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		protected PERMISOS_VISUALIZACION_FLUJOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		protected PERMISOS_VISUALIZACION_FLUJOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> objects.</returns>
		protected virtual PERMISOS_VISUALIZACION_FLUJOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int estado_idColumnIndex = reader.GetOrdinal("ESTADO_ID");
			int tipo_especificoColumnIndex = reader.GetOrdinal("TIPO_ESPECIFICO");
			int rol_idColumnIndex = reader.GetOrdinal("ROL_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PERMISOS_VISUALIZACION_FLUJOSRow record = new PERMISOS_VISUALIZACION_FLUJOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_idColumnIndex))
						record.ESTADO_ID = Convert.ToString(reader.GetValue(estado_idColumnIndex));
					if(!reader.IsDBNull(tipo_especificoColumnIndex))
						record.TIPO_ESPECIFICO = Convert.ToString(reader.GetValue(tipo_especificoColumnIndex));
					record.ROL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rol_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PERMISOS_VISUALIZACION_FLUJOSRow[])(recordList.ToArray(typeof(PERMISOS_VISUALIZACION_FLUJOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PERMISOS_VISUALIZACION_FLUJOSRow"/> object.</returns>
		protected virtual PERMISOS_VISUALIZACION_FLUJOSRow MapRow(DataRow row)
		{
			PERMISOS_VISUALIZACION_FLUJOSRow mappedObject = new PERMISOS_VISUALIZACION_FLUJOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_ID"
			dataColumn = dataTable.Columns["ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ID = (string)row[dataColumn];
			// Column "TIPO_ESPECIFICO"
			dataColumn = dataTable.Columns["TIPO_ESPECIFICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ESPECIFICO = (string)row[dataColumn];
			// Column "ROL_ID"
			dataColumn = dataTable.Columns["ROL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PERMISOS_VISUALIZACION_FLUJOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PERMISOS_VISUALIZACION_FLUJOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TIPO_ESPECIFICO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ROL_ID", typeof(decimal));
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

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_ESPECIFICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ROL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PERMISOS_VISUALIZACION_FLUJOSCollection_Base class
}  // End of namespace
