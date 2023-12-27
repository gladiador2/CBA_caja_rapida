// <fileinfo name="COPARNCollection_Base.cs">
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
	/// The base class for <see cref="COPARNCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="COPARNCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COPARNCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHAColumnName = "FECHA";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string TIPO_COPARNColumnName = "TIPO_COPARN";
		public const string BOOKINGColumnName = "BOOKING";
		public const string CLIENTEColumnName = "CLIENTE";
		public const string CANTIDAD_CONTENEDORESColumnName = "CANTIDAD_CONTENEDORES";
		public const string BUQUEColumnName = "BUQUE";
		public const string NOMBRE_ARCHIVO_COPARNColumnName = "NOMBRE_ARCHIVO_COPARN";
		public const string ADJUNTO_IDColumnName = "ADJUNTO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string PROCESADOColumnName = "PROCESADO";
		public const string NOMINA_CONTENEDORES_IDColumnName = "NOMINA_CONTENEDORES_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="COPARNCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public COPARNCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>COPARN</c> table.
		/// </summary>
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public virtual COPARNRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>COPARN</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>COPARN</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="COPARNRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="COPARNRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public COPARNRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			COPARNRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COPARNRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public COPARNRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="COPARNRow"/> objects that 
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
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public virtual COPARNRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.COPARN";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="COPARNRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="COPARNRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual COPARNRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			COPARNRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COPARNRow"/> objects 
		/// by the <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public COPARNRow[] GetByADJUNTO_ID(decimal adjunto_id)
		{
			return GetByADJUNTO_ID(adjunto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="COPARNRow"/> objects 
		/// by the <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <param name="adjunto_idNull">true if the method ignores the adjunto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public virtual COPARNRow[] GetByADJUNTO_ID(decimal adjunto_id, bool adjunto_idNull)
		{
			return MapRecords(CreateGetByADJUNTO_IDCommand(adjunto_id, adjunto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByADJUNTO_IDAsDataTable(decimal adjunto_id)
		{
			return GetByADJUNTO_IDAsDataTable(adjunto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <param name="adjunto_idNull">true if the method ignores the adjunto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByADJUNTO_IDAsDataTable(decimal adjunto_id, bool adjunto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByADJUNTO_IDCommand(adjunto_id, adjunto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <param name="adjunto_idNull">true if the method ignores the adjunto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByADJUNTO_IDCommand(decimal adjunto_id, bool adjunto_idNull)
		{
			string whereSql = "";
			if(adjunto_idNull)
				whereSql += "ADJUNTO_ID IS NULL";
			else
				whereSql += "ADJUNTO_ID=" + _db.CreateSqlParameterName("ADJUNTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!adjunto_idNull)
				AddParameter(cmd, "ADJUNTO_ID", adjunto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="COPARNRow"/> objects 
		/// by the <c>FK_COPARN_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public virtual COPARNRow[] GetByLINEA_ID(decimal linea_id)
		{
			return MapRecords(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COPARN_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLINEA_IDAsDataTable(decimal linea_id)
		{
			return MapRecordsToDataTable(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COPARN_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLINEA_IDCommand(decimal linea_id)
		{
			string whereSql = "";
			whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="COPARNRow"/> objects 
		/// by the <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public COPARNRow[] GetByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id)
		{
			return GetByNOMINA_CONTENEDORES_ID(nomina_contenedores_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="COPARNRow"/> objects 
		/// by the <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		public virtual COPARNRow[] GetByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			return MapRecords(CreateGetByNOMINA_CONTENEDORES_IDCommand(nomina_contenedores_id, nomina_contenedores_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNOMINA_CONTENEDORES_IDAsDataTable(decimal nomina_contenedores_id)
		{
			return GetByNOMINA_CONTENEDORES_IDAsDataTable(nomina_contenedores_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNOMINA_CONTENEDORES_IDAsDataTable(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNOMINA_CONTENEDORES_IDCommand(nomina_contenedores_id, nomina_contenedores_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNOMINA_CONTENEDORES_IDCommand(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			string whereSql = "";
			if(nomina_contenedores_idNull)
				whereSql += "NOMINA_CONTENEDORES_ID IS NULL";
			else
				whereSql += "NOMINA_CONTENEDORES_ID=" + _db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nomina_contenedores_idNull)
				AddParameter(cmd, "NOMINA_CONTENEDORES_ID", nomina_contenedores_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>COPARN</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COPARNRow"/> object to be inserted.</param>
		public virtual void Insert(COPARNRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.COPARN (" +
				"ID, " +
				"FECHA, " +
				"LINEA_ID, " +
				"TIPO_COPARN, " +
				"BOOKING, " +
				"CLIENTE, " +
				"CANTIDAD_CONTENEDORES, " +
				"BUQUE, " +
				"NOMBRE_ARCHIVO_COPARN, " +
				"ADJUNTO_ID, " +
				"ESTADO, " +
				"PROCESADO, " +
				"NOMINA_CONTENEDORES_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("LINEA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_COPARN") + ", " +
				_db.CreateSqlParameterName("BOOKING") + ", " +
				_db.CreateSqlParameterName("CLIENTE") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CONTENEDORES") + ", " +
				_db.CreateSqlParameterName("BUQUE") + ", " +
				_db.CreateSqlParameterName("NOMBRE_ARCHIVO_COPARN") + ", " +
				_db.CreateSqlParameterName("ADJUNTO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("PROCESADO") + ", " +
				_db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "TIPO_COPARN", value.TIPO_COPARN);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "CLIENTE", value.CLIENTE);
			AddParameter(cmd, "CANTIDAD_CONTENEDORES", value.CANTIDAD_CONTENEDORES);
			AddParameter(cmd, "BUQUE", value.BUQUE);
			AddParameter(cmd, "NOMBRE_ARCHIVO_COPARN", value.NOMBRE_ARCHIVO_COPARN);
			AddParameter(cmd, "ADJUNTO_ID",
				value.IsADJUNTO_IDNull ? DBNull.Value : (object)value.ADJUNTO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PROCESADO", value.PROCESADO);
			AddParameter(cmd, "NOMINA_CONTENEDORES_ID",
				value.IsNOMINA_CONTENEDORES_IDNull ? DBNull.Value : (object)value.NOMINA_CONTENEDORES_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>COPARN</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COPARNRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(COPARNRow value)
		{
			
			string sqlStr = "UPDATE TRC.COPARN SET " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID") + ", " +
				"TIPO_COPARN=" + _db.CreateSqlParameterName("TIPO_COPARN") + ", " +
				"BOOKING=" + _db.CreateSqlParameterName("BOOKING") + ", " +
				"CLIENTE=" + _db.CreateSqlParameterName("CLIENTE") + ", " +
				"CANTIDAD_CONTENEDORES=" + _db.CreateSqlParameterName("CANTIDAD_CONTENEDORES") + ", " +
				"BUQUE=" + _db.CreateSqlParameterName("BUQUE") + ", " +
				"NOMBRE_ARCHIVO_COPARN=" + _db.CreateSqlParameterName("NOMBRE_ARCHIVO_COPARN") + ", " +
				"ADJUNTO_ID=" + _db.CreateSqlParameterName("ADJUNTO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"PROCESADO=" + _db.CreateSqlParameterName("PROCESADO") + ", " +
				"NOMINA_CONTENEDORES_ID=" + _db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "TIPO_COPARN", value.TIPO_COPARN);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "CLIENTE", value.CLIENTE);
			AddParameter(cmd, "CANTIDAD_CONTENEDORES", value.CANTIDAD_CONTENEDORES);
			AddParameter(cmd, "BUQUE", value.BUQUE);
			AddParameter(cmd, "NOMBRE_ARCHIVO_COPARN", value.NOMBRE_ARCHIVO_COPARN);
			AddParameter(cmd, "ADJUNTO_ID",
				value.IsADJUNTO_IDNull ? DBNull.Value : (object)value.ADJUNTO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PROCESADO", value.PROCESADO);
			AddParameter(cmd, "NOMINA_CONTENEDORES_ID",
				value.IsNOMINA_CONTENEDORES_IDNull ? DBNull.Value : (object)value.NOMINA_CONTENEDORES_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>COPARN</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>COPARN</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>COPARN</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COPARNRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(COPARNRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>COPARN</c> table using
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
		/// Deletes records from the <c>COPARN</c> table using the 
		/// <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByADJUNTO_ID(decimal adjunto_id)
		{
			return DeleteByADJUNTO_ID(adjunto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>COPARN</c> table using the 
		/// <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <param name="adjunto_idNull">true if the method ignores the adjunto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByADJUNTO_ID(decimal adjunto_id, bool adjunto_idNull)
		{
			return CreateDeleteByADJUNTO_IDCommand(adjunto_id, adjunto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COPARN_ADJUNTO_ID</c> foreign key.
		/// </summary>
		/// <param name="adjunto_id">The <c>ADJUNTO_ID</c> column value.</param>
		/// <param name="adjunto_idNull">true if the method ignores the adjunto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByADJUNTO_IDCommand(decimal adjunto_id, bool adjunto_idNull)
		{
			string whereSql = "";
			if(adjunto_idNull)
				whereSql += "ADJUNTO_ID IS NULL";
			else
				whereSql += "ADJUNTO_ID=" + _db.CreateSqlParameterName("ADJUNTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!adjunto_idNull)
				AddParameter(cmd, "ADJUNTO_ID", adjunto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>COPARN</c> table using the 
		/// <c>FK_COPARN_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id)
		{
			return CreateDeleteByLINEA_IDCommand(linea_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COPARN_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLINEA_IDCommand(decimal linea_id)
		{
			string whereSql = "";
			whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>COPARN</c> table using the 
		/// <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id)
		{
			return DeleteByNOMINA_CONTENEDORES_ID(nomina_contenedores_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>COPARN</c> table using the 
		/// <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOMINA_CONTENEDORES_ID(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			return CreateDeleteByNOMINA_CONTENEDORES_IDCommand(nomina_contenedores_id, nomina_contenedores_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COPARN_NOMINA_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="nomina_contenedores_id">The <c>NOMINA_CONTENEDORES_ID</c> column value.</param>
		/// <param name="nomina_contenedores_idNull">true if the method ignores the nomina_contenedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNOMINA_CONTENEDORES_IDCommand(decimal nomina_contenedores_id, bool nomina_contenedores_idNull)
		{
			string whereSql = "";
			if(nomina_contenedores_idNull)
				whereSql += "NOMINA_CONTENEDORES_ID IS NULL";
			else
				whereSql += "NOMINA_CONTENEDORES_ID=" + _db.CreateSqlParameterName("NOMINA_CONTENEDORES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nomina_contenedores_idNull)
				AddParameter(cmd, "NOMINA_CONTENEDORES_ID", nomina_contenedores_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>COPARN</c> records that match the specified criteria.
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
		/// to delete <c>COPARN</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.COPARN";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>COPARN</c> table.
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
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		protected COPARNRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		protected COPARNRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="COPARNRow"/> objects.</returns>
		protected virtual COPARNRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int tipo_coparnColumnIndex = reader.GetOrdinal("TIPO_COPARN");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int clienteColumnIndex = reader.GetOrdinal("CLIENTE");
			int cantidad_contenedoresColumnIndex = reader.GetOrdinal("CANTIDAD_CONTENEDORES");
			int buqueColumnIndex = reader.GetOrdinal("BUQUE");
			int nombre_archivo_coparnColumnIndex = reader.GetOrdinal("NOMBRE_ARCHIVO_COPARN");
			int adjunto_idColumnIndex = reader.GetOrdinal("ADJUNTO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int procesadoColumnIndex = reader.GetOrdinal("PROCESADO");
			int nomina_contenedores_idColumnIndex = reader.GetOrdinal("NOMINA_CONTENEDORES_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					COPARNRow record = new COPARNRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					record.TIPO_COPARN = Convert.ToString(reader.GetValue(tipo_coparnColumnIndex));
					record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(clienteColumnIndex))
						record.CLIENTE = Convert.ToString(reader.GetValue(clienteColumnIndex));
					record.CANTIDAD_CONTENEDORES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_contenedoresColumnIndex)), 9);
					if(!reader.IsDBNull(buqueColumnIndex))
						record.BUQUE = Convert.ToString(reader.GetValue(buqueColumnIndex));
					record.NOMBRE_ARCHIVO_COPARN = Convert.ToString(reader.GetValue(nombre_archivo_coparnColumnIndex));
					if(!reader.IsDBNull(adjunto_idColumnIndex))
						record.ADJUNTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(adjunto_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.PROCESADO = Convert.ToString(reader.GetValue(procesadoColumnIndex));
					if(!reader.IsDBNull(nomina_contenedores_idColumnIndex))
						record.NOMINA_CONTENEDORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nomina_contenedores_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (COPARNRow[])(recordList.ToArray(typeof(COPARNRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="COPARNRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="COPARNRow"/> object.</returns>
		protected virtual COPARNRow MapRow(DataRow row)
		{
			COPARNRow mappedObject = new COPARNRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "TIPO_COPARN"
			dataColumn = dataTable.Columns["TIPO_COPARN"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_COPARN = (string)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "CLIENTE"
			dataColumn = dataTable.Columns["CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLIENTE = (string)row[dataColumn];
			// Column "CANTIDAD_CONTENEDORES"
			dataColumn = dataTable.Columns["CANTIDAD_CONTENEDORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CONTENEDORES = (decimal)row[dataColumn];
			// Column "BUQUE"
			dataColumn = dataTable.Columns["BUQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE = (string)row[dataColumn];
			// Column "NOMBRE_ARCHIVO_COPARN"
			dataColumn = dataTable.Columns["NOMBRE_ARCHIVO_COPARN"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_ARCHIVO_COPARN = (string)row[dataColumn];
			// Column "ADJUNTO_ID"
			dataColumn = dataTable.Columns["ADJUNTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ADJUNTO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PROCESADO"
			dataColumn = dataTable.Columns["PROCESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADO = (string)row[dataColumn];
			// Column "NOMINA_CONTENEDORES_ID"
			dataColumn = dataTable.Columns["NOMINA_CONTENEDORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMINA_CONTENEDORES_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>COPARN</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "COPARN";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_COPARN", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CLIENTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CONTENEDORES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BUQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NOMBRE_ARCHIVO_COPARN", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ADJUNTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROCESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMINA_CONTENEDORES_ID", typeof(decimal));
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

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_COPARN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CONTENEDORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BUQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_ARCHIVO_COPARN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ADJUNTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROCESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMINA_CONTENEDORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of COPARNCollection_Base class
}  // End of namespace
