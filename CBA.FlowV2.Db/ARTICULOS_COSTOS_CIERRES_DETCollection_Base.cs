// <fileinfo name="ARTICULOS_COSTOS_CIERRES_DETCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COSTOS_CIERRES_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_COSTOS_CIERRES_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COSTOS_CIERRES_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULO_COSTO_CIERRE_IDColumnName = "ARTICULO_COSTO_CIERRE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string CANTIDAD_ANTERIORColumnName = "CANTIDAD_ANTERIOR";
		public const string CANTIDAD_VARIACION_POSITIVAColumnName = "CANTIDAD_VARIACION_POSITIVA";
		public const string COSTO_ANTERIORColumnName = "COSTO_ANTERIOR";
		public const string COSTO_ACTUALColumnName = "COSTO_ACTUAL";
		public const string ESTADOColumnName = "ESTADO";
		public const string CANTIDAD_VARIACION_NEGATIVAColumnName = "CANTIDAD_VARIACION_NEGATIVA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COSTOS_CIERRES_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_COSTOS_CIERRES_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRES_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_COSTOS_CIERRES_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_COSTOS_CIERRES_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		public ARTICULOS_COSTOS_CIERRES_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRES_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_COSTOS_CIERRES_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_COSTOS_CIERRES_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_COSTOS_CIERRES_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects 
		/// by the <c>FK_ART_COST_CIERRES_DET_ARTIC</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRES_DETRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIERRES_DET_ARTIC</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_COST_CIERRES_DET_ARTIC</c> foreign key.
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
		/// Gets an array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects 
		/// by the <c>FK_ART_COST_CIERRES_DET_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="articulo_costo_cierre_id">The <c>ARTICULO_COSTO_CIERRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		public virtual ARTICULOS_COSTOS_CIERRES_DETRow[] GetByARTICULO_COSTO_CIERRE_ID(decimal articulo_costo_cierre_id)
		{
			return MapRecords(CreateGetByARTICULO_COSTO_CIERRE_IDCommand(articulo_costo_cierre_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ART_COST_CIERRES_DET_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="articulo_costo_cierre_id">The <c>ARTICULO_COSTO_CIERRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_COSTO_CIERRE_IDAsDataTable(decimal articulo_costo_cierre_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_COSTO_CIERRE_IDCommand(articulo_costo_cierre_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ART_COST_CIERRES_DET_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="articulo_costo_cierre_id">The <c>ARTICULO_COSTO_CIERRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_COSTO_CIERRE_IDCommand(decimal articulo_costo_cierre_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_COSTO_CIERRE_ID=" + _db.CreateSqlParameterName("ARTICULO_COSTO_CIERRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_COSTO_CIERRE_ID", articulo_costo_cierre_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_COSTOS_CIERRES_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_COSTOS_CIERRES_DET (" +
				"ID, " +
				"ARTICULO_COSTO_CIERRE_ID, " +
				"ARTICULO_ID, " +
				"CANTIDAD_ANTERIOR, " +
				"CANTIDAD_VARIACION_POSITIVA, " +
				"COSTO_ANTERIOR, " +
				"COSTO_ACTUAL, " +
				"ESTADO, " +
				"CANTIDAD_VARIACION_NEGATIVA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_COSTO_CIERRE_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ANTERIOR") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_VARIACION_POSITIVA") + ", " +
				_db.CreateSqlParameterName("COSTO_ANTERIOR") + ", " +
				_db.CreateSqlParameterName("COSTO_ACTUAL") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_VARIACION_NEGATIVA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULO_COSTO_CIERRE_ID", value.ARTICULO_COSTO_CIERRE_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "CANTIDAD_ANTERIOR", value.CANTIDAD_ANTERIOR);
			AddParameter(cmd, "CANTIDAD_VARIACION_POSITIVA", value.CANTIDAD_VARIACION_POSITIVA);
			AddParameter(cmd, "COSTO_ANTERIOR", value.COSTO_ANTERIOR);
			AddParameter(cmd, "COSTO_ACTUAL", value.COSTO_ACTUAL);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CANTIDAD_VARIACION_NEGATIVA", value.CANTIDAD_VARIACION_NEGATIVA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_COSTOS_CIERRES_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_COSTOS_CIERRES_DET SET " +
				"ARTICULO_COSTO_CIERRE_ID=" + _db.CreateSqlParameterName("ARTICULO_COSTO_CIERRE_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"CANTIDAD_ANTERIOR=" + _db.CreateSqlParameterName("CANTIDAD_ANTERIOR") + ", " +
				"CANTIDAD_VARIACION_POSITIVA=" + _db.CreateSqlParameterName("CANTIDAD_VARIACION_POSITIVA") + ", " +
				"COSTO_ANTERIOR=" + _db.CreateSqlParameterName("COSTO_ANTERIOR") + ", " +
				"COSTO_ACTUAL=" + _db.CreateSqlParameterName("COSTO_ACTUAL") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CANTIDAD_VARIACION_NEGATIVA=" + _db.CreateSqlParameterName("CANTIDAD_VARIACION_NEGATIVA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULO_COSTO_CIERRE_ID", value.ARTICULO_COSTO_CIERRE_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "CANTIDAD_ANTERIOR", value.CANTIDAD_ANTERIOR);
			AddParameter(cmd, "CANTIDAD_VARIACION_POSITIVA", value.CANTIDAD_VARIACION_POSITIVA);
			AddParameter(cmd, "COSTO_ANTERIOR", value.COSTO_ANTERIOR);
			AddParameter(cmd, "COSTO_ACTUAL", value.COSTO_ACTUAL);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CANTIDAD_VARIACION_NEGATIVA", value.CANTIDAD_VARIACION_NEGATIVA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_COSTOS_CIERRES_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table using
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
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table using the 
		/// <c>FK_ART_COST_CIERRES_DET_ARTIC</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_COST_CIERRES_DET_ARTIC</c> foreign key.
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
		/// Deletes records from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table using the 
		/// <c>FK_ART_COST_CIERRES_DET_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="articulo_costo_cierre_id">The <c>ARTICULO_COSTO_CIERRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_COSTO_CIERRE_ID(decimal articulo_costo_cierre_id)
		{
			return CreateDeleteByARTICULO_COSTO_CIERRE_IDCommand(articulo_costo_cierre_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ART_COST_CIERRES_DET_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="articulo_costo_cierre_id">The <c>ARTICULO_COSTO_CIERRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_COSTO_CIERRE_IDCommand(decimal articulo_costo_cierre_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_COSTO_CIERRE_ID=" + _db.CreateSqlParameterName("ARTICULO_COSTO_CIERRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_COSTO_CIERRE_ID", articulo_costo_cierre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_COSTOS_CIERRES_DET</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_COSTOS_CIERRES_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_COSTOS_CIERRES_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		protected ARTICULOS_COSTOS_CIERRES_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		protected ARTICULOS_COSTOS_CIERRES_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> objects.</returns>
		protected virtual ARTICULOS_COSTOS_CIERRES_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulo_costo_cierre_idColumnIndex = reader.GetOrdinal("ARTICULO_COSTO_CIERRE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int cantidad_anteriorColumnIndex = reader.GetOrdinal("CANTIDAD_ANTERIOR");
			int cantidad_variacion_positivaColumnIndex = reader.GetOrdinal("CANTIDAD_VARIACION_POSITIVA");
			int costo_anteriorColumnIndex = reader.GetOrdinal("COSTO_ANTERIOR");
			int costo_actualColumnIndex = reader.GetOrdinal("COSTO_ACTUAL");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int cantidad_variacion_negativaColumnIndex = reader.GetOrdinal("CANTIDAD_VARIACION_NEGATIVA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_COSTOS_CIERRES_DETRow record = new ARTICULOS_COSTOS_CIERRES_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULO_COSTO_CIERRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_costo_cierre_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.CANTIDAD_ANTERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_anteriorColumnIndex)), 9);
					record.CANTIDAD_VARIACION_POSITIVA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_variacion_positivaColumnIndex)), 9);
					record.COSTO_ANTERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(costo_anteriorColumnIndex)), 9);
					record.COSTO_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_actualColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.CANTIDAD_VARIACION_NEGATIVA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_variacion_negativaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_COSTOS_CIERRES_DETRow[])(recordList.ToArray(typeof(ARTICULOS_COSTOS_CIERRES_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_COSTOS_CIERRES_DETRow"/> object.</returns>
		protected virtual ARTICULOS_COSTOS_CIERRES_DETRow MapRow(DataRow row)
		{
			ARTICULOS_COSTOS_CIERRES_DETRow mappedObject = new ARTICULOS_COSTOS_CIERRES_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULO_COSTO_CIERRE_ID"
			dataColumn = dataTable.Columns["ARTICULO_COSTO_CIERRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_COSTO_CIERRE_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_ANTERIOR"
			dataColumn = dataTable.Columns["CANTIDAD_ANTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ANTERIOR = (decimal)row[dataColumn];
			// Column "CANTIDAD_VARIACION_POSITIVA"
			dataColumn = dataTable.Columns["CANTIDAD_VARIACION_POSITIVA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_VARIACION_POSITIVA = (decimal)row[dataColumn];
			// Column "COSTO_ANTERIOR"
			dataColumn = dataTable.Columns["COSTO_ANTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ANTERIOR = (decimal)row[dataColumn];
			// Column "COSTO_ACTUAL"
			dataColumn = dataTable.Columns["COSTO_ACTUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ACTUAL = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CANTIDAD_VARIACION_NEGATIVA"
			dataColumn = dataTable.Columns["CANTIDAD_VARIACION_NEGATIVA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_VARIACION_NEGATIVA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_COSTOS_CIERRES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_COSTOS_CIERRES_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_COSTO_CIERRE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ANTERIOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_VARIACION_POSITIVA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_ANTERIOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_ACTUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_VARIACION_NEGATIVA", typeof(decimal));
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

				case "ARTICULO_COSTO_CIERRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ANTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_VARIACION_POSITIVA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ANTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ACTUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CANTIDAD_VARIACION_NEGATIVA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_COSTOS_CIERRES_DETCollection_Base class
}  // End of namespace
