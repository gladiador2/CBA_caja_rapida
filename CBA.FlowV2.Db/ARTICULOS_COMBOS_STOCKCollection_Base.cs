// <fileinfo name="ARTICULOS_COMBOS_STOCKCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_COMBOS_STOCKCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_COMBOS_STOCKCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_COMBOS_STOCKCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string ARTICULO_COMBO_LOTE_IDColumnName = "ARTICULO_COMBO_LOTE_ID";
		public const string OPERACIONColumnName = "OPERACION";
		public const string FECHA_OPERACIONColumnName = "FECHA_OPERACION";
		public const string USUARIO_OPERACION_IDColumnName = "USUARIO_OPERACION_ID";
		public const string CANTIDADColumnName = "CANTIDAD";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_COMBOS_STOCKCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_COMBOS_STOCKCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_COMBOS_STOCK</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		public virtual ARTICULOS_COMBOS_STOCKRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_COMBOS_STOCK</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_COMBOS_STOCK</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_COMBOS_STOCKRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_COMBOS_STOCKRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_COMBOS_STOCKRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		public ARTICULOS_COMBOS_STOCKRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		public virtual ARTICULOS_COMBOS_STOCKRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_COMBOS_STOCK";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_COMBOS_STOCKRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_COMBOS_STOCKRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_COMBOS_STOCKRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_COMBOS_STOCKRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects 
		/// by the <c>FK_STOCK_COMBOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		public virtual ARTICULOS_COMBOS_STOCKRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_COMBOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_COMBOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects 
		/// by the <c>FK_STOCK_COMBOS_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_combo_lote_id">The <c>ARTICULO_COMBO_LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		public virtual ARTICULOS_COMBOS_STOCKRow[] GetByARTICULO_COMBO_LOTE_ID(decimal articulo_combo_lote_id)
		{
			return MapRecords(CreateGetByARTICULO_COMBO_LOTE_IDCommand(articulo_combo_lote_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_COMBOS_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_combo_lote_id">The <c>ARTICULO_COMBO_LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_COMBO_LOTE_IDAsDataTable(decimal articulo_combo_lote_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_COMBO_LOTE_IDCommand(articulo_combo_lote_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_COMBOS_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_combo_lote_id">The <c>ARTICULO_COMBO_LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_COMBO_LOTE_IDCommand(decimal articulo_combo_lote_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_COMBO_LOTE_ID=" + _db.CreateSqlParameterName("ARTICULO_COMBO_LOTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_COMBO_LOTE_ID", articulo_combo_lote_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects 
		/// by the <c>FK_STOCK_COMBOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		public virtual ARTICULOS_COMBOS_STOCKRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_COMBOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_COMBOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects 
		/// by the <c>FK_STOCK_COMBOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		public virtual ARTICULOS_COMBOS_STOCKRow[] GetByUSUARIO_OPERACION_ID(decimal usuario_operacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_OPERACION_IDCommand(usuario_operacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_COMBOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_OPERACION_IDAsDataTable(decimal usuario_operacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_OPERACION_IDCommand(usuario_operacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_COMBOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_OPERACION_IDCommand(decimal usuario_operacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_OPERACION_ID=" + _db.CreateSqlParameterName("USUARIO_OPERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_OPERACION_ID", usuario_operacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_COMBOS_STOCK</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COMBOS_STOCKRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_COMBOS_STOCKRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_COMBOS_STOCK (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"ARTICULO_COMBO_LOTE_ID, " +
				"OPERACION, " +
				"FECHA_OPERACION, " +
				"USUARIO_OPERACION_ID, " +
				"CANTIDAD" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_COMBO_LOTE_ID") + ", " +
				_db.CreateSqlParameterName("OPERACION") + ", " +
				_db.CreateSqlParameterName("FECHA_OPERACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_OPERACION_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "ARTICULO_COMBO_LOTE_ID", value.ARTICULO_COMBO_LOTE_ID);
			AddParameter(cmd, "OPERACION", value.OPERACION);
			AddParameter(cmd, "FECHA_OPERACION", value.FECHA_OPERACION);
			AddParameter(cmd, "USUARIO_OPERACION_ID", value.USUARIO_OPERACION_ID);
			AddParameter(cmd, "CANTIDAD", value.CANTIDAD);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_COMBOS_STOCK</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COMBOS_STOCKRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_COMBOS_STOCKRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_COMBOS_STOCK SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"ARTICULO_COMBO_LOTE_ID=" + _db.CreateSqlParameterName("ARTICULO_COMBO_LOTE_ID") + ", " +
				"OPERACION=" + _db.CreateSqlParameterName("OPERACION") + ", " +
				"FECHA_OPERACION=" + _db.CreateSqlParameterName("FECHA_OPERACION") + ", " +
				"USUARIO_OPERACION_ID=" + _db.CreateSqlParameterName("USUARIO_OPERACION_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "ARTICULO_COMBO_LOTE_ID", value.ARTICULO_COMBO_LOTE_ID);
			AddParameter(cmd, "OPERACION", value.OPERACION);
			AddParameter(cmd, "FECHA_OPERACION", value.FECHA_OPERACION);
			AddParameter(cmd, "USUARIO_OPERACION_ID", value.USUARIO_OPERACION_ID);
			AddParameter(cmd, "CANTIDAD", value.CANTIDAD);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_COMBOS_STOCK</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_COMBOS_STOCK</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_COMBOS_STOCK</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_COMBOS_STOCKRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_COMBOS_STOCKRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_COMBOS_STOCK</c> table using
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
		/// Deletes records from the <c>ARTICULOS_COMBOS_STOCK</c> table using the 
		/// <c>FK_STOCK_COMBOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_COMBOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_COMBOS_STOCK</c> table using the 
		/// <c>FK_STOCK_COMBOS_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_combo_lote_id">The <c>ARTICULO_COMBO_LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_COMBO_LOTE_ID(decimal articulo_combo_lote_id)
		{
			return CreateDeleteByARTICULO_COMBO_LOTE_IDCommand(articulo_combo_lote_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_COMBOS_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_combo_lote_id">The <c>ARTICULO_COMBO_LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_COMBO_LOTE_IDCommand(decimal articulo_combo_lote_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_COMBO_LOTE_ID=" + _db.CreateSqlParameterName("ARTICULO_COMBO_LOTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_COMBO_LOTE_ID", articulo_combo_lote_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_COMBOS_STOCK</c> table using the 
		/// <c>FK_STOCK_COMBOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_COMBOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_COMBOS_STOCK</c> table using the 
		/// <c>FK_STOCK_COMBOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_OPERACION_ID(decimal usuario_operacion_id)
		{
			return CreateDeleteByUSUARIO_OPERACION_IDCommand(usuario_operacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_COMBOS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_OPERACION_IDCommand(decimal usuario_operacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_OPERACION_ID=" + _db.CreateSqlParameterName("USUARIO_OPERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_OPERACION_ID", usuario_operacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_COMBOS_STOCK</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_COMBOS_STOCK</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_COMBOS_STOCK";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_COMBOS_STOCK</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		protected ARTICULOS_COMBOS_STOCKRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		protected ARTICULOS_COMBOS_STOCKRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_COMBOS_STOCKRow"/> objects.</returns>
		protected virtual ARTICULOS_COMBOS_STOCKRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int articulo_combo_lote_idColumnIndex = reader.GetOrdinal("ARTICULO_COMBO_LOTE_ID");
			int operacionColumnIndex = reader.GetOrdinal("OPERACION");
			int fecha_operacionColumnIndex = reader.GetOrdinal("FECHA_OPERACION");
			int usuario_operacion_idColumnIndex = reader.GetOrdinal("USUARIO_OPERACION_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_COMBOS_STOCKRow record = new ARTICULOS_COMBOS_STOCKRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.ARTICULO_COMBO_LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_combo_lote_idColumnIndex)), 9);
					record.OPERACION = Convert.ToString(reader.GetValue(operacionColumnIndex));
					record.FECHA_OPERACION = Convert.ToDateTime(reader.GetValue(fecha_operacionColumnIndex));
					record.USUARIO_OPERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_operacion_idColumnIndex)), 9);
					record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_COMBOS_STOCKRow[])(recordList.ToArray(typeof(ARTICULOS_COMBOS_STOCKRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_COMBOS_STOCKRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_COMBOS_STOCKRow"/> object.</returns>
		protected virtual ARTICULOS_COMBOS_STOCKRow MapRow(DataRow row)
		{
			ARTICULOS_COMBOS_STOCKRow mappedObject = new ARTICULOS_COMBOS_STOCKRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_COMBO_LOTE_ID"
			dataColumn = dataTable.Columns["ARTICULO_COMBO_LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_COMBO_LOTE_ID = (decimal)row[dataColumn];
			// Column "OPERACION"
			dataColumn = dataTable.Columns["OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERACION = (string)row[dataColumn];
			// Column "FECHA_OPERACION"
			dataColumn = dataTable.Columns["FECHA_OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_OPERACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_OPERACION_ID"
			dataColumn = dataTable.Columns["USUARIO_OPERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_OPERACION_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_COMBOS_STOCK</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_COMBOS_STOCK";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_COMBO_LOTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OPERACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_OPERACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_OPERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_COMBO_LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_OPERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_COMBOS_STOCKCollection_Base class
}  // End of namespace
