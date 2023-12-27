// <fileinfo name="FICHAS_MEDICA_REMEDIOSCollection_Base.cs">
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
	/// The base class for <see cref="FICHAS_MEDICA_REMEDIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FICHAS_MEDICA_REMEDIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FICHAS_MEDICA_REMEDIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FICHAS_MEDICA_IDColumnName = "FICHAS_MEDICA_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string DOSISColumnName = "DOSIS";
		public const string DOSIS_TOTALColumnName = "DOSIS_TOTAL";
		public const string CANTIDAD_UNIDAD_MEDIDAColumnName = "CANTIDAD_UNIDAD_MEDIDA";
		public const string RUAEColumnName = "RUAE";
		public const string INTERVALO_DOSISColumnName = "INTERVALO_DOSIS";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string AFECTA_STOCKColumnName = "AFECTA_STOCK";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FICHAS_MEDICA_REMEDIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FICHAS_MEDICA_REMEDIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FICHAS_MEDICA_REMEDIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects.</returns>
		public virtual FICHAS_MEDICA_REMEDIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FICHAS_MEDICA_REMEDIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FICHAS_MEDICA_REMEDIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FICHAS_MEDICA_REMEDIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FICHAS_MEDICA_REMEDIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects.</returns>
		public FICHAS_MEDICA_REMEDIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects.</returns>
		public virtual FICHAS_MEDICA_REMEDIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FICHAS_MEDICA_REMEDIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FICHAS_MEDICA_REMEDIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FICHAS_MEDICA_REMEDIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FICHAS_MEDICA_REMEDIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>FICHAS_MEDICA_REMEDIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FICHAS_MEDICA_REMEDIOSRow"/> object to be inserted.</param>
		public virtual void Insert(FICHAS_MEDICA_REMEDIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FICHAS_MEDICA_REMEDIOS (" +
				"ID, " +
				"FICHAS_MEDICA_ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"DOSIS, " +
				"DOSIS_TOTAL, " +
				"CANTIDAD_UNIDAD_MEDIDA, " +
				"RUAE, " +
				"INTERVALO_DOSIS, " +
				"OBSERVACION, " +
				"AFECTA_STOCK" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FICHAS_MEDICA_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("DOSIS") + ", " +
				_db.CreateSqlParameterName("DOSIS_TOTAL") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_MEDIDA") + ", " +
				_db.CreateSqlParameterName("RUAE") + ", " +
				_db.CreateSqlParameterName("INTERVALO_DOSIS") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("AFECTA_STOCK") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FICHAS_MEDICA_ID",
				value.IsFICHAS_MEDICA_IDNull ? DBNull.Value : (object)value.FICHAS_MEDICA_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "DOSIS",
				value.IsDOSISNull ? DBNull.Value : (object)value.DOSIS);
			AddParameter(cmd, "DOSIS_TOTAL",
				value.IsDOSIS_TOTALNull ? DBNull.Value : (object)value.DOSIS_TOTAL);
			AddParameter(cmd, "CANTIDAD_UNIDAD_MEDIDA",
				value.IsCANTIDAD_UNIDAD_MEDIDANull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_MEDIDA);
			AddParameter(cmd, "RUAE", value.RUAE);
			AddParameter(cmd, "INTERVALO_DOSIS", value.INTERVALO_DOSIS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FICHAS_MEDICA_REMEDIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FICHAS_MEDICA_REMEDIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FICHAS_MEDICA_REMEDIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.FICHAS_MEDICA_REMEDIOS SET " +
				"FICHAS_MEDICA_ID=" + _db.CreateSqlParameterName("FICHAS_MEDICA_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"DOSIS=" + _db.CreateSqlParameterName("DOSIS") + ", " +
				"DOSIS_TOTAL=" + _db.CreateSqlParameterName("DOSIS_TOTAL") + ", " +
				"CANTIDAD_UNIDAD_MEDIDA=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_MEDIDA") + ", " +
				"RUAE=" + _db.CreateSqlParameterName("RUAE") + ", " +
				"INTERVALO_DOSIS=" + _db.CreateSqlParameterName("INTERVALO_DOSIS") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"AFECTA_STOCK=" + _db.CreateSqlParameterName("AFECTA_STOCK") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FICHAS_MEDICA_ID",
				value.IsFICHAS_MEDICA_IDNull ? DBNull.Value : (object)value.FICHAS_MEDICA_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "DOSIS",
				value.IsDOSISNull ? DBNull.Value : (object)value.DOSIS);
			AddParameter(cmd, "DOSIS_TOTAL",
				value.IsDOSIS_TOTALNull ? DBNull.Value : (object)value.DOSIS_TOTAL);
			AddParameter(cmd, "CANTIDAD_UNIDAD_MEDIDA",
				value.IsCANTIDAD_UNIDAD_MEDIDANull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_MEDIDA);
			AddParameter(cmd, "RUAE", value.RUAE);
			AddParameter(cmd, "INTERVALO_DOSIS", value.INTERVALO_DOSIS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FICHAS_MEDICA_REMEDIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FICHAS_MEDICA_REMEDIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FICHAS_MEDICA_REMEDIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FICHAS_MEDICA_REMEDIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FICHAS_MEDICA_REMEDIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FICHAS_MEDICA_REMEDIOS</c> table using
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
		/// Deletes <c>FICHAS_MEDICA_REMEDIOS</c> records that match the specified criteria.
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
		/// to delete <c>FICHAS_MEDICA_REMEDIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FICHAS_MEDICA_REMEDIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FICHAS_MEDICA_REMEDIOS</c> table.
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
		/// <returns>An array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects.</returns>
		protected FICHAS_MEDICA_REMEDIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects.</returns>
		protected FICHAS_MEDICA_REMEDIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FICHAS_MEDICA_REMEDIOSRow"/> objects.</returns>
		protected virtual FICHAS_MEDICA_REMEDIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fichas_medica_idColumnIndex = reader.GetOrdinal("FICHAS_MEDICA_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int dosisColumnIndex = reader.GetOrdinal("DOSIS");
			int dosis_totalColumnIndex = reader.GetOrdinal("DOSIS_TOTAL");
			int cantidad_unidad_medidaColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_MEDIDA");
			int ruaeColumnIndex = reader.GetOrdinal("RUAE");
			int intervalo_dosisColumnIndex = reader.GetOrdinal("INTERVALO_DOSIS");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int afecta_stockColumnIndex = reader.GetOrdinal("AFECTA_STOCK");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FICHAS_MEDICA_REMEDIOSRow record = new FICHAS_MEDICA_REMEDIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fichas_medica_idColumnIndex))
						record.FICHAS_MEDICA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fichas_medica_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(dosisColumnIndex))
						record.DOSIS = Math.Round(Convert.ToDecimal(reader.GetValue(dosisColumnIndex)), 9);
					if(!reader.IsDBNull(dosis_totalColumnIndex))
						record.DOSIS_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(dosis_totalColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unidad_medidaColumnIndex))
						record.CANTIDAD_UNIDAD_MEDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_medidaColumnIndex)), 9);
					if(!reader.IsDBNull(ruaeColumnIndex))
						record.RUAE = Convert.ToString(reader.GetValue(ruaeColumnIndex));
					if(!reader.IsDBNull(intervalo_dosisColumnIndex))
						record.INTERVALO_DOSIS = Convert.ToString(reader.GetValue(intervalo_dosisColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(afecta_stockColumnIndex))
						record.AFECTA_STOCK = Convert.ToString(reader.GetValue(afecta_stockColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FICHAS_MEDICA_REMEDIOSRow[])(recordList.ToArray(typeof(FICHAS_MEDICA_REMEDIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FICHAS_MEDICA_REMEDIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FICHAS_MEDICA_REMEDIOSRow"/> object.</returns>
		protected virtual FICHAS_MEDICA_REMEDIOSRow MapRow(DataRow row)
		{
			FICHAS_MEDICA_REMEDIOSRow mappedObject = new FICHAS_MEDICA_REMEDIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FICHAS_MEDICA_ID"
			dataColumn = dataTable.Columns["FICHAS_MEDICA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FICHAS_MEDICA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "DOSIS"
			dataColumn = dataTable.Columns["DOSIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOSIS = (decimal)row[dataColumn];
			// Column "DOSIS_TOTAL"
			dataColumn = dataTable.Columns["DOSIS_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOSIS_TOTAL = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_MEDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_MEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_MEDIDA = (decimal)row[dataColumn];
			// Column "RUAE"
			dataColumn = dataTable.Columns["RUAE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUAE = (string)row[dataColumn];
			// Column "INTERVALO_DOSIS"
			dataColumn = dataTable.Columns["INTERVALO_DOSIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERVALO_DOSIS = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "AFECTA_STOCK"
			dataColumn = dataTable.Columns["AFECTA_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_STOCK = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FICHAS_MEDICA_REMEDIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FICHAS_MEDICA_REMEDIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FICHAS_MEDICA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DOSIS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DOSIS_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_MEDIDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUAE", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn = dataTable.Columns.Add("INTERVALO_DOSIS", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn = dataTable.Columns.Add("AFECTA_STOCK", typeof(string));
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

				case "FICHAS_MEDICA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DOSIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DOSIS_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_MEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUAE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INTERVALO_DOSIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AFECTA_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FICHAS_MEDICA_REMEDIOSCollection_Base class
}  // End of namespace
