// <fileinfo name="DESC_DOCS_PAGOS_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="DESC_DOCS_PAGOS_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESC_DOCS_PAGOS_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESC_DOCS_PAGOS_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string DESCUENTO_DOCUMENTO_IDColumnName = "DESCUENTO_DOCUMENTO_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_VALOR_NOMBREColumnName = "CTACTE_VALOR_NOMBRE";
		public const string CHEQUE_CTACTE_BANCO_IDColumnName = "CHEQUE_CTACTE_BANCO_ID";
		public const string CHEQUE_CTACTE_BANCO_NOMBREColumnName = "CHEQUE_CTACTE_BANCO_NOMBRE";
		public const string CHEQUE_FECHA_POSTDATADOColumnName = "CHEQUE_FECHA_POSTDATADO";
		public const string CHEQUE_NOMBRE_EMISORColumnName = "CHEQUE_NOMBRE_EMISOR";
		public const string CHEQUE_NOMBRE_BENEFICIARIOColumnName = "CHEQUE_NOMBRE_BENEFICIARIO";
		public const string CHEQUE_FECHA_VENCIMIENTOColumnName = "CHEQUE_FECHA_VENCIMIENTO";
		public const string CHEQUE_ES_DIFERIDOColumnName = "CHEQUE_ES_DIFERIDO";
		public const string CHEQUE_NRO_CUENTAColumnName = "CHEQUE_NRO_CUENTA";
		public const string CHEQUE_NRO_CHEQUEColumnName = "CHEQUE_NRO_CHEQUE";
		public const string CHEQUE_DOCUMENTO_EMISORColumnName = "CHEQUE_DOCUMENTO_EMISOR";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string TRANSFERENCIA_BANCARIA_IDColumnName = "TRANSFERENCIA_BANCARIA_ID";
		public const string DEPOSITO_BANCARIO_IDColumnName = "DEPOSITO_BANCARIO_ID";
		public const string DEPOSITO_CTACTE_BANCARIA_IDColumnName = "DEPOSITO_CTACTE_BANCARIA_ID";
		public const string DEPOSITO_NRO_BOLETAColumnName = "DEPOSITO_NRO_BOLETA";
		public const string DEPOSITO_FECHAColumnName = "DEPOSITO_FECHA";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESC_DOCS_PAGOS_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESC_DOCS_PAGOS_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESC_DOCS_PAGOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects.</returns>
		public virtual DESC_DOCS_PAGOS_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESC_DOCS_PAGOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESC_DOCS_PAGOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESC_DOCS_PAGOS_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESC_DOCS_PAGOS_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects.</returns>
		public DESC_DOCS_PAGOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects.</returns>
		public virtual DESC_DOCS_PAGOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESC_DOCS_PAGOS_INFO_COMPL";
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
		/// <returns>An array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects.</returns>
		protected DESC_DOCS_PAGOS_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects.</returns>
		protected DESC_DOCS_PAGOS_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> objects.</returns>
		protected virtual DESC_DOCS_PAGOS_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int descuento_documento_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_valor_nombreColumnIndex = reader.GetOrdinal("CTACTE_VALOR_NOMBRE");
			int cheque_ctacte_banco_idColumnIndex = reader.GetOrdinal("CHEQUE_CTACTE_BANCO_ID");
			int cheque_ctacte_banco_nombreColumnIndex = reader.GetOrdinal("CHEQUE_CTACTE_BANCO_NOMBRE");
			int cheque_fecha_postdatadoColumnIndex = reader.GetOrdinal("CHEQUE_FECHA_POSTDATADO");
			int cheque_nombre_emisorColumnIndex = reader.GetOrdinal("CHEQUE_NOMBRE_EMISOR");
			int cheque_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CHEQUE_NOMBRE_BENEFICIARIO");
			int cheque_fecha_vencimientoColumnIndex = reader.GetOrdinal("CHEQUE_FECHA_VENCIMIENTO");
			int cheque_es_diferidoColumnIndex = reader.GetOrdinal("CHEQUE_ES_DIFERIDO");
			int cheque_nro_cuentaColumnIndex = reader.GetOrdinal("CHEQUE_NRO_CUENTA");
			int cheque_nro_chequeColumnIndex = reader.GetOrdinal("CHEQUE_NRO_CHEQUE");
			int cheque_documento_emisorColumnIndex = reader.GetOrdinal("CHEQUE_DOCUMENTO_EMISOR");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int transferencia_bancaria_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BANCARIA_ID");
			int deposito_bancario_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_ID");
			int deposito_ctacte_bancaria_idColumnIndex = reader.GetOrdinal("DEPOSITO_CTACTE_BANCARIA_ID");
			int deposito_nro_boletaColumnIndex = reader.GetOrdinal("DEPOSITO_NRO_BOLETA");
			int deposito_fechaColumnIndex = reader.GetOrdinal("DEPOSITO_FECHA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESC_DOCS_PAGOS_INFO_COMPLRow record = new DESC_DOCS_PAGOS_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.DESCUENTO_DOCUMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_idColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.CTACTE_VALOR_NOMBRE = Convert.ToString(reader.GetValue(ctacte_valor_nombreColumnIndex));
					if(!reader.IsDBNull(cheque_ctacte_banco_idColumnIndex))
						record.CHEQUE_CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_ctacte_banco_nombreColumnIndex))
						record.CHEQUE_CTACTE_BANCO_NOMBRE = Convert.ToString(reader.GetValue(cheque_ctacte_banco_nombreColumnIndex));
					if(!reader.IsDBNull(cheque_fecha_postdatadoColumnIndex))
						record.CHEQUE_FECHA_POSTDATADO = Convert.ToDateTime(reader.GetValue(cheque_fecha_postdatadoColumnIndex));
					if(!reader.IsDBNull(cheque_nombre_emisorColumnIndex))
						record.CHEQUE_NOMBRE_EMISOR = Convert.ToString(reader.GetValue(cheque_nombre_emisorColumnIndex));
					if(!reader.IsDBNull(cheque_nombre_beneficiarioColumnIndex))
						record.CHEQUE_NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(cheque_nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cheque_fecha_vencimientoColumnIndex))
						record.CHEQUE_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(cheque_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(cheque_es_diferidoColumnIndex))
						record.CHEQUE_ES_DIFERIDO = Convert.ToString(reader.GetValue(cheque_es_diferidoColumnIndex));
					if(!reader.IsDBNull(cheque_nro_cuentaColumnIndex))
						record.CHEQUE_NRO_CUENTA = Convert.ToString(reader.GetValue(cheque_nro_cuentaColumnIndex));
					if(!reader.IsDBNull(cheque_nro_chequeColumnIndex))
						record.CHEQUE_NRO_CHEQUE = Convert.ToString(reader.GetValue(cheque_nro_chequeColumnIndex));
					if(!reader.IsDBNull(cheque_documento_emisorColumnIndex))
						record.CHEQUE_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(cheque_documento_emisorColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_bancaria_idColumnIndex))
						record.TRANSFERENCIA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_idColumnIndex))
						record.DEPOSITO_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_ctacte_bancaria_idColumnIndex))
						record.DEPOSITO_CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_nro_boletaColumnIndex))
						record.DEPOSITO_NRO_BOLETA = Convert.ToString(reader.GetValue(deposito_nro_boletaColumnIndex));
					if(!reader.IsDBNull(deposito_fechaColumnIndex))
						record.DEPOSITO_FECHA = Convert.ToDateTime(reader.GetValue(deposito_fechaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESC_DOCS_PAGOS_INFO_COMPLRow[])(recordList.ToArray(typeof(DESC_DOCS_PAGOS_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESC_DOCS_PAGOS_INFO_COMPLRow"/> object.</returns>
		protected virtual DESC_DOCS_PAGOS_INFO_COMPLRow MapRow(DataRow row)
		{
			DESC_DOCS_PAGOS_INFO_COMPLRow mappedObject = new DESC_DOCS_PAGOS_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_VALOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_NOMBRE = (string)row[dataColumn];
			// Column "CHEQUE_CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CHEQUE_CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CHEQUE_CTACTE_BANCO_NOMBRE"
			dataColumn = dataTable.Columns["CHEQUE_CTACTE_BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_CTACTE_BANCO_NOMBRE = (string)row[dataColumn];
			// Column "CHEQUE_FECHA_POSTDATADO"
			dataColumn = dataTable.Columns["CHEQUE_FECHA_POSTDATADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_FECHA_POSTDATADO = (System.DateTime)row[dataColumn];
			// Column "CHEQUE_NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["CHEQUE_NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "CHEQUE_NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["CHEQUE_NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CHEQUE_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CHEQUE_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CHEQUE_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CHEQUE_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ES_DIFERIDO = (string)row[dataColumn];
			// Column "CHEQUE_NRO_CUENTA"
			dataColumn = dataTable.Columns["CHEQUE_NRO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NRO_CUENTA = (string)row[dataColumn];
			// Column "CHEQUE_NRO_CHEQUE"
			dataColumn = dataTable.Columns["CHEQUE_NRO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NRO_CHEQUE = (string)row[dataColumn];
			// Column "CHEQUE_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["CHEQUE_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_BANCARIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["DEPOSITO_CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_NRO_BOLETA"
			dataColumn = dataTable.Columns["DEPOSITO_NRO_BOLETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_NRO_BOLETA = (string)row[dataColumn];
			// Column "DEPOSITO_FECHA"
			dataColumn = dataTable.Columns["DEPOSITO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_FECHA = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESC_DOCS_PAGOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESC_DOCS_PAGOS_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_CTACTE_BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_FECHA_POSTDATADO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_NRO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_NRO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_NRO_BOLETA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 125;
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

				case "DESCUENTO_DOCUMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_CTACTE_BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_FECHA_POSTDATADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHEQUE_NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHEQUE_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CHEQUE_NRO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NRO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_NRO_BOLETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESC_DOCS_PAGOS_INFO_COMPLCollection_Base class
}  // End of namespace
