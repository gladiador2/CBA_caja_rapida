// <fileinfo name="CTACTE_GIROS_MOV_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_GIROS_MOV_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_GIROS_MOV_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_GIROS_MOV_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_GIRO_IDColumnName = "CTACTE_GIRO_ID";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string FECHA_DESEMBOLSOColumnName = "FECHA_DESEMBOLSO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string CREDITOColumnName = "CREDITO";
		public const string DEBITOColumnName = "DEBITO";
		public const string CTACTE_GIRO_RELACIONADO_IDColumnName = "CTACTE_GIRO_RELACIONADO_ID";
		public const string NRO_CUOTAColumnName = "NRO_CUOTA";
		public const string TOTAL_CUOTASColumnName = "TOTAL_CUOTAS";
		public const string GIRO_MOV_SALDOColumnName = "GIRO_MOV_SALDO";
		public const string GIRO_MOV_CUOTA_DESColumnName = "GIRO_MOV_CUOTA_DES";
		public const string GIRO_COMPROBANTEColumnName = "GIRO_COMPROBANTE";
		public const string GIRO_MOV_MONEDA_NOMBREColumnName = "GIRO_MOV_MONEDA_NOMBRE";
		public const string CTACTE_PLANES_DESEMBOLSO_IDColumnName = "CTACTE_PLANES_DESEMBOLSO_ID";
		public const string CTACTE_PROCESADORA_IDColumnName = "CTACTE_PROCESADORA_ID";
		public const string CTACTE_RED_PAGO_IDColumnName = "CTACTE_RED_PAGO_ID";
		public const string CTACTE_RED_PAGO_NOMBREColumnName = "CTACTE_RED_PAGO_NOMBRE";
		public const string DESEMBOLSO_GIRO_DET_IDColumnName = "DESEMBOLSO_GIRO_DET_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_FECHAColumnName = "CASO_FECHA";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string FLUJO_DESCRIPCIONColumnName = "FLUJO_DESCRIPCION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_GIROS_MOV_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_GIROS_MOV_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_GIROS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOV_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_GIROS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_GIROS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_GIROS_MOV_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_GIROS_MOV_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects.</returns>
		public CTACTE_GIROS_MOV_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOV_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_GIROS_MOV_INFO_COMP";
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_GIROS_MOV_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_GIROS_MOV_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> objects.</returns>
		protected virtual CTACTE_GIROS_MOV_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_giro_idColumnIndex = reader.GetOrdinal("CTACTE_GIRO_ID");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int fecha_desembolsoColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int creditoColumnIndex = reader.GetOrdinal("CREDITO");
			int debitoColumnIndex = reader.GetOrdinal("DEBITO");
			int ctacte_giro_relacionado_idColumnIndex = reader.GetOrdinal("CTACTE_GIRO_RELACIONADO_ID");
			int nro_cuotaColumnIndex = reader.GetOrdinal("NRO_CUOTA");
			int total_cuotasColumnIndex = reader.GetOrdinal("TOTAL_CUOTAS");
			int giro_mov_saldoColumnIndex = reader.GetOrdinal("GIRO_MOV_SALDO");
			int giro_mov_cuota_desColumnIndex = reader.GetOrdinal("GIRO_MOV_CUOTA_DES");
			int giro_comprobanteColumnIndex = reader.GetOrdinal("GIRO_COMPROBANTE");
			int giro_mov_moneda_nombreColumnIndex = reader.GetOrdinal("GIRO_MOV_MONEDA_NOMBRE");
			int ctacte_planes_desembolso_idColumnIndex = reader.GetOrdinal("CTACTE_PLANES_DESEMBOLSO_ID");
			int ctacte_procesadora_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_ID");
			int ctacte_red_pago_idColumnIndex = reader.GetOrdinal("CTACTE_RED_PAGO_ID");
			int ctacte_red_pago_nombreColumnIndex = reader.GetOrdinal("CTACTE_RED_PAGO_NOMBRE");
			int desembolso_giro_det_idColumnIndex = reader.GetOrdinal("DESEMBOLSO_GIRO_DET_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_fechaColumnIndex = reader.GetOrdinal("CASO_FECHA");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int flujo_descripcionColumnIndex = reader.GetOrdinal("FLUJO_DESCRIPCION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_GIROS_MOV_INFO_COMPRow record = new CTACTE_GIROS_MOV_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_giro_idColumnIndex))
						record.CTACTE_GIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_giro_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_insercionColumnIndex))
						record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					if(!reader.IsDBNull(fecha_desembolsoColumnIndex))
						record.FECHA_DESEMBOLSO = Convert.ToDateTime(reader.GetValue(fecha_desembolsoColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(creditoColumnIndex))
						record.CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(creditoColumnIndex)), 9);
					if(!reader.IsDBNull(debitoColumnIndex))
						record.DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(debitoColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_giro_relacionado_idColumnIndex))
						record.CTACTE_GIRO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_giro_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_cuotaColumnIndex))
						record.NRO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(nro_cuotaColumnIndex)), 9);
					if(!reader.IsDBNull(total_cuotasColumnIndex))
						record.TOTAL_CUOTAS = Math.Round(Convert.ToDecimal(reader.GetValue(total_cuotasColumnIndex)), 9);
					if(!reader.IsDBNull(giro_mov_saldoColumnIndex))
						record.GIRO_MOV_SALDO = Math.Round(Convert.ToDecimal(reader.GetValue(giro_mov_saldoColumnIndex)), 9);
					if(!reader.IsDBNull(giro_mov_cuota_desColumnIndex))
						record.GIRO_MOV_CUOTA_DES = Convert.ToString(reader.GetValue(giro_mov_cuota_desColumnIndex));
					if(!reader.IsDBNull(giro_comprobanteColumnIndex))
						record.GIRO_COMPROBANTE = Convert.ToString(reader.GetValue(giro_comprobanteColumnIndex));
					record.GIRO_MOV_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(giro_mov_moneda_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_planes_desembolso_idColumnIndex))
						record.CTACTE_PLANES_DESEMBOLSO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_planes_desembolso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadora_idColumnIndex))
						record.CTACTE_PROCESADORA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_red_pago_idColumnIndex))
						record.CTACTE_RED_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_red_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_red_pago_nombreColumnIndex))
						record.CTACTE_RED_PAGO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_red_pago_nombreColumnIndex));
					if(!reader.IsDBNull(desembolso_giro_det_idColumnIndex))
						record.DESEMBOLSO_GIRO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desembolso_giro_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_fechaColumnIndex))
						record.CASO_FECHA = Convert.ToDateTime(reader.GetValue(caso_fechaColumnIndex));
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_descripcionColumnIndex))
						record.FLUJO_DESCRIPCION = Convert.ToString(reader.GetValue(flujo_descripcionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_GIROS_MOV_INFO_COMPRow[])(recordList.ToArray(typeof(CTACTE_GIROS_MOV_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_GIROS_MOV_INFO_COMPRow"/> object.</returns>
		protected virtual CTACTE_GIROS_MOV_INFO_COMPRow MapRow(DataRow row)
		{
			CTACTE_GIROS_MOV_INFO_COMPRow mappedObject = new CTACTE_GIROS_MOV_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_GIRO_ID"
			dataColumn = dataTable.Columns["CTACTE_GIRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIRO_ID = (decimal)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_DESEMBOLSO"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "CREDITO"
			dataColumn = dataTable.Columns["CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO = (decimal)row[dataColumn];
			// Column "DEBITO"
			dataColumn = dataTable.Columns["DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO = (decimal)row[dataColumn];
			// Column "CTACTE_GIRO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CTACTE_GIRO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIRO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "NRO_CUOTA"
			dataColumn = dataTable.Columns["NRO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CUOTA = (decimal)row[dataColumn];
			// Column "TOTAL_CUOTAS"
			dataColumn = dataTable.Columns["TOTAL_CUOTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CUOTAS = (decimal)row[dataColumn];
			// Column "GIRO_MOV_SALDO"
			dataColumn = dataTable.Columns["GIRO_MOV_SALDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIRO_MOV_SALDO = (decimal)row[dataColumn];
			// Column "GIRO_MOV_CUOTA_DES"
			dataColumn = dataTable.Columns["GIRO_MOV_CUOTA_DES"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIRO_MOV_CUOTA_DES = (string)row[dataColumn];
			// Column "GIRO_COMPROBANTE"
			dataColumn = dataTable.Columns["GIRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIRO_COMPROBANTE = (string)row[dataColumn];
			// Column "GIRO_MOV_MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["GIRO_MOV_MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIRO_MOV_MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_PLANES_DESEMBOLSO_ID"
			dataColumn = dataTable.Columns["CTACTE_PLANES_DESEMBOLSO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PLANES_DESEMBOLSO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RED_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RED_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RED_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RED_PAGO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_RED_PAGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RED_PAGO_NOMBRE = (string)row[dataColumn];
			// Column "DESEMBOLSO_GIRO_DET_ID"
			dataColumn = dataTable.Columns["DESEMBOLSO_GIRO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_GIRO_DET_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_FECHA"
			dataColumn = dataTable.Columns["CASO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FECHA = (System.DateTime)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_DESCRIPCION"
			dataColumn = dataTable.Columns["FLUJO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_DESCRIPCION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_GIROS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_GIROS_MOV_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_GIRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEBITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_GIRO_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_CUOTA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CUOTAS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIRO_MOV_SALDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIRO_MOV_CUOTA_DES", typeof(string));
			dataColumn.MaxLength = 87;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIRO_MOV_MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PLANES_DESEMBOLSO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RED_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RED_PAGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_GIRO_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_DESCRIPCION", typeof(string));
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

				case "CTACTE_GIRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DESEMBOLSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_GIRO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CUOTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIRO_MOV_SALDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIRO_MOV_CUOTA_DES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GIRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GIRO_MOV_MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PLANES_DESEMBOLSO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROCESADORA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RED_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RED_PAGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESEMBOLSO_GIRO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_GIROS_MOV_INFO_COMPCollection_Base class
}  // End of namespace
