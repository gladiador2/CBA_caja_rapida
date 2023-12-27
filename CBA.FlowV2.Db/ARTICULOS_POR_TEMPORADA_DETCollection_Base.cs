// <fileinfo name="ARTICULOS_POR_TEMPORADA_DETCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_POR_TEMPORADA_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_POR_TEMPORADA_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_POR_TEMPORADA_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULOS_POR_TEMPORADA_IDColumnName = "ARTICULOS_POR_TEMPORADA_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string CANTIDAD_OBJETIVOColumnName = "CANTIDAD_OBJETIVO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_POR_TEMPORADA_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_POR_TEMPORADA_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		public virtual ARTICULOS_POR_TEMPORADA_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_POR_TEMPORADA_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_POR_TEMPORADA_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		public ARTICULOS_POR_TEMPORADA_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		public virtual ARTICULOS_POR_TEMPORADA_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_POR_TEMPORADA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_POR_TEMPORADA_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_POR_TEMPORADA_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects 
		/// by the <c>FK_ART_POR_TEMP_DET_ART_POR_TE</c> foreign key.
		/// </summary>
		/// <param name="articulos_por_temporada_id">The <c>ARTICULOS_POR_TEMPORADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		public virtual ARTICULOS_POR_TEMPORADA_DETRow[] GetByARTICULOS_POR_TEMPORADA_ID(decimal articulos_por_temporada_id)
		{
			return MapRecords(CreateGetByARTICULOS_POR_TEMPORADA_IDCommand(articulos_por_temporada_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_POR_TEMP_DET_ART_POR_TE</c> foreign key.
		/// </summary>
		/// <param name="articulos_por_temporada_id">The <c>ARTICULOS_POR_TEMPORADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULOS_POR_TEMPORADA_IDAsDataTable(decimal articulos_por_temporada_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULOS_POR_TEMPORADA_IDCommand(articulos_por_temporada_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_POR_TEMP_DET_ART_POR_TE</c> foreign key.
		/// </summary>
		/// <param name="articulos_por_temporada_id">The <c>ARTICULOS_POR_TEMPORADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULOS_POR_TEMPORADA_IDCommand(decimal articulos_por_temporada_id)
		{
			string whereSql = "";
			whereSql += "ARTICULOS_POR_TEMPORADA_ID=" + _db.CreateSqlParameterName("ARTICULOS_POR_TEMPORADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULOS_POR_TEMPORADA_ID", articulos_por_temporada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects 
		/// by the <c>FK_ART_POR_TEMP_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		public virtual ARTICULOS_POR_TEMPORADA_DETRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_POR_TEMP_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_POR_TEMP_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_POR_TEMPORADA_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_POR_TEMPORADA_DET (" +
				"ID, " +
				"ARTICULOS_POR_TEMPORADA_ID, " +
				"ARTICULO_ID, " +
				"CANTIDAD_OBJETIVO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULOS_POR_TEMPORADA_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_OBJETIVO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULOS_POR_TEMPORADA_ID", value.ARTICULOS_POR_TEMPORADA_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "CANTIDAD_OBJETIVO", value.CANTIDAD_OBJETIVO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_POR_TEMPORADA_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_POR_TEMPORADA_DET SET " +
				"ARTICULOS_POR_TEMPORADA_ID=" + _db.CreateSqlParameterName("ARTICULOS_POR_TEMPORADA_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"CANTIDAD_OBJETIVO=" + _db.CreateSqlParameterName("CANTIDAD_OBJETIVO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULOS_POR_TEMPORADA_ID", value.ARTICULOS_POR_TEMPORADA_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "CANTIDAD_OBJETIVO", value.CANTIDAD_OBJETIVO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_POR_TEMPORADA_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_POR_TEMPORADA_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_POR_TEMPORADA_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table using
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
		/// Deletes records from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table using the 
		/// <c>FK_ART_POR_TEMP_DET_ART_POR_TE</c> foreign key.
		/// </summary>
		/// <param name="articulos_por_temporada_id">The <c>ARTICULOS_POR_TEMPORADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULOS_POR_TEMPORADA_ID(decimal articulos_por_temporada_id)
		{
			return CreateDeleteByARTICULOS_POR_TEMPORADA_IDCommand(articulos_por_temporada_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_POR_TEMP_DET_ART_POR_TE</c> foreign key.
		/// </summary>
		/// <param name="articulos_por_temporada_id">The <c>ARTICULOS_POR_TEMPORADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULOS_POR_TEMPORADA_IDCommand(decimal articulos_por_temporada_id)
		{
			string whereSql = "";
			whereSql += "ARTICULOS_POR_TEMPORADA_ID=" + _db.CreateSqlParameterName("ARTICULOS_POR_TEMPORADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULOS_POR_TEMPORADA_ID", articulos_por_temporada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table using the 
		/// <c>FK_ART_POR_TEMP_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_POR_TEMP_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_POR_TEMPORADA_DET</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_POR_TEMPORADA_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_POR_TEMPORADA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		protected ARTICULOS_POR_TEMPORADA_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		protected ARTICULOS_POR_TEMPORADA_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> objects.</returns>
		protected virtual ARTICULOS_POR_TEMPORADA_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulos_por_temporada_idColumnIndex = reader.GetOrdinal("ARTICULOS_POR_TEMPORADA_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int cantidad_objetivoColumnIndex = reader.GetOrdinal("CANTIDAD_OBJETIVO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_POR_TEMPORADA_DETRow record = new ARTICULOS_POR_TEMPORADA_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULOS_POR_TEMPORADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_por_temporada_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.CANTIDAD_OBJETIVO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_objetivoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_POR_TEMPORADA_DETRow[])(recordList.ToArray(typeof(ARTICULOS_POR_TEMPORADA_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_POR_TEMPORADA_DETRow"/> object.</returns>
		protected virtual ARTICULOS_POR_TEMPORADA_DETRow MapRow(DataRow row)
		{
			ARTICULOS_POR_TEMPORADA_DETRow mappedObject = new ARTICULOS_POR_TEMPORADA_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULOS_POR_TEMPORADA_ID"
			dataColumn = dataTable.Columns["ARTICULOS_POR_TEMPORADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_POR_TEMPORADA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_OBJETIVO"
			dataColumn = dataTable.Columns["CANTIDAD_OBJETIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_OBJETIVO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_POR_TEMPORADA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_POR_TEMPORADA_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULOS_POR_TEMPORADA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_OBJETIVO", typeof(decimal));
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

				case "ARTICULOS_POR_TEMPORADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_OBJETIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_POR_TEMPORADA_DETCollection_Base class
}  // End of namespace
