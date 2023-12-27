// <fileinfo name="IMPORTACIONES_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONES_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="IMPORTACIONES_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONES_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_SALIDAColumnName = "FECHA_SALIDA";
		public const string DOCUMENTOSColumnName = "DOCUMENTOS";
		public const string NUMERO_BLColumnName = "NUMERO_BL";
		public const string FECHA_LLEGADA_SITIO_INTERMEDIOColumnName = "FECHA_LLEGADA_SITIO_INTERMEDIO";
		public const string FECHA_LLEGADA_DESTINO_FINALColumnName = "FECHA_LLEGADA_DESTINO_FINAL";
		public const string EMBARCADORColumnName = "EMBARCADOR";
		public const string SE_PUEDE_MODIFICARColumnName = "SE_PUEDE_MODIFICAR";
		public const string FINALIZADOColumnName = "FINALIZADO";
		public const string NOMBRE_INTERNOColumnName = "NOMBRE_INTERNO";
		public const string MONEDA_PAIS_IDColumnName = "MONEDA_PAIS_ID";
		public const string MONEDA_PAIS_COTIZACIONColumnName = "MONEDA_PAIS_COTIZACION";
		public const string TOTAL_GASTOColumnName = "TOTAL_GASTO";
		public const string TOTAL_FACTURAColumnName = "TOTAL_FACTURA";
		public const string TOTAL_IMPUESTO_FACTURAColumnName = "TOTAL_IMPUESTO_FACTURA";
		public const string TOTAL_IMPUESTO_GASTOColumnName = "TOTAL_IMPUESTO_GASTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONES_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public IMPORTACIONES_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>IMPORTACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects.</returns>
		public virtual IMPORTACIONES_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>IMPORTACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>IMPORTACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public IMPORTACIONES_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			IMPORTACIONES_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects.</returns>
		public IMPORTACIONES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects.</returns>
		public virtual IMPORTACIONES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.IMPORTACIONES_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects.</returns>
		protected IMPORTACIONES_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects.</returns>
		protected IMPORTACIONES_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="IMPORTACIONES_INFO_COMPLETARow"/> objects.</returns>
		protected virtual IMPORTACIONES_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_salidaColumnIndex = reader.GetOrdinal("FECHA_SALIDA");
			int documentosColumnIndex = reader.GetOrdinal("DOCUMENTOS");
			int numero_blColumnIndex = reader.GetOrdinal("NUMERO_BL");
			int fecha_llegada_sitio_intermedioColumnIndex = reader.GetOrdinal("FECHA_LLEGADA_SITIO_INTERMEDIO");
			int fecha_llegada_destino_finalColumnIndex = reader.GetOrdinal("FECHA_LLEGADA_DESTINO_FINAL");
			int embarcadorColumnIndex = reader.GetOrdinal("EMBARCADOR");
			int se_puede_modificarColumnIndex = reader.GetOrdinal("SE_PUEDE_MODIFICAR");
			int finalizadoColumnIndex = reader.GetOrdinal("FINALIZADO");
			int nombre_internoColumnIndex = reader.GetOrdinal("NOMBRE_INTERNO");
			int moneda_pais_idColumnIndex = reader.GetOrdinal("MONEDA_PAIS_ID");
			int moneda_pais_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_PAIS_COTIZACION");
			int total_gastoColumnIndex = reader.GetOrdinal("TOTAL_GASTO");
			int total_facturaColumnIndex = reader.GetOrdinal("TOTAL_FACTURA");
			int total_impuesto_facturaColumnIndex = reader.GetOrdinal("TOTAL_IMPUESTO_FACTURA");
			int total_impuesto_gastoColumnIndex = reader.GetOrdinal("TOTAL_IMPUESTO_GASTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					IMPORTACIONES_INFO_COMPLETARow record = new IMPORTACIONES_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_salidaColumnIndex))
						record.FECHA_SALIDA = Convert.ToDateTime(reader.GetValue(fecha_salidaColumnIndex));
					if(!reader.IsDBNull(documentosColumnIndex))
						record.DOCUMENTOS = Convert.ToString(reader.GetValue(documentosColumnIndex));
					if(!reader.IsDBNull(numero_blColumnIndex))
						record.NUMERO_BL = Convert.ToString(reader.GetValue(numero_blColumnIndex));
					if(!reader.IsDBNull(fecha_llegada_sitio_intermedioColumnIndex))
						record.FECHA_LLEGADA_SITIO_INTERMEDIO = Convert.ToDateTime(reader.GetValue(fecha_llegada_sitio_intermedioColumnIndex));
					if(!reader.IsDBNull(fecha_llegada_destino_finalColumnIndex))
						record.FECHA_LLEGADA_DESTINO_FINAL = Convert.ToDateTime(reader.GetValue(fecha_llegada_destino_finalColumnIndex));
					if(!reader.IsDBNull(embarcadorColumnIndex))
						record.EMBARCADOR = Convert.ToString(reader.GetValue(embarcadorColumnIndex));
					if(!reader.IsDBNull(se_puede_modificarColumnIndex))
						record.SE_PUEDE_MODIFICAR = Convert.ToString(reader.GetValue(se_puede_modificarColumnIndex));
					if(!reader.IsDBNull(finalizadoColumnIndex))
						record.FINALIZADO = Convert.ToString(reader.GetValue(finalizadoColumnIndex));
					if(!reader.IsDBNull(nombre_internoColumnIndex))
						record.NOMBRE_INTERNO = Convert.ToString(reader.GetValue(nombre_internoColumnIndex));
					if(!reader.IsDBNull(moneda_pais_idColumnIndex))
						record.MONEDA_PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_pais_cotizacionColumnIndex))
						record.MONEDA_PAIS_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_pais_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(total_gastoColumnIndex))
						record.TOTAL_GASTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_gastoColumnIndex)), 9);
					if(!reader.IsDBNull(total_facturaColumnIndex))
						record.TOTAL_FACTURA = Math.Round(Convert.ToDecimal(reader.GetValue(total_facturaColumnIndex)), 9);
					if(!reader.IsDBNull(total_impuesto_facturaColumnIndex))
						record.TOTAL_IMPUESTO_FACTURA = Math.Round(Convert.ToDecimal(reader.GetValue(total_impuesto_facturaColumnIndex)), 9);
					if(!reader.IsDBNull(total_impuesto_gastoColumnIndex))
						record.TOTAL_IMPUESTO_GASTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_impuesto_gastoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (IMPORTACIONES_INFO_COMPLETARow[])(recordList.ToArray(typeof(IMPORTACIONES_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="IMPORTACIONES_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="IMPORTACIONES_INFO_COMPLETARow"/> object.</returns>
		protected virtual IMPORTACIONES_INFO_COMPLETARow MapRow(DataRow row)
		{
			IMPORTACIONES_INFO_COMPLETARow mappedObject = new IMPORTACIONES_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_SALIDA"
			dataColumn = dataTable.Columns["FECHA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA = (System.DateTime)row[dataColumn];
			// Column "DOCUMENTOS"
			dataColumn = dataTable.Columns["DOCUMENTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTOS = (string)row[dataColumn];
			// Column "NUMERO_BL"
			dataColumn = dataTable.Columns["NUMERO_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_BL = (string)row[dataColumn];
			// Column "FECHA_LLEGADA_SITIO_INTERMEDIO"
			dataColumn = dataTable.Columns["FECHA_LLEGADA_SITIO_INTERMEDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_LLEGADA_SITIO_INTERMEDIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_LLEGADA_DESTINO_FINAL"
			dataColumn = dataTable.Columns["FECHA_LLEGADA_DESTINO_FINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_LLEGADA_DESTINO_FINAL = (System.DateTime)row[dataColumn];
			// Column "EMBARCADOR"
			dataColumn = dataTable.Columns["EMBARCADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMBARCADOR = (string)row[dataColumn];
			// Column "SE_PUEDE_MODIFICAR"
			dataColumn = dataTable.Columns["SE_PUEDE_MODIFICAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.SE_PUEDE_MODIFICAR = (string)row[dataColumn];
			// Column "FINALIZADO"
			dataColumn = dataTable.Columns["FINALIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FINALIZADO = (string)row[dataColumn];
			// Column "NOMBRE_INTERNO"
			dataColumn = dataTable.Columns["NOMBRE_INTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_INTERNO = (string)row[dataColumn];
			// Column "MONEDA_PAIS_ID"
			dataColumn = dataTable.Columns["MONEDA_PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_PAIS_ID = (decimal)row[dataColumn];
			// Column "MONEDA_PAIS_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_PAIS_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_PAIS_COTIZACION = (decimal)row[dataColumn];
			// Column "TOTAL_GASTO"
			dataColumn = dataTable.Columns["TOTAL_GASTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_GASTO = (decimal)row[dataColumn];
			// Column "TOTAL_FACTURA"
			dataColumn = dataTable.Columns["TOTAL_FACTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_FACTURA = (decimal)row[dataColumn];
			// Column "TOTAL_IMPUESTO_FACTURA"
			dataColumn = dataTable.Columns["TOTAL_IMPUESTO_FACTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPUESTO_FACTURA = (decimal)row[dataColumn];
			// Column "TOTAL_IMPUESTO_GASTO"
			dataColumn = dataTable.Columns["TOTAL_IMPUESTO_GASTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPUESTO_GASTO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>IMPORTACIONES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "IMPORTACIONES_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DOCUMENTOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_BL", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_LLEGADA_SITIO_INTERMEDIO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_LLEGADA_DESTINO_FINAL", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMBARCADOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SE_PUEDE_MODIFICAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FINALIZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_INTERNO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_PAIS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_PAIS_COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_GASTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_FACTURA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_IMPUESTO_FACTURA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_IMPUESTO_GASTO", typeof(decimal));
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

				case "FECHA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DOCUMENTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NUMERO_BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_LLEGADA_SITIO_INTERMEDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_LLEGADA_DESTINO_FINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EMBARCADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SE_PUEDE_MODIFICAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FINALIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE_INTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_PAIS_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_GASTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_FACTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPUESTO_FACTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPUESTO_GASTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of IMPORTACIONES_INFO_COMPLETACollection_Base class
}  // End of namespace
