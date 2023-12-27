// <fileinfo name="EDI_WEBSERVICE_CONTABILIDADCollection_Base.cs">
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
	/// The base class for <see cref="EDI_WEBSERVICE_CONTABILIDADCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EDI_WEBSERVICE_CONTABILIDADCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EDI_WEBSERVICE_CONTABILIDADCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string EDIColumnName = "EDI";
		public const string ASIENTO_AUTOMATICO_IDColumnName = "ASIENTO_AUTOMATICO_ID";
		public const string ASIENTO_IDColumnName = "ASIENTO_ID";
		public const string REGENERARColumnName = "REGENERAR";
		public const string ELIMINADOColumnName = "ELIMINADO";
		public const string MKT_FLUJO_IDColumnName = "MKT_FLUJO_ID";
		public const string MKT_CASO_IDColumnName = "MKT_CASO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EDI_WEBSERVICE_CONTABILIDADCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EDI_WEBSERVICE_CONTABILIDADCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EDI_WEBSERVICE_CONTABILIDAD</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects.</returns>
		public virtual EDI_WEBSERVICE_CONTABILIDADRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EDI_WEBSERVICE_CONTABILIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EDI_WEBSERVICE_CONTABILIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EDI_WEBSERVICE_CONTABILIDADRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EDI_WEBSERVICE_CONTABILIDADRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects.</returns>
		public EDI_WEBSERVICE_CONTABILIDADRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects that 
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
		/// <returns>An array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects.</returns>
		public virtual EDI_WEBSERVICE_CONTABILIDADRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EDI_WEBSERVICE_CONTABILIDAD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Adds a new record into the <c>EDI_WEBSERVICE_CONTABILIDAD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> object to be inserted.</param>
		public virtual void Insert(EDI_WEBSERVICE_CONTABILIDADRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EDI_WEBSERVICE_CONTABILIDAD (" +
				"ID, " +
				"EDI, " +
				"ASIENTO_AUTOMATICO_ID, " +
				"ASIENTO_ID, " +
				"REGENERAR, " +
				"ELIMINADO, " +
				"MKT_FLUJO_ID, " +
				"MKT_CASO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("EDI") + ", " +
				_db.CreateSqlParameterName("ASIENTO_AUTOMATICO_ID") + ", " +
				_db.CreateSqlParameterName("ASIENTO_ID") + ", " +
				_db.CreateSqlParameterName("REGENERAR") + ", " +
				_db.CreateSqlParameterName("ELIMINADO") + ", " +
				_db.CreateSqlParameterName("MKT_FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("MKT_CASO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID",
				value.IsIDNull ? DBNull.Value : (object)value.ID);
			AddParameter(cmd, "EDI", value.EDI);
			AddParameter(cmd, "ASIENTO_AUTOMATICO_ID",
				value.IsASIENTO_AUTOMATICO_IDNull ? DBNull.Value : (object)value.ASIENTO_AUTOMATICO_ID);
			AddParameter(cmd, "ASIENTO_ID",
				value.IsASIENTO_IDNull ? DBNull.Value : (object)value.ASIENTO_ID);
			AddParameter(cmd, "REGENERAR", value.REGENERAR);
			AddParameter(cmd, "ELIMINADO", value.ELIMINADO);
			AddParameter(cmd, "MKT_FLUJO_ID",
				value.IsMKT_FLUJO_IDNull ? DBNull.Value : (object)value.MKT_FLUJO_ID);
			AddParameter(cmd, "MKT_CASO_ID",
				value.IsMKT_CASO_IDNull ? DBNull.Value : (object)value.MKT_CASO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes <c>EDI_WEBSERVICE_CONTABILIDAD</c> records that match the specified criteria.
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
		/// to delete <c>EDI_WEBSERVICE_CONTABILIDAD</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EDI_WEBSERVICE_CONTABILIDAD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EDI_WEBSERVICE_CONTABILIDAD</c> table.
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
		/// <returns>An array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects.</returns>
		protected EDI_WEBSERVICE_CONTABILIDADRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects.</returns>
		protected EDI_WEBSERVICE_CONTABILIDADRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> objects.</returns>
		protected virtual EDI_WEBSERVICE_CONTABILIDADRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ediColumnIndex = reader.GetOrdinal("EDI");
			int asiento_automatico_idColumnIndex = reader.GetOrdinal("ASIENTO_AUTOMATICO_ID");
			int asiento_idColumnIndex = reader.GetOrdinal("ASIENTO_ID");
			int regenerarColumnIndex = reader.GetOrdinal("REGENERAR");
			int eliminadoColumnIndex = reader.GetOrdinal("ELIMINADO");
			int mkt_flujo_idColumnIndex = reader.GetOrdinal("MKT_FLUJO_ID");
			int mkt_caso_idColumnIndex = reader.GetOrdinal("MKT_CASO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EDI_WEBSERVICE_CONTABILIDADRow record = new EDI_WEBSERVICE_CONTABILIDADRow();
					recordList.Add(record);

					if(!reader.IsDBNull(idColumnIndex))
						record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ediColumnIndex))
						record.EDI = Convert.ToString(reader.GetValue(ediColumnIndex));
					if(!reader.IsDBNull(asiento_automatico_idColumnIndex))
						record.ASIENTO_AUTOMATICO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(asiento_automatico_idColumnIndex)), 9);
					if(!reader.IsDBNull(asiento_idColumnIndex))
						record.ASIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(asiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(regenerarColumnIndex))
						record.REGENERAR = Convert.ToString(reader.GetValue(regenerarColumnIndex));
					if(!reader.IsDBNull(eliminadoColumnIndex))
						record.ELIMINADO = Convert.ToString(reader.GetValue(eliminadoColumnIndex));
					if(!reader.IsDBNull(mkt_flujo_idColumnIndex))
						record.MKT_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(mkt_flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(mkt_caso_idColumnIndex))
						record.MKT_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(mkt_caso_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EDI_WEBSERVICE_CONTABILIDADRow[])(recordList.ToArray(typeof(EDI_WEBSERVICE_CONTABILIDADRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> object.</returns>
		protected virtual EDI_WEBSERVICE_CONTABILIDADRow MapRow(DataRow row)
		{
			EDI_WEBSERVICE_CONTABILIDADRow mappedObject = new EDI_WEBSERVICE_CONTABILIDADRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "EDI"
			dataColumn = dataTable.Columns["EDI"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI = (string)row[dataColumn];
			// Column "ASIENTO_AUTOMATICO_ID"
			dataColumn = dataTable.Columns["ASIENTO_AUTOMATICO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ASIENTO_AUTOMATICO_ID = (decimal)row[dataColumn];
			// Column "ASIENTO_ID"
			dataColumn = dataTable.Columns["ASIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ASIENTO_ID = (decimal)row[dataColumn];
			// Column "REGENERAR"
			dataColumn = dataTable.Columns["REGENERAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGENERAR = (string)row[dataColumn];
			// Column "ELIMINADO"
			dataColumn = dataTable.Columns["ELIMINADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ELIMINADO = (string)row[dataColumn];
			// Column "MKT_FLUJO_ID"
			dataColumn = dataTable.Columns["MKT_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MKT_FLUJO_ID = (decimal)row[dataColumn];
			// Column "MKT_CASO_ID"
			dataColumn = dataTable.Columns["MKT_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MKT_CASO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EDI_WEBSERVICE_CONTABILIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EDI_WEBSERVICE_CONTABILIDAD";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EDI", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("ASIENTO_AUTOMATICO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ASIENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REGENERAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ELIMINADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("MKT_FLUJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MKT_CASO_ID", typeof(decimal));
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

				case "EDI":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ASIENTO_AUTOMATICO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ASIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGENERAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ELIMINADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MKT_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MKT_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EDI_WEBSERVICE_CONTABILIDADCollection_Base class
}  // End of namespace
