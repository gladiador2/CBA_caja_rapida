// <fileinfo name="DESEMBOLSOS_GIROS_DETCollection_Base.cs">
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
	/// The base class for <see cref="DESEMBOLSOS_GIROS_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESEMBOLSOS_GIROS_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESEMBOLSOS_GIROS_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string DESEMBOLSO_GIRO_IDColumnName = "DESEMBOLSO_GIRO_ID";
		public const string CTACTE_GIROS_MOVIMIENTO_IDColumnName = "CTACTE_GIROS_MOVIMIENTO_ID";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESEMBOLSOS_GIROS_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESEMBOLSOS_GIROS_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESEMBOLSOS_GIROS_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROS_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESEMBOLSOS_GIROS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESEMBOLSOS_GIROS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESEMBOLSOS_GIROS_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESEMBOLSOS_GIROS_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESEMBOLSOS_GIROS_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		public DESEMBOLSOS_GIROS_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROS_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESEMBOLSOS_GIROS_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DESEMBOLSOS_GIROS_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DESEMBOLSOS_GIROS_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DESEMBOLSOS_GIROS_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DESEMBOLSOS_GIROS_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects 
		/// by the <c>FK_DESEM_GIRO_DET_DESEMB_GIROS</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROS_DETRow[] GetByDESEMBOLSO_GIRO_ID(decimal desembolso_giro_id)
		{
			return MapRecords(CreateGetByDESEMBOLSO_GIRO_IDCommand(desembolso_giro_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIRO_DET_DESEMB_GIROS</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESEMBOLSO_GIRO_IDAsDataTable(decimal desembolso_giro_id)
		{
			return MapRecordsToDataTable(CreateGetByDESEMBOLSO_GIRO_IDCommand(desembolso_giro_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIRO_DET_DESEMB_GIROS</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESEMBOLSO_GIRO_IDCommand(decimal desembolso_giro_id)
		{
			string whereSql = "";
			whereSql += "DESEMBOLSO_GIRO_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DESEMBOLSO_GIRO_ID", desembolso_giro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects 
		/// by the <c>FK_DESEM_GIRO_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROS_DETRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIRO_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIRO_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects 
		/// by the <c>FK_DESEM_GIRO_GIROS_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giros_movimiento_id">The <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		public virtual DESEMBOLSOS_GIROS_DETRow[] GetByCTACTE_GIROS_MOVIMIENTO_ID(decimal ctacte_giros_movimiento_id)
		{
			return MapRecords(CreateGetByCTACTE_GIROS_MOVIMIENTO_IDCommand(ctacte_giros_movimiento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESEM_GIRO_GIROS_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giros_movimiento_id">The <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_GIROS_MOVIMIENTO_IDAsDataTable(decimal ctacte_giros_movimiento_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_GIROS_MOVIMIENTO_IDCommand(ctacte_giros_movimiento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESEM_GIRO_GIROS_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giros_movimiento_id">The <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_GIROS_MOVIMIENTO_IDCommand(decimal ctacte_giros_movimiento_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_GIROS_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("CTACTE_GIROS_MOVIMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_GIROS_MOVIMIENTO_ID", ctacte_giros_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DESEMBOLSOS_GIROS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESEMBOLSOS_GIROS_DETRow"/> object to be inserted.</param>
		public virtual void Insert(DESEMBOLSOS_GIROS_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DESEMBOLSOS_GIROS_DET (" +
				"ID, " +
				"DESEMBOLSO_GIRO_ID, " +
				"CTACTE_GIROS_MOVIMIENTO_ID, " +
				"MONTO_ORIGEN, " +
				"MONEDA_ORIGEN_ID, " +
				"COTIZACION_MONEDA_ORIGEN, " +
				"MONTO_DESTINO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_GIROS_MOVIMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_DESTINO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "DESEMBOLSO_GIRO_ID", value.DESEMBOLSO_GIRO_ID);
			AddParameter(cmd, "CTACTE_GIROS_MOVIMIENTO_ID", value.CTACTE_GIROS_MOVIMIENTO_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO",
				value.IsMONTO_DESTINONull ? DBNull.Value : (object)value.MONTO_DESTINO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DESEMBOLSOS_GIROS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESEMBOLSOS_GIROS_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DESEMBOLSOS_GIROS_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.DESEMBOLSOS_GIROS_DET SET " +
				"DESEMBOLSO_GIRO_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID") + ", " +
				"CTACTE_GIROS_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("CTACTE_GIROS_MOVIMIENTO_ID") + ", " +
				"MONTO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"COTIZACION_MONEDA_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				"MONTO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DESTINO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "DESEMBOLSO_GIRO_ID", value.DESEMBOLSO_GIRO_ID);
			AddParameter(cmd, "CTACTE_GIROS_MOVIMIENTO_ID", value.CTACTE_GIROS_MOVIMIENTO_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO",
				value.IsMONTO_DESTINONull ? DBNull.Value : (object)value.MONTO_DESTINO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DESEMBOLSOS_GIROS_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DESEMBOLSOS_GIROS_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DESEMBOLSOS_GIROS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESEMBOLSOS_GIROS_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DESEMBOLSOS_GIROS_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DESEMBOLSOS_GIROS_DET</c> table using
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
		/// Deletes records from the <c>DESEMBOLSOS_GIROS_DET</c> table using the 
		/// <c>FK_DESEM_GIRO_DET_DESEMB_GIROS</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESEMBOLSO_GIRO_ID(decimal desembolso_giro_id)
		{
			return CreateDeleteByDESEMBOLSO_GIRO_IDCommand(desembolso_giro_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIRO_DET_DESEMB_GIROS</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESEMBOLSO_GIRO_IDCommand(decimal desembolso_giro_id)
		{
			string whereSql = "";
			whereSql += "DESEMBOLSO_GIRO_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DESEMBOLSO_GIRO_ID", desembolso_giro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS_DET</c> table using the 
		/// <c>FK_DESEM_GIRO_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIRO_DET_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESEMBOLSOS_GIROS_DET</c> table using the 
		/// <c>FK_DESEM_GIRO_GIROS_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giros_movimiento_id">The <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_GIROS_MOVIMIENTO_ID(decimal ctacte_giros_movimiento_id)
		{
			return CreateDeleteByCTACTE_GIROS_MOVIMIENTO_IDCommand(ctacte_giros_movimiento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESEM_GIRO_GIROS_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giros_movimiento_id">The <c>CTACTE_GIROS_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_GIROS_MOVIMIENTO_IDCommand(decimal ctacte_giros_movimiento_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_GIROS_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("CTACTE_GIROS_MOVIMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_GIROS_MOVIMIENTO_ID", ctacte_giros_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DESEMBOLSOS_GIROS_DET</c> records that match the specified criteria.
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
		/// to delete <c>DESEMBOLSOS_GIROS_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DESEMBOLSOS_GIROS_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DESEMBOLSOS_GIROS_DET</c> table.
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		protected DESEMBOLSOS_GIROS_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		protected DESEMBOLSOS_GIROS_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESEMBOLSOS_GIROS_DETRow"/> objects.</returns>
		protected virtual DESEMBOLSOS_GIROS_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int desembolso_giro_idColumnIndex = reader.GetOrdinal("DESEMBOLSO_GIRO_ID");
			int ctacte_giros_movimiento_idColumnIndex = reader.GetOrdinal("CTACTE_GIROS_MOVIMIENTO_ID");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESEMBOLSOS_GIROS_DETRow record = new DESEMBOLSOS_GIROS_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.DESEMBOLSO_GIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desembolso_giro_idColumnIndex)), 9);
					record.CTACTE_GIROS_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_giros_movimiento_idColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					if(!reader.IsDBNull(monto_destinoColumnIndex))
						record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESEMBOLSOS_GIROS_DETRow[])(recordList.ToArray(typeof(DESEMBOLSOS_GIROS_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESEMBOLSOS_GIROS_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESEMBOLSOS_GIROS_DETRow"/> object.</returns>
		protected virtual DESEMBOLSOS_GIROS_DETRow MapRow(DataRow row)
		{
			DESEMBOLSOS_GIROS_DETRow mappedObject = new DESEMBOLSOS_GIROS_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "DESEMBOLSO_GIRO_ID"
			dataColumn = dataTable.Columns["DESEMBOLSO_GIRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_GIRO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_GIROS_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["CTACTE_GIROS_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIROS_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESEMBOLSOS_GIROS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESEMBOLSOS_GIROS_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_GIRO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_GIROS_MOVIMIENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
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

				case "DESEMBOLSO_GIRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_GIROS_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESEMBOLSOS_GIROS_DETCollection_Base class
}  // End of namespace
