// <fileinfo name="PRESUPUESTOS_ETAPASCollection_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_ETAPASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRESUPUESTOS_ETAPASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_ETAPASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PRESUPUESTO_IDColumnName = "PRESUPUESTO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string FECHA_ESTIMADA_INICIOColumnName = "FECHA_ESTIMADA_INICIO";
		public const string FECHA_ESTIMADA_FINColumnName = "FECHA_ESTIMADA_FIN";
		public const string FUNCIONARIO_RESPONSABLE_IDColumnName = "FUNCIONARIO_RESPONSABLE_ID";
		public const string ORDENColumnName = "ORDEN";
		public const string MORA_PORCENTAJEColumnName = "MORA_PORCENTAJE";
		public const string MORA_DIAS_GRACIAColumnName = "MORA_DIAS_GRACIA";
		public const string ARTICULO_PORCENTAJEColumnName = "ARTICULO_PORCENTAJE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_ETAPASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRESUPUESTOS_ETAPASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRESUPUESTOS_ETAPAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		public virtual PRESUPUESTOS_ETAPASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRESUPUESTOS_ETAPAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRESUPUESTOS_ETAPAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRESUPUESTOS_ETAPASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOS_ETAPASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRESUPUESTOS_ETAPASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRESUPUESTOS_ETAPASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		public PRESUPUESTOS_ETAPASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects that 
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
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		public virtual PRESUPUESTOS_ETAPASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRESUPUESTOS_ETAPAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PRESUPUESTOS_ETAPASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOS_ETAPASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PRESUPUESTOS_ETAPASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PRESUPUESTOS_ETAPASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects 
		/// by the <c>FK_PRESUP_ETAPAS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_responsable_id">The <c>FUNCIONARIO_RESPONSABLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		public virtual PRESUPUESTOS_ETAPASRow[] GetByFUNCIONARIO_RESPONSABLE_ID(decimal funcionario_responsable_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_RESPONSABLE_IDCommand(funcionario_responsable_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_ETAPAS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_responsable_id">The <c>FUNCIONARIO_RESPONSABLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_RESPONSABLE_IDAsDataTable(decimal funcionario_responsable_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_RESPONSABLE_IDCommand(funcionario_responsable_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_ETAPAS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_responsable_id">The <c>FUNCIONARIO_RESPONSABLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_RESPONSABLE_IDCommand(decimal funcionario_responsable_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_RESPONSABLE_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_RESPONSABLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_RESPONSABLE_ID", funcionario_responsable_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects 
		/// by the <c>FK_PRESUP_ETAPAS_PRESUP_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_id">The <c>PRESUPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		public virtual PRESUPUESTOS_ETAPASRow[] GetByPRESUPUESTO_ID(decimal presupuesto_id)
		{
			return MapRecords(CreateGetByPRESUPUESTO_IDCommand(presupuesto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_ETAPAS_PRESUP_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_id">The <c>PRESUPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPRESUPUESTO_IDAsDataTable(decimal presupuesto_id)
		{
			return MapRecordsToDataTable(CreateGetByPRESUPUESTO_IDCommand(presupuesto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_ETAPAS_PRESUP_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_id">The <c>PRESUPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPRESUPUESTO_IDCommand(decimal presupuesto_id)
		{
			string whereSql = "";
			whereSql += "PRESUPUESTO_ID=" + _db.CreateSqlParameterName("PRESUPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PRESUPUESTO_ID", presupuesto_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PRESUPUESTOS_ETAPAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOS_ETAPASRow"/> object to be inserted.</param>
		public virtual void Insert(PRESUPUESTOS_ETAPASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PRESUPUESTOS_ETAPAS (" +
				"ID, " +
				"PRESUPUESTO_ID, " +
				"NOMBRE, " +
				"FECHA_ESTIMADA_INICIO, " +
				"FECHA_ESTIMADA_FIN, " +
				"FUNCIONARIO_RESPONSABLE_ID, " +
				"ORDEN, " +
				"MORA_PORCENTAJE, " +
				"MORA_DIAS_GRACIA, " +
				"ARTICULO_PORCENTAJE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PRESUPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("FECHA_ESTIMADA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_ESTIMADA_FIN") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_RESPONSABLE_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("MORA_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("MORA_DIAS_GRACIA") + ", " +
				_db.CreateSqlParameterName("ARTICULO_PORCENTAJE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PRESUPUESTO_ID", value.PRESUPUESTO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "FECHA_ESTIMADA_INICIO",
				value.IsFECHA_ESTIMADA_INICIONull ? DBNull.Value : (object)value.FECHA_ESTIMADA_INICIO);
			AddParameter(cmd, "FECHA_ESTIMADA_FIN",
				value.IsFECHA_ESTIMADA_FINNull ? DBNull.Value : (object)value.FECHA_ESTIMADA_FIN);
			AddParameter(cmd, "FUNCIONARIO_RESPONSABLE_ID", value.FUNCIONARIO_RESPONSABLE_ID);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "MORA_PORCENTAJE", value.MORA_PORCENTAJE);
			AddParameter(cmd, "MORA_DIAS_GRACIA", value.MORA_DIAS_GRACIA);
			AddParameter(cmd, "ARTICULO_PORCENTAJE", value.ARTICULO_PORCENTAJE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PRESUPUESTOS_ETAPAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOS_ETAPASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PRESUPUESTOS_ETAPASRow value)
		{
			
			string sqlStr = "UPDATE TRC.PRESUPUESTOS_ETAPAS SET " +
				"PRESUPUESTO_ID=" + _db.CreateSqlParameterName("PRESUPUESTO_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"FECHA_ESTIMADA_INICIO=" + _db.CreateSqlParameterName("FECHA_ESTIMADA_INICIO") + ", " +
				"FECHA_ESTIMADA_FIN=" + _db.CreateSqlParameterName("FECHA_ESTIMADA_FIN") + ", " +
				"FUNCIONARIO_RESPONSABLE_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_RESPONSABLE_ID") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"MORA_PORCENTAJE=" + _db.CreateSqlParameterName("MORA_PORCENTAJE") + ", " +
				"MORA_DIAS_GRACIA=" + _db.CreateSqlParameterName("MORA_DIAS_GRACIA") + ", " +
				"ARTICULO_PORCENTAJE=" + _db.CreateSqlParameterName("ARTICULO_PORCENTAJE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PRESUPUESTO_ID", value.PRESUPUESTO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "FECHA_ESTIMADA_INICIO",
				value.IsFECHA_ESTIMADA_INICIONull ? DBNull.Value : (object)value.FECHA_ESTIMADA_INICIO);
			AddParameter(cmd, "FECHA_ESTIMADA_FIN",
				value.IsFECHA_ESTIMADA_FINNull ? DBNull.Value : (object)value.FECHA_ESTIMADA_FIN);
			AddParameter(cmd, "FUNCIONARIO_RESPONSABLE_ID", value.FUNCIONARIO_RESPONSABLE_ID);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "MORA_PORCENTAJE", value.MORA_PORCENTAJE);
			AddParameter(cmd, "MORA_DIAS_GRACIA", value.MORA_DIAS_GRACIA);
			AddParameter(cmd, "ARTICULO_PORCENTAJE", value.ARTICULO_PORCENTAJE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PRESUPUESTOS_ETAPAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PRESUPUESTOS_ETAPAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PRESUPUESTOS_ETAPAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOS_ETAPASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PRESUPUESTOS_ETAPASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PRESUPUESTOS_ETAPAS</c> table using
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
		/// Deletes records from the <c>PRESUPUESTOS_ETAPAS</c> table using the 
		/// <c>FK_PRESUP_ETAPAS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_responsable_id">The <c>FUNCIONARIO_RESPONSABLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_RESPONSABLE_ID(decimal funcionario_responsable_id)
		{
			return CreateDeleteByFUNCIONARIO_RESPONSABLE_IDCommand(funcionario_responsable_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_ETAPAS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_responsable_id">The <c>FUNCIONARIO_RESPONSABLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_RESPONSABLE_IDCommand(decimal funcionario_responsable_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_RESPONSABLE_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_RESPONSABLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_RESPONSABLE_ID", funcionario_responsable_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS_ETAPAS</c> table using the 
		/// <c>FK_PRESUP_ETAPAS_PRESUP_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_id">The <c>PRESUPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRESUPUESTO_ID(decimal presupuesto_id)
		{
			return CreateDeleteByPRESUPUESTO_IDCommand(presupuesto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_ETAPAS_PRESUP_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_id">The <c>PRESUPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPRESUPUESTO_IDCommand(decimal presupuesto_id)
		{
			string whereSql = "";
			whereSql += "PRESUPUESTO_ID=" + _db.CreateSqlParameterName("PRESUPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PRESUPUESTO_ID", presupuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PRESUPUESTOS_ETAPAS</c> records that match the specified criteria.
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
		/// to delete <c>PRESUPUESTOS_ETAPAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PRESUPUESTOS_ETAPAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PRESUPUESTOS_ETAPAS</c> table.
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
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		protected PRESUPUESTOS_ETAPASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		protected PRESUPUESTOS_ETAPASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_ETAPASRow"/> objects.</returns>
		protected virtual PRESUPUESTOS_ETAPASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int presupuesto_idColumnIndex = reader.GetOrdinal("PRESUPUESTO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int fecha_estimada_inicioColumnIndex = reader.GetOrdinal("FECHA_ESTIMADA_INICIO");
			int fecha_estimada_finColumnIndex = reader.GetOrdinal("FECHA_ESTIMADA_FIN");
			int funcionario_responsable_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_RESPONSABLE_ID");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int mora_porcentajeColumnIndex = reader.GetOrdinal("MORA_PORCENTAJE");
			int mora_dias_graciaColumnIndex = reader.GetOrdinal("MORA_DIAS_GRACIA");
			int articulo_porcentajeColumnIndex = reader.GetOrdinal("ARTICULO_PORCENTAJE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRESUPUESTOS_ETAPASRow record = new PRESUPUESTOS_ETAPASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PRESUPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(presupuesto_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(fecha_estimada_inicioColumnIndex))
						record.FECHA_ESTIMADA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_estimada_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_estimada_finColumnIndex))
						record.FECHA_ESTIMADA_FIN = Convert.ToDateTime(reader.GetValue(fecha_estimada_finColumnIndex));
					record.FUNCIONARIO_RESPONSABLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_responsable_idColumnIndex)), 9);
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					record.MORA_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(mora_porcentajeColumnIndex)), 9);
					record.MORA_DIAS_GRACIA = Math.Round(Convert.ToDecimal(reader.GetValue(mora_dias_graciaColumnIndex)), 9);
					record.ARTICULO_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_porcentajeColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRESUPUESTOS_ETAPASRow[])(recordList.ToArray(typeof(PRESUPUESTOS_ETAPASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRESUPUESTOS_ETAPASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRESUPUESTOS_ETAPASRow"/> object.</returns>
		protected virtual PRESUPUESTOS_ETAPASRow MapRow(DataRow row)
		{
			PRESUPUESTOS_ETAPASRow mappedObject = new PRESUPUESTOS_ETAPASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PRESUPUESTO_ID"
			dataColumn = dataTable.Columns["PRESUPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESUPUESTO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "FECHA_ESTIMADA_INICIO"
			dataColumn = dataTable.Columns["FECHA_ESTIMADA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ESTIMADA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_ESTIMADA_FIN"
			dataColumn = dataTable.Columns["FECHA_ESTIMADA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ESTIMADA_FIN = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_RESPONSABLE_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_RESPONSABLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_RESPONSABLE_ID = (decimal)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "MORA_PORCENTAJE"
			dataColumn = dataTable.Columns["MORA_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_PORCENTAJE = (decimal)row[dataColumn];
			// Column "MORA_DIAS_GRACIA"
			dataColumn = dataTable.Columns["MORA_DIAS_GRACIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_DIAS_GRACIA = (decimal)row[dataColumn];
			// Column "ARTICULO_PORCENTAJE"
			dataColumn = dataTable.Columns["ARTICULO_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_PORCENTAJE = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRESUPUESTOS_ETAPAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRESUPUESTOS_ETAPAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRESUPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ESTIMADA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ESTIMADA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_RESPONSABLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MORA_PORCENTAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MORA_DIAS_GRACIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_PORCENTAJE", typeof(decimal));
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

				case "PRESUPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ESTIMADA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ESTIMADA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_RESPONSABLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MORA_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MORA_DIAS_GRACIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRESUPUESTOS_ETAPASCollection_Base class
}  // End of namespace
