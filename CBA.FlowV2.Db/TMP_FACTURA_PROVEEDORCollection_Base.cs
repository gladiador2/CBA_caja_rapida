// <fileinfo name="TMP_FACTURA_PROVEEDORCollection_Base.cs">
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
	/// The base class for <see cref="TMP_FACTURA_PROVEEDORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TMP_FACTURA_PROVEEDORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TMP_FACTURA_PROVEEDORCollection_Base
	{
		// Constants
		public const string RUCColumnName = "RUC";
		public const string RAZON_SOCIALColumnName = "RAZON_SOCIAL";
		public const string FECHA_FACTURAColumnName = "FECHA_FACTURA";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string NRO_TIMBRADOColumnName = "NRO_TIMBRADO";
		public const string FECHA_VTO_TIMBRADOColumnName = "FECHA_VTO_TIMBRADO";
		public const string MONEDAColumnName = "MONEDA";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string CONDICION_PAGOColumnName = "CONDICION_PAGO";
		public const string ES_TICKETColumnName = "ES_TICKET";
		public const string OBSERVACION_CABECERAColumnName = "OBSERVACION_CABECERA";
		public const string OBSERVACION_DETALLEColumnName = "OBSERVACION_DETALLE";
		public const string TEXTO_PREDEFINIDOColumnName = "TEXTO_PREDEFINIDO";
		public const string CODIGO_ARTICULOColumnName = "CODIGO_ARTICULO";
		public const string CANTIDAD_TOTALColumnName = "CANTIDAD_TOTAL";
		public const string MONTO_NETOColumnName = "MONTO_NETO";
		public const string MONTO_IMPUESTOColumnName = "MONTO_IMPUESTO";
		public const string MONTO_DESCUENTOColumnName = "MONTO_DESCUENTO";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string TIPO_FACTURA_IDColumnName = "TIPO_FACTURA_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string MONTO_BRUTOColumnName = "MONTO_BRUTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TMP_FACTURA_PROVEEDORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TMP_FACTURA_PROVEEDORCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this table belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>TMP_FACTURA_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects.</returns>
		public virtual TMP_FACTURA_PROVEEDORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TMP_FACTURA_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TMP_FACTURA_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TMP_FACTURA_PROVEEDORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TMP_FACTURA_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TMP_FACTURA_PROVEEDORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TMP_FACTURA_PROVEEDORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects.</returns>
		public TMP_FACTURA_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects that 
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
		/// <returns>An array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects.</returns>
		public virtual TMP_FACTURA_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TMP_FACTURA_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Adds a new record into the <c>TMP_FACTURA_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TMP_FACTURA_PROVEEDORRow"/> object to be inserted.</param>
		public virtual void Insert(TMP_FACTURA_PROVEEDORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TMP_FACTURA_PROVEEDOR (" +
				"RUC, " +
				"RAZON_SOCIAL, " +
				"FECHA_FACTURA, " +
				"NRO_COMPROBANTE, " +
				"NRO_TIMBRADO, " +
				"FECHA_VTO_TIMBRADO, " +
				"MONEDA, " +
				"COTIZACION, " +
				"CONDICION_PAGO, " +
				"ES_TICKET, " +
				"OBSERVACION_CABECERA, " +
				"OBSERVACION_DETALLE, " +
				"TEXTO_PREDEFINIDO, " +
				"CODIGO_ARTICULO, " +
				"CANTIDAD_TOTAL, " +
				"MONTO_NETO, " +
				"MONTO_IMPUESTO, " +
				"MONTO_DESCUENTO, " +
				"PROVEEDOR_ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"MONEDA_ID, " +
				"IMPUESTO_ID, " +
				"CONDICION_PAGO_ID, " +
				"TIPO_FACTURA_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"RUBRO_ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"CASO_ID, " +
				"PORCENTAJE_IMPUESTO, " +
				"MONTO_BRUTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("RUC") + ", " +
				_db.CreateSqlParameterName("RAZON_SOCIAL") + ", " +
				_db.CreateSqlParameterName("FECHA_FACTURA") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("NRO_TIMBRADO") + ", " +
				_db.CreateSqlParameterName("FECHA_VTO_TIMBRADO") + ", " +
				_db.CreateSqlParameterName("MONEDA") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO") + ", " +
				_db.CreateSqlParameterName("ES_TICKET") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_CABECERA") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_DETALLE") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO") + ", " +
				_db.CreateSqlParameterName("CODIGO_ARTICULO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_TOTAL") + ", " +
				_db.CreateSqlParameterName("MONTO_NETO") + ", " +
				_db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("MONTO_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_FACTURA_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("MONTO_BRUTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "RAZON_SOCIAL", value.RAZON_SOCIAL);
			AddParameter(cmd, "FECHA_FACTURA",
				value.IsFECHA_FACTURANull ? DBNull.Value : (object)value.FECHA_FACTURA);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "NRO_TIMBRADO", value.NRO_TIMBRADO);
			AddParameter(cmd, "FECHA_VTO_TIMBRADO",
				value.IsFECHA_VTO_TIMBRADONull ? DBNull.Value : (object)value.FECHA_VTO_TIMBRADO);
			AddParameter(cmd, "MONEDA", value.MONEDA);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "CONDICION_PAGO", value.CONDICION_PAGO);
			AddParameter(cmd, "ES_TICKET", value.ES_TICKET);
			AddParameter(cmd, "OBSERVACION_CABECERA", value.OBSERVACION_CABECERA);
			AddParameter(cmd, "OBSERVACION_DETALLE", value.OBSERVACION_DETALLE);
			AddParameter(cmd, "TEXTO_PREDEFINIDO", value.TEXTO_PREDEFINIDO);
			AddParameter(cmd, "CODIGO_ARTICULO", value.CODIGO_ARTICULO);
			AddParameter(cmd, "CANTIDAD_TOTAL",
				value.IsCANTIDAD_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_TOTAL);
			AddParameter(cmd, "MONTO_NETO",
				value.IsMONTO_NETONull ? DBNull.Value : (object)value.MONTO_NETO);
			AddParameter(cmd, "MONTO_IMPUESTO",
				value.IsMONTO_IMPUESTONull ? DBNull.Value : (object)value.MONTO_IMPUESTO);
			AddParameter(cmd, "MONTO_DESCUENTO",
				value.IsMONTO_DESCUENTONull ? DBNull.Value : (object)value.MONTO_DESCUENTO);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "TIPO_FACTURA_ID",
				value.IsTIPO_FACTURA_IDNull ? DBNull.Value : (object)value.TIPO_FACTURA_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO",
				value.IsPORCENTAJE_IMPUESTONull ? DBNull.Value : (object)value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "MONTO_BRUTO",
				value.IsMONTO_BRUTONull ? DBNull.Value : (object)value.MONTO_BRUTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes <c>TMP_FACTURA_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>The number of deleted records.</returns>
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used 
		/// to delete <c>TMP_FACTURA_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TMP_FACTURA_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TMP_FACTURA_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>The number of deleted records.</returns>
		public int DeleteAll()
		{
			return Delete("");
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects.</returns>
		protected TMP_FACTURA_PROVEEDORRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>An array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects.</returns>
		protected TMP_FACTURA_PROVEEDORRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="TMP_FACTURA_PROVEEDORRow"/> objects.</returns>
		protected virtual TMP_FACTURA_PROVEEDORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int rucColumnIndex = reader.GetOrdinal("RUC");
			int razon_socialColumnIndex = reader.GetOrdinal("RAZON_SOCIAL");
			int fecha_facturaColumnIndex = reader.GetOrdinal("FECHA_FACTURA");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int nro_timbradoColumnIndex = reader.GetOrdinal("NRO_TIMBRADO");
			int fecha_vto_timbradoColumnIndex = reader.GetOrdinal("FECHA_VTO_TIMBRADO");
			int monedaColumnIndex = reader.GetOrdinal("MONEDA");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int condicion_pagoColumnIndex = reader.GetOrdinal("CONDICION_PAGO");
			int es_ticketColumnIndex = reader.GetOrdinal("ES_TICKET");
			int observacion_cabeceraColumnIndex = reader.GetOrdinal("OBSERVACION_CABECERA");
			int observacion_detalleColumnIndex = reader.GetOrdinal("OBSERVACION_DETALLE");
			int texto_predefinidoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO");
			int codigo_articuloColumnIndex = reader.GetOrdinal("CODIGO_ARTICULO");
			int cantidad_totalColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL");
			int monto_netoColumnIndex = reader.GetOrdinal("MONTO_NETO");
			int monto_impuestoColumnIndex = reader.GetOrdinal("MONTO_IMPUESTO");
			int monto_descuentoColumnIndex = reader.GetOrdinal("MONTO_DESCUENTO");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int tipo_factura_idColumnIndex = reader.GetOrdinal("TIPO_FACTURA_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int monto_brutoColumnIndex = reader.GetOrdinal("MONTO_BRUTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TMP_FACTURA_PROVEEDORRow record = new TMP_FACTURA_PROVEEDORRow();
					recordList.Add(record);

					if(!reader.IsDBNull(rucColumnIndex))
						record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
					if(!reader.IsDBNull(razon_socialColumnIndex))
						record.RAZON_SOCIAL = Convert.ToString(reader.GetValue(razon_socialColumnIndex));
					if(!reader.IsDBNull(fecha_facturaColumnIndex))
						record.FECHA_FACTURA = Convert.ToDateTime(reader.GetValue(fecha_facturaColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(nro_timbradoColumnIndex))
						record.NRO_TIMBRADO = Convert.ToString(reader.GetValue(nro_timbradoColumnIndex));
					if(!reader.IsDBNull(fecha_vto_timbradoColumnIndex))
						record.FECHA_VTO_TIMBRADO = Convert.ToDateTime(reader.GetValue(fecha_vto_timbradoColumnIndex));
					if(!reader.IsDBNull(monedaColumnIndex))
						record.MONEDA = Convert.ToString(reader.GetValue(monedaColumnIndex));
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_pagoColumnIndex))
						record.CONDICION_PAGO = Convert.ToString(reader.GetValue(condicion_pagoColumnIndex));
					if(!reader.IsDBNull(es_ticketColumnIndex))
						record.ES_TICKET = Convert.ToString(reader.GetValue(es_ticketColumnIndex));
					if(!reader.IsDBNull(observacion_cabeceraColumnIndex))
						record.OBSERVACION_CABECERA = Convert.ToString(reader.GetValue(observacion_cabeceraColumnIndex));
					if(!reader.IsDBNull(observacion_detalleColumnIndex))
						record.OBSERVACION_DETALLE = Convert.ToString(reader.GetValue(observacion_detalleColumnIndex));
					if(!reader.IsDBNull(texto_predefinidoColumnIndex))
						record.TEXTO_PREDEFINIDO = Convert.ToString(reader.GetValue(texto_predefinidoColumnIndex));
					if(!reader.IsDBNull(codigo_articuloColumnIndex))
						record.CODIGO_ARTICULO = Convert.ToString(reader.GetValue(codigo_articuloColumnIndex));
					if(!reader.IsDBNull(cantidad_totalColumnIndex))
						record.CANTIDAD_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_totalColumnIndex)), 9);
					if(!reader.IsDBNull(monto_netoColumnIndex))
						record.MONTO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_netoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_impuestoColumnIndex))
						record.MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_descuentoColumnIndex))
						record.MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_factura_idColumnIndex))
						record.TIPO_FACTURA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_factura_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_impuestoColumnIndex))
						record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_brutoColumnIndex))
						record.MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_brutoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TMP_FACTURA_PROVEEDORRow[])(recordList.ToArray(typeof(TMP_FACTURA_PROVEEDORRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TMP_FACTURA_PROVEEDORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TMP_FACTURA_PROVEEDORRow"/> object.</returns>
		protected virtual TMP_FACTURA_PROVEEDORRow MapRow(DataRow row)
		{
			TMP_FACTURA_PROVEEDORRow mappedObject = new TMP_FACTURA_PROVEEDORRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
			// Column "RAZON_SOCIAL"
			dataColumn = dataTable.Columns["RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_SOCIAL = (string)row[dataColumn];
			// Column "FECHA_FACTURA"
			dataColumn = dataTable.Columns["FECHA_FACTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FACTURA = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NRO_TIMBRADO"
			dataColumn = dataTable.Columns["NRO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TIMBRADO = (string)row[dataColumn];
			// Column "FECHA_VTO_TIMBRADO"
			dataColumn = dataTable.Columns["FECHA_VTO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VTO_TIMBRADO = (System.DateTime)row[dataColumn];
			// Column "MONEDA"
			dataColumn = dataTable.Columns["MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA = (string)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO"
			dataColumn = dataTable.Columns["CONDICION_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO = (string)row[dataColumn];
			// Column "ES_TICKET"
			dataColumn = dataTable.Columns["ES_TICKET"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TICKET = (string)row[dataColumn];
			// Column "OBSERVACION_CABECERA"
			dataColumn = dataTable.Columns["OBSERVACION_CABECERA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_CABECERA = (string)row[dataColumn];
			// Column "OBSERVACION_DETALLE"
			dataColumn = dataTable.Columns["OBSERVACION_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_DETALLE = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO = (string)row[dataColumn];
			// Column "CODIGO_ARTICULO"
			dataColumn = dataTable.Columns["CODIGO_ARTICULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_ARTICULO = (string)row[dataColumn];
			// Column "CANTIDAD_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL = (decimal)row[dataColumn];
			// Column "MONTO_NETO"
			dataColumn = dataTable.Columns["MONTO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_NETO = (decimal)row[dataColumn];
			// Column "MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "MONTO_DESCUENTO"
			dataColumn = dataTable.Columns["MONTO_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESCUENTO = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "TIPO_FACTURA_ID"
			dataColumn = dataTable.Columns["TIPO_FACTURA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FACTURA_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "MONTO_BRUTO"
			dataColumn = dataTable.Columns["MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TMP_FACTURA_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TMP_FACTURA_PROVEEDOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("FECHA_FACTURA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("NRO_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("FECHA_VTO_TIMBRADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MONEDA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("ES_TICKET", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("OBSERVACION_CABECERA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("OBSERVACION_DETALLE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CODIGO_ARTICULO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_DESCUENTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_FACTURA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO", typeof(decimal));
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
				case "RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_FACTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VTO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_TICKET":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION_CABECERA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_ARTICULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_FACTURA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TMP_FACTURA_PROVEEDORCollection_Base class
}  // End of namespace
