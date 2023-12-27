// <fileinfo name="CTACTE_TARJETA_CONF_PROC_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_TARJETA_CONF_PROC_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string POS_IDColumnName = "POS_ID";
		public const string PROCESADORA_IDColumnName = "PROCESADORA_ID";
		public const string COMISION_PORCColumnName = "COMISION_PORC";
		public const string IVA_SOBRE_COMISION_PORCColumnName = "IVA_SOBRE_COMISION_PORC";
		public const string RENTA_SOBRE_IVA_PORCColumnName = "RENTA_SOBRE_IVA_PORC";
		public const string CTACTE_BANCARIA_ID_DESTColumnName = "CTACTE_BANCARIA_ID_DEST";
		public const string ES_TARJETA_CREDITOColumnName = "ES_TARJETA_CREDITO";
		public const string CTACTE_CAJA_IDColumnName = "CTACTE_CAJA_ID";
		public const string PROCESADORA_ID_RED_DINELCOColumnName = "PROCESADORA_ID_RED_DINELCO";
		public const string PROCESADORA_ID_RED_INFONETColumnName = "PROCESADORA_ID_RED_INFONET";
		public const string POS_NOMBREColumnName = "POS_NOMBRE";
		public const string PROCESADORA_NOMBREColumnName = "PROCESADORA_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_TARJETA_CONF_PROC_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_TARJETA_CONF_PROC_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects.</returns>
		public virtual CTACTE_TARJETA_CONF_PROC_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_TARJETA_CONF_PROC_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_TARJETA_CONF_PROC_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_TARJETA_CONF_PROC_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_TARJETA_CONF_PROC_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects.</returns>
		public CTACTE_TARJETA_CONF_PROC_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects.</returns>
		public virtual CTACTE_TARJETA_CONF_PROC_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_TARJETA_CONF_PROC_INF_COMP";
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects.</returns>
		protected CTACTE_TARJETA_CONF_PROC_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects.</returns>
		protected CTACTE_TARJETA_CONF_PROC_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> objects.</returns>
		protected virtual CTACTE_TARJETA_CONF_PROC_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pos_idColumnIndex = reader.GetOrdinal("POS_ID");
			int procesadora_idColumnIndex = reader.GetOrdinal("PROCESADORA_ID");
			int comision_porcColumnIndex = reader.GetOrdinal("COMISION_PORC");
			int iva_sobre_comision_porcColumnIndex = reader.GetOrdinal("IVA_SOBRE_COMISION_PORC");
			int renta_sobre_iva_porcColumnIndex = reader.GetOrdinal("RENTA_SOBRE_IVA_PORC");
			int ctacte_bancaria_id_destColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID_DEST");
			int es_tarjeta_creditoColumnIndex = reader.GetOrdinal("ES_TARJETA_CREDITO");
			int ctacte_caja_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_ID");
			int procesadora_id_red_dinelcoColumnIndex = reader.GetOrdinal("PROCESADORA_ID_RED_DINELCO");
			int procesadora_id_red_infonetColumnIndex = reader.GetOrdinal("PROCESADORA_ID_RED_INFONET");
			int pos_nombreColumnIndex = reader.GetOrdinal("POS_NOMBRE");
			int procesadora_nombreColumnIndex = reader.GetOrdinal("PROCESADORA_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_TARJETA_CONF_PROC_INF_COMPRow record = new CTACTE_TARJETA_CONF_PROC_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.POS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pos_idColumnIndex)), 9);
					record.PROCESADORA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(procesadora_idColumnIndex)), 9);
					record.COMISION_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(comision_porcColumnIndex)), 9);
					record.IVA_SOBRE_COMISION_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(iva_sobre_comision_porcColumnIndex)), 9);
					record.RENTA_SOBRE_IVA_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(renta_sobre_iva_porcColumnIndex)), 9);
					record.CTACTE_BANCARIA_ID_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_id_destColumnIndex)), 9);
					record.ES_TARJETA_CREDITO = Convert.ToString(reader.GetValue(es_tarjeta_creditoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_idColumnIndex))
						record.CTACTE_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_idColumnIndex)), 9);
					if(!reader.IsDBNull(procesadora_id_red_dinelcoColumnIndex))
						record.PROCESADORA_ID_RED_DINELCO = Math.Round(Convert.ToDecimal(reader.GetValue(procesadora_id_red_dinelcoColumnIndex)), 9);
					if(!reader.IsDBNull(procesadora_id_red_infonetColumnIndex))
						record.PROCESADORA_ID_RED_INFONET = Math.Round(Convert.ToDecimal(reader.GetValue(procesadora_id_red_infonetColumnIndex)), 9);
					record.POS_NOMBRE = Convert.ToString(reader.GetValue(pos_nombreColumnIndex));
					record.PROCESADORA_NOMBRE = Convert.ToString(reader.GetValue(procesadora_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_TARJETA_CONF_PROC_INF_COMPRow[])(recordList.ToArray(typeof(CTACTE_TARJETA_CONF_PROC_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_TARJETA_CONF_PROC_INF_COMPRow"/> object.</returns>
		protected virtual CTACTE_TARJETA_CONF_PROC_INF_COMPRow MapRow(DataRow row)
		{
			CTACTE_TARJETA_CONF_PROC_INF_COMPRow mappedObject = new CTACTE_TARJETA_CONF_PROC_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "POS_ID"
			dataColumn = dataTable.Columns["POS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.POS_ID = (decimal)row[dataColumn];
			// Column "PROCESADORA_ID"
			dataColumn = dataTable.Columns["PROCESADORA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_ID = (decimal)row[dataColumn];
			// Column "COMISION_PORC"
			dataColumn = dataTable.Columns["COMISION_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_PORC = (decimal)row[dataColumn];
			// Column "IVA_SOBRE_COMISION_PORC"
			dataColumn = dataTable.Columns["IVA_SOBRE_COMISION_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.IVA_SOBRE_COMISION_PORC = (decimal)row[dataColumn];
			// Column "RENTA_SOBRE_IVA_PORC"
			dataColumn = dataTable.Columns["RENTA_SOBRE_IVA_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RENTA_SOBRE_IVA_PORC = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID_DEST"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID_DEST = (decimal)row[dataColumn];
			// Column "ES_TARJETA_CREDITO"
			dataColumn = dataTable.Columns["ES_TARJETA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TARJETA_CREDITO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_ID = (decimal)row[dataColumn];
			// Column "PROCESADORA_ID_RED_DINELCO"
			dataColumn = dataTable.Columns["PROCESADORA_ID_RED_DINELCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_ID_RED_DINELCO = (decimal)row[dataColumn];
			// Column "PROCESADORA_ID_RED_INFONET"
			dataColumn = dataTable.Columns["PROCESADORA_ID_RED_INFONET"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_ID_RED_INFONET = (decimal)row[dataColumn];
			// Column "POS_NOMBRE"
			dataColumn = dataTable.Columns["POS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.POS_NOMBRE = (string)row[dataColumn];
			// Column "PROCESADORA_NOMBRE"
			dataColumn = dataTable.Columns["PROCESADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_TARJETA_CONF_PROC_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_TARJETA_CONF_PROC_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("POS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCESADORA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMISION_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IVA_SOBRE_COMISION_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RENTA_SOBRE_IVA_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_TARJETA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCESADORA_ID_RED_DINELCO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCESADORA_ID_RED_INFONET", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("POS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCESADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "POS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCESADORA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IVA_SOBRE_COMISION_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RENTA_SOBRE_IVA_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_ID_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_TARJETA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCESADORA_ID_RED_DINELCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCESADORA_ID_RED_INFONET":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "POS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROCESADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_TARJETA_CONF_PROC_INF_COMPCollection_Base class
}  // End of namespace
