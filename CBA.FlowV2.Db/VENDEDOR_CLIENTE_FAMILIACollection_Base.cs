// <fileinfo name="VENDEDOR_CLIENTE_FAMILIACollection_Base.cs">
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
	/// The base class for <see cref="VENDEDOR_CLIENTE_FAMILIACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="VENDEDOR_CLIENTE_FAMILIACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class VENDEDOR_CLIENTE_FAMILIACollection_Base
	{
		// Constants
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="VENDEDOR_CLIENTE_FAMILIACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public VENDEDOR_CLIENTE_FAMILIACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		public virtual VENDEDOR_CLIENTE_FAMILIARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public VENDEDOR_CLIENTE_FAMILIARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			VENDEDOR_CLIENTE_FAMILIARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		public VENDEDOR_CLIENTE_FAMILIARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects that 
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
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		public virtual VENDEDOR_CLIENTE_FAMILIARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.VENDEDOR_CLIENTE_FAMILIA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> by the primary key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>An instance of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual VENDEDOR_CLIENTE_FAMILIARow GetByPrimaryKey(decimal funcionario_id, decimal persona_id, decimal articulo_familia_id)
		{
			string whereSql = "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + " AND " +
							  "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + " AND " +
							  "ARTICULO_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULO_FAMILIA_ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			AddParameter(cmd, "ARTICULO_FAMILIA_ID", articulo_familia_id);
			VENDEDOR_CLIENTE_FAMILIARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects 
		/// by the <c>FK_VEND_CLI_FAM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		public virtual VENDEDOR_CLIENTE_FAMILIARow[] GetByARTICULO_FAMILIA_ID(decimal articulo_familia_id)
		{
			return MapRecords(CreateGetByARTICULO_FAMILIA_IDCommand(articulo_familia_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEND_CLI_FAM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_FAMILIA_IDAsDataTable(decimal articulo_familia_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_FAMILIA_IDCommand(articulo_familia_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_VEND_CLI_FAM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_FAMILIA_IDCommand(decimal articulo_familia_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULO_FAMILIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_FAMILIA_ID", articulo_familia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects 
		/// by the <c>FK_VEND_CLI_FAM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		public virtual VENDEDOR_CLIENTE_FAMILIARow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEND_CLI_FAM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_VEND_CLI_FAM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects 
		/// by the <c>FK_VEND_CLI_FAM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		public virtual VENDEDOR_CLIENTE_FAMILIARow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_VEND_CLI_FAM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_VEND_CLI_FAM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> object to be inserted.</param>
		public virtual void Insert(VENDEDOR_CLIENTE_FAMILIARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.VENDEDOR_CLIENTE_FAMILIA (" +
				"FUNCIONARIO_ID, " +
				"PERSONA_ID, " +
				"ARTICULO_FAMILIA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_FAMILIA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "ARTICULO_FAMILIA_ID", value.ARTICULO_FAMILIA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes the specified object from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(VENDEDOR_CLIENTE_FAMILIARow value)
		{
			return DeleteByPrimaryKey(value.FUNCIONARIO_ID, value.PERSONA_ID, value.ARTICULO_FAMILIA_ID);
		}

		/// <summary>
		/// Deletes a record from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal funcionario_id, decimal persona_id, decimal articulo_familia_id)
		{
			string whereSql = "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + " AND " +
							  "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + " AND " +
							  "ARTICULO_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULO_FAMILIA_ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			AddParameter(cmd, "ARTICULO_FAMILIA_ID", articulo_familia_id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table using the 
		/// <c>FK_VEND_CLI_FAM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_FAMILIA_ID(decimal articulo_familia_id)
		{
			return CreateDeleteByARTICULO_FAMILIA_IDCommand(articulo_familia_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_VEND_CLI_FAM_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="articulo_familia_id">The <c>ARTICULO_FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_FAMILIA_IDCommand(decimal articulo_familia_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_FAMILIA_ID=" + _db.CreateSqlParameterName("ARTICULO_FAMILIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_FAMILIA_ID", articulo_familia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table using the 
		/// <c>FK_VEND_CLI_FAM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_VEND_CLI_FAM_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table using the 
		/// <c>FK_VEND_CLI_FAM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_VEND_CLI_FAM_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>VENDEDOR_CLIENTE_FAMILIA</c> records that match the specified criteria.
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
		/// to delete <c>VENDEDOR_CLIENTE_FAMILIA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.VENDEDOR_CLIENTE_FAMILIA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
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
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		protected VENDEDOR_CLIENTE_FAMILIARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		protected VENDEDOR_CLIENTE_FAMILIARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> objects.</returns>
		protected virtual VENDEDOR_CLIENTE_FAMILIARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					VENDEDOR_CLIENTE_FAMILIARow record = new VENDEDOR_CLIENTE_FAMILIARow();
					recordList.Add(record);

					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (VENDEDOR_CLIENTE_FAMILIARow[])(recordList.ToArray(typeof(VENDEDOR_CLIENTE_FAMILIARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="VENDEDOR_CLIENTE_FAMILIARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="VENDEDOR_CLIENTE_FAMILIARow"/> object.</returns>
		protected virtual VENDEDOR_CLIENTE_FAMILIARow MapRow(DataRow row)
		{
			VENDEDOR_CLIENTE_FAMILIARow mappedObject = new VENDEDOR_CLIENTE_FAMILIARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>VENDEDOR_CLIENTE_FAMILIA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "VENDEDOR_CLIENTE_FAMILIA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
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
				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of VENDEDOR_CLIENTE_FAMILIACollection_Base class
}  // End of namespace
