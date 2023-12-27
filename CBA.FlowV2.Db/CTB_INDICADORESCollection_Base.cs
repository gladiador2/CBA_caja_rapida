// <fileinfo name="CTB_INDICADORESCollection_Base.cs">
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
	/// The base class for <see cref="CTB_INDICADORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_INDICADORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_INDICADORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string LIMITE_INFERIOR_NORMALColumnName = "LIMITE_INFERIOR_NORMAL";
		public const string LIMITE_SUPERIOR_NORMALColumnName = "LIMITE_SUPERIOR_NORMAL";
		public const string LIMITE_INFERIOR_MULTINACIONALColumnName = "LIMITE_INFERIOR_MULTINACIONAL";
		public const string LIMITE_SUPERIOR_MULTINACIONALColumnName = "LIMITE_SUPERIOR_MULTINACIONAL";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string CTB_PLAN_CUENTASColumnName = "CTB_PLAN_CUENTAS";
		public const string PORCENTAJE_DE_ALARMAColumnName = "PORCENTAJE_DE_ALARMA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_INDICADORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_INDICADORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_INDICADORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		public virtual CTB_INDICADORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_INDICADORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_INDICADORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_INDICADORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_INDICADORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_INDICADORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_INDICADORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		public CTB_INDICADORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORESRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		public virtual CTB_INDICADORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_INDICADORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_INDICADORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_INDICADORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_INDICADORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_INDICADORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORESRow"/> objects 
		/// by the <c>FK_CTB_INDICAD_PLAN_CUENTAS</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuentas">The <c>CTB_PLAN_CUENTAS</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		public virtual CTB_INDICADORESRow[] GetByCTB_PLAN_CUENTAS(decimal ctb_plan_cuentas)
		{
			return MapRecords(CreateGetByCTB_PLAN_CUENTASCommand(ctb_plan_cuentas));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_PLAN_CUENTAS</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuentas">The <c>CTB_PLAN_CUENTAS</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_PLAN_CUENTASAsDataTable(decimal ctb_plan_cuentas)
		{
			return MapRecordsToDataTable(CreateGetByCTB_PLAN_CUENTASCommand(ctb_plan_cuentas));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICAD_PLAN_CUENTAS</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuentas">The <c>CTB_PLAN_CUENTAS</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_PLAN_CUENTASCommand(decimal ctb_plan_cuentas)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTAS=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTAS");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_PLAN_CUENTAS", ctb_plan_cuentas);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORESRow"/> objects 
		/// by the <c>FK_CTB_INDICADORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		public virtual CTB_INDICADORESRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICADORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICADORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_INDICADORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_INDICADORESRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_INDICADORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_INDICADORES (" +
				"ID, " +
				"NOMBRE, " +
				"DESCRIPCION, " +
				"LIMITE_INFERIOR_NORMAL, " +
				"LIMITE_SUPERIOR_NORMAL, " +
				"LIMITE_INFERIOR_MULTINACIONAL, " +
				"LIMITE_SUPERIOR_MULTINACIONAL, " +
				"ENTIDAD_ID, " +
				"CTB_PLAN_CUENTAS, " +
				"PORCENTAJE_DE_ALARMA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("LIMITE_INFERIOR_NORMAL") + ", " +
				_db.CreateSqlParameterName("LIMITE_SUPERIOR_NORMAL") + ", " +
				_db.CreateSqlParameterName("LIMITE_INFERIOR_MULTINACIONAL") + ", " +
				_db.CreateSqlParameterName("LIMITE_SUPERIOR_MULTINACIONAL") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("CTB_PLAN_CUENTAS") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DE_ALARMA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "LIMITE_INFERIOR_NORMAL", value.LIMITE_INFERIOR_NORMAL);
			AddParameter(cmd, "LIMITE_SUPERIOR_NORMAL", value.LIMITE_SUPERIOR_NORMAL);
			AddParameter(cmd, "LIMITE_INFERIOR_MULTINACIONAL",
				value.IsLIMITE_INFERIOR_MULTINACIONALNull ? DBNull.Value : (object)value.LIMITE_INFERIOR_MULTINACIONAL);
			AddParameter(cmd, "LIMITE_SUPERIOR_MULTINACIONAL",
				value.IsLIMITE_SUPERIOR_MULTINACIONALNull ? DBNull.Value : (object)value.LIMITE_SUPERIOR_MULTINACIONAL);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "CTB_PLAN_CUENTAS", value.CTB_PLAN_CUENTAS);
			AddParameter(cmd, "PORCENTAJE_DE_ALARMA", value.PORCENTAJE_DE_ALARMA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_INDICADORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_INDICADORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_INDICADORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_INDICADORES SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"LIMITE_INFERIOR_NORMAL=" + _db.CreateSqlParameterName("LIMITE_INFERIOR_NORMAL") + ", " +
				"LIMITE_SUPERIOR_NORMAL=" + _db.CreateSqlParameterName("LIMITE_SUPERIOR_NORMAL") + ", " +
				"LIMITE_INFERIOR_MULTINACIONAL=" + _db.CreateSqlParameterName("LIMITE_INFERIOR_MULTINACIONAL") + ", " +
				"LIMITE_SUPERIOR_MULTINACIONAL=" + _db.CreateSqlParameterName("LIMITE_SUPERIOR_MULTINACIONAL") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"CTB_PLAN_CUENTAS=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTAS") + ", " +
				"PORCENTAJE_DE_ALARMA=" + _db.CreateSqlParameterName("PORCENTAJE_DE_ALARMA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "LIMITE_INFERIOR_NORMAL", value.LIMITE_INFERIOR_NORMAL);
			AddParameter(cmd, "LIMITE_SUPERIOR_NORMAL", value.LIMITE_SUPERIOR_NORMAL);
			AddParameter(cmd, "LIMITE_INFERIOR_MULTINACIONAL",
				value.IsLIMITE_INFERIOR_MULTINACIONALNull ? DBNull.Value : (object)value.LIMITE_INFERIOR_MULTINACIONAL);
			AddParameter(cmd, "LIMITE_SUPERIOR_MULTINACIONAL",
				value.IsLIMITE_SUPERIOR_MULTINACIONALNull ? DBNull.Value : (object)value.LIMITE_SUPERIOR_MULTINACIONAL);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "CTB_PLAN_CUENTAS", value.CTB_PLAN_CUENTAS);
			AddParameter(cmd, "PORCENTAJE_DE_ALARMA", value.PORCENTAJE_DE_ALARMA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_INDICADORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_INDICADORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_INDICADORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_INDICADORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_INDICADORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_INDICADORES</c> table using
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
		/// Deletes records from the <c>CTB_INDICADORES</c> table using the 
		/// <c>FK_CTB_INDICAD_PLAN_CUENTAS</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuentas">The <c>CTB_PLAN_CUENTAS</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_PLAN_CUENTAS(decimal ctb_plan_cuentas)
		{
			return CreateDeleteByCTB_PLAN_CUENTASCommand(ctb_plan_cuentas).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICAD_PLAN_CUENTAS</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuentas">The <c>CTB_PLAN_CUENTAS</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_PLAN_CUENTASCommand(decimal ctb_plan_cuentas)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTAS=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTAS");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_PLAN_CUENTAS", ctb_plan_cuentas);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES</c> table using the 
		/// <c>FK_CTB_INDICADORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICADORES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_INDICADORES</c> records that match the specified criteria.
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
		/// to delete <c>CTB_INDICADORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_INDICADORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_INDICADORES</c> table.
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
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		protected CTB_INDICADORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		protected CTB_INDICADORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_INDICADORESRow"/> objects.</returns>
		protected virtual CTB_INDICADORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int limite_inferior_normalColumnIndex = reader.GetOrdinal("LIMITE_INFERIOR_NORMAL");
			int limite_superior_normalColumnIndex = reader.GetOrdinal("LIMITE_SUPERIOR_NORMAL");
			int limite_inferior_multinacionalColumnIndex = reader.GetOrdinal("LIMITE_INFERIOR_MULTINACIONAL");
			int limite_superior_multinacionalColumnIndex = reader.GetOrdinal("LIMITE_SUPERIOR_MULTINACIONAL");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int ctb_plan_cuentasColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTAS");
			int porcentaje_de_alarmaColumnIndex = reader.GetOrdinal("PORCENTAJE_DE_ALARMA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_INDICADORESRow record = new CTB_INDICADORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.LIMITE_INFERIOR_NORMAL = Math.Round(Convert.ToDecimal(reader.GetValue(limite_inferior_normalColumnIndex)), 9);
					record.LIMITE_SUPERIOR_NORMAL = Math.Round(Convert.ToDecimal(reader.GetValue(limite_superior_normalColumnIndex)), 9);
					if(!reader.IsDBNull(limite_inferior_multinacionalColumnIndex))
						record.LIMITE_INFERIOR_MULTINACIONAL = Math.Round(Convert.ToDecimal(reader.GetValue(limite_inferior_multinacionalColumnIndex)), 9);
					if(!reader.IsDBNull(limite_superior_multinacionalColumnIndex))
						record.LIMITE_SUPERIOR_MULTINACIONAL = Math.Round(Convert.ToDecimal(reader.GetValue(limite_superior_multinacionalColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.CTB_PLAN_CUENTAS = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_plan_cuentasColumnIndex)), 9);
					record.PORCENTAJE_DE_ALARMA = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_de_alarmaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_INDICADORESRow[])(recordList.ToArray(typeof(CTB_INDICADORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_INDICADORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_INDICADORESRow"/> object.</returns>
		protected virtual CTB_INDICADORESRow MapRow(DataRow row)
		{
			CTB_INDICADORESRow mappedObject = new CTB_INDICADORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "LIMITE_INFERIOR_NORMAL"
			dataColumn = dataTable.Columns["LIMITE_INFERIOR_NORMAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_INFERIOR_NORMAL = (decimal)row[dataColumn];
			// Column "LIMITE_SUPERIOR_NORMAL"
			dataColumn = dataTable.Columns["LIMITE_SUPERIOR_NORMAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_SUPERIOR_NORMAL = (decimal)row[dataColumn];
			// Column "LIMITE_INFERIOR_MULTINACIONAL"
			dataColumn = dataTable.Columns["LIMITE_INFERIOR_MULTINACIONAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_INFERIOR_MULTINACIONAL = (decimal)row[dataColumn];
			// Column "LIMITE_SUPERIOR_MULTINACIONAL"
			dataColumn = dataTable.Columns["LIMITE_SUPERIOR_MULTINACIONAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_SUPERIOR_MULTINACIONAL = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTAS"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTAS = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DE_ALARMA"
			dataColumn = dataTable.Columns["PORCENTAJE_DE_ALARMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DE_ALARMA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_INDICADORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_INDICADORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("LIMITE_INFERIOR_NORMAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIMITE_SUPERIOR_NORMAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIMITE_INFERIOR_MULTINACIONAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LIMITE_SUPERIOR_MULTINACIONAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DE_ALARMA", typeof(decimal));
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

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIMITE_INFERIOR_NORMAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_SUPERIOR_NORMAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_INFERIOR_MULTINACIONAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_SUPERIOR_MULTINACIONAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_PLAN_CUENTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DE_ALARMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_INDICADORESCollection_Base class
}  // End of namespace
