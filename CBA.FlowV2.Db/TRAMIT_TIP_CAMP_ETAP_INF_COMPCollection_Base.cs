// <fileinfo name="TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string TIPO_DE_DATO_IDColumnName = "TIPO_DE_DATO_ID";
		public const string ORDENColumnName = "ORDEN";
		public const string TRAMITE_TIPO_ETAPA_IDColumnName = "TRAMITE_TIPO_ETAPA_ID";
		public const string TRAMITE_TIPO_ETAPA_NOMBREColumnName = "TRAMITE_TIPO_ETAPA_NOMBRE";
		public const string TRAMITE_TIPO_IDColumnName = "TRAMITE_TIPO_ID";
		public const string TRAMITE_TIPO_NOMBREColumnName = "TRAMITE_TIPO_NOMBRE";
		public const string GENERA_ALARMAColumnName = "GENERA_ALARMA";
		public const string ES_OBLIGATORIOColumnName = "ES_OBLIGATORIO";
		public const string TIPO_TEXTO_PREDEFINIDO_IDColumnName = "TIPO_TEXTO_PREDEFINIDO_ID";
		public const string TIPO_TEXTO_PREDEFINIDO_NOMBREColumnName = "TIPO_TEXTO_PREDEFINIDO_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRAMIT_TIP_CAMP_ETAP_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects.</returns>
		public virtual TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRAMIT_TIP_CAMP_ETAP_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRAMIT_TIP_CAMP_ETAP_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRAMIT_TIP_CAMP_ETAP_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects.</returns>
		public TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects.</returns>
		public virtual TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRAMIT_TIP_CAMP_ETAP_INF_COMP";
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
		/// <returns>An array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects.</returns>
		protected TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects.</returns>
		protected TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> objects.</returns>
		protected virtual TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int tipo_de_dato_idColumnIndex = reader.GetOrdinal("TIPO_DE_DATO_ID");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int tramite_tipo_etapa_idColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ETAPA_ID");
			int tramite_tipo_etapa_nombreColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ETAPA_NOMBRE");
			int tramite_tipo_idColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_ID");
			int tramite_tipo_nombreColumnIndex = reader.GetOrdinal("TRAMITE_TIPO_NOMBRE");
			int genera_alarmaColumnIndex = reader.GetOrdinal("GENERA_ALARMA");
			int es_obligatorioColumnIndex = reader.GetOrdinal("ES_OBLIGATORIO");
			int tipo_texto_predefinido_idColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEFINIDO_ID");
			int tipo_texto_predefinido_nombreColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEFINIDO_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRAMIT_TIP_CAMP_ETAP_INF_COMPRow record = new TRAMIT_TIP_CAMP_ETAP_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.TIPO_DE_DATO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_de_dato_idColumnIndex)), 9);
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(tramite_tipo_etapa_idColumnIndex))
						record.TRAMITE_TIPO_ETAPA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_tipo_etapa_idColumnIndex)), 9);
					if(!reader.IsDBNull(tramite_tipo_etapa_nombreColumnIndex))
						record.TRAMITE_TIPO_ETAPA_NOMBRE = Convert.ToString(reader.GetValue(tramite_tipo_etapa_nombreColumnIndex));
					if(!reader.IsDBNull(tramite_tipo_idColumnIndex))
						record.TRAMITE_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(tramite_tipo_nombreColumnIndex))
						record.TRAMITE_TIPO_NOMBRE = Convert.ToString(reader.GetValue(tramite_tipo_nombreColumnIndex));
					record.GENERA_ALARMA = Convert.ToString(reader.GetValue(genera_alarmaColumnIndex));
					record.ES_OBLIGATORIO = Convert.ToString(reader.GetValue(es_obligatorioColumnIndex));
					if(!reader.IsDBNull(tipo_texto_predefinido_idColumnIndex))
						record.TIPO_TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_texto_predefinido_nombreColumnIndex))
						record.TIPO_TEXTO_PREDEFINIDO_NOMBRE = Convert.ToString(reader.GetValue(tipo_texto_predefinido_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRAMIT_TIP_CAMP_ETAP_INF_COMPRow[])(recordList.ToArray(typeof(TRAMIT_TIP_CAMP_ETAP_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRAMIT_TIP_CAMP_ETAP_INF_COMPRow"/> object.</returns>
		protected virtual TRAMIT_TIP_CAMP_ETAP_INF_COMPRow MapRow(DataRow row)
		{
			TRAMIT_TIP_CAMP_ETAP_INF_COMPRow mappedObject = new TRAMIT_TIP_CAMP_ETAP_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "TIPO_DE_DATO_ID"
			dataColumn = dataTable.Columns["TIPO_DE_DATO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DE_DATO_ID = (decimal)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
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
			// Column "GENERA_ALARMA"
			dataColumn = dataTable.Columns["GENERA_ALARMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERA_ALARMA = (string)row[dataColumn];
			// Column "ES_OBLIGATORIO"
			dataColumn = dataTable.Columns["ES_OBLIGATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_OBLIGATORIO = (string)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEFINIDO_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEFINIDO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEFINIDO_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRAMIT_TIP_CAMP_ETAP_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRAMIT_TIP_CAMP_ETAP_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DE_DATO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ETAPA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ETAPA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITE_TIPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERA_ALARMA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_OBLIGATORIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEFINIDO_NOMBRE", typeof(string));
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

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_DE_DATO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN":
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

				case "GENERA_ALARMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_OBLIGATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_TEXTO_PREDEFINIDO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRAMIT_TIP_CAMP_ETAP_INF_COMPCollection_Base class
}  // End of namespace
