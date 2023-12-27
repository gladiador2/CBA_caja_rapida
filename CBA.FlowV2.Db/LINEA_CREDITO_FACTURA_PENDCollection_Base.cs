// <fileinfo name="LINEA_CREDITO_FACTURA_PENDCollection_Base.cs">
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
	/// The base class for <see cref="LINEA_CREDITO_FACTURA_PENDCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="LINEA_CREDITO_FACTURA_PENDCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LINEA_CREDITO_FACTURA_PENDCollection_Base
	{
		// Constants
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_GARANTE_1_IDColumnName = "PERSONA_GARANTE_1_ID";
		public const string PERSONA_GARANTE_2_IDColumnName = "PERSONA_GARANTE_2_ID";
		public const string PERSONA_GARANTE_3_IDColumnName = "PERSONA_GARANTE_3_ID";
		public const string COTIZACION_DESTINOColumnName = "COTIZACION_DESTINO";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string PENDIENTEColumnName = "PENDIENTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="LINEA_CREDITO_FACTURA_PENDCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public LINEA_CREDITO_FACTURA_PENDCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>LINEA_CREDITO_FACTURA_PEND</c> view.
		/// </summary>
		/// <returns>An array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects.</returns>
		public virtual LINEA_CREDITO_FACTURA_PENDRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>LINEA_CREDITO_FACTURA_PEND</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>LINEA_CREDITO_FACTURA_PEND</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public LINEA_CREDITO_FACTURA_PENDRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			LINEA_CREDITO_FACTURA_PENDRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects.</returns>
		public LINEA_CREDITO_FACTURA_PENDRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects that 
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
		/// <returns>An array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects.</returns>
		public virtual LINEA_CREDITO_FACTURA_PENDRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.LINEA_CREDITO_FACTURA_PEND";
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
		/// <returns>An array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects.</returns>
		protected LINEA_CREDITO_FACTURA_PENDRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects.</returns>
		protected LINEA_CREDITO_FACTURA_PENDRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> objects.</returns>
		protected virtual LINEA_CREDITO_FACTURA_PENDRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_garante_1_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_1_ID");
			int persona_garante_2_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_2_ID");
			int persona_garante_3_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_3_ID");
			int cotizacion_destinoColumnIndex = reader.GetOrdinal("COTIZACION_DESTINO");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int pendienteColumnIndex = reader.GetOrdinal("PENDIENTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					LINEA_CREDITO_FACTURA_PENDRow record = new LINEA_CREDITO_FACTURA_PENDRow();
					recordList.Add(record);

					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_1_idColumnIndex))
						record.PERSONA_GARANTE_1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_1_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_2_idColumnIndex))
						record.PERSONA_GARANTE_2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_2_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_3_idColumnIndex))
						record.PERSONA_GARANTE_3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_3_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_destinoColumnIndex))
						record.COTIZACION_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_destino_idColumnIndex))
						record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(pendienteColumnIndex))
						record.PENDIENTE = Math.Round(Convert.ToDecimal(reader.GetValue(pendienteColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LINEA_CREDITO_FACTURA_PENDRow[])(recordList.ToArray(typeof(LINEA_CREDITO_FACTURA_PENDRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="LINEA_CREDITO_FACTURA_PENDRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="LINEA_CREDITO_FACTURA_PENDRow"/> object.</returns>
		protected virtual LINEA_CREDITO_FACTURA_PENDRow MapRow(DataRow row)
		{
			LINEA_CREDITO_FACTURA_PENDRow mappedObject = new LINEA_CREDITO_FACTURA_PENDRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_1_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_1_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_2_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_2_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_3_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_3_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_3_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_DESTINO = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "PENDIENTE"
			dataColumn = dataTable.Columns["PENDIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PENDIENTE = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>LINEA_CREDITO_FACTURA_PEND</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "LINEA_CREDITO_FACTURA_PEND";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_3_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PENDIENTE", typeof(decimal));
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
				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_3_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PENDIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of LINEA_CREDITO_FACTURA_PENDCollection_Base class
}  // End of namespace
