// <fileinfo name="PEDIDOS_PROVEEDOR_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_PROVEEDOR_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSALColumnName = "SUCURSAL";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITOColumnName = "DEPOSITO";
		public const string FECHA_PEDIDOColumnName = "FECHA_PEDIDO";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string NOMBRE_FANTASIAColumnName = "NOMBRE_FANTASIA";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string AUTONUMERACIONColumnName = "AUTONUMERACION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string CONDICION_PAGOColumnName = "CONDICION_PAGO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDAColumnName = "MONEDA";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string AFECTA_LINEA_CREDITOColumnName = "AFECTA_LINEA_CREDITO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string NUMERO_CONTRATOColumnName = "NUMERO_CONTRATO";
		public const string CASO_FACTURA_PROVEEDOR_IDColumnName = "CASO_FACTURA_PROVEEDOR_ID";
		public const string INVOICEColumnName = "INVOICE";
		public const string FECHA_INVOICEColumnName = "FECHA_INVOICE";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string ESTADO_DOCUMENTOColumnName = "ESTADO_DOCUMENTO";
		public const string TIPO_EMBARQUE_IDColumnName = "TIPO_EMBARQUE_ID";
		public const string TIPO_EMBARQUEColumnName = "TIPO_EMBARQUE";
		public const string TIPO_CONTENEDOR_IDColumnName = "TIPO_CONTENEDOR_ID";
		public const string TIPO_CONTENEDORColumnName = "TIPO_CONTENEDOR";
		public const string CANTIDAD_CONTENEDORESColumnName = "CANTIDAD_CONTENEDORES";
		public const string TOTAL_BRUTO_PEDIDOColumnName = "TOTAL_BRUTO_PEDIDO";
		public const string TOTAL_DTO_PEDIDOColumnName = "TOTAL_DTO_PEDIDO";
		public const string TOTAL_IMP_PEDIDOColumnName = "TOTAL_IMP_PEDIDO";
		public const string TOTAL_NETO_PEDIDOColumnName = "TOTAL_NETO_PEDIDO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PEDIDOS_PROVEEDOR_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PEDIDOS_PROVEEDOR_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PEDIDOS_PROVEEDOR_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PEDIDOS_PROVEEDOR_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PEDIDOS_PROVEEDOR_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PEDIDOS_PROVEEDOR_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects.</returns>
		public PEDIDOS_PROVEEDOR_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PEDIDOS_PROVEEDOR_INFO_COMPL";
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects.</returns>
		protected PEDIDOS_PROVEEDOR_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects.</returns>
		protected PEDIDOS_PROVEEDOR_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> objects.</returns>
		protected virtual PEDIDOS_PROVEEDOR_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursalColumnIndex = reader.GetOrdinal("SUCURSAL");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int depositoColumnIndex = reader.GetOrdinal("DEPOSITO");
			int fecha_pedidoColumnIndex = reader.GetOrdinal("FECHA_PEDIDO");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int nombre_fantasiaColumnIndex = reader.GetOrdinal("NOMBRE_FANTASIA");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int autonumeracionColumnIndex = reader.GetOrdinal("AUTONUMERACION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int condicion_pagoColumnIndex = reader.GetOrdinal("CONDICION_PAGO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monedaColumnIndex = reader.GetOrdinal("MONEDA");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int afecta_linea_creditoColumnIndex = reader.GetOrdinal("AFECTA_LINEA_CREDITO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int numero_contratoColumnIndex = reader.GetOrdinal("NUMERO_CONTRATO");
			int caso_factura_proveedor_idColumnIndex = reader.GetOrdinal("CASO_FACTURA_PROVEEDOR_ID");
			int invoiceColumnIndex = reader.GetOrdinal("INVOICE");
			int fecha_invoiceColumnIndex = reader.GetOrdinal("FECHA_INVOICE");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int estado_documentoColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTO");
			int tipo_embarque_idColumnIndex = reader.GetOrdinal("TIPO_EMBARQUE_ID");
			int tipo_embarqueColumnIndex = reader.GetOrdinal("TIPO_EMBARQUE");
			int tipo_contenedor_idColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_ID");
			int tipo_contenedorColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR");
			int cantidad_contenedoresColumnIndex = reader.GetOrdinal("CANTIDAD_CONTENEDORES");
			int total_bruto_pedidoColumnIndex = reader.GetOrdinal("TOTAL_BRUTO_PEDIDO");
			int total_dto_pedidoColumnIndex = reader.GetOrdinal("TOTAL_DTO_PEDIDO");
			int total_imp_pedidoColumnIndex = reader.GetOrdinal("TOTAL_IMP_PEDIDO");
			int total_neto_pedidoColumnIndex = reader.GetOrdinal("TOTAL_NETO_PEDIDO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PEDIDOS_PROVEEDOR_INFO_COMPLRow record = new PEDIDOS_PROVEEDOR_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL = Convert.ToString(reader.GetValue(sucursalColumnIndex));
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.DEPOSITO = Convert.ToString(reader.GetValue(depositoColumnIndex));
					if(!reader.IsDBNull(fecha_pedidoColumnIndex))
						record.FECHA_PEDIDO = Convert.ToDateTime(reader.GetValue(fecha_pedidoColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_fantasiaColumnIndex))
						record.NOMBRE_FANTASIA = Convert.ToString(reader.GetValue(nombre_fantasiaColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracionColumnIndex))
						record.AUTONUMERACION = Convert.ToString(reader.GetValue(autonumeracionColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_pagoColumnIndex))
						record.CONDICION_PAGO = Convert.ToString(reader.GetValue(condicion_pagoColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(monedaColumnIndex))
						record.MONEDA = Convert.ToString(reader.GetValue(monedaColumnIndex));
					if(!reader.IsDBNull(cotizacion_monedaColumnIndex))
						record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.AFECTA_LINEA_CREDITO = Convert.ToString(reader.GetValue(afecta_linea_creditoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(numero_contratoColumnIndex))
						record.NUMERO_CONTRATO = Convert.ToString(reader.GetValue(numero_contratoColumnIndex));
					if(!reader.IsDBNull(caso_factura_proveedor_idColumnIndex))
						record.CASO_FACTURA_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_factura_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(invoiceColumnIndex))
						record.INVOICE = Convert.ToString(reader.GetValue(invoiceColumnIndex));
					if(!reader.IsDBNull(fecha_invoiceColumnIndex))
						record.FECHA_INVOICE = Convert.ToDateTime(reader.GetValue(fecha_invoiceColumnIndex));
					if(!reader.IsDBNull(estado_documentacion_idColumnIndex))
						record.ESTADO_DOCUMENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_documentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_documentoColumnIndex))
						record.ESTADO_DOCUMENTO = Convert.ToString(reader.GetValue(estado_documentoColumnIndex));
					if(!reader.IsDBNull(tipo_embarque_idColumnIndex))
						record.TIPO_EMBARQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_embarque_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_embarqueColumnIndex))
						record.TIPO_EMBARQUE = Convert.ToString(reader.GetValue(tipo_embarqueColumnIndex));
					if(!reader.IsDBNull(tipo_contenedor_idColumnIndex))
						record.TIPO_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_contenedorColumnIndex))
						record.TIPO_CONTENEDOR = Convert.ToString(reader.GetValue(tipo_contenedorColumnIndex));
					if(!reader.IsDBNull(cantidad_contenedoresColumnIndex))
						record.CANTIDAD_CONTENEDORES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_contenedoresColumnIndex)), 9);
					if(!reader.IsDBNull(total_bruto_pedidoColumnIndex))
						record.TOTAL_BRUTO_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_bruto_pedidoColumnIndex)), 9);
					if(!reader.IsDBNull(total_dto_pedidoColumnIndex))
						record.TOTAL_DTO_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_dto_pedidoColumnIndex)), 9);
					if(!reader.IsDBNull(total_imp_pedidoColumnIndex))
						record.TOTAL_IMP_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_imp_pedidoColumnIndex)), 9);
					if(!reader.IsDBNull(total_neto_pedidoColumnIndex))
						record.TOTAL_NETO_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_neto_pedidoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PEDIDOS_PROVEEDOR_INFO_COMPLRow[])(recordList.ToArray(typeof(PEDIDOS_PROVEEDOR_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PEDIDOS_PROVEEDOR_INFO_COMPLRow"/> object.</returns>
		protected virtual PEDIDOS_PROVEEDOR_INFO_COMPLRow MapRow(DataRow row)
		{
			PEDIDOS_PROVEEDOR_INFO_COMPLRow mappedObject = new PEDIDOS_PROVEEDOR_INFO_COMPLRow();
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
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL"
			dataColumn = dataTable.Columns["SUCURSAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL = (string)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO"
			dataColumn = dataTable.Columns["DEPOSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO = (string)row[dataColumn];
			// Column "FECHA_PEDIDO"
			dataColumn = dataTable.Columns["FECHA_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_PEDIDO = (System.DateTime)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_FANTASIA"
			dataColumn = dataTable.Columns["NOMBRE_FANTASIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_FANTASIA = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION"
			dataColumn = dataTable.Columns["AUTONUMERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO"
			dataColumn = dataTable.Columns["CONDICION_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA"
			dataColumn = dataTable.Columns["MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "AFECTA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["AFECTA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_LINEA_CREDITO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "NUMERO_CONTRATO"
			dataColumn = dataTable.Columns["NUMERO_CONTRATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CONTRATO = (string)row[dataColumn];
			// Column "CASO_FACTURA_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CASO_FACTURA_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FACTURA_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "INVOICE"
			dataColumn = dataTable.Columns["INVOICE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVOICE = (string)row[dataColumn];
			// Column "FECHA_INVOICE"
			dataColumn = dataTable.Columns["FECHA_INVOICE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INVOICE = (System.DateTime)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_ID"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_ID = (decimal)row[dataColumn];
			// Column "ESTADO_DOCUMENTO"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTO = (string)row[dataColumn];
			// Column "TIPO_EMBARQUE_ID"
			dataColumn = dataTable.Columns["TIPO_EMBARQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMBARQUE_ID = (decimal)row[dataColumn];
			// Column "TIPO_EMBARQUE"
			dataColumn = dataTable.Columns["TIPO_EMBARQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMBARQUE = (string)row[dataColumn];
			// Column "TIPO_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "TIPO_CONTENEDOR"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR = (string)row[dataColumn];
			// Column "CANTIDAD_CONTENEDORES"
			dataColumn = dataTable.Columns["CANTIDAD_CONTENEDORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CONTENEDORES = (decimal)row[dataColumn];
			// Column "TOTAL_BRUTO_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_BRUTO_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BRUTO_PEDIDO = (decimal)row[dataColumn];
			// Column "TOTAL_DTO_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_DTO_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DTO_PEDIDO = (decimal)row[dataColumn];
			// Column "TOTAL_IMP_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_IMP_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMP_PEDIDO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_NETO_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO_PEDIDO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PEDIDOS_PROVEEDOR_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PEDIDOS_PROVEEDOR_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_PEDIDO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_FANTASIA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_LINEA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CONTRATO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_FACTURA_PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INVOICE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INVOICE", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_EMBARQUE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_EMBARQUE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CONTENEDORES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_BRUTO_PEDIDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_DTO_PEDIDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_IMP_PEDIDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO_PEDIDO", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_FANTASIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AFECTA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CONTRATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_FACTURA_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INVOICE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INVOICE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO_DOCUMENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_EMBARQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_EMBARQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CONTENEDORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BRUTO_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DTO_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMP_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PEDIDOS_PROVEEDOR_INFO_COMPLCollection_Base class
}  // End of namespace
