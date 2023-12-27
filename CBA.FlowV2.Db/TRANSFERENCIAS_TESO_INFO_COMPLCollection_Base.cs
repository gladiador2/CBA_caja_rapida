// <fileinfo name="TRANSFERENCIAS_TESO_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIAS_TESO_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSFERENCIAS_TESO_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIAS_TESO_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADOColumnName = "CASO_ESTADO";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string ENTIDAD_NOMBREColumnName = "ENTIDAD_NOMBRE";
		public const string ENTIDAD_ABREVIATURAColumnName = "ENTIDAD_ABREVIATURA";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string SUCURSAL_ORIGEN_NOMBREColumnName = "SUCURSAL_ORIGEN_NOMBRE";
		public const string SUCURSAL_ORIGEN_ABREVIATURAColumnName = "SUCURSAL_ORIGEN_ABREVIATURA";
		public const string CAJA_TESORERIA_ORIGEN_IDColumnName = "CAJA_TESORERIA_ORIGEN_ID";
		public const string CAJA_TESORERIA_ORIGEN_NOMBREColumnName = "CAJA_TESORERIA_ORIGEN_NOMBRE";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string SUCURSAL_DESTINO_NOMBREColumnName = "SUCURSAL_DESTINO_NOMBRE";
		public const string SUCURSAL_DESTINO_ABREVIATURAColumnName = "SUCURSAL_DESTINO_ABREVIATURA";
		public const string CAJA_TESORERIA_DESTINO_IDColumnName = "CAJA_TESORERIA_DESTINO_ID";
		public const string CAJA_TESORERIA_DESTINO_NOMBREColumnName = "CAJA_TESORERIA_DESTINO_NOMBRE";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHAColumnName = "FECHA";
		public const string TOTAL_DOLARIZADOColumnName = "TOTAL_DOLARIZADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ORDEN_PAGO_RESPALDA_CASO_IDColumnName = "ORDEN_PAGO_RESPALDA_CASO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_TESO_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSFERENCIAS_TESO_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSFERENCIAS_TESO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_TESO_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSFERENCIAS_TESO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSFERENCIAS_TESO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSFERENCIAS_TESO_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSFERENCIAS_TESO_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects.</returns>
		public TRANSFERENCIAS_TESO_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_TESO_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSFERENCIAS_TESO_INFO_COMPL";
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects.</returns>
		protected TRANSFERENCIAS_TESO_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects.</returns>
		protected TRANSFERENCIAS_TESO_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> objects.</returns>
		protected virtual TRANSFERENCIAS_TESO_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estadoColumnIndex = reader.GetOrdinal("CASO_ESTADO");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int entidad_nombreColumnIndex = reader.GetOrdinal("ENTIDAD_NOMBRE");
			int entidad_abreviaturaColumnIndex = reader.GetOrdinal("ENTIDAD_ABREVIATURA");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int sucursal_origen_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_NOMBRE");
			int sucursal_origen_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ABREVIATURA");
			int caja_tesoreria_origen_idColumnIndex = reader.GetOrdinal("CAJA_TESORERIA_ORIGEN_ID");
			int caja_tesoreria_origen_nombreColumnIndex = reader.GetOrdinal("CAJA_TESORERIA_ORIGEN_NOMBRE");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int sucursal_destino_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_NOMBRE");
			int sucursal_destino_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ABREVIATURA");
			int caja_tesoreria_destino_idColumnIndex = reader.GetOrdinal("CAJA_TESORERIA_DESTINO_ID");
			int caja_tesoreria_destino_nombreColumnIndex = reader.GetOrdinal("CAJA_TESORERIA_DESTINO_NOMBRE");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int total_dolarizadoColumnIndex = reader.GetOrdinal("TOTAL_DOLARIZADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int orden_pago_respalda_caso_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_RESPALDA_CASO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSFERENCIAS_TESO_INFO_COMPLRow record = new TRANSFERENCIAS_TESO_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO = Convert.ToString(reader.GetValue(caso_estadoColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(entidad_nombreColumnIndex));
					record.ENTIDAD_ABREVIATURA = Convert.ToString(reader.GetValue(entidad_abreviaturaColumnIndex));
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(sucursal_origen_nombreColumnIndex));
					record.SUCURSAL_ORIGEN_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_origen_abreviaturaColumnIndex));
					record.CAJA_TESORERIA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_tesoreria_origen_idColumnIndex)), 9);
					record.CAJA_TESORERIA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(caja_tesoreria_origen_nombreColumnIndex));
					record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					record.SUCURSAL_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(sucursal_destino_nombreColumnIndex));
					record.SUCURSAL_DESTINO_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_destino_abreviaturaColumnIndex));
					record.CAJA_TESORERIA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_tesoreria_destino_idColumnIndex)), 9);
					record.CAJA_TESORERIA_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(caja_tesoreria_destino_nombreColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(total_dolarizadoColumnIndex))
						record.TOTAL_DOLARIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(total_dolarizadoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(orden_pago_respalda_caso_idColumnIndex))
						record.ORDEN_PAGO_RESPALDA_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_respalda_caso_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSFERENCIAS_TESO_INFO_COMPLRow[])(recordList.ToArray(typeof(TRANSFERENCIAS_TESO_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSFERENCIAS_TESO_INFO_COMPLRow"/> object.</returns>
		protected virtual TRANSFERENCIAS_TESO_INFO_COMPLRow MapRow(DataRow row)
		{
			TRANSFERENCIAS_TESO_INFO_COMPLRow mappedObject = new TRANSFERENCIAS_TESO_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO"
			dataColumn = dataTable.Columns["CASO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "ENTIDAD_ABREVIATURA"
			dataColumn = dataTable.Columns["ENTIDAD_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ABREVIATURA = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ABREVIATURA = (string)row[dataColumn];
			// Column "CAJA_TESORERIA_ORIGEN_ID"
			dataColumn = dataTable.Columns["CAJA_TESORERIA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESORERIA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CAJA_TESORERIA_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["CAJA_TESORERIA_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESORERIA_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ABREVIATURA = (string)row[dataColumn];
			// Column "CAJA_TESORERIA_DESTINO_ID"
			dataColumn = dataTable.Columns["CAJA_TESORERIA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESORERIA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CAJA_TESORERIA_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["CAJA_TESORERIA_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESORERIA_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "TOTAL_DOLARIZADO"
			dataColumn = dataTable.Columns["TOTAL_DOLARIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DOLARIZADO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ORDEN_PAGO_RESPALDA_CASO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_RESPALDA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_RESPALDA_CASO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSFERENCIAS_TESO_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSFERENCIAS_TESO_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESORERIA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESORERIA_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESORERIA_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESORERIA_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_DOLARIZADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ORIGEN_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAJA_TESORERIA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_TESORERIA_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_DESTINO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAJA_TESORERIA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_TESORERIA_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TOTAL_DOLARIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN_PAGO_RESPALDA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSFERENCIAS_TESO_INFO_COMPLCollection_Base class
}  // End of namespace
