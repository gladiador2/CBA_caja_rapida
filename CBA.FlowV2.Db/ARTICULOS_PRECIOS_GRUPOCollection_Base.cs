// <fileinfo name="ARTICULOS_PRECIOS_GRUPOCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_PRECIOS_GRUPOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_PRECIOS_GRUPOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_PRECIOS_GRUPOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";
		public const string ARTICULOS_GRUPO_IDColumnName = "ARTICULOS_GRUPO_ID";
		public const string PORCENTAJEColumnName = "PORCENTAJE";
		public const string MONTOColumnName = "MONTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PRECIOS_GRUPOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_PRECIOS_GRUPOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		public virtual ARTICULOS_PRECIOS_GRUPORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_PRECIOS_GRUPORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_PRECIOS_GRUPORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		public ARTICULOS_PRECIOS_GRUPORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		public virtual ARTICULOS_PRECIOS_GRUPORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_PRECIOS_GRUPO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_PRECIOS_GRUPORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_PRECIOS_GRUPORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_PRECIOS_GRUPORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects 
		/// by the <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		public ARTICULOS_PRECIOS_GRUPORow[] GetByARTICULOS_GRUPO_ID(decimal articulos_grupo_id)
		{
			return GetByARTICULOS_GRUPO_ID(articulos_grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects 
		/// by the <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <param name="articulos_grupo_idNull">true if the method ignores the articulos_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		public virtual ARTICULOS_PRECIOS_GRUPORow[] GetByARTICULOS_GRUPO_ID(decimal articulos_grupo_id, bool articulos_grupo_idNull)
		{
			return MapRecords(CreateGetByARTICULOS_GRUPO_IDCommand(articulos_grupo_id, articulos_grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULOS_GRUPO_IDAsDataTable(decimal articulos_grupo_id)
		{
			return GetByARTICULOS_GRUPO_IDAsDataTable(articulos_grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <param name="articulos_grupo_idNull">true if the method ignores the articulos_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULOS_GRUPO_IDAsDataTable(decimal articulos_grupo_id, bool articulos_grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULOS_GRUPO_IDCommand(articulos_grupo_id, articulos_grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <param name="articulos_grupo_idNull">true if the method ignores the articulos_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULOS_GRUPO_IDCommand(decimal articulos_grupo_id, bool articulos_grupo_idNull)
		{
			string whereSql = "";
			if(articulos_grupo_idNull)
				whereSql += "ARTICULOS_GRUPO_ID IS NULL";
			else
				whereSql += "ARTICULOS_GRUPO_ID=" + _db.CreateSqlParameterName("ARTICULOS_GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulos_grupo_idNull)
				AddParameter(cmd, "ARTICULOS_GRUPO_ID", articulos_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects 
		/// by the <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		public ARTICULOS_PRECIOS_GRUPORow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects 
		/// by the <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		public virtual ARTICULOS_PRECIOS_GRUPORow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_IDAsDataTable(lista_precio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_PRECIOS_GRUPORow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_PRECIOS_GRUPORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_PRECIOS_GRUPO (" +
				"ID, " +
				"LISTA_PRECIO_ID, " +
				"ARTICULOS_GRUPO_ID, " +
				"PORCENTAJE, " +
				"MONTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULOS_GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("MONTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "ARTICULOS_GRUPO_ID",
				value.IsARTICULOS_GRUPO_IDNull ? DBNull.Value : (object)value.ARTICULOS_GRUPO_ID);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_PRECIOS_GRUPORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_PRECIOS_GRUPORow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_PRECIOS_GRUPO SET " +
				"LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				"ARTICULOS_GRUPO_ID=" + _db.CreateSqlParameterName("ARTICULOS_GRUPO_ID") + ", " +
				"PORCENTAJE=" + _db.CreateSqlParameterName("PORCENTAJE") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "ARTICULOS_GRUPO_ID",
				value.IsARTICULOS_GRUPO_IDNull ? DBNull.Value : (object)value.ARTICULOS_GRUPO_ID);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_PRECIOS_GRUPO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_PRECIOS_GRUPO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_PRECIOS_GRUPORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_PRECIOS_GRUPORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_PRECIOS_GRUPO</c> table using
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
		/// Deletes records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table using the 
		/// <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULOS_GRUPO_ID(decimal articulos_grupo_id)
		{
			return DeleteByARTICULOS_GRUPO_ID(articulos_grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table using the 
		/// <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <param name="articulos_grupo_idNull">true if the method ignores the articulos_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULOS_GRUPO_ID(decimal articulos_grupo_id, bool articulos_grupo_idNull)
		{
			return CreateDeleteByARTICULOS_GRUPO_IDCommand(articulos_grupo_id, articulos_grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LISTA_PREC_GRU_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="articulos_grupo_id">The <c>ARTICULOS_GRUPO_ID</c> column value.</param>
		/// <param name="articulos_grupo_idNull">true if the method ignores the articulos_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULOS_GRUPO_IDCommand(decimal articulos_grupo_id, bool articulos_grupo_idNull)
		{
			string whereSql = "";
			if(articulos_grupo_idNull)
				whereSql += "ARTICULOS_GRUPO_ID IS NULL";
			else
				whereSql += "ARTICULOS_GRUPO_ID=" + _db.CreateSqlParameterName("ARTICULOS_GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulos_grupo_idNull)
				AddParameter(cmd, "ARTICULOS_GRUPO_ID", articulos_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table using the 
		/// <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return DeleteByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table using the 
		/// <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return CreateDeleteByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LISTA_PREC_GRU_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_PRECIOS_GRUPO</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_PRECIOS_GRUPO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_PRECIOS_GRUPO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		protected ARTICULOS_PRECIOS_GRUPORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		protected ARTICULOS_PRECIOS_GRUPORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_PRECIOS_GRUPORow"/> objects.</returns>
		protected virtual ARTICULOS_PRECIOS_GRUPORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");
			int articulos_grupo_idColumnIndex = reader.GetOrdinal("ARTICULOS_GRUPO_ID");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");
			int montoColumnIndex = reader.GetOrdinal("MONTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_PRECIOS_GRUPORow record = new ARTICULOS_PRECIOS_GRUPORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulos_grupo_idColumnIndex))
						record.ARTICULOS_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(porcentajeColumnIndex))
						record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_PRECIOS_GRUPORow[])(recordList.ToArray(typeof(ARTICULOS_PRECIOS_GRUPORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_PRECIOS_GRUPORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_PRECIOS_GRUPORow"/> object.</returns>
		protected virtual ARTICULOS_PRECIOS_GRUPORow MapRow(DataRow row)
		{
			ARTICULOS_PRECIOS_GRUPORow mappedObject = new ARTICULOS_PRECIOS_GRUPORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			// Column "ARTICULOS_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULOS_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_GRUPO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_PRECIOS_GRUPO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULOS_GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
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

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULOS_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_PRECIOS_GRUPOCollection_Base class
}  // End of namespace
