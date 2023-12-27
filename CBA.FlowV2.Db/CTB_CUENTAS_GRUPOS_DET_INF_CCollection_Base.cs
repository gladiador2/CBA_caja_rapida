// <fileinfo name="CTB_CUENTAS_GRUPOS_DET_INF_CCollection_Base.cs">
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
	/// The base class for <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_CUENTAS_GRUPOS_DET_INF_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_CUENTA_IDColumnName = "CTB_CUENTA_ID";
		public const string CUENTA_NOMBREColumnName = "CUENTA_NOMBRE";
		public const string CTB_CUENTAS_GRUPOS_IDColumnName = "CTB_CUENTAS_GRUPOS_ID";
		public const string CUENTA_GRUPOS_NOMBREColumnName = "CUENTA_GRUPOS_NOMBRE";
		public const string CUENTA_GRUPOS_ESTADOColumnName = "CUENTA_GRUPOS_ESTADO";
		public const string CTB_CUENTAS_GRUPOS_HIJO_IDColumnName = "CTB_CUENTAS_GRUPOS_HIJO_ID";
		public const string CUENTA_GRUPOS_HIJO_NOMBREColumnName = "CUENTA_GRUPOS_HIJO_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_CUENTAS_GRUPOS_DET_INF_CCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this view belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>CTB_CUENTAS_GRUPOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects.</returns>
		public virtual CTB_CUENTAS_GRUPOS_DET_INF_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_CUENTAS_GRUPOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_CUENTAS_GRUPOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_CUENTAS_GRUPOS_DET_INF_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_CUENTAS_GRUPOS_DET_INF_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects.</returns>
		public CTB_CUENTAS_GRUPOS_DET_INF_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects.</returns>
		public virtual CTB_CUENTAS_GRUPOS_DET_INF_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_CUENTAS_GRUPOS_DET_INF_C";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects.</returns>
		protected CTB_CUENTAS_GRUPOS_DET_INF_CRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects.</returns>
		protected CTB_CUENTAS_GRUPOS_DET_INF_CRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> objects.</returns>
		protected virtual CTB_CUENTAS_GRUPOS_DET_INF_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_cuenta_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_ID");
			int cuenta_nombreColumnIndex = reader.GetOrdinal("CUENTA_NOMBRE");
			int ctb_cuentas_grupos_idColumnIndex = reader.GetOrdinal("CTB_CUENTAS_GRUPOS_ID");
			int cuenta_grupos_nombreColumnIndex = reader.GetOrdinal("CUENTA_GRUPOS_NOMBRE");
			int cuenta_grupos_estadoColumnIndex = reader.GetOrdinal("CUENTA_GRUPOS_ESTADO");
			int ctb_cuentas_grupos_hijo_idColumnIndex = reader.GetOrdinal("CTB_CUENTAS_GRUPOS_HIJO_ID");
			int cuenta_grupos_hijo_nombreColumnIndex = reader.GetOrdinal("CUENTA_GRUPOS_HIJO_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_CUENTAS_GRUPOS_DET_INF_CRow record = new CTB_CUENTAS_GRUPOS_DET_INF_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_cuenta_idColumnIndex))
						record.CTB_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_idColumnIndex)), 9);
					if(!reader.IsDBNull(cuenta_nombreColumnIndex))
						record.CUENTA_NOMBRE = Convert.ToString(reader.GetValue(cuenta_nombreColumnIndex));
					record.CTB_CUENTAS_GRUPOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuentas_grupos_idColumnIndex)), 9);
					record.CUENTA_GRUPOS_NOMBRE = Convert.ToString(reader.GetValue(cuenta_grupos_nombreColumnIndex));
					record.CUENTA_GRUPOS_ESTADO = Convert.ToString(reader.GetValue(cuenta_grupos_estadoColumnIndex));
					if(!reader.IsDBNull(ctb_cuentas_grupos_hijo_idColumnIndex))
						record.CTB_CUENTAS_GRUPOS_HIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuentas_grupos_hijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(cuenta_grupos_hijo_nombreColumnIndex))
						record.CUENTA_GRUPOS_HIJO_NOMBRE = Convert.ToString(reader.GetValue(cuenta_grupos_hijo_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_CUENTAS_GRUPOS_DET_INF_CRow[])(recordList.ToArray(typeof(CTB_CUENTAS_GRUPOS_DET_INF_CRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_CUENTAS_GRUPOS_DET_INF_CRow"/> object.</returns>
		protected virtual CTB_CUENTAS_GRUPOS_DET_INF_CRow MapRow(DataRow row)
		{
			CTB_CUENTAS_GRUPOS_DET_INF_CRow mappedObject = new CTB_CUENTAS_GRUPOS_DET_INF_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CUENTA_NOMBRE"
			dataColumn = dataTable.Columns["CUENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_NOMBRE = (string)row[dataColumn];
			// Column "CTB_CUENTAS_GRUPOS_ID"
			dataColumn = dataTable.Columns["CTB_CUENTAS_GRUPOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTAS_GRUPOS_ID = (decimal)row[dataColumn];
			// Column "CUENTA_GRUPOS_NOMBRE"
			dataColumn = dataTable.Columns["CUENTA_GRUPOS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_GRUPOS_NOMBRE = (string)row[dataColumn];
			// Column "CUENTA_GRUPOS_ESTADO"
			dataColumn = dataTable.Columns["CUENTA_GRUPOS_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_GRUPOS_ESTADO = (string)row[dataColumn];
			// Column "CTB_CUENTAS_GRUPOS_HIJO_ID"
			dataColumn = dataTable.Columns["CTB_CUENTAS_GRUPOS_HIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTAS_GRUPOS_HIJO_ID = (decimal)row[dataColumn];
			// Column "CUENTA_GRUPOS_HIJO_NOMBRE"
			dataColumn = dataTable.Columns["CUENTA_GRUPOS_HIJO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_GRUPOS_HIJO_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_CUENTAS_GRUPOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_CUENTAS_GRUPOS_DET_INF_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTAS_GRUPOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_GRUPOS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_GRUPOS_ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTAS_GRUPOS_HIJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_GRUPOS_HIJO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
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

				case "CTB_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CUENTAS_GRUPOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUENTA_GRUPOS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CUENTA_GRUPOS_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTB_CUENTAS_GRUPOS_HIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUENTA_GRUPOS_HIJO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_CUENTAS_GRUPOS_DET_INF_CCollection_Base class
}  // End of namespace
