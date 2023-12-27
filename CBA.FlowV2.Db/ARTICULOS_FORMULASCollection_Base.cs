// <fileinfo name="ARTICULOS_FORMULASCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_FORMULASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_FORMULASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_FORMULASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULO_FORMULA_IDColumnName = "ARTICULO_FORMULA_ID";
		public const string ARTICULO_DETALLE_IDColumnName = "ARTICULO_DETALLE_ID";
		public const string CANTIDAD_ORIGENColumnName = "CANTIDAD_ORIGEN";
		public const string UNIDAD_ORIGEN_IDColumnName = "UNIDAD_ORIGEN_ID";
		public const string CANTIDAD_DESTINOColumnName = "CANTIDAD_DESTINO";
		public const string UNIDAD_DESTINO_IDColumnName = "UNIDAD_DESTINO_ID";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FORMULASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_FORMULASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_FORMULAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		public virtual ARTICULOS_FORMULASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_FORMULAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_FORMULAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_FORMULASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_FORMULASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_FORMULASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_FORMULASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FORMULASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		public ARTICULOS_FORMULASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FORMULASRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		public virtual ARTICULOS_FORMULASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_FORMULAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_FORMULASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_FORMULASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_FORMULASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_FORMULASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FORMULASRow"/> objects 
		/// by the <c>FK_ARTICULO_FORMULA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_detalle_id">The <c>ARTICULO_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		public virtual ARTICULOS_FORMULASRow[] GetByARTICULO_DETALLE_ID(decimal articulo_detalle_id)
		{
			return MapRecords(CreateGetByARTICULO_DETALLE_IDCommand(articulo_detalle_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULO_FORMULA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_detalle_id">The <c>ARTICULO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_DETALLE_IDAsDataTable(decimal articulo_detalle_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_DETALLE_IDCommand(articulo_detalle_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULO_FORMULA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_detalle_id">The <c>ARTICULO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_DETALLE_IDCommand(decimal articulo_detalle_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_DETALLE_ID=" + _db.CreateSqlParameterName("ARTICULO_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_DETALLE_ID", articulo_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FORMULASRow"/> objects 
		/// by the <c>FK_ARTICULO_FORMULA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_formula_id">The <c>ARTICULO_FORMULA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		public virtual ARTICULOS_FORMULASRow[] GetByARTICULO_FORMULA_ID(decimal articulo_formula_id)
		{
			return MapRecords(CreateGetByARTICULO_FORMULA_IDCommand(articulo_formula_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ARTICULO_FORMULA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_formula_id">The <c>ARTICULO_FORMULA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_FORMULA_IDAsDataTable(decimal articulo_formula_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_FORMULA_IDCommand(articulo_formula_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ARTICULO_FORMULA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_formula_id">The <c>ARTICULO_FORMULA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_FORMULA_IDCommand(decimal articulo_formula_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_FORMULA_ID=" + _db.CreateSqlParameterName("ARTICULO_FORMULA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_FORMULA_ID", articulo_formula_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_FORMULAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FORMULASRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_FORMULASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_FORMULAS (" +
				"ID, " +
				"ARTICULO_FORMULA_ID, " +
				"ARTICULO_DETALLE_ID, " +
				"CANTIDAD_ORIGEN, " +
				"UNIDAD_ORIGEN_ID, " +
				"CANTIDAD_DESTINO, " +
				"UNIDAD_DESTINO_ID, " +
				"FACTOR_CONVERSION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_FORMULA_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DESTINO") + ", " +
				_db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULO_FORMULA_ID", value.ARTICULO_FORMULA_ID);
			AddParameter(cmd, "ARTICULO_DETALLE_ID", value.ARTICULO_DETALLE_ID);
			AddParameter(cmd, "CANTIDAD_ORIGEN", value.CANTIDAD_ORIGEN);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_DESTINO", value.CANTIDAD_DESTINO);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "FACTOR_CONVERSION", value.FACTOR_CONVERSION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_FORMULAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FORMULASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_FORMULASRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_FORMULAS SET " +
				"ARTICULO_FORMULA_ID=" + _db.CreateSqlParameterName("ARTICULO_FORMULA_ID") + ", " +
				"ARTICULO_DETALLE_ID=" + _db.CreateSqlParameterName("ARTICULO_DETALLE_ID") + ", " +
				"CANTIDAD_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_ORIGEN") + ", " +
				"UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				"CANTIDAD_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_DESTINO") + ", " +
				"UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULO_FORMULA_ID", value.ARTICULO_FORMULA_ID);
			AddParameter(cmd, "ARTICULO_DETALLE_ID", value.ARTICULO_DETALLE_ID);
			AddParameter(cmd, "CANTIDAD_ORIGEN", value.CANTIDAD_ORIGEN);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_DESTINO", value.CANTIDAD_DESTINO);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "FACTOR_CONVERSION", value.FACTOR_CONVERSION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_FORMULAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_FORMULAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_FORMULAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FORMULASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_FORMULASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_FORMULAS</c> table using
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
		/// Deletes records from the <c>ARTICULOS_FORMULAS</c> table using the 
		/// <c>FK_ARTICULO_FORMULA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_detalle_id">The <c>ARTICULO_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_DETALLE_ID(decimal articulo_detalle_id)
		{
			return CreateDeleteByARTICULO_DETALLE_IDCommand(articulo_detalle_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULO_FORMULA_DETALLE_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_detalle_id">The <c>ARTICULO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_DETALLE_IDCommand(decimal articulo_detalle_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_DETALLE_ID=" + _db.CreateSqlParameterName("ARTICULO_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_DETALLE_ID", articulo_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FORMULAS</c> table using the 
		/// <c>FK_ARTICULO_FORMULA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_formula_id">The <c>ARTICULO_FORMULA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_FORMULA_ID(decimal articulo_formula_id)
		{
			return CreateDeleteByARTICULO_FORMULA_IDCommand(articulo_formula_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ARTICULO_FORMULA_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_formula_id">The <c>ARTICULO_FORMULA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_FORMULA_IDCommand(decimal articulo_formula_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_FORMULA_ID=" + _db.CreateSqlParameterName("ARTICULO_FORMULA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_FORMULA_ID", articulo_formula_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_FORMULAS</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_FORMULAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_FORMULAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_FORMULAS</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		protected ARTICULOS_FORMULASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		protected ARTICULOS_FORMULASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_FORMULASRow"/> objects.</returns>
		protected virtual ARTICULOS_FORMULASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulo_formula_idColumnIndex = reader.GetOrdinal("ARTICULO_FORMULA_ID");
			int articulo_detalle_idColumnIndex = reader.GetOrdinal("ARTICULO_DETALLE_ID");
			int cantidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_ORIGEN");
			int unidad_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_ID");
			int cantidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_DESTINO");
			int unidad_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_ID");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_FORMULASRow record = new ARTICULOS_FORMULASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULO_FORMULA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_formula_idColumnIndex)), 9);
					record.ARTICULO_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_detalle_idColumnIndex)), 9);
					record.CANTIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_origenColumnIndex)), 9);
					record.UNIDAD_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_origen_idColumnIndex));
					record.CANTIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_destinoColumnIndex)), 9);
					record.UNIDAD_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_destino_idColumnIndex));
					record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_FORMULASRow[])(recordList.ToArray(typeof(ARTICULOS_FORMULASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_FORMULASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_FORMULASRow"/> object.</returns>
		protected virtual ARTICULOS_FORMULASRow MapRow(DataRow row)
		{
			ARTICULOS_FORMULASRow mappedObject = new ARTICULOS_FORMULASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FORMULA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FORMULA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FORMULA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_DETALLE_ID"
			dataColumn = dataTable.Columns["ARTICULO_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DETALLE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "UNIDAD_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_ID = (string)row[dataColumn];
			// Column "CANTIDAD_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DESTINO = (decimal)row[dataColumn];
			// Column "UNIDAD_DESTINO_ID"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO_ID = (string)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_FORMULAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_FORMULAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_FORMULA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_DETALLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
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

				case "ARTICULO_FORMULA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_FORMULASCollection_Base class
}  // End of namespace
