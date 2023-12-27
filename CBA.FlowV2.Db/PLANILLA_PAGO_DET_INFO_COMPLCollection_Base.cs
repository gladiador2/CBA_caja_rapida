// <fileinfo name="PLANILLA_PAGO_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_PAGO_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_PAGO_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_PAGO_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLANILLA_PAGO_IDColumnName = "PLANILLA_PAGO_ID";
		public const string CTACTE_PROVEEDOR_IDColumnName = "CTACTE_PROVEEDOR_ID";
		public const string MONTO_PAGARColumnName = "MONTO_PAGAR";
		public const string CTACTE_PROV_CASO_IDColumnName = "CTACTE_PROV_CASO_ID";
		public const string MONTO_BRUTOColumnName = "MONTO_BRUTO";
		public const string CTACTE_CASO_IDColumnName = "CTACTE_CASO_ID";
		public const string CTACTE_NRO_COMPROBANTEColumnName = "CTACTE_NRO_COMPROBANTE";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PROVEEDOR_NOMBREColumnName = "PROVEEDOR_NOMBRE";
		public const string CTACTE_MONEDA_IDColumnName = "CTACTE_MONEDA_ID";
		public const string CTACTE_MONEDA_NOMBREColumnName = "CTACTE_MONEDA_NOMBRE";
		public const string CTACTE_MONEDA_SIMBOLOColumnName = "CTACTE_MONEDA_SIMBOLO";
		public const string CTACTE_MONEDA_COTIZACIONColumnName = "CTACTE_MONEDA_COTIZACION";
		public const string SALDO_CTACTEColumnName = "SALDO_CTACTE";
		public const string CTACTE_FECHA_VENCIMIENTOColumnName = "CTACTE_FECHA_VENCIMIENTO";
		public const string OP_CASO_IDColumnName = "OP_CASO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_PAGO_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_PAGO_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_PAGO_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual PLANILLA_PAGO_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_PAGO_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_PAGO_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_PAGO_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_PAGO_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects.</returns>
		public PLANILLA_PAGO_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual PLANILLA_PAGO_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_PAGO_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects.</returns>
		protected PLANILLA_PAGO_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects.</returns>
		protected PLANILLA_PAGO_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual PLANILLA_PAGO_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int planilla_pago_idColumnIndex = reader.GetOrdinal("PLANILLA_PAGO_ID");
			int ctacte_proveedor_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_ID");
			int monto_pagarColumnIndex = reader.GetOrdinal("MONTO_PAGAR");
			int ctacte_prov_caso_idColumnIndex = reader.GetOrdinal("CTACTE_PROV_CASO_ID");
			int monto_brutoColumnIndex = reader.GetOrdinal("MONTO_BRUTO");
			int ctacte_caso_idColumnIndex = reader.GetOrdinal("CTACTE_CASO_ID");
			int ctacte_nro_comprobanteColumnIndex = reader.GetOrdinal("CTACTE_NRO_COMPROBANTE");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int proveedor_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_NOMBRE");
			int ctacte_moneda_idColumnIndex = reader.GetOrdinal("CTACTE_MONEDA_ID");
			int ctacte_moneda_nombreColumnIndex = reader.GetOrdinal("CTACTE_MONEDA_NOMBRE");
			int ctacte_moneda_simboloColumnIndex = reader.GetOrdinal("CTACTE_MONEDA_SIMBOLO");
			int ctacte_moneda_cotizacionColumnIndex = reader.GetOrdinal("CTACTE_MONEDA_COTIZACION");
			int saldo_ctacteColumnIndex = reader.GetOrdinal("SALDO_CTACTE");
			int ctacte_fecha_vencimientoColumnIndex = reader.GetOrdinal("CTACTE_FECHA_VENCIMIENTO");
			int op_caso_idColumnIndex = reader.GetOrdinal("OP_CASO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_PAGO_DET_INFO_COMPLRow record = new PLANILLA_PAGO_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLANILLA_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_pago_idColumnIndex)), 9);
					record.CTACTE_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_pagarColumnIndex))
						record.MONTO_PAGAR = Math.Round(Convert.ToDecimal(reader.GetValue(monto_pagarColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_prov_caso_idColumnIndex))
						record.CTACTE_PROV_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_prov_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_brutoColumnIndex))
						record.MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caso_idColumnIndex))
						record.CTACTE_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_nro_comprobanteColumnIndex))
						record.CTACTE_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(ctacte_nro_comprobanteColumnIndex));
					record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_nombreColumnIndex))
						record.PROVEEDOR_NOMBRE = Convert.ToString(reader.GetValue(proveedor_nombreColumnIndex));
					record.CTACTE_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_moneda_idColumnIndex)), 9);
					record.CTACTE_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(ctacte_moneda_nombreColumnIndex));
					record.CTACTE_MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(ctacte_moneda_simboloColumnIndex));
					record.CTACTE_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(saldo_ctacteColumnIndex))
						record.SALDO_CTACTE = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_ctacteColumnIndex)), 9);
					record.CTACTE_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(ctacte_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(op_caso_idColumnIndex))
						record.OP_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(op_caso_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_PAGO_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(PLANILLA_PAGO_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_PAGO_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual PLANILLA_PAGO_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			PLANILLA_PAGO_DET_INFO_COMPLRow mappedObject = new PLANILLA_PAGO_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLANILLA_PAGO_ID"
			dataColumn = dataTable.Columns["PLANILLA_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "MONTO_PAGAR"
			dataColumn = dataTable.Columns["MONTO_PAGAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PAGAR = (decimal)row[dataColumn];
			// Column "CTACTE_PROV_CASO_ID"
			dataColumn = dataTable.Columns["CTACTE_PROV_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROV_CASO_ID = (decimal)row[dataColumn];
			// Column "MONTO_BRUTO"
			dataColumn = dataTable.Columns["MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO = (decimal)row[dataColumn];
			// Column "CTACTE_CASO_ID"
			dataColumn = dataTable.Columns["CTACTE_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CASO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["CTACTE_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_MONEDA_ID"
			dataColumn = dataTable.Columns["CTACTE_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_MONEDA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["CTACTE_MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "CTACTE_MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["CTACTE_MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "SALDO_CTACTE"
			dataColumn = dataTable.Columns["SALDO_CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_CTACTE = (decimal)row[dataColumn];
			// Column "CTACTE_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CTACTE_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "OP_CASO_ID"
			dataColumn = dataTable.Columns["OP_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.OP_CASO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_PAGO_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_PAGO_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PLANILLA_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_PAGAR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROV_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_MONEDA_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO_CTACTE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OP_CASO_ID", typeof(decimal));
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

				case "PLANILLA_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PAGAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROV_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_CTACTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OP_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_PAGO_DET_INFO_COMPLCollection_Base class
}  // End of namespace
