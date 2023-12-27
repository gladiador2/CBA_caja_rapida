// <fileinfo name="CTACTE_PAGOS_PER_COMPEN_SALIDACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PER_COMPEN_SALIDACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_PAGOS_PERSONA_DOC_IDColumnName = "CTACTE_PAGOS_PERSONA_DOC_ID";
		public const string CTACTE_PAGOS_PERSONA_IDColumnName = "CTACTE_PAGOS_PERSONA_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PAGOS_PER_COMPEN_SALIDACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PER_COMPEN_SALIDARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PAGOS_PER_COMPEN_SALIDARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PAGOS_PER_COMPEN_SALIDARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		public CTACTE_PAGOS_PER_COMPEN_SALIDARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PER_COMPEN_SALIDARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PAGOS_PER_COMPEN_SALIDA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PAGOS_PER_COMPEN_SALIDARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PAGOS_PER_COMPEN_SALIDARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PE_COM_SAL_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_doc_id">The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PER_COMPEN_SALIDARow[] GetByCTACTE_PAGOS_PERSONA_DOC_ID(decimal ctacte_pagos_persona_doc_id)
		{
			return MapRecords(CreateGetByCTACTE_PAGOS_PERSONA_DOC_IDCommand(ctacte_pagos_persona_doc_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PE_COM_SAL_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_doc_id">The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGOS_PERSONA_DOC_IDAsDataTable(decimal ctacte_pagos_persona_doc_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGOS_PERSONA_DOC_IDCommand(ctacte_pagos_persona_doc_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PE_COM_SAL_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_doc_id">The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGOS_PERSONA_DOC_IDCommand(decimal ctacte_pagos_persona_doc_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PAGOS_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_DOC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_DOC_ID", ctacte_pagos_persona_doc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PE_COM_SAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_id">The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PER_COMPEN_SALIDARow[] GetByCTACTE_PAGOS_PERSONA_ID(decimal ctacte_pagos_persona_id)
		{
			return MapRecords(CreateGetByCTACTE_PAGOS_PERSONA_IDCommand(ctacte_pagos_persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PE_COM_SAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_id">The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGOS_PERSONA_IDAsDataTable(decimal ctacte_pagos_persona_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGOS_PERSONA_IDCommand(ctacte_pagos_persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PE_COM_SAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_id">The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGOS_PERSONA_IDCommand(decimal ctacte_pagos_persona_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PAGOS_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_ID", ctacte_pagos_persona_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PAGOS_PER_COMPEN_SALIDARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PAGOS_PER_COMPEN_SALIDA (" +
				"ID, " +
				"CTACTE_PAGOS_PERSONA_DOC_ID, " +
				"CTACTE_PAGOS_PERSONA_ID, " +
				"ESTADO, " +
				"FECHA_CREACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_DOC_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_DOC_ID", value.CTACTE_PAGOS_PERSONA_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_ID", value.CTACTE_PAGOS_PERSONA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PAGOS_PER_COMPEN_SALIDARow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PAGOS_PER_COMPEN_SALIDA SET " +
				"CTACTE_PAGOS_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_DOC_ID") + ", " +
				"CTACTE_PAGOS_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_DOC_ID", value.CTACTE_PAGOS_PERSONA_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_ID", value.CTACTE_PAGOS_PERSONA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PAGOS_PER_COMPEN_SALIDARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table using
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
		/// Deletes records from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PE_COM_SAL_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_doc_id">The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGOS_PERSONA_DOC_ID(decimal ctacte_pagos_persona_doc_id)
		{
			return CreateDeleteByCTACTE_PAGOS_PERSONA_DOC_IDCommand(ctacte_pagos_persona_doc_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PE_COM_SAL_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_doc_id">The <c>CTACTE_PAGOS_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGOS_PERSONA_DOC_IDCommand(decimal ctacte_pagos_persona_doc_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PAGOS_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_DOC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_DOC_ID", ctacte_pagos_persona_doc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PE_COM_SAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_id">The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGOS_PERSONA_ID(decimal ctacte_pagos_persona_id)
		{
			return CreateDeleteByCTACTE_PAGOS_PERSONA_IDCommand(ctacte_pagos_persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PE_COM_SAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagos_persona_id">The <c>CTACTE_PAGOS_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGOS_PERSONA_IDCommand(decimal ctacte_pagos_persona_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PAGOS_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGOS_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_PAGOS_PERSONA_ID", ctacte_pagos_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PAGOS_PER_COMPEN_SALIDA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		protected CTACTE_PAGOS_PER_COMPEN_SALIDARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		protected CTACTE_PAGOS_PER_COMPEN_SALIDARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> objects.</returns>
		protected virtual CTACTE_PAGOS_PER_COMPEN_SALIDARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_pagos_persona_doc_idColumnIndex = reader.GetOrdinal("CTACTE_PAGOS_PERSONA_DOC_ID");
			int ctacte_pagos_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PAGOS_PERSONA_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PAGOS_PER_COMPEN_SALIDARow record = new CTACTE_PAGOS_PER_COMPEN_SALIDARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_PAGOS_PERSONA_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagos_persona_doc_idColumnIndex)), 9);
					record.CTACTE_PAGOS_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagos_persona_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PAGOS_PER_COMPEN_SALIDARow[])(recordList.ToArray(typeof(CTACTE_PAGOS_PER_COMPEN_SALIDARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PAGOS_PER_COMPEN_SALIDARow"/> object.</returns>
		protected virtual CTACTE_PAGOS_PER_COMPEN_SALIDARow MapRow(DataRow row)
		{
			CTACTE_PAGOS_PER_COMPEN_SALIDARow mappedObject = new CTACTE_PAGOS_PER_COMPEN_SALIDARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGOS_PERSONA_DOC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGOS_PERSONA_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGOS_PERSONA_DOC_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGOS_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGOS_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGOS_PERSONA_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PAGOS_PER_COMPEN_SALIDA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PAGOS_PER_COMPEN_SALIDA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGOS_PERSONA_DOC_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGOS_PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
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

				case "CTACTE_PAGOS_PERSONA_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGOS_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PAGOS_PER_COMPEN_SALIDACollection_Base class
}  // End of namespace
