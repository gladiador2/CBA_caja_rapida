// <fileinfo name="RETENCION_ARTIC_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="RETENCION_ARTIC_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="RETENCION_ARTIC_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class RETENCION_ARTIC_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PORCENTAJEColumnName = "PORCENTAJE";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string CODIGO_EMPRESAColumnName = "CODIGO_EMPRESA";
		public const string CODIGO_BARRAS_EMPRESAColumnName = "CODIGO_BARRAS_EMPRESA";
		public const string DESCRIPCION_INTERNAColumnName = "DESCRIPCION_INTERNA";
		public const string DESCRIPCION_IMPRESIONColumnName = "DESCRIPCION_IMPRESION";
		public const string UNIDAD_MEDIDA_IDColumnName = "UNIDAD_MEDIDA_ID";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string CANTIDAD_MAXIMAColumnName = "CANTIDAD_MAXIMA";
		public const string CANTIDAD_MAYORISTAColumnName = "CANTIDAD_MAYORISTA";
		public const string UNIDAD_MEDIDA_CONTROLColumnName = "UNIDAD_MEDIDA_CONTROL";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="RETENCION_ARTIC_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public RETENCION_ARTIC_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>RETENCION_ARTIC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects.</returns>
		public virtual RETENCION_ARTIC_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>RETENCION_ARTIC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>RETENCION_ARTIC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public RETENCION_ARTIC_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			RETENCION_ARTIC_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects.</returns>
		public RETENCION_ARTIC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects.</returns>
		public virtual RETENCION_ARTIC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.RETENCION_ARTIC_INFO_COMPL";
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
		/// <returns>An array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects.</returns>
		protected RETENCION_ARTIC_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects.</returns>
		protected RETENCION_ARTIC_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> objects.</returns>
		protected virtual RETENCION_ARTIC_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int codigo_empresaColumnIndex = reader.GetOrdinal("CODIGO_EMPRESA");
			int codigo_barras_empresaColumnIndex = reader.GetOrdinal("CODIGO_BARRAS_EMPRESA");
			int descripcion_internaColumnIndex = reader.GetOrdinal("DESCRIPCION_INTERNA");
			int descripcion_impresionColumnIndex = reader.GetOrdinal("DESCRIPCION_IMPRESION");
			int unidad_medida_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ID");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int cantidad_maximaColumnIndex = reader.GetOrdinal("CANTIDAD_MAXIMA");
			int cantidad_mayoristaColumnIndex = reader.GetOrdinal("CANTIDAD_MAYORISTA");
			int unidad_medida_controlColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_CONTROL");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					RETENCION_ARTIC_INFO_COMPLRow record = new RETENCION_ARTIC_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_empresaColumnIndex))
						record.CODIGO_EMPRESA = Convert.ToString(reader.GetValue(codigo_empresaColumnIndex));
					if(!reader.IsDBNull(codigo_barras_empresaColumnIndex))
						record.CODIGO_BARRAS_EMPRESA = Convert.ToString(reader.GetValue(codigo_barras_empresaColumnIndex));
					if(!reader.IsDBNull(descripcion_internaColumnIndex))
						record.DESCRIPCION_INTERNA = Convert.ToString(reader.GetValue(descripcion_internaColumnIndex));
					if(!reader.IsDBNull(descripcion_impresionColumnIndex))
						record.DESCRIPCION_IMPRESION = Convert.ToString(reader.GetValue(descripcion_impresionColumnIndex));
					record.UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(unidad_medida_idColumnIndex));
					if(!reader.IsDBNull(cantidad_minimaColumnIndex))
						record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_maximaColumnIndex))
						record.CANTIDAD_MAXIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_maximaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_mayoristaColumnIndex))
						record.CANTIDAD_MAYORISTA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_mayoristaColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_controlColumnIndex))
						record.UNIDAD_MEDIDA_CONTROL = Convert.ToString(reader.GetValue(unidad_medida_controlColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (RETENCION_ARTIC_INFO_COMPLRow[])(recordList.ToArray(typeof(RETENCION_ARTIC_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="RETENCION_ARTIC_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="RETENCION_ARTIC_INFO_COMPLRow"/> object.</returns>
		protected virtual RETENCION_ARTIC_INFO_COMPLRow MapRow(DataRow row)
		{
			RETENCION_ARTIC_INFO_COMPLRow mappedObject = new RETENCION_ARTIC_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "CODIGO_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EMPRESA = (string)row[dataColumn];
			// Column "CODIGO_BARRAS_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_BARRAS_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BARRAS_EMPRESA = (string)row[dataColumn];
			// Column "DESCRIPCION_INTERNA"
			dataColumn = dataTable.Columns["DESCRIPCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_INTERNA = (string)row[dataColumn];
			// Column "DESCRIPCION_IMPRESION"
			dataColumn = dataTable.Columns["DESCRIPCION_IMPRESION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_IMPRESION = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "CANTIDAD_MAXIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MAXIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAXIMA = (decimal)row[dataColumn];
			// Column "CANTIDAD_MAYORISTA"
			dataColumn = dataTable.Columns["CANTIDAD_MAYORISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MAYORISTA = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_CONTROL"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_CONTROL"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_CONTROL = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>RETENCION_ARTIC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "RETENCION_ARTIC_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_BARRAS_EMPRESA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_IMPRESION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAXIMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MAYORISTA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_CONTROL", typeof(string));
			dataColumn.MaxLength = 20;
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

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_BARRAS_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_IMPRESION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MAXIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MAYORISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_CONTROL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of RETENCION_ARTIC_INFO_COMPLCollection_Base class
}  // End of namespace
