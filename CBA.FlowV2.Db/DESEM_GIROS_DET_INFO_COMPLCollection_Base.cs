// <fileinfo name="DESEM_GIROS_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="DESEM_GIROS_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESEM_GIROS_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESEM_GIROS_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string DESEMBOLSO_GIRO_IDColumnName = "DESEMBOLSO_GIRO_ID";
		public const string CTACTE_GIROS_MOVIMIENTO_IDColumnName = "CTACTE_GIROS_MOVIMIENTO_ID";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string GIRO_MOV_MONEDA_IDColumnName = "GIRO_MOV_MONEDA_ID";
		public const string CTACTE_GIRO_MOV_FECHA_DESEMBColumnName = "CTACTE_GIRO_MOV_FECHA_DESEMB";
		public const string GIRO_MOV_SALDOColumnName = "GIRO_MOV_SALDO";
		public const string GIRO_MOV_CUOTA_DESColumnName = "GIRO_MOV_CUOTA_DES";
		public const string GIRO_COMPROBANTEColumnName = "GIRO_COMPROBANTE";
		public const string GIRO_MOV_MONEDA_NOMBREColumnName = "GIRO_MOV_MONEDA_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESEM_GIROS_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESEM_GIROS_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESEM_GIROS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual DESEM_GIROS_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESEM_GIROS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESEM_GIROS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESEM_GIROS_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESEM_GIROS_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects.</returns>
		public DESEM_GIROS_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual DESEM_GIROS_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESEM_GIROS_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects.</returns>
		protected DESEM_GIROS_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects.</returns>
		protected DESEM_GIROS_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual DESEM_GIROS_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int desembolso_giro_idColumnIndex = reader.GetOrdinal("DESEMBOLSO_GIRO_ID");
			int ctacte_giros_movimiento_idColumnIndex = reader.GetOrdinal("CTACTE_GIROS_MOVIMIENTO_ID");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int giro_mov_moneda_idColumnIndex = reader.GetOrdinal("GIRO_MOV_MONEDA_ID");
			int ctacte_giro_mov_fecha_desembColumnIndex = reader.GetOrdinal("CTACTE_GIRO_MOV_FECHA_DESEMB");
			int giro_mov_saldoColumnIndex = reader.GetOrdinal("GIRO_MOV_SALDO");
			int giro_mov_cuota_desColumnIndex = reader.GetOrdinal("GIRO_MOV_CUOTA_DES");
			int giro_comprobanteColumnIndex = reader.GetOrdinal("GIRO_COMPROBANTE");
			int giro_mov_moneda_nombreColumnIndex = reader.GetOrdinal("GIRO_MOV_MONEDA_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESEM_GIROS_DET_INFO_COMPLRow record = new DESEM_GIROS_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.DESEMBOLSO_GIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desembolso_giro_idColumnIndex)), 9);
					record.CTACTE_GIROS_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_giros_movimiento_idColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					if(!reader.IsDBNull(monto_destinoColumnIndex))
						record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(giro_mov_moneda_idColumnIndex))
						record.GIRO_MOV_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(giro_mov_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_giro_mov_fecha_desembColumnIndex))
						record.CTACTE_GIRO_MOV_FECHA_DESEMB = Convert.ToDateTime(reader.GetValue(ctacte_giro_mov_fecha_desembColumnIndex));
					if(!reader.IsDBNull(giro_mov_saldoColumnIndex))
						record.GIRO_MOV_SALDO = Math.Round(Convert.ToDecimal(reader.GetValue(giro_mov_saldoColumnIndex)), 9);
					if(!reader.IsDBNull(giro_mov_cuota_desColumnIndex))
						record.GIRO_MOV_CUOTA_DES = Convert.ToString(reader.GetValue(giro_mov_cuota_desColumnIndex));
					if(!reader.IsDBNull(giro_comprobanteColumnIndex))
						record.GIRO_COMPROBANTE = Convert.ToString(reader.GetValue(giro_comprobanteColumnIndex));
					record.GIRO_MOV_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(giro_mov_moneda_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESEM_GIROS_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(DESEM_GIROS_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESEM_GIROS_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual DESEM_GIROS_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			DESEM_GIROS_DET_INFO_COMPLRow mappedObject = new DESEM_GIROS_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "DESEMBOLSO_GIRO_ID"
			dataColumn = dataTable.Columns["DESEMBOLSO_GIRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_GIRO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_GIROS_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["CTACTE_GIROS_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIROS_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "GIRO_MOV_MONEDA_ID"
			dataColumn = dataTable.Columns["GIRO_MOV_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIRO_MOV_MONEDA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_GIRO_MOV_FECHA_DESEMB"
			dataColumn = dataTable.Columns["CTACTE_GIRO_MOV_FECHA_DESEMB"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIRO_MOV_FECHA_DESEMB = (System.DateTime)row[dataColumn];
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
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESEM_GIROS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESEM_GIROS_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_GIRO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_GIROS_MOVIMIENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GIRO_MOV_MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_GIRO_MOV_FECHA_DESEMB", typeof(System.DateTime));
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

				case "DESEMBOLSO_GIRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_GIROS_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIRO_MOV_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_GIRO_MOV_FECHA_DESEMB":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
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

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESEM_GIROS_DET_INFO_COMPLCollection_Base class
}  // End of namespace
