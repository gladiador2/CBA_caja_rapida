// <fileinfo name="CTACTE_BANCARIAS_MOV_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCARIAS_MOV_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string INGRESOColumnName = "INGRESO";
		public const string EGRESOColumnName = "EGRESO";
		public const string SALDOColumnName = "SALDO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_NRO_COMPROBANTEColumnName = "CASO_NRO_COMPROBANTE";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string DEPOSITO_BANCARIO_IDColumnName = "DEPOSITO_BANCARIO_ID";
		public const string TRANSFERENCIA_BANCARIA_IDColumnName = "TRANSFERENCIA_BANCARIA_ID";
		public const string AJUSTE_BANCARIO_IDColumnName = "AJUSTE_BANCARIO_ID";
		public const string DESCUENTO_DOCUMENTO_IDColumnName = "DESCUENTO_DOCUMENTO_ID";
		public const string CUSTODIA_VALORES_IDColumnName = "CUSTODIA_VALORES_ID";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string MOVIMIENTO_VARIO_TESORERIA_IDColumnName = "MOVIMIENTO_VARIO_TESORERIA_ID";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CONCILIADOColumnName = "CONCILIADO";
		public const string CONCILIADO_USUARIO_IDColumnName = "CONCILIADO_USUARIO_ID";
		public const string CONCILIADO_USUARIO_NOMBREColumnName = "CONCILIADO_USUARIO_NOMBRE";
		public const string CONCILIADO_FECHAColumnName = "CONCILIADO_FECHA";
		public const string DESCONCILIADO_USUARIO_IDColumnName = "DESCONCILIADO_USUARIO_ID";
		public const string DESCONCILIADO_USUARIO_NOMBREColumnName = "DESCONCILIADO_USUARIO_NOMBRE";
		public const string DESCONCILIADO_FECHAColumnName = "DESCONCILIADO_FECHA";
		public const string CTACTE_CHEQUE_GIRADO_IDColumnName = "CTACTE_CHEQUE_GIRADO_ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_BANCARIAS_MOV_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_BANCARIAS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOV_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_BANCARIAS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_BANCARIAS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_BANCARIAS_MOV_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_BANCARIAS_MOV_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOV_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOV_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_BANCARIAS_MOV_INFO_COMP";
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_BANCARIAS_MOV_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_BANCARIAS_MOV_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> objects.</returns>
		protected virtual CTACTE_BANCARIAS_MOV_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int ingresoColumnIndex = reader.GetOrdinal("INGRESO");
			int egresoColumnIndex = reader.GetOrdinal("EGRESO");
			int saldoColumnIndex = reader.GetOrdinal("SALDO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_nro_comprobanteColumnIndex = reader.GetOrdinal("CASO_NRO_COMPROBANTE");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int deposito_bancario_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_ID");
			int transferencia_bancaria_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BANCARIA_ID");
			int ajuste_bancario_idColumnIndex = reader.GetOrdinal("AJUSTE_BANCARIO_ID");
			int descuento_documento_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_ID");
			int custodia_valores_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALORES_ID");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int movimiento_vario_tesoreria_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_VARIO_TESORERIA_ID");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int conciliadoColumnIndex = reader.GetOrdinal("CONCILIADO");
			int conciliado_usuario_idColumnIndex = reader.GetOrdinal("CONCILIADO_USUARIO_ID");
			int conciliado_usuario_nombreColumnIndex = reader.GetOrdinal("CONCILIADO_USUARIO_NOMBRE");
			int conciliado_fechaColumnIndex = reader.GetOrdinal("CONCILIADO_FECHA");
			int desconciliado_usuario_idColumnIndex = reader.GetOrdinal("DESCONCILIADO_USUARIO_ID");
			int desconciliado_usuario_nombreColumnIndex = reader.GetOrdinal("DESCONCILIADO_USUARIO_NOMBRE");
			int desconciliado_fechaColumnIndex = reader.GetOrdinal("DESCONCILIADO_FECHA");
			int ctacte_cheque_girado_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_GIRADO_ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_BANCARIAS_MOV_INFO_COMPRow record = new CTACTE_BANCARIAS_MOV_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingresoColumnIndex))
						record.INGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(ingresoColumnIndex)), 9);
					if(!reader.IsDBNull(egresoColumnIndex))
						record.EGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(egresoColumnIndex)), 9);
					if(!reader.IsDBNull(saldoColumnIndex))
						record.SALDO = Math.Round(Convert.ToDecimal(reader.GetValue(saldoColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_nro_comprobanteColumnIndex))
						record.CASO_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(caso_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_idColumnIndex))
						record.DEPOSITO_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_bancaria_idColumnIndex))
						record.TRANSFERENCIA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_bancario_idColumnIndex))
						record.AJUSTE_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valores_idColumnIndex))
						record.CUSTODIA_VALORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valores_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_vario_tesoreria_idColumnIndex))
						record.MOVIMIENTO_VARIO_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_vario_tesoreria_idColumnIndex)), 9);
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					if(!reader.IsDBNull(egreso_vario_caja_idColumnIndex))
						record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.CONCILIADO = Convert.ToString(reader.GetValue(conciliadoColumnIndex));
					if(!reader.IsDBNull(conciliado_usuario_idColumnIndex))
						record.CONCILIADO_USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conciliado_usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(conciliado_usuario_nombreColumnIndex))
						record.CONCILIADO_USUARIO_NOMBRE = Convert.ToString(reader.GetValue(conciliado_usuario_nombreColumnIndex));
					if(!reader.IsDBNull(conciliado_fechaColumnIndex))
						record.CONCILIADO_FECHA = Convert.ToDateTime(reader.GetValue(conciliado_fechaColumnIndex));
					if(!reader.IsDBNull(desconciliado_usuario_idColumnIndex))
						record.DESCONCILIADO_USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desconciliado_usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(desconciliado_usuario_nombreColumnIndex))
						record.DESCONCILIADO_USUARIO_NOMBRE = Convert.ToString(reader.GetValue(desconciliado_usuario_nombreColumnIndex));
					if(!reader.IsDBNull(desconciliado_fechaColumnIndex))
						record.DESCONCILIADO_FECHA = Convert.ToDateTime(reader.GetValue(desconciliado_fechaColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_girado_idColumnIndex))
						record.CTACTE_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_BANCARIAS_MOV_INFO_COMPRow[])(recordList.ToArray(typeof(CTACTE_BANCARIAS_MOV_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_BANCARIAS_MOV_INFO_COMPRow"/> object.</returns>
		protected virtual CTACTE_BANCARIAS_MOV_INFO_COMPRow MapRow(DataRow row)
		{
			CTACTE_BANCARIAS_MOV_INFO_COMPRow mappedObject = new CTACTE_BANCARIAS_MOV_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "INGRESO"
			dataColumn = dataTable.Columns["INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO = (decimal)row[dataColumn];
			// Column "EGRESO"
			dataColumn = dataTable.Columns["EGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO = (decimal)row[dataColumn];
			// Column "SALDO"
			dataColumn = dataTable.Columns["SALDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["CASO_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_BANCARIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "AJUSTE_BANCARIO_ID"
			dataColumn = dataTable.Columns["AJUSTE_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALORES_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALORES_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_VARIO_TESORERIA_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_VARIO_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_VARIO_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CONCILIADO"
			dataColumn = dataTable.Columns["CONCILIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCILIADO = (string)row[dataColumn];
			// Column "CONCILIADO_USUARIO_ID"
			dataColumn = dataTable.Columns["CONCILIADO_USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCILIADO_USUARIO_ID = (decimal)row[dataColumn];
			// Column "CONCILIADO_USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["CONCILIADO_USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCILIADO_USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "CONCILIADO_FECHA"
			dataColumn = dataTable.Columns["CONCILIADO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCILIADO_FECHA = (System.DateTime)row[dataColumn];
			// Column "DESCONCILIADO_USUARIO_ID"
			dataColumn = dataTable.Columns["DESCONCILIADO_USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONCILIADO_USUARIO_ID = (decimal)row[dataColumn];
			// Column "DESCONCILIADO_USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["DESCONCILIADO_USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONCILIADO_USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "DESCONCILIADO_FECHA"
			dataColumn = dataTable.Columns["DESCONCILIADO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONCILIADO_FECHA = (System.DateTime)row[dataColumn];
			// Column "CTACTE_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_BANCARIAS_MOV_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_BANCARIAS_MOV_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANCARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALORES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_VARIO_TESORERIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONCILIADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONCILIADO_USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONCILIADO_USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONCILIADO_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCONCILIADO_USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCONCILIADO_USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCONCILIADO_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
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

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_VARIO_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONCILIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONCILIADO_USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONCILIADO_USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONCILIADO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESCONCILIADO_USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCONCILIADO_USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCONCILIADO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_BANCARIAS_MOV_INFO_COMPCollection_Base class
}  // End of namespace
