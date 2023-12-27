// <fileinfo name="ITEMS_INGRESO_DEPOSITOCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESO_DEPOSITOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_INGRESO_DEPOSITOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESO_DEPOSITOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEMS_INGRESO_IDColumnName = "ITEMS_INGRESO_ID";
		public const string FECHA_INGRESOColumnName = "FECHA_INGRESO";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string GENERACION_CONFIRMADAColumnName = "GENERACION_CONFIRMADA";
		public const string INGRESO_CONFIRMADOColumnName = "INGRESO_CONFIRMADO";
		public const string NUMERO_COMPROBANTEColumnName = "NUMERO_COMPROBANTE";
		public const string PRECINTOSColumnName = "PRECINTOS";
		public const string INICIOColumnName = "INICIO";
		public const string FINColumnName = "FIN";
		public const string DESPACHOColumnName = "DESPACHO";
		public const string IDA3ColumnName = "IDA3";
		public const string ICColumnName = "IC";
		public const string OTROSColumnName = "OTROS";
		public const string SEMANAColumnName = "SEMANA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESO_DEPOSITOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_INGRESO_DEPOSITOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_INGRESO_DEPOSITO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_INGRESO_DEPOSITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_INGRESO_DEPOSITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESO_DEPOSITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_INGRESO_DEPOSITORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_INGRESO_DEPOSITORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		public ITEMS_INGRESO_DEPOSITORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_INGRESO_DEPOSITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ITEMS_INGRESO_DEPOSITORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESO_DEPOSITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ITEMS_INGRESO_DEPOSITORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ITEMS_INGRESO_DEPOSITORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects 
		/// by the <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		public ITEMS_INGRESO_DEPOSITORow[] GetByITEMS_INGRESO_ID(decimal items_ingreso_id)
		{
			return GetByITEMS_INGRESO_ID(items_ingreso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects 
		/// by the <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITORow[] GetByITEMS_INGRESO_ID(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			return MapRecords(CreateGetByITEMS_INGRESO_IDCommand(items_ingreso_id, items_ingreso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEMS_INGRESO_IDAsDataTable(decimal items_ingreso_id)
		{
			return GetByITEMS_INGRESO_IDAsDataTable(items_ingreso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEMS_INGRESO_IDAsDataTable(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEMS_INGRESO_IDCommand(items_ingreso_id, items_ingreso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEMS_INGRESO_IDCommand(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			string whereSql = "";
			if(items_ingreso_idNull)
				whereSql += "ITEMS_INGRESO_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!items_ingreso_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_ID", items_ingreso_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ITEMS_INGRESO_DEPOSITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESO_DEPOSITORow"/> object to be inserted.</param>
		public virtual void Insert(ITEMS_INGRESO_DEPOSITORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ITEMS_INGRESO_DEPOSITO (" +
				"ID, " +
				"ITEMS_INGRESO_ID, " +
				"FECHA_INGRESO, " +
				"FECHA_EMISION, " +
				"GENERACION_CONFIRMADA, " +
				"INGRESO_CONFIRMADO, " +
				"NUMERO_COMPROBANTE, " +
				"PRECINTOS, " +
				"INICIO, " +
				"FIN, " +
				"DESPACHO, " +
				"IDA3, " +
				"IC, " +
				"OTROS, " +
				"SEMANA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ITEMS_INGRESO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				_db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				_db.CreateSqlParameterName("GENERACION_CONFIRMADA") + ", " +
				_db.CreateSqlParameterName("INGRESO_CONFIRMADO") + ", " +
				_db.CreateSqlParameterName("NUMERO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("PRECINTOS") + ", " +
				_db.CreateSqlParameterName("INICIO") + ", " +
				_db.CreateSqlParameterName("FIN") + ", " +
				_db.CreateSqlParameterName("DESPACHO") + ", " +
				_db.CreateSqlParameterName("IDA3") + ", " +
				_db.CreateSqlParameterName("IC") + ", " +
				_db.CreateSqlParameterName("OTROS") + ", " +
				_db.CreateSqlParameterName("SEMANA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ITEMS_INGRESO_ID",
				value.IsITEMS_INGRESO_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_ID);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "FECHA_EMISION",
				value.IsFECHA_EMISIONNull ? DBNull.Value : (object)value.FECHA_EMISION);
			AddParameter(cmd, "GENERACION_CONFIRMADA", value.GENERACION_CONFIRMADA);
			AddParameter(cmd, "INGRESO_CONFIRMADO", value.INGRESO_CONFIRMADO);
			AddParameter(cmd, "NUMERO_COMPROBANTE", value.NUMERO_COMPROBANTE);
			AddParameter(cmd, "PRECINTOS", value.PRECINTOS);
			AddParameter(cmd, "INICIO",
				value.IsINICIONull ? DBNull.Value : (object)value.INICIO);
			AddParameter(cmd, "FIN",
				value.IsFINNull ? DBNull.Value : (object)value.FIN);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "IDA3", value.IDA3);
			AddParameter(cmd, "IC", value.IC);
			AddParameter(cmd, "OTROS", value.OTROS);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ITEMS_INGRESO_DEPOSITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESO_DEPOSITORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ITEMS_INGRESO_DEPOSITORow value)
		{
			
			string sqlStr = "UPDATE TRC.ITEMS_INGRESO_DEPOSITO SET " +
				"ITEMS_INGRESO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_ID") + ", " +
				"FECHA_INGRESO=" + _db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				"FECHA_EMISION=" + _db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				"GENERACION_CONFIRMADA=" + _db.CreateSqlParameterName("GENERACION_CONFIRMADA") + ", " +
				"INGRESO_CONFIRMADO=" + _db.CreateSqlParameterName("INGRESO_CONFIRMADO") + ", " +
				"NUMERO_COMPROBANTE=" + _db.CreateSqlParameterName("NUMERO_COMPROBANTE") + ", " +
				"PRECINTOS=" + _db.CreateSqlParameterName("PRECINTOS") + ", " +
				"INICIO=" + _db.CreateSqlParameterName("INICIO") + ", " +
				"FIN=" + _db.CreateSqlParameterName("FIN") + ", " +
				"DESPACHO=" + _db.CreateSqlParameterName("DESPACHO") + ", " +
				"IDA3=" + _db.CreateSqlParameterName("IDA3") + ", " +
				"IC=" + _db.CreateSqlParameterName("IC") + ", " +
				"OTROS=" + _db.CreateSqlParameterName("OTROS") + ", " +
				"SEMANA=" + _db.CreateSqlParameterName("SEMANA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ITEMS_INGRESO_ID",
				value.IsITEMS_INGRESO_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_ID);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "FECHA_EMISION",
				value.IsFECHA_EMISIONNull ? DBNull.Value : (object)value.FECHA_EMISION);
			AddParameter(cmd, "GENERACION_CONFIRMADA", value.GENERACION_CONFIRMADA);
			AddParameter(cmd, "INGRESO_CONFIRMADO", value.INGRESO_CONFIRMADO);
			AddParameter(cmd, "NUMERO_COMPROBANTE", value.NUMERO_COMPROBANTE);
			AddParameter(cmd, "PRECINTOS", value.PRECINTOS);
			AddParameter(cmd, "INICIO",
				value.IsINICIONull ? DBNull.Value : (object)value.INICIO);
			AddParameter(cmd, "FIN",
				value.IsFINNull ? DBNull.Value : (object)value.FIN);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "IDA3", value.IDA3);
			AddParameter(cmd, "IC", value.IC);
			AddParameter(cmd, "OTROS", value.OTROS);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESO_DEPOSITO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESO_DEPOSITO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ITEMS_INGRESO_DEPOSITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESO_DEPOSITORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ITEMS_INGRESO_DEPOSITORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ITEMS_INGRESO_DEPOSITO</c> table using
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
		/// Deletes records from the <c>ITEMS_INGRESO_DEPOSITO</c> table using the 
		/// <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_ID(decimal items_ingreso_id)
		{
			return DeleteByITEMS_INGRESO_ID(items_ingreso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESO_DEPOSITO</c> table using the 
		/// <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_ID(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			return CreateDeleteByITEMS_INGRESO_IDCommand(items_ingreso_id, items_ingreso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IT_ING_DEP_IT_INGRE_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEMS_INGRESO_IDCommand(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			string whereSql = "";
			if(items_ingreso_idNull)
				whereSql += "ITEMS_INGRESO_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!items_ingreso_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_ID", items_ingreso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ITEMS_INGRESO_DEPOSITO</c> records that match the specified criteria.
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
		/// to delete <c>ITEMS_INGRESO_DEPOSITO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ITEMS_INGRESO_DEPOSITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ITEMS_INGRESO_DEPOSITO</c> table.
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		protected ITEMS_INGRESO_DEPOSITORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		protected ITEMS_INGRESO_DEPOSITORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITORow"/> objects.</returns>
		protected virtual ITEMS_INGRESO_DEPOSITORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int items_ingreso_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_ID");
			int fecha_ingresoColumnIndex = reader.GetOrdinal("FECHA_INGRESO");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int generacion_confirmadaColumnIndex = reader.GetOrdinal("GENERACION_CONFIRMADA");
			int ingreso_confirmadoColumnIndex = reader.GetOrdinal("INGRESO_CONFIRMADO");
			int numero_comprobanteColumnIndex = reader.GetOrdinal("NUMERO_COMPROBANTE");
			int precintosColumnIndex = reader.GetOrdinal("PRECINTOS");
			int inicioColumnIndex = reader.GetOrdinal("INICIO");
			int finColumnIndex = reader.GetOrdinal("FIN");
			int despachoColumnIndex = reader.GetOrdinal("DESPACHO");
			int ida3ColumnIndex = reader.GetOrdinal("IDA3");
			int icColumnIndex = reader.GetOrdinal("IC");
			int otrosColumnIndex = reader.GetOrdinal("OTROS");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_INGRESO_DEPOSITORow record = new ITEMS_INGRESO_DEPOSITORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingreso_idColumnIndex))
						record.ITEMS_INGRESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ingresoColumnIndex))
						record.FECHA_INGRESO = Convert.ToDateTime(reader.GetValue(fecha_ingresoColumnIndex));
					if(!reader.IsDBNull(fecha_emisionColumnIndex))
						record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(generacion_confirmadaColumnIndex))
						record.GENERACION_CONFIRMADA = Convert.ToString(reader.GetValue(generacion_confirmadaColumnIndex));
					if(!reader.IsDBNull(ingreso_confirmadoColumnIndex))
						record.INGRESO_CONFIRMADO = Convert.ToString(reader.GetValue(ingreso_confirmadoColumnIndex));
					if(!reader.IsDBNull(numero_comprobanteColumnIndex))
						record.NUMERO_COMPROBANTE = Convert.ToString(reader.GetValue(numero_comprobanteColumnIndex));
					if(!reader.IsDBNull(precintosColumnIndex))
						record.PRECINTOS = Convert.ToString(reader.GetValue(precintosColumnIndex));
					if(!reader.IsDBNull(inicioColumnIndex))
						record.INICIO = Convert.ToDateTime(reader.GetValue(inicioColumnIndex));
					if(!reader.IsDBNull(finColumnIndex))
						record.FIN = Convert.ToDateTime(reader.GetValue(finColumnIndex));
					if(!reader.IsDBNull(despachoColumnIndex))
						record.DESPACHO = Convert.ToString(reader.GetValue(despachoColumnIndex));
					if(!reader.IsDBNull(ida3ColumnIndex))
						record.IDA3 = Convert.ToString(reader.GetValue(ida3ColumnIndex));
					if(!reader.IsDBNull(icColumnIndex))
						record.IC = Convert.ToString(reader.GetValue(icColumnIndex));
					if(!reader.IsDBNull(otrosColumnIndex))
						record.OTROS = Convert.ToString(reader.GetValue(otrosColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_INGRESO_DEPOSITORow[])(recordList.ToArray(typeof(ITEMS_INGRESO_DEPOSITORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_INGRESO_DEPOSITORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_INGRESO_DEPOSITORow"/> object.</returns>
		protected virtual ITEMS_INGRESO_DEPOSITORow MapRow(DataRow row)
		{
			ITEMS_INGRESO_DEPOSITORow mappedObject = new ITEMS_INGRESO_DEPOSITORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESO_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_ID = (decimal)row[dataColumn];
			// Column "FECHA_INGRESO"
			dataColumn = dataTable.Columns["FECHA_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO = (System.DateTime)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "GENERACION_CONFIRMADA"
			dataColumn = dataTable.Columns["GENERACION_CONFIRMADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERACION_CONFIRMADA = (string)row[dataColumn];
			// Column "INGRESO_CONFIRMADO"
			dataColumn = dataTable.Columns["INGRESO_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_CONFIRMADO = (string)row[dataColumn];
			// Column "NUMERO_COMPROBANTE"
			dataColumn = dataTable.Columns["NUMERO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_COMPROBANTE = (string)row[dataColumn];
			// Column "PRECINTOS"
			dataColumn = dataTable.Columns["PRECINTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTOS = (string)row[dataColumn];
			// Column "INICIO"
			dataColumn = dataTable.Columns["INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INICIO = (System.DateTime)row[dataColumn];
			// Column "FIN"
			dataColumn = dataTable.Columns["FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FIN = (System.DateTime)row[dataColumn];
			// Column "DESPACHO"
			dataColumn = dataTable.Columns["DESPACHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO = (string)row[dataColumn];
			// Column "IDA3"
			dataColumn = dataTable.Columns["IDA3"];
			if(!row.IsNull(dataColumn))
				mappedObject.IDA3 = (string)row[dataColumn];
			// Column "IC"
			dataColumn = dataTable.Columns["IC"];
			if(!row.IsNull(dataColumn))
				mappedObject.IC = (string)row[dataColumn];
			// Column "OTROS"
			dataColumn = dataTable.Columns["OTROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.OTROS = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_INGRESO_DEPOSITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_INGRESO_DEPOSITO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("GENERACION_CONFIRMADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("INGRESO_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NUMERO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("PRECINTOS", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("DESPACHO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn = dataTable.Columns.Add("IDA3", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("IC", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("OTROS", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
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

				case "ITEMS_INGRESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "GENERACION_CONFIRMADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INGRESO_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NUMERO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESPACHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IDA3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OTROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_INGRESO_DEPOSITOCollection_Base class
}  // End of namespace
