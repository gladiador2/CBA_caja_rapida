// <fileinfo name="PERSONAS_LINEA_CREDITO_ACTIVACollection_Base.cs">
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
	/// The base class for <see cref="PERSONAS_LINEA_CREDITO_ACTIVACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PERSONAS_LINEA_CREDITO_ACTIVACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_LINEA_CREDITO_ACTIVACollection_Base
	{
		// Constants
		public const string PERSONAS_LINEA_CREDITO_IDColumnName = "PERSONAS_LINEA_CREDITO_ID";
		public const string TEMPORALColumnName = "TEMPORAL";
		public const string APROBADOColumnName = "APROBADO";
		public const string UTILIZADOColumnName = "UTILIZADO";
		public const string MONTO_LINEA_CREDITOColumnName = "MONTO_LINEA_CREDITO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string FECHA_ASIGNACIONColumnName = "FECHA_ASIGNACION";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string NOMBRE_COMPLETOColumnName = "NOMBRE_COMPLETO";
		public const string CREDITO_MENOS_DEBITOColumnName = "CREDITO_MENOS_DEBITO";
		public const string CREDITO_MENOS_DEBITO_MONEDA_LCColumnName = "CREDITO_MENOS_DEBITO_MONEDA_LC";
		public const string TOT_CHEQ_NO_DEPOSIT_NI_EFECTIVColumnName = "TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV";
		public const string TOT_CHEQ_NO_DEP_NI_EFEC_MON_LCColumnName = "TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_LINEA_CREDITO_ACTIVACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PERSONAS_LINEA_CREDITO_ACTIVACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PERSONAS_LINEA_CREDITO_ACTIVA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITO_ACTIVARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PERSONAS_LINEA_CREDITO_ACTIVA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PERSONAS_LINEA_CREDITO_ACTIVA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PERSONAS_LINEA_CREDITO_ACTIVARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PERSONAS_LINEA_CREDITO_ACTIVARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects.</returns>
		public PERSONAS_LINEA_CREDITO_ACTIVARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects that 
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects.</returns>
		public virtual PERSONAS_LINEA_CREDITO_ACTIVARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PERSONAS_LINEA_CREDITO_ACTIVA";
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects.</returns>
		protected PERSONAS_LINEA_CREDITO_ACTIVARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects.</returns>
		protected PERSONAS_LINEA_CREDITO_ACTIVARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> objects.</returns>
		protected virtual PERSONAS_LINEA_CREDITO_ACTIVARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int personas_linea_credito_idColumnIndex = reader.GetOrdinal("PERSONAS_LINEA_CREDITO_ID");
			int temporalColumnIndex = reader.GetOrdinal("TEMPORAL");
			int aprobadoColumnIndex = reader.GetOrdinal("APROBADO");
			int utilizadoColumnIndex = reader.GetOrdinal("UTILIZADO");
			int monto_linea_creditoColumnIndex = reader.GetOrdinal("MONTO_LINEA_CREDITO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int fecha_asignacionColumnIndex = reader.GetOrdinal("FECHA_ASIGNACION");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int nombre_completoColumnIndex = reader.GetOrdinal("NOMBRE_COMPLETO");
			int credito_menos_debitoColumnIndex = reader.GetOrdinal("CREDITO_MENOS_DEBITO");
			int credito_menos_debito_moneda_lcColumnIndex = reader.GetOrdinal("CREDITO_MENOS_DEBITO_MONEDA_LC");
			int tot_cheq_no_deposit_ni_efectivColumnIndex = reader.GetOrdinal("TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV");
			int tot_cheq_no_dep_ni_efec_mon_lcColumnIndex = reader.GetOrdinal("TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PERSONAS_LINEA_CREDITO_ACTIVARow record = new PERSONAS_LINEA_CREDITO_ACTIVARow();
					recordList.Add(record);

					record.PERSONAS_LINEA_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(personas_linea_credito_idColumnIndex)), 9);
					record.TEMPORAL = Convert.ToString(reader.GetValue(temporalColumnIndex));
					if(!reader.IsDBNull(aprobadoColumnIndex))
						record.APROBADO = Convert.ToString(reader.GetValue(aprobadoColumnIndex));
					if(!reader.IsDBNull(utilizadoColumnIndex))
						record.UTILIZADO = Convert.ToString(reader.GetValue(utilizadoColumnIndex));
					record.MONTO_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_linea_creditoColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.FECHA_ASIGNACION = Convert.ToDateTime(reader.GetValue(fecha_asignacionColumnIndex));
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_completoColumnIndex))
						record.NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(nombre_completoColumnIndex));
					if(!reader.IsDBNull(credito_menos_debitoColumnIndex))
						record.CREDITO_MENOS_DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(credito_menos_debitoColumnIndex)), 9);
					if(!reader.IsDBNull(credito_menos_debito_moneda_lcColumnIndex))
						record.CREDITO_MENOS_DEBITO_MONEDA_LC = Math.Round(Convert.ToDecimal(reader.GetValue(credito_menos_debito_moneda_lcColumnIndex)), 9);
					if(!reader.IsDBNull(tot_cheq_no_deposit_ni_efectivColumnIndex))
						record.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV = Math.Round(Convert.ToDecimal(reader.GetValue(tot_cheq_no_deposit_ni_efectivColumnIndex)), 9);
					if(!reader.IsDBNull(tot_cheq_no_dep_ni_efec_mon_lcColumnIndex))
						record.TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC = Math.Round(Convert.ToDecimal(reader.GetValue(tot_cheq_no_dep_ni_efec_mon_lcColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PERSONAS_LINEA_CREDITO_ACTIVARow[])(recordList.ToArray(typeof(PERSONAS_LINEA_CREDITO_ACTIVARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PERSONAS_LINEA_CREDITO_ACTIVARow"/> object.</returns>
		protected virtual PERSONAS_LINEA_CREDITO_ACTIVARow MapRow(DataRow row)
		{
			PERSONAS_LINEA_CREDITO_ACTIVARow mappedObject = new PERSONAS_LINEA_CREDITO_ACTIVARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PERSONAS_LINEA_CREDITO_ID"
			dataColumn = dataTable.Columns["PERSONAS_LINEA_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONAS_LINEA_CREDITO_ID = (decimal)row[dataColumn];
			// Column "TEMPORAL"
			dataColumn = dataTable.Columns["TEMPORAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPORAL = (string)row[dataColumn];
			// Column "APROBADO"
			dataColumn = dataTable.Columns["APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBADO = (string)row[dataColumn];
			// Column "UTILIZADO"
			dataColumn = dataTable.Columns["UTILIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.UTILIZADO = (string)row[dataColumn];
			// Column "MONTO_LINEA_CREDITO"
			dataColumn = dataTable.Columns["MONTO_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_LINEA_CREDITO = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "FECHA_ASIGNACION"
			dataColumn = dataTable.Columns["FECHA_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ASIGNACION = (System.DateTime)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "CREDITO_MENOS_DEBITO"
			dataColumn = dataTable.Columns["CREDITO_MENOS_DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO_MENOS_DEBITO = (decimal)row[dataColumn];
			// Column "CREDITO_MENOS_DEBITO_MONEDA_LC"
			dataColumn = dataTable.Columns["CREDITO_MENOS_DEBITO_MONEDA_LC"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO_MENOS_DEBITO_MONEDA_LC = (decimal)row[dataColumn];
			// Column "TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV"
			dataColumn = dataTable.Columns["TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV = (decimal)row[dataColumn];
			// Column "TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC"
			dataColumn = dataTable.Columns["TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PERSONAS_LINEA_CREDITO_ACTIVA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PERSONAS_LINEA_CREDITO_ACTIVA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PERSONAS_LINEA_CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEMPORAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UTILIZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_LINEA_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ASIGNACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREDITO_MENOS_DEBITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREDITO_MENOS_DEBITO_MONEDA_LC", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC", typeof(decimal));
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
				case "PERSONAS_LINEA_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEMPORAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "UTILIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CREDITO_MENOS_DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO_MENOS_DEBITO_MONEDA_LC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOT_CHEQ_NO_DEP_NI_EFEC_MON_LC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PERSONAS_LINEA_CREDITO_ACTIVACollection_Base class
}  // End of namespace
