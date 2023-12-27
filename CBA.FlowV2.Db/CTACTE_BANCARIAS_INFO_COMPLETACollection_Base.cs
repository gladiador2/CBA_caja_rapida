// <fileinfo name="CTACTE_BANCARIAS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCARIAS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_BANCARIAS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCARIAS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NUMERO_CUENTAColumnName = "NUMERO_CUENTA";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string BANCO_NOMBREColumnName = "BANCO_NOMBRE";
		public const string BANCO_ABREVIATURAColumnName = "BANCO_ABREVIATURA";
		public const string BANCO_PAIS_IDColumnName = "BANCO_PAIS_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDAColumnName = "MONEDA";
		public const string SALDO_INICIALColumnName = "SALDO_INICIAL";
		public const string SALDO_EXTRACTOColumnName = "SALDO_EXTRACTO";
		public const string MONTO_LINEA_CREDITOColumnName = "MONTO_LINEA_CREDITO";
		public const string MONTO_SOBREGIROColumnName = "MONTO_SOBREGIRO";
		public const string ESTADOColumnName = "ESTADO";
		public const string TITULARColumnName = "TITULAR";
		public const string SALDO_ACTUALColumnName = "SALDO_ACTUAL";
		public const string SALDO_CONCILIADOColumnName = "SALDO_CONCILIADO";
		public const string REPORTE_IDColumnName = "REPORTE_ID";
		public const string REPORTE_NOMBREColumnName = "REPORTE_NOMBRE";
		public const string REPORTE_PARA_BANCO_IDColumnName = "REPORTE_PARA_BANCO_ID";
		public const string TIPO_IDColumnName = "TIPO_ID";
		public const string TIPOS_CTACTE_BANCARIA_DESCRColumnName = "TIPOS_CTACTE_BANCARIA_DESCR";
		public const string ORDENColumnName = "ORDEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIAS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_BANCARIAS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_BANCARIAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_BANCARIAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_BANCARIAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_BANCARIAS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_BANCARIAS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects.</returns>
		public CTACTE_BANCARIAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_BANCARIAS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_BANCARIAS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_BANCARIAS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTACTE_BANCARIAS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int numero_cuentaColumnIndex = reader.GetOrdinal("NUMERO_CUENTA");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int banco_nombreColumnIndex = reader.GetOrdinal("BANCO_NOMBRE");
			int banco_abreviaturaColumnIndex = reader.GetOrdinal("BANCO_ABREVIATURA");
			int banco_pais_idColumnIndex = reader.GetOrdinal("BANCO_PAIS_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monedaColumnIndex = reader.GetOrdinal("MONEDA");
			int saldo_inicialColumnIndex = reader.GetOrdinal("SALDO_INICIAL");
			int saldo_extractoColumnIndex = reader.GetOrdinal("SALDO_EXTRACTO");
			int monto_linea_creditoColumnIndex = reader.GetOrdinal("MONTO_LINEA_CREDITO");
			int monto_sobregiroColumnIndex = reader.GetOrdinal("MONTO_SOBREGIRO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int titularColumnIndex = reader.GetOrdinal("TITULAR");
			int saldo_actualColumnIndex = reader.GetOrdinal("SALDO_ACTUAL");
			int saldo_conciliadoColumnIndex = reader.GetOrdinal("SALDO_CONCILIADO");
			int reporte_idColumnIndex = reader.GetOrdinal("REPORTE_ID");
			int reporte_nombreColumnIndex = reader.GetOrdinal("REPORTE_NOMBRE");
			int reporte_para_banco_idColumnIndex = reader.GetOrdinal("REPORTE_PARA_BANCO_ID");
			int tipo_idColumnIndex = reader.GetOrdinal("TIPO_ID");
			int tipos_ctacte_bancaria_descrColumnIndex = reader.GetOrdinal("TIPOS_CTACTE_BANCARIA_DESCR");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_BANCARIAS_INFO_COMPLETARow record = new CTACTE_BANCARIAS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NUMERO_CUENTA = Convert.ToString(reader.GetValue(numero_cuentaColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(entidad_idColumnIndex))
						record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					record.BANCO_NOMBRE = Convert.ToString(reader.GetValue(banco_nombreColumnIndex));
					record.BANCO_ABREVIATURA = Convert.ToString(reader.GetValue(banco_abreviaturaColumnIndex));
					record.BANCO_PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(banco_pais_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA = Convert.ToString(reader.GetValue(monedaColumnIndex));
					record.SALDO_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_inicialColumnIndex)), 9);
					if(!reader.IsDBNull(saldo_extractoColumnIndex))
						record.SALDO_EXTRACTO = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_extractoColumnIndex)), 9);
					record.MONTO_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_linea_creditoColumnIndex)), 9);
					record.MONTO_SOBREGIRO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_sobregiroColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(titularColumnIndex))
						record.TITULAR = Convert.ToString(reader.GetValue(titularColumnIndex));
					if(!reader.IsDBNull(saldo_actualColumnIndex))
						record.SALDO_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_actualColumnIndex)), 9);
					if(!reader.IsDBNull(saldo_conciliadoColumnIndex))
						record.SALDO_CONCILIADO = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_conciliadoColumnIndex)), 9);
					record.REPORTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reporte_idColumnIndex)), 9);
					record.REPORTE_NOMBRE = Convert.ToString(reader.GetValue(reporte_nombreColumnIndex));
					if(!reader.IsDBNull(reporte_para_banco_idColumnIndex))
						record.REPORTE_PARA_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reporte_para_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_idColumnIndex))
						record.TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipos_ctacte_bancaria_descrColumnIndex))
						record.TIPOS_CTACTE_BANCARIA_DESCR = Convert.ToString(reader.GetValue(tipos_ctacte_bancaria_descrColumnIndex));
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_BANCARIAS_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTACTE_BANCARIAS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_BANCARIAS_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTACTE_BANCARIAS_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTACTE_BANCARIAS_INFO_COMPLETARow mappedObject = new CTACTE_BANCARIAS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NUMERO_CUENTA"
			dataColumn = dataTable.Columns["NUMERO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "BANCO_NOMBRE"
			dataColumn = dataTable.Columns["BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANCO_NOMBRE = (string)row[dataColumn];
			// Column "BANCO_ABREVIATURA"
			dataColumn = dataTable.Columns["BANCO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANCO_ABREVIATURA = (string)row[dataColumn];
			// Column "BANCO_PAIS_ID"
			dataColumn = dataTable.Columns["BANCO_PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANCO_PAIS_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA"
			dataColumn = dataTable.Columns["MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA = (string)row[dataColumn];
			// Column "SALDO_INICIAL"
			dataColumn = dataTable.Columns["SALDO_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_INICIAL = (decimal)row[dataColumn];
			// Column "SALDO_EXTRACTO"
			dataColumn = dataTable.Columns["SALDO_EXTRACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_EXTRACTO = (decimal)row[dataColumn];
			// Column "MONTO_LINEA_CREDITO"
			dataColumn = dataTable.Columns["MONTO_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_LINEA_CREDITO = (decimal)row[dataColumn];
			// Column "MONTO_SOBREGIRO"
			dataColumn = dataTable.Columns["MONTO_SOBREGIRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_SOBREGIRO = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TITULAR"
			dataColumn = dataTable.Columns["TITULAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULAR = (string)row[dataColumn];
			// Column "SALDO_ACTUAL"
			dataColumn = dataTable.Columns["SALDO_ACTUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_ACTUAL = (decimal)row[dataColumn];
			// Column "SALDO_CONCILIADO"
			dataColumn = dataTable.Columns["SALDO_CONCILIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_CONCILIADO = (decimal)row[dataColumn];
			// Column "REPORTE_ID"
			dataColumn = dataTable.Columns["REPORTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REPORTE_ID = (decimal)row[dataColumn];
			// Column "REPORTE_NOMBRE"
			dataColumn = dataTable.Columns["REPORTE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.REPORTE_NOMBRE = (string)row[dataColumn];
			// Column "REPORTE_PARA_BANCO_ID"
			dataColumn = dataTable.Columns["REPORTE_PARA_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REPORTE_PARA_BANCO_ID = (decimal)row[dataColumn];
			// Column "TIPO_ID"
			dataColumn = dataTable.Columns["TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ID = (decimal)row[dataColumn];
			// Column "TIPOS_CTACTE_BANCARIA_DESCR"
			dataColumn = dataTable.Columns["TIPOS_CTACTE_BANCARIA_DESCR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPOS_CTACTE_BANCARIA_DESCR = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_BANCARIAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_BANCARIAS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANCO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANCO_PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO_EXTRACTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_LINEA_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_SOBREGIRO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TITULAR", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO_ACTUAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO_CONCILIADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REPORTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REPORTE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REPORTE_PARA_BANCO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPOS_CTACTE_BANCARIA_DESCR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
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

				case "NUMERO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BANCO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BANCO_PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SALDO_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_EXTRACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_SOBREGIRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TITULAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SALDO_ACTUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_CONCILIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REPORTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REPORTE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REPORTE_PARA_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPOS_CTACTE_BANCARIA_DESCR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_BANCARIAS_INFO_COMPLETACollection_Base class
}  // End of namespace
