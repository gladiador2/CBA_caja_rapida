// <fileinfo name="CONTRATOS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="CONTRATOS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTRATOS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTRATOS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CONTRATO_IDColumnName = "CONTRATO_ID";
		public const string TITULO_ETAPAColumnName = "TITULO_ETAPA";
		public const string DESCRIPCIO_ETAPAColumnName = "DESCRIPCIO_ETAPA";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string ESTADO_ETAPAColumnName = "ESTADO_ETAPA";
		public const string MONTO_ETAPAColumnName = "MONTO_ETAPA";
		public const string REQUERIMIENTO_COBRARColumnName = "REQUERIMIENTO_COBRAR";
		public const string COBRADOColumnName = "COBRADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTRATOS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTRATOS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTRATOS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONTRATOS_DETALLESRow"/> objects.</returns>
		public virtual CONTRATOS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTRATOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTRATOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTRATOS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTRATOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTRATOS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTRATOS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTRATOS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTRATOS_DETALLESRow"/> objects.</returns>
		public CONTRATOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTRATOS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="CONTRATOS_DETALLESRow"/> objects.</returns>
		public virtual CONTRATOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTRATOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONTRATOS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONTRATOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONTRATOS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONTRATOS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTRATOS_DETALLESRow"/> objects 
		/// by the <c>FK_CONTRATOS_DETALLE_CONT</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTRATOS_DETALLESRow"/> objects.</returns>
		public virtual CONTRATOS_DETALLESRow[] GetByCONTRATO_ID(decimal contrato_id)
		{
			return MapRecords(CreateGetByCONTRATO_IDCommand(contrato_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTRATOS_DETALLE_CONT</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTRATO_IDAsDataTable(decimal contrato_id)
		{
			return MapRecordsToDataTable(CreateGetByCONTRATO_IDCommand(contrato_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTRATOS_DETALLE_CONT</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTRATO_IDCommand(decimal contrato_id)
		{
			string whereSql = "";
			whereSql += "CONTRATO_ID=" + _db.CreateSqlParameterName("CONTRATO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONTRATO_ID", contrato_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CONTRATOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTRATOS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(CONTRATOS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONTRATOS_DETALLES (" +
				"ID, " +
				"CONTRATO_ID, " +
				"TITULO_ETAPA, " +
				"DESCRIPCIO_ETAPA, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"ESTADO_ETAPA, " +
				"MONTO_ETAPA, " +
				"REQUERIMIENTO_COBRAR, " +
				"COBRADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CONTRATO_ID") + ", " +
				_db.CreateSqlParameterName("TITULO_ETAPA") + ", " +
				_db.CreateSqlParameterName("DESCRIPCIO_ETAPA") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("ESTADO_ETAPA") + ", " +
				_db.CreateSqlParameterName("MONTO_ETAPA") + ", " +
				_db.CreateSqlParameterName("REQUERIMIENTO_COBRAR") + ", " +
				_db.CreateSqlParameterName("COBRADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CONTRATO_ID", value.CONTRATO_ID);
			AddParameter(cmd, "TITULO_ETAPA", value.TITULO_ETAPA);
			AddParameter(cmd, "DESCRIPCIO_ETAPA", value.DESCRIPCIO_ETAPA);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "ESTADO_ETAPA", value.ESTADO_ETAPA);
			AddParameter(cmd, "MONTO_ETAPA",
				value.IsMONTO_ETAPANull ? DBNull.Value : (object)value.MONTO_ETAPA);
			AddParameter(cmd, "REQUERIMIENTO_COBRAR", value.REQUERIMIENTO_COBRAR);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONTRATOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTRATOS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONTRATOS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONTRATOS_DETALLES SET " +
				"CONTRATO_ID=" + _db.CreateSqlParameterName("CONTRATO_ID") + ", " +
				"TITULO_ETAPA=" + _db.CreateSqlParameterName("TITULO_ETAPA") + ", " +
				"DESCRIPCIO_ETAPA=" + _db.CreateSqlParameterName("DESCRIPCIO_ETAPA") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"ESTADO_ETAPA=" + _db.CreateSqlParameterName("ESTADO_ETAPA") + ", " +
				"MONTO_ETAPA=" + _db.CreateSqlParameterName("MONTO_ETAPA") + ", " +
				"REQUERIMIENTO_COBRAR=" + _db.CreateSqlParameterName("REQUERIMIENTO_COBRAR") + ", " +
				"COBRADO=" + _db.CreateSqlParameterName("COBRADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CONTRATO_ID", value.CONTRATO_ID);
			AddParameter(cmd, "TITULO_ETAPA", value.TITULO_ETAPA);
			AddParameter(cmd, "DESCRIPCIO_ETAPA", value.DESCRIPCIO_ETAPA);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "ESTADO_ETAPA", value.ESTADO_ETAPA);
			AddParameter(cmd, "MONTO_ETAPA",
				value.IsMONTO_ETAPANull ? DBNull.Value : (object)value.MONTO_ETAPA);
			AddParameter(cmd, "REQUERIMIENTO_COBRAR", value.REQUERIMIENTO_COBRAR);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONTRATOS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONTRATOS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONTRATOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTRATOS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONTRATOS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONTRATOS_DETALLES</c> table using
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
		/// Deletes records from the <c>CONTRATOS_DETALLES</c> table using the 
		/// <c>FK_CONTRATOS_DETALLE_CONT</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTRATO_ID(decimal contrato_id)
		{
			return CreateDeleteByCONTRATO_IDCommand(contrato_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTRATOS_DETALLE_CONT</c> foreign key.
		/// </summary>
		/// <param name="contrato_id">The <c>CONTRATO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTRATO_IDCommand(decimal contrato_id)
		{
			string whereSql = "";
			whereSql += "CONTRATO_ID=" + _db.CreateSqlParameterName("CONTRATO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONTRATO_ID", contrato_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CONTRATOS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>CONTRATOS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONTRATOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONTRATOS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="CONTRATOS_DETALLESRow"/> objects.</returns>
		protected CONTRATOS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTRATOS_DETALLESRow"/> objects.</returns>
		protected CONTRATOS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTRATOS_DETALLESRow"/> objects.</returns>
		protected virtual CONTRATOS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int contrato_idColumnIndex = reader.GetOrdinal("CONTRATO_ID");
			int titulo_etapaColumnIndex = reader.GetOrdinal("TITULO_ETAPA");
			int descripcio_etapaColumnIndex = reader.GetOrdinal("DESCRIPCIO_ETAPA");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int estado_etapaColumnIndex = reader.GetOrdinal("ESTADO_ETAPA");
			int monto_etapaColumnIndex = reader.GetOrdinal("MONTO_ETAPA");
			int requerimiento_cobrarColumnIndex = reader.GetOrdinal("REQUERIMIENTO_COBRAR");
			int cobradoColumnIndex = reader.GetOrdinal("COBRADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTRATOS_DETALLESRow record = new CONTRATOS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CONTRATO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contrato_idColumnIndex)), 9);
					if(!reader.IsDBNull(titulo_etapaColumnIndex))
						record.TITULO_ETAPA = Convert.ToString(reader.GetValue(titulo_etapaColumnIndex));
					if(!reader.IsDBNull(descripcio_etapaColumnIndex))
						record.DESCRIPCIO_ETAPA = Convert.ToString(reader.GetValue(descripcio_etapaColumnIndex));
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(estado_etapaColumnIndex))
						record.ESTADO_ETAPA = Convert.ToString(reader.GetValue(estado_etapaColumnIndex));
					if(!reader.IsDBNull(monto_etapaColumnIndex))
						record.MONTO_ETAPA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_etapaColumnIndex)), 9);
					if(!reader.IsDBNull(requerimiento_cobrarColumnIndex))
						record.REQUERIMIENTO_COBRAR = Convert.ToString(reader.GetValue(requerimiento_cobrarColumnIndex));
					record.COBRADO = Convert.ToString(reader.GetValue(cobradoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTRATOS_DETALLESRow[])(recordList.ToArray(typeof(CONTRATOS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTRATOS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTRATOS_DETALLESRow"/> object.</returns>
		protected virtual CONTRATOS_DETALLESRow MapRow(DataRow row)
		{
			CONTRATOS_DETALLESRow mappedObject = new CONTRATOS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CONTRATO_ID"
			dataColumn = dataTable.Columns["CONTRATO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTRATO_ID = (decimal)row[dataColumn];
			// Column "TITULO_ETAPA"
			dataColumn = dataTable.Columns["TITULO_ETAPA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULO_ETAPA = (string)row[dataColumn];
			// Column "DESCRIPCIO_ETAPA"
			dataColumn = dataTable.Columns["DESCRIPCIO_ETAPA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCIO_ETAPA = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "ESTADO_ETAPA"
			dataColumn = dataTable.Columns["ESTADO_ETAPA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ETAPA = (string)row[dataColumn];
			// Column "MONTO_ETAPA"
			dataColumn = dataTable.Columns["MONTO_ETAPA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ETAPA = (decimal)row[dataColumn];
			// Column "REQUERIMIENTO_COBRAR"
			dataColumn = dataTable.Columns["REQUERIMIENTO_COBRAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.REQUERIMIENTO_COBRAR = (string)row[dataColumn];
			// Column "COBRADO"
			dataColumn = dataTable.Columns["COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTRATOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTRATOS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTRATO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TITULO_ETAPA", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("DESCRIPCIO_ETAPA", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO_ETAPA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("MONTO_ETAPA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REQUERIMIENTO_COBRAR", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("COBRADO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "CONTRATO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TITULO_ETAPA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCIO_ETAPA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO_ETAPA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_ETAPA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REQUERIMIENTO_COBRAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTRATOS_DETALLESCollection_Base class
}  // End of namespace
