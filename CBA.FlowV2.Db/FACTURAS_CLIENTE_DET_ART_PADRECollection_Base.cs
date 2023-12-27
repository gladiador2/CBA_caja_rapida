// <fileinfo name="FACTURAS_CLIENTE_DET_ART_PADRECollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_DET_ART_PADRECollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_CLIENTE_DET_ART_PADRECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_DET_ART_PADRECollection_Base
	{
		// Constants
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string FACTURAS_CLIENTE_IDColumnName = "FACTURAS_CLIENTE_ID";
		public const string TOTAL_BRUTOColumnName = "TOTAL_BRUTO";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string CANTIDAD_UNITARIA_TOTAL_DESTColumnName = "CANTIDAD_UNITARIA_TOTAL_DEST";
		public const string COSTO_MONTOColumnName = "COSTO_MONTO";
		public const string COSTO_MONEDA_CABECERAColumnName = "COSTO_MONEDA_CABECERA";
		public const string RENTABILIDADColumnName = "RENTABILIDAD";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DET_ART_PADRECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_CLIENTE_DET_ART_PADRECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURAS_CLIENTE_DET_ART_PADRE</c> view.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DET_ART_PADRERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_CLIENTE_DET_ART_PADRE</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_CLIENTE_DET_ART_PADRE</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_CLIENTE_DET_ART_PADRERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_CLIENTE_DET_ART_PADRERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DET_ART_PADRERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DET_ART_PADRERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_CLIENTE_DET_ART_PADRE";
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects.</returns>
		protected FACTURAS_CLIENTE_DET_ART_PADRERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects.</returns>
		protected FACTURAS_CLIENTE_DET_ART_PADRERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> objects.</returns>
		protected virtual FACTURAS_CLIENTE_DET_ART_PADRERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int facturas_cliente_idColumnIndex = reader.GetOrdinal("FACTURAS_CLIENTE_ID");
			int total_brutoColumnIndex = reader.GetOrdinal("TOTAL_BRUTO");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int cantidad_unitaria_total_destColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_DEST");
			int costo_montoColumnIndex = reader.GetOrdinal("COSTO_MONTO");
			int costo_moneda_cabeceraColumnIndex = reader.GetOrdinal("COSTO_MONEDA_CABECERA");
			int rentabilidadColumnIndex = reader.GetOrdinal("RENTABILIDAD");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_CLIENTE_DET_ART_PADRERow record = new FACTURAS_CLIENTE_DET_ART_PADRERow();
					recordList.Add(record);

					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					record.FACTURAS_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(facturas_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(total_brutoColumnIndex))
						record.TOTAL_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_impuestoColumnIndex))
						record.TOTAL_MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_dtoColumnIndex))
						record.TOTAL_MONTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_dtoColumnIndex)), 9);
					if(!reader.IsDBNull(total_netoColumnIndex))
						record.TOTAL_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_recargo_financieroColumnIndex))
						record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_total_destColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_destColumnIndex)), 9);
					if(!reader.IsDBNull(costo_montoColumnIndex))
						record.COSTO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_cabeceraColumnIndex))
						record.COSTO_MONEDA_CABECERA = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cabeceraColumnIndex)), 9);
					if(!reader.IsDBNull(rentabilidadColumnIndex))
						record.RENTABILIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(rentabilidadColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_CLIENTE_DET_ART_PADRERow[])(recordList.ToArray(typeof(FACTURAS_CLIENTE_DET_ART_PADRERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_CLIENTE_DET_ART_PADRERow"/> object.</returns>
		protected virtual FACTURAS_CLIENTE_DET_ART_PADRERow MapRow(DataRow row)
		{
			FACTURAS_CLIENTE_DET_ART_PADRERow mappedObject = new FACTURAS_CLIENTE_DET_ART_PADRERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "FACTURAS_CLIENTE_ID"
			dataColumn = dataTable.Columns["FACTURAS_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAS_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "TOTAL_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_DTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_DTO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO"
			dataColumn = dataTable.Columns["TOTAL_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO = (decimal)row[dataColumn];
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_DEST"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_DEST = (decimal)row[dataColumn];
			// Column "COSTO_MONTO"
			dataColumn = dataTable.Columns["COSTO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONTO = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_CABECERA"
			dataColumn = dataTable.Columns["COSTO_MONEDA_CABECERA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_CABECERA = (decimal)row[dataColumn];
			// Column "RENTABILIDAD"
			dataColumn = dataTable.Columns["RENTABILIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.RENTABILIDAD = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_CLIENTE_DET_ART_PADRE</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_CLIENTE_DET_ART_PADRE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 951;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURAS_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_DEST", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_CABECERA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RENTABILIDAD", typeof(decimal));
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
				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURAS_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_CABECERA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RENTABILIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_CLIENTE_DET_ART_PADRECollection_Base class
}  // End of namespace
