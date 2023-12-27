// <fileinfo name="DESC_DOCS_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="DESC_DOCS_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESC_DOCS_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESC_DOCS_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string CTACTE_BANCO_NOMBREColumnName = "CTACTE_BANCO_NOMBRE";
		public const string CTACTE_BANCO_ABREVIATURAColumnName = "CTACTE_BANCO_ABREVIATURA";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string CTACTE_BANCARIA_NRO_CUENTAColumnName = "CTACTE_BANCARIA_NRO_CUENTA";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string CTACTE_CAJA_TESORERIA_NOMBREColumnName = "CTACTE_CAJA_TESORERIA_NOMBRE";
		public const string CTACTE_CAJA_TESORERIA_ABREVColumnName = "CTACTE_CAJA_TESORERIA_ABREV";
		public const string FECHAColumnName = "FECHA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NOMBRE_INSTITUCIONColumnName = "NOMBRE_INSTITUCION";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_COTIZACIONColumnName = "MONEDA_COTIZACION";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string MONTO_DOLARIZADOColumnName = "MONTO_DOLARIZADO";
		public const string MONTO_COMISION_DOLARIZADOColumnName = "MONTO_COMISION_DOLARIZADO";
		public const string MONTO_EFECTIVO_DOLARIZADOColumnName = "MONTO_EFECTIVO_DOLARIZADO";
		public const string MONTO_IMPUESTO_DOLARIZADOColumnName = "MONTO_IMPUESTO_DOLARIZADO";
		public const string ORDEN_PAGO_RESPALDA_CASO_IDColumnName = "ORDEN_PAGO_RESPALDA_CASO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESC_DOCS_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESC_DOCS_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESC_DOCS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects.</returns>
		public virtual DESC_DOCS_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESC_DOCS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESC_DOCS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESC_DOCS_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESC_DOCS_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESC_DOCS_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESC_DOCS_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects.</returns>
		public DESC_DOCS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects.</returns>
		public virtual DESC_DOCS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESC_DOCS_INFO_COMPL";
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
		/// <returns>An array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects.</returns>
		protected DESC_DOCS_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects.</returns>
		protected DESC_DOCS_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESC_DOCS_INFO_COMPLRow"/> objects.</returns>
		protected virtual DESC_DOCS_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int ctacte_banco_nombreColumnIndex = reader.GetOrdinal("CTACTE_BANCO_NOMBRE");
			int ctacte_banco_abreviaturaColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ABREVIATURA");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int ctacte_bancaria_nro_cuentaColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_NRO_CUENTA");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int ctacte_caja_tesoreria_nombreColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_NOMBRE");
			int ctacte_caja_tesoreria_abrevColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ABREV");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nombre_institucionColumnIndex = reader.GetOrdinal("NOMBRE_INSTITUCION");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_COTIZACION");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int monto_dolarizadoColumnIndex = reader.GetOrdinal("MONTO_DOLARIZADO");
			int monto_comision_dolarizadoColumnIndex = reader.GetOrdinal("MONTO_COMISION_DOLARIZADO");
			int monto_efectivo_dolarizadoColumnIndex = reader.GetOrdinal("MONTO_EFECTIVO_DOLARIZADO");
			int monto_impuesto_dolarizadoColumnIndex = reader.GetOrdinal("MONTO_IMPUESTO_DOLARIZADO");
			int orden_pago_respalda_caso_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_RESPALDA_CASO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESC_DOCS_INFO_COMPLRow record = new DESC_DOCS_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					if(!reader.IsDBNull(ctacte_banco_idColumnIndex))
						record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_banco_nombreColumnIndex))
						record.CTACTE_BANCO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_banco_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_banco_abreviaturaColumnIndex))
						record.CTACTE_BANCO_ABREVIATURA = Convert.ToString(reader.GetValue(ctacte_banco_abreviaturaColumnIndex));
					if(!reader.IsDBNull(ctacte_bancaria_idColumnIndex))
						record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_bancaria_nro_cuentaColumnIndex))
						record.CTACTE_BANCARIA_NRO_CUENTA = Convert.ToString(reader.GetValue(ctacte_bancaria_nro_cuentaColumnIndex));
					record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					record.CTACTE_CAJA_TESORERIA_NOMBRE = Convert.ToString(reader.GetValue(ctacte_caja_tesoreria_nombreColumnIndex));
					record.CTACTE_CAJA_TESORERIA_ABREV = Convert.ToString(reader.GetValue(ctacte_caja_tesoreria_abrevColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					record.NOMBRE_INSTITUCION = Convert.ToString(reader.GetValue(nombre_institucionColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cotizacionColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(monto_totalColumnIndex))
						record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					if(!reader.IsDBNull(monto_dolarizadoColumnIndex))
						record.MONTO_DOLARIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_dolarizadoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_comision_dolarizadoColumnIndex))
						record.MONTO_COMISION_DOLARIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_comision_dolarizadoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_efectivo_dolarizadoColumnIndex))
						record.MONTO_EFECTIVO_DOLARIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_efectivo_dolarizadoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_impuesto_dolarizadoColumnIndex))
						record.MONTO_IMPUESTO_DOLARIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_impuesto_dolarizadoColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_respalda_caso_idColumnIndex))
						record.ORDEN_PAGO_RESPALDA_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_respalda_caso_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESC_DOCS_INFO_COMPLRow[])(recordList.ToArray(typeof(DESC_DOCS_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESC_DOCS_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESC_DOCS_INFO_COMPLRow"/> object.</returns>
		protected virtual DESC_DOCS_INFO_COMPLRow MapRow(DataRow row)
		{
			DESC_DOCS_INFO_COMPLRow mappedObject = new DESC_DOCS_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCO_ABREVIATURA"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ABREVIATURA = (string)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_NRO_CUENTA"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_NRO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_NRO_CUENTA = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ABREV"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ABREV"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ABREV = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_INSTITUCION"
			dataColumn = dataTable.Columns["NOMBRE_INSTITUCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_INSTITUCION = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "MONTO_DOLARIZADO"
			dataColumn = dataTable.Columns["MONTO_DOLARIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DOLARIZADO = (decimal)row[dataColumn];
			// Column "MONTO_COMISION_DOLARIZADO"
			dataColumn = dataTable.Columns["MONTO_COMISION_DOLARIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COMISION_DOLARIZADO = (decimal)row[dataColumn];
			// Column "MONTO_EFECTIVO_DOLARIZADO"
			dataColumn = dataTable.Columns["MONTO_EFECTIVO_DOLARIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EFECTIVO_DOLARIZADO = (decimal)row[dataColumn];
			// Column "MONTO_IMPUESTO_DOLARIZADO"
			dataColumn = dataTable.Columns["MONTO_IMPUESTO_DOLARIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_IMPUESTO_DOLARIZADO = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_RESPALDA_CASO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_RESPALDA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_RESPALDA_CASO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESC_DOCS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESC_DOCS_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_NRO_CUENTA", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ABREV", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_INSTITUCION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COTIZACION", typeof(decimal));
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
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DOLARIZADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_COMISION_DOLARIZADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_EFECTIVO_DOLARIZADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_IMPUESTO_DOLARIZADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_RESPALDA_CASO_ID", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_NRO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESORERIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ABREV":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_INSTITUCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DOLARIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COMISION_DOLARIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_EFECTIVO_DOLARIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_IMPUESTO_DOLARIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_RESPALDA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESC_DOCS_INFO_COMPLCollection_Base class
}  // End of namespace
