// <fileinfo name="RECALEN_MAS_CUOT_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="RECALEN_MAS_CUOT_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="RECALEN_MAS_CUOT_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RECALEN_MAS_CUOT_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string RECAL_MASIVA_DET_IDColumnName = "RECAL_MASIVA_DET_ID";
		public const string CAL_PAGO_CLI_FC_ORIGINAL_IDColumnName = "CAL_PAGO_CLI_FC_ORIGINAL_ID";
		public const string CAL_PAGO_CLI_FC_NUEVO_IDColumnName = "CAL_PAGO_CLI_FC_NUEVO_ID";
		public const string NUEVO_VENCIMIENTOColumnName = "NUEVO_VENCIMIENTO";
		public const string FECHA_VENCIMIENTO_ORIGINALColumnName = "FECHA_VENCIMIENTO_ORIGINAL";
		public const string FECHA_VENCIMIENTO_NUEVOColumnName = "FECHA_VENCIMIENTO_NUEVO";
		public const string MONTO_CUOTAColumnName = "MONTO_CUOTA";
		public const string INTERES_CUOTAColumnName = "INTERES_CUOTA";
		public const string NUMERO_CUOTAColumnName = "NUMERO_CUOTA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="RECALEN_MAS_CUOT_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public RECALEN_MAS_CUOT_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>RECALEN_MAS_CUOT_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects.</returns>
		public virtual RECALEN_MAS_CUOT_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>RECALEN_MAS_CUOT_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>RECALEN_MAS_CUOT_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public RECALEN_MAS_CUOT_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			RECALEN_MAS_CUOT_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects.</returns>
		public RECALEN_MAS_CUOT_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects.</returns>
		public virtual RECALEN_MAS_CUOT_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.RECALEN_MAS_CUOT_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects.</returns>
		protected RECALEN_MAS_CUOT_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects.</returns>
		protected RECALEN_MAS_CUOT_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> objects.</returns>
		protected virtual RECALEN_MAS_CUOT_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int recal_masiva_det_idColumnIndex = reader.GetOrdinal("RECAL_MASIVA_DET_ID");
			int cal_pago_cli_fc_original_idColumnIndex = reader.GetOrdinal("CAL_PAGO_CLI_FC_ORIGINAL_ID");
			int cal_pago_cli_fc_nuevo_idColumnIndex = reader.GetOrdinal("CAL_PAGO_CLI_FC_NUEVO_ID");
			int nuevo_vencimientoColumnIndex = reader.GetOrdinal("NUEVO_VENCIMIENTO");
			int fecha_vencimiento_originalColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_ORIGINAL");
			int fecha_vencimiento_nuevoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_NUEVO");
			int monto_cuotaColumnIndex = reader.GetOrdinal("MONTO_CUOTA");
			int interes_cuotaColumnIndex = reader.GetOrdinal("INTERES_CUOTA");
			int numero_cuotaColumnIndex = reader.GetOrdinal("NUMERO_CUOTA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					RECALEN_MAS_CUOT_INFO_COMPLETARow record = new RECALEN_MAS_CUOT_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.RECAL_MASIVA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(recal_masiva_det_idColumnIndex)), 9);
					record.CAL_PAGO_CLI_FC_ORIGINAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cal_pago_cli_fc_original_idColumnIndex)), 9);
					if(!reader.IsDBNull(cal_pago_cli_fc_nuevo_idColumnIndex))
						record.CAL_PAGO_CLI_FC_NUEVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cal_pago_cli_fc_nuevo_idColumnIndex)), 9);
					record.NUEVO_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(nuevo_vencimientoColumnIndex));
					record.FECHA_VENCIMIENTO_ORIGINAL = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_originalColumnIndex));
					if(!reader.IsDBNull(fecha_vencimiento_nuevoColumnIndex))
						record.FECHA_VENCIMIENTO_NUEVO = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_nuevoColumnIndex));
					record.MONTO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_cuotaColumnIndex)), 9);
					record.INTERES_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(interes_cuotaColumnIndex)), 9);
					record.NUMERO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(numero_cuotaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (RECALEN_MAS_CUOT_INFO_COMPLETARow[])(recordList.ToArray(typeof(RECALEN_MAS_CUOT_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="RECALEN_MAS_CUOT_INFO_COMPLETARow"/> object.</returns>
		protected virtual RECALEN_MAS_CUOT_INFO_COMPLETARow MapRow(DataRow row)
		{
			RECALEN_MAS_CUOT_INFO_COMPLETARow mappedObject = new RECALEN_MAS_CUOT_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "RECAL_MASIVA_DET_ID"
			dataColumn = dataTable.Columns["RECAL_MASIVA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECAL_MASIVA_DET_ID = (decimal)row[dataColumn];
			// Column "CAL_PAGO_CLI_FC_ORIGINAL_ID"
			dataColumn = dataTable.Columns["CAL_PAGO_CLI_FC_ORIGINAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAL_PAGO_CLI_FC_ORIGINAL_ID = (decimal)row[dataColumn];
			// Column "CAL_PAGO_CLI_FC_NUEVO_ID"
			dataColumn = dataTable.Columns["CAL_PAGO_CLI_FC_NUEVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAL_PAGO_CLI_FC_NUEVO_ID = (decimal)row[dataColumn];
			// Column "NUEVO_VENCIMIENTO"
			dataColumn = dataTable.Columns["NUEVO_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUEVO_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_ORIGINAL"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_ORIGINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_ORIGINAL = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_NUEVO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_NUEVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_NUEVO = (System.DateTime)row[dataColumn];
			// Column "MONTO_CUOTA"
			dataColumn = dataTable.Columns["MONTO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CUOTA = (decimal)row[dataColumn];
			// Column "INTERES_CUOTA"
			dataColumn = dataTable.Columns["INTERES_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_CUOTA = (decimal)row[dataColumn];
			// Column "NUMERO_CUOTA"
			dataColumn = dataTable.Columns["NUMERO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUOTA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>RECALEN_MAS_CUOT_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "RECALEN_MAS_CUOT_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECAL_MASIVA_DET_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAL_PAGO_CLI_FC_ORIGINAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAL_PAGO_CLI_FC_NUEVO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUEVO_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_ORIGINAL", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_NUEVO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INTERES_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
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

				case "RECAL_MASIVA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAL_PAGO_CLI_FC_ORIGINAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAL_PAGO_CLI_FC_NUEVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUEVO_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_ORIGINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_NUEVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONTO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of RECALEN_MAS_CUOT_INFO_COMPLETACollection_Base class
}  // End of namespace
