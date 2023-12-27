// <fileinfo name="TRAMITES_TIPOS_ESTAD_INF_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_TIPOS_ESTAD_INF_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TRAMITE_TIPO_ETAPA_IDColumnName = "TRAMITE_TIPO_ETAPA_ID";
		public const string TRAMITE_TIPO_ETAPA_NOMBREColumnName = "TRAMITE_TIPO_ETAPA_NOMBRE";
		public const string TRAMITE_TIPO_IDColumnName = "TRAMITE_TIPO_ID";
		public const string TRAMITE_TIPO_NOMBREColumnName = "TRAMITE_TIPO_NOMBRE";
		public const string ES_INICIOColumnName = "ES_INICIO";
		public const string ES_FINColumnName = "ES_FIN";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRAMITES_TIPOS_ESTAD_INF_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRAMITES_TIPOS_ESTAD_INF_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects.</returns>
		public virtual TRAMITES_TIPOS_ESTAD_INF_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRAMITES_TIPOS_ESTAD_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRAMITES_TIPOS_ESTAD_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRAMITES_TIPOS_ESTAD_INF_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRAMITES_TIPOS_ESTAD_INF_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects.</returns>
		public TRAMITES_TIPOS_ESTAD_INF_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects.</returns>
		public virtual TRAMITES_TIPOS_ESTAD_INF_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRAMITES_TIPOS_ESTAD_INF_COMPL";
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects.</returns>
		protected TRAMITES_TIPOS_ESTAD_INF_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects.</returns>
		protected TRAMITES_TIPOS_ESTAD_INF_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> objects.</returns>
		protected virtual TRAMITES_TIPOS_ESTAD_INF_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tramite_tipo_etapa_idColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ETAPA_ID");
			int tramite_tipo_etapa_nombreColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ETAPA_NOMBRE");
			int tramite_tipo_idColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ID");
			int tramite_tipo_nombreColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_NOMBRE");
			int es_inicioColumnIndex = reader.GetOrdinal("ES_INICIO");
			int es_finColumnIndex = reader.GetOrdinal("ES_FIN");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRAMITES_TIPOS_ESTAD_INF_COMPLRow record = new TRAMITES_TIPOS_ESTAD_INF_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TRAMITE_TIPO_ETAPA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_tipo_etapa_idColumnIndex)), 9);
					record.TRAMITE_TIPO_ETAPA_NOMBRE = Convert.ToString(reader.GetValue(tramite_tipo_etapa_nombreColumnIndex));
					record.TRAMITE_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_tipo_idColumnIndex)), 9);
					record.TRAMITE_TIPO_NOMBRE = Convert.ToString(reader.GetValue(tramite_tipo_nombreColumnIndex));
					record.ES_INICIO = Convert.ToString(reader.GetValue(es_inicioColumnIndex));
					record.ES_FIN = Convert.ToString(reader.GetValue(es_finColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRAMITES_TIPOS_ESTAD_INF_COMPLRow[])(recordList.ToArray(typeof(TRAMITES_TIPOS_ESTAD_INF_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRAMITES_TIPOS_ESTAD_INF_COMPLRow"/> object.</returns>
		protected virtual TRAMITES_TIPOS_ESTAD_INF_COMPLRow MapRow(DataRow row)
		{
			TRAMITES_TIPOS_ESTAD_INF_COMPLRow mappedObject = new TRAMITES_TIPOS_ESTAD_INF_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TRAMITE_TIPO_ETAPA_ID"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_ETAPA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_ETAPA_ID = (decimal)row[dataColumn];
			// Column "TRAMITE_TIPO_ETAPA_NOMBRE"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_ETAPA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_ETAPA_NOMBRE = (string)row[dataColumn];
			// Column "TRAMITE_TIPO_ID"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_ID = (decimal)row[dataColumn];
			// Column "TRAMITE_TIPO_NOMBRE"
			dataColumn = dataTable.Columns["TRAMITE_TIPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_TIPO_NOMBRE = (string)row[dataColumn];
			// Column "ES_INICIO"
			dataColumn = dataTable.Columns["ES_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_INICIO = (string)row[dataColumn];
			// Column "ES_FIN"
			dataColumn = dataTable.Columns["ES_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_FIN = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRAMITES_TIPOS_ESTAD_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRAMITES_TIPOS_ESTAD_INF_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ETAPA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ETAPA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_INICIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_FIN", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
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

				case "TRAMITE_TIPO_ETAPA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITE_TIPO_ETAPA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRAMITE_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITE_TIPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRAMITES_TIPOS_ESTAD_INF_COMPLCollection_Base class
}  // End of namespace
