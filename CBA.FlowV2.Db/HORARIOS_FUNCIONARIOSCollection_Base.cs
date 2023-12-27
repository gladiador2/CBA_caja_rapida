// <fileinfo name="HORARIOS_FUNCIONARIOSCollection_Base.cs">
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
	/// The base class for <see cref="HORARIOS_FUNCIONARIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="HORARIOS_FUNCIONARIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOS_FUNCIONARIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string HORARIO_IDColumnName = "HORARIO_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string EMPRESA_SECCION_IDColumnName = "EMPRESA_SECCION_ID";
		public const string EMPRESA_DEPARTAMENTO_IDColumnName = "EMPRESA_DEPARTAMENTO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_FUNCIONARIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public HORARIOS_FUNCIONARIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>HORARIOS_FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public virtual HORARIOS_FUNCIONARIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>HORARIOS_FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>HORARIOS_FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="HORARIOS_FUNCIONARIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="HORARIOS_FUNCIONARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public HORARIOS_FUNCIONARIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			HORARIOS_FUNCIONARIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public HORARIOS_FUNCIONARIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public virtual HORARIOS_FUNCIONARIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.HORARIOS_FUNCIONARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="HORARIOS_FUNCIONARIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="HORARIOS_FUNCIONARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual HORARIOS_FUNCIONARIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			HORARIOS_FUNCIONARIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="empresa_departamento_id">The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public virtual HORARIOS_FUNCIONARIOSRow[] GetByEMPRESA_DEPARTAMENTO_ID(string empresa_departamento_id)
		{
			return MapRecords(CreateGetByEMPRESA_DEPARTAMENTO_IDCommand(empresa_departamento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="empresa_departamento_id">The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEMPRESA_DEPARTAMENTO_IDAsDataTable(string empresa_departamento_id)
		{
			return MapRecordsToDataTable(CreateGetByEMPRESA_DEPARTAMENTO_IDCommand(empresa_departamento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_HORARIOS_FUNCIONARIOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="empresa_departamento_id">The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEMPRESA_DEPARTAMENTO_IDCommand(string empresa_departamento_id)
		{
			string whereSql = "";
			if(null == empresa_departamento_id)
				whereSql += "EMPRESA_DEPARTAMENTO_ID IS NULL";
			else
				whereSql += "EMPRESA_DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("EMPRESA_DEPARTAMENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != empresa_departamento_id)
				AddParameter(cmd, "EMPRESA_DEPARTAMENTO_ID", empresa_departamento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public HORARIOS_FUNCIONARIOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public virtual HORARIOS_FUNCIONARIOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_HOR</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public virtual HORARIOS_FUNCIONARIOSRow[] GetByHORARIO_ID(decimal horario_id)
		{
			return MapRecords(CreateGetByHORARIO_IDCommand(horario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_HOR</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByHORARIO_IDAsDataTable(decimal horario_id)
		{
			return MapRecordsToDataTable(CreateGetByHORARIO_IDCommand(horario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_HORARIOS_FUNCIONARIOS_HOR</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByHORARIO_IDCommand(decimal horario_id)
		{
			string whereSql = "";
			whereSql += "HORARIO_ID=" + _db.CreateSqlParameterName("HORARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "HORARIO_ID", horario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public HORARIOS_FUNCIONARIOSRow[] GetByEMPRESA_SECCION_ID(decimal empresa_seccion_id)
		{
			return GetByEMPRESA_SECCION_ID(empresa_seccion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		public virtual HORARIOS_FUNCIONARIOSRow[] GetByEMPRESA_SECCION_ID(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			return MapRecords(CreateGetByEMPRESA_SECCION_IDCommand(empresa_seccion_id, empresa_seccion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEMPRESA_SECCION_IDAsDataTable(decimal empresa_seccion_id)
		{
			return GetByEMPRESA_SECCION_IDAsDataTable(empresa_seccion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEMPRESA_SECCION_IDAsDataTable(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEMPRESA_SECCION_IDCommand(empresa_seccion_id, empresa_seccion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEMPRESA_SECCION_IDCommand(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			string whereSql = "";
			if(empresa_seccion_idNull)
				whereSql += "EMPRESA_SECCION_ID IS NULL";
			else
				whereSql += "EMPRESA_SECCION_ID=" + _db.CreateSqlParameterName("EMPRESA_SECCION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!empresa_seccion_idNull)
				AddParameter(cmd, "EMPRESA_SECCION_ID", empresa_seccion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>HORARIOS_FUNCIONARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HORARIOS_FUNCIONARIOSRow"/> object to be inserted.</param>
		public virtual void Insert(HORARIOS_FUNCIONARIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.HORARIOS_FUNCIONARIOS (" +
				"ID, " +
				"HORARIO_ID, " +
				"FUNCIONARIO_ID, " +
				"EMPRESA_SECCION_ID, " +
				"EMPRESA_DEPARTAMENTO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("HORARIO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("EMPRESA_SECCION_ID") + ", " +
				_db.CreateSqlParameterName("EMPRESA_DEPARTAMENTO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "HORARIO_ID", value.HORARIO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "EMPRESA_SECCION_ID",
				value.IsEMPRESA_SECCION_IDNull ? DBNull.Value : (object)value.EMPRESA_SECCION_ID);
			AddParameter(cmd, "EMPRESA_DEPARTAMENTO_ID", value.EMPRESA_DEPARTAMENTO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>HORARIOS_FUNCIONARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HORARIOS_FUNCIONARIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(HORARIOS_FUNCIONARIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.HORARIOS_FUNCIONARIOS SET " +
				"HORARIO_ID=" + _db.CreateSqlParameterName("HORARIO_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"EMPRESA_SECCION_ID=" + _db.CreateSqlParameterName("EMPRESA_SECCION_ID") + ", " +
				"EMPRESA_DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("EMPRESA_DEPARTAMENTO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "HORARIO_ID", value.HORARIO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "EMPRESA_SECCION_ID",
				value.IsEMPRESA_SECCION_IDNull ? DBNull.Value : (object)value.EMPRESA_SECCION_ID);
			AddParameter(cmd, "EMPRESA_DEPARTAMENTO_ID", value.EMPRESA_DEPARTAMENTO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>HORARIOS_FUNCIONARIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>HORARIOS_FUNCIONARIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>HORARIOS_FUNCIONARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HORARIOS_FUNCIONARIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(HORARIOS_FUNCIONARIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>HORARIOS_FUNCIONARIOS</c> table using
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
		/// Deletes records from the <c>HORARIOS_FUNCIONARIOS</c> table using the 
		/// <c>FK_HORARIOS_FUNCIONARIOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="empresa_departamento_id">The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEMPRESA_DEPARTAMENTO_ID(string empresa_departamento_id)
		{
			return CreateDeleteByEMPRESA_DEPARTAMENTO_IDCommand(empresa_departamento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_HORARIOS_FUNCIONARIOS_DEP</c> foreign key.
		/// </summary>
		/// <param name="empresa_departamento_id">The <c>EMPRESA_DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEMPRESA_DEPARTAMENTO_IDCommand(string empresa_departamento_id)
		{
			string whereSql = "";
			if(null == empresa_departamento_id)
				whereSql += "EMPRESA_DEPARTAMENTO_ID IS NULL";
			else
				whereSql += "EMPRESA_DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("EMPRESA_DEPARTAMENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != empresa_departamento_id)
				AddParameter(cmd, "EMPRESA_DEPARTAMENTO_ID", empresa_departamento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>HORARIOS_FUNCIONARIOS</c> table using the 
		/// <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>HORARIOS_FUNCIONARIOS</c> table using the 
		/// <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_HORARIOS_FUNCIONARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>HORARIOS_FUNCIONARIOS</c> table using the 
		/// <c>FK_HORARIOS_FUNCIONARIOS_HOR</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByHORARIO_ID(decimal horario_id)
		{
			return CreateDeleteByHORARIO_IDCommand(horario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_HORARIOS_FUNCIONARIOS_HOR</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByHORARIO_IDCommand(decimal horario_id)
		{
			string whereSql = "";
			whereSql += "HORARIO_ID=" + _db.CreateSqlParameterName("HORARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "HORARIO_ID", horario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>HORARIOS_FUNCIONARIOS</c> table using the 
		/// <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEMPRESA_SECCION_ID(decimal empresa_seccion_id)
		{
			return DeleteByEMPRESA_SECCION_ID(empresa_seccion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>HORARIOS_FUNCIONARIOS</c> table using the 
		/// <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEMPRESA_SECCION_ID(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			return CreateDeleteByEMPRESA_SECCION_IDCommand(empresa_seccion_id, empresa_seccion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_HORARIOS_FUNCIONARIOS_SEC</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEMPRESA_SECCION_IDCommand(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			string whereSql = "";
			if(empresa_seccion_idNull)
				whereSql += "EMPRESA_SECCION_ID IS NULL";
			else
				whereSql += "EMPRESA_SECCION_ID=" + _db.CreateSqlParameterName("EMPRESA_SECCION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!empresa_seccion_idNull)
				AddParameter(cmd, "EMPRESA_SECCION_ID", empresa_seccion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>HORARIOS_FUNCIONARIOS</c> records that match the specified criteria.
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
		/// to delete <c>HORARIOS_FUNCIONARIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.HORARIOS_FUNCIONARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>HORARIOS_FUNCIONARIOS</c> table.
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
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		protected HORARIOS_FUNCIONARIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		protected HORARIOS_FUNCIONARIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="HORARIOS_FUNCIONARIOSRow"/> objects.</returns>
		protected virtual HORARIOS_FUNCIONARIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int horario_idColumnIndex = reader.GetOrdinal("HORARIO_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int empresa_seccion_idColumnIndex = reader.GetOrdinal("EMPRESA_SECCION_ID");
			int empresa_departamento_idColumnIndex = reader.GetOrdinal("EMPRESA_DEPARTAMENTO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					HORARIOS_FUNCIONARIOSRow record = new HORARIOS_FUNCIONARIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.HORARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(horario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(empresa_seccion_idColumnIndex))
						record.EMPRESA_SECCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(empresa_seccion_idColumnIndex)), 9);
					if(!reader.IsDBNull(empresa_departamento_idColumnIndex))
						record.EMPRESA_DEPARTAMENTO_ID = Convert.ToString(reader.GetValue(empresa_departamento_idColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (HORARIOS_FUNCIONARIOSRow[])(recordList.ToArray(typeof(HORARIOS_FUNCIONARIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="HORARIOS_FUNCIONARIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="HORARIOS_FUNCIONARIOSRow"/> object.</returns>
		protected virtual HORARIOS_FUNCIONARIOSRow MapRow(DataRow row)
		{
			HORARIOS_FUNCIONARIOSRow mappedObject = new HORARIOS_FUNCIONARIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "HORARIO_ID"
			dataColumn = dataTable.Columns["HORARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "EMPRESA_SECCION_ID"
			dataColumn = dataTable.Columns["EMPRESA_SECCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_SECCION_ID = (decimal)row[dataColumn];
			// Column "EMPRESA_DEPARTAMENTO_ID"
			dataColumn = dataTable.Columns["EMPRESA_DEPARTAMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_DEPARTAMENTO_ID = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>HORARIOS_FUNCIONARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "HORARIOS_FUNCIONARIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HORARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EMPRESA_SECCION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EMPRESA_DEPARTAMENTO_ID", typeof(string));
			dataColumn.MaxLength = 100;
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

				case "HORARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_SECCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_DEPARTAMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of HORARIOS_FUNCIONARIOSCollection_Base class
}  // End of namespace
