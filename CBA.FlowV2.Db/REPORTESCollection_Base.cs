// <fileinfo name="REPORTESCollection_Base.cs">
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
	/// The base class for <see cref="REPORTESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REPORTESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPORTESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string NOMBRE_FISICOColumnName = "NOMBRE_FISICO";
		public const string TIPO_REPORTE_IDColumnName = "TIPO_REPORTE_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string MOSTRAR_EN_ARBOLColumnName = "MOSTRAR_EN_ARBOL";
		public const string RECURSOColumnName = "RECURSO";
		public const string FORMATO_REPORTE_IDColumnName = "FORMATO_REPORTE_ID";
		public const string IMPRESION_SILENCIOSAColumnName = "IMPRESION_SILENCIOSA";
		public const string LINKABLEColumnName = "LINKABLE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPORTESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REPORTESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REPORTES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		public virtual REPORTESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REPORTES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REPORTES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REPORTESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REPORTESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REPORTESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REPORTESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REPORTESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		public REPORTESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REPORTESRow"/> objects that 
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
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		public virtual REPORTESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REPORTES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REPORTESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REPORTESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REPORTESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REPORTESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REPORTESRow"/> objects 
		/// by the <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		public REPORTESRow[] GetByFORMATO_REPORTE_ID(decimal formato_reporte_id)
		{
			return GetByFORMATO_REPORTE_ID(formato_reporte_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPORTESRow"/> objects 
		/// by the <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <param name="formato_reporte_idNull">true if the method ignores the formato_reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		public virtual REPORTESRow[] GetByFORMATO_REPORTE_ID(decimal formato_reporte_id, bool formato_reporte_idNull)
		{
			return MapRecords(CreateGetByFORMATO_REPORTE_IDCommand(formato_reporte_id, formato_reporte_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFORMATO_REPORTE_IDAsDataTable(decimal formato_reporte_id)
		{
			return GetByFORMATO_REPORTE_IDAsDataTable(formato_reporte_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <param name="formato_reporte_idNull">true if the method ignores the formato_reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFORMATO_REPORTE_IDAsDataTable(decimal formato_reporte_id, bool formato_reporte_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFORMATO_REPORTE_IDCommand(formato_reporte_id, formato_reporte_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <param name="formato_reporte_idNull">true if the method ignores the formato_reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFORMATO_REPORTE_IDCommand(decimal formato_reporte_id, bool formato_reporte_idNull)
		{
			string whereSql = "";
			if(formato_reporte_idNull)
				whereSql += "FORMATO_REPORTE_ID IS NULL";
			else
				whereSql += "FORMATO_REPORTE_ID=" + _db.CreateSqlParameterName("FORMATO_REPORTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!formato_reporte_idNull)
				AddParameter(cmd, "FORMATO_REPORTE_ID", formato_reporte_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPORTESRow"/> objects 
		/// by the <c>FK_REPORTES_TIPO_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="tipo_reporte_id">The <c>TIPO_REPORTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		public virtual REPORTESRow[] GetByTIPO_REPORTE_ID(decimal tipo_reporte_id)
		{
			return MapRecords(CreateGetByTIPO_REPORTE_IDCommand(tipo_reporte_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPORTES_TIPO_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="tipo_reporte_id">The <c>TIPO_REPORTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_REPORTE_IDAsDataTable(decimal tipo_reporte_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_REPORTE_IDCommand(tipo_reporte_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPORTES_TIPO_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="tipo_reporte_id">The <c>TIPO_REPORTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_REPORTE_IDCommand(decimal tipo_reporte_id)
		{
			string whereSql = "";
			whereSql += "TIPO_REPORTE_ID=" + _db.CreateSqlParameterName("TIPO_REPORTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_REPORTE_ID", tipo_reporte_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>REPORTES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REPORTESRow"/> object to be inserted.</param>
		public virtual void Insert(REPORTESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REPORTES (" +
				"ID, " +
				"NOMBRE, " +
				"NOMBRE_FISICO, " +
				"TIPO_REPORTE_ID, " +
				"ESTADO, " +
				"MOSTRAR_EN_ARBOL, " +
				"RECURSO, " +
				"FORMATO_REPORTE_ID, " +
				"IMPRESION_SILENCIOSA, " +
				"LINKABLE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("NOMBRE_FISICO") + ", " +
				_db.CreateSqlParameterName("TIPO_REPORTE_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("MOSTRAR_EN_ARBOL") + ", " +
				_db.CreateSqlParameterName("RECURSO") + ", " +
				_db.CreateSqlParameterName("FORMATO_REPORTE_ID") + ", " +
				_db.CreateSqlParameterName("IMPRESION_SILENCIOSA") + ", " +
				_db.CreateSqlParameterName("LINKABLE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "NOMBRE_FISICO", value.NOMBRE_FISICO);
			AddParameter(cmd, "TIPO_REPORTE_ID", value.TIPO_REPORTE_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "MOSTRAR_EN_ARBOL", value.MOSTRAR_EN_ARBOL);
			AddParameter(cmd, "RECURSO", value.RECURSO);
			AddParameter(cmd, "FORMATO_REPORTE_ID",
				value.IsFORMATO_REPORTE_IDNull ? DBNull.Value : (object)value.FORMATO_REPORTE_ID);
			AddParameter(cmd, "IMPRESION_SILENCIOSA", value.IMPRESION_SILENCIOSA);
			AddParameter(cmd, "LINKABLE", value.LINKABLE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REPORTES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REPORTESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REPORTESRow value)
		{
			
			string sqlStr = "UPDATE TRC.REPORTES SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"NOMBRE_FISICO=" + _db.CreateSqlParameterName("NOMBRE_FISICO") + ", " +
				"TIPO_REPORTE_ID=" + _db.CreateSqlParameterName("TIPO_REPORTE_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"MOSTRAR_EN_ARBOL=" + _db.CreateSqlParameterName("MOSTRAR_EN_ARBOL") + ", " +
				"RECURSO=" + _db.CreateSqlParameterName("RECURSO") + ", " +
				"FORMATO_REPORTE_ID=" + _db.CreateSqlParameterName("FORMATO_REPORTE_ID") + ", " +
				"IMPRESION_SILENCIOSA=" + _db.CreateSqlParameterName("IMPRESION_SILENCIOSA") + ", " +
				"LINKABLE=" + _db.CreateSqlParameterName("LINKABLE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "NOMBRE_FISICO", value.NOMBRE_FISICO);
			AddParameter(cmd, "TIPO_REPORTE_ID", value.TIPO_REPORTE_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "MOSTRAR_EN_ARBOL", value.MOSTRAR_EN_ARBOL);
			AddParameter(cmd, "RECURSO", value.RECURSO);
			AddParameter(cmd, "FORMATO_REPORTE_ID",
				value.IsFORMATO_REPORTE_IDNull ? DBNull.Value : (object)value.FORMATO_REPORTE_ID);
			AddParameter(cmd, "IMPRESION_SILENCIOSA", value.IMPRESION_SILENCIOSA);
			AddParameter(cmd, "LINKABLE", value.LINKABLE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REPORTES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REPORTES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REPORTES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REPORTESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REPORTESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REPORTES</c> table using
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
		/// Deletes records from the <c>REPORTES</c> table using the 
		/// <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFORMATO_REPORTE_ID(decimal formato_reporte_id)
		{
			return DeleteByFORMATO_REPORTE_ID(formato_reporte_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPORTES</c> table using the 
		/// <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <param name="formato_reporte_idNull">true if the method ignores the formato_reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFORMATO_REPORTE_ID(decimal formato_reporte_id, bool formato_reporte_idNull)
		{
			return CreateDeleteByFORMATO_REPORTE_IDCommand(formato_reporte_id, formato_reporte_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPORTES_FORM_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="formato_reporte_id">The <c>FORMATO_REPORTE_ID</c> column value.</param>
		/// <param name="formato_reporte_idNull">true if the method ignores the formato_reporte_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFORMATO_REPORTE_IDCommand(decimal formato_reporte_id, bool formato_reporte_idNull)
		{
			string whereSql = "";
			if(formato_reporte_idNull)
				whereSql += "FORMATO_REPORTE_ID IS NULL";
			else
				whereSql += "FORMATO_REPORTE_ID=" + _db.CreateSqlParameterName("FORMATO_REPORTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!formato_reporte_idNull)
				AddParameter(cmd, "FORMATO_REPORTE_ID", formato_reporte_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPORTES</c> table using the 
		/// <c>FK_REPORTES_TIPO_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="tipo_reporte_id">The <c>TIPO_REPORTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_REPORTE_ID(decimal tipo_reporte_id)
		{
			return CreateDeleteByTIPO_REPORTE_IDCommand(tipo_reporte_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPORTES_TIPO_REPORTE</c> foreign key.
		/// </summary>
		/// <param name="tipo_reporte_id">The <c>TIPO_REPORTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_REPORTE_IDCommand(decimal tipo_reporte_id)
		{
			string whereSql = "";
			whereSql += "TIPO_REPORTE_ID=" + _db.CreateSqlParameterName("TIPO_REPORTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_REPORTE_ID", tipo_reporte_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>REPORTES</c> records that match the specified criteria.
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
		/// to delete <c>REPORTES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REPORTES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REPORTES</c> table.
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
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		protected REPORTESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		protected REPORTESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REPORTESRow"/> objects.</returns>
		protected virtual REPORTESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int nombre_fisicoColumnIndex = reader.GetOrdinal("NOMBRE_FISICO");
			int tipo_reporte_idColumnIndex = reader.GetOrdinal("TIPO_REPORTE_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int mostrar_en_arbolColumnIndex = reader.GetOrdinal("MOSTRAR_EN_ARBOL");
			int recursoColumnIndex = reader.GetOrdinal("RECURSO");
			int formato_reporte_idColumnIndex = reader.GetOrdinal("FORMATO_REPORTE_ID");
			int impresion_silenciosaColumnIndex = reader.GetOrdinal("IMPRESION_SILENCIOSA");
			int linkableColumnIndex = reader.GetOrdinal("LINKABLE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REPORTESRow record = new REPORTESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(nombre_fisicoColumnIndex))
						record.NOMBRE_FISICO = Convert.ToString(reader.GetValue(nombre_fisicoColumnIndex));
					record.TIPO_REPORTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_reporte_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.MOSTRAR_EN_ARBOL = Convert.ToString(reader.GetValue(mostrar_en_arbolColumnIndex));
					if(!reader.IsDBNull(recursoColumnIndex))
						record.RECURSO = Convert.ToString(reader.GetValue(recursoColumnIndex));
					if(!reader.IsDBNull(formato_reporte_idColumnIndex))
						record.FORMATO_REPORTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(formato_reporte_idColumnIndex)), 9);
					record.IMPRESION_SILENCIOSA = Convert.ToString(reader.GetValue(impresion_silenciosaColumnIndex));
					if(!reader.IsDBNull(linkableColumnIndex))
						record.LINKABLE = Convert.ToString(reader.GetValue(linkableColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REPORTESRow[])(recordList.ToArray(typeof(REPORTESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REPORTESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REPORTESRow"/> object.</returns>
		protected virtual REPORTESRow MapRow(DataRow row)
		{
			REPORTESRow mappedObject = new REPORTESRow();
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
			// Column "NOMBRE_FISICO"
			dataColumn = dataTable.Columns["NOMBRE_FISICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_FISICO = (string)row[dataColumn];
			// Column "TIPO_REPORTE_ID"
			dataColumn = dataTable.Columns["TIPO_REPORTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_REPORTE_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "MOSTRAR_EN_ARBOL"
			dataColumn = dataTable.Columns["MOSTRAR_EN_ARBOL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOSTRAR_EN_ARBOL = (string)row[dataColumn];
			// Column "RECURSO"
			dataColumn = dataTable.Columns["RECURSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECURSO = (string)row[dataColumn];
			// Column "FORMATO_REPORTE_ID"
			dataColumn = dataTable.Columns["FORMATO_REPORTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FORMATO_REPORTE_ID = (decimal)row[dataColumn];
			// Column "IMPRESION_SILENCIOSA"
			dataColumn = dataTable.Columns["IMPRESION_SILENCIOSA"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESION_SILENCIOSA = (string)row[dataColumn];
			// Column "LINKABLE"
			dataColumn = dataTable.Columns["LINKABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINKABLE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REPORTES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REPORTES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_FISICO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("TIPO_REPORTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOSTRAR_EN_ARBOL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RECURSO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("FORMATO_REPORTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPRESION_SILENCIOSA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LINKABLE", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "NOMBRE_FISICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_REPORTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MOSTRAR_EN_ARBOL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RECURSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FORMATO_REPORTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPRESION_SILENCIOSA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "LINKABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REPORTESCollection_Base class
}  // End of namespace
