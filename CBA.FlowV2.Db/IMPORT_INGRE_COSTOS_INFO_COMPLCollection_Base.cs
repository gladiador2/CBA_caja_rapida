// <fileinfo name="IMPORT_INGRE_COSTOS_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORT_INGRE_COSTOS_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string INGRESO_STOCK_IDColumnName = "INGRESO_STOCK_ID";
		public const string INGRESO_CASO_IDColumnName = "INGRESO_CASO_ID";
		public const string INGRESO_CASO_FC_PROVEEDOR_IDColumnName = "INGRESO_CASO_FC_PROVEEDOR_ID";
		public const string INGRESO_SUCURSAL_IDColumnName = "INGRESO_SUCURSAL_ID";
		public const string INGRESO_SUCURSAL_NOMBREColumnName = "INGRESO_SUCURSAL_NOMBRE";
		public const string INGRESO_SUCURSAL_ABREVIATURAColumnName = "INGRESO_SUCURSAL_ABREVIATURA";
		public const string INGRESO_DEPOSITO_IDColumnName = "INGRESO_DEPOSITO_ID";
		public const string INGRESO_DEPOSITO_NOMBREColumnName = "INGRESO_DEPOSITO_NOMBRE";
		public const string INGRESO_DEPOSITO_ABREVIATURAColumnName = "INGRESO_DEPOSITO_ABREVIATURA";
		public const string MONTO_PRORATEOColumnName = "MONTO_PRORATEO";
		public const string INGRESO_STOCK_DETALLE_IDColumnName = "INGRESO_STOCK_DETALLE_ID";
		public const string INGRESO_DET_LOTE_IDColumnName = "INGRESO_DET_LOTE_ID";
		public const string INGRESO_DET_ARTICULO_IDColumnName = "INGRESO_DET_ARTICULO_ID";
		public const string INGRESO_DET_ARTICULO_CODIGOColumnName = "INGRESO_DET_ARTICULO_CODIGO";
		public const string INGRESO_DET_LOTEColumnName = "INGRESO_DET_LOTE";
		public const string INGRESO_DET_MONEDA_IDColumnName = "INGRESO_DET_MONEDA_ID";
		public const string INGRESO_DET_MONEDA_SIMBOLOColumnName = "INGRESO_DET_MONEDA_SIMBOLO";
		public const string INGRESO_DET_COTIZACIONColumnName = "INGRESO_DET_COTIZACION";
		public const string IMPORTACION_IDColumnName = "IMPORTACION_ID";
		public const string IMPORTACION_NOMBREColumnName = "IMPORTACION_NOMBRE";
		public const string IMPORTACION_TOTAL_GASTOSColumnName = "IMPORTACION_TOTAL_GASTOS";
		public const string IMPORTACION_FACTURASColumnName = "IMPORTACION_FACTURAS";
		public const string IMPORTACION_GASTOS_IDColumnName = "IMPORTACION_GASTOS_ID";
		public const string IMPORTACION_GASTOS_MONTOColumnName = "IMPORTACION_GASTOS_MONTO";
		public const string IMPORT_GASTOS_MONEDA_IDColumnName = "IMPORT_GASTOS_MONEDA_ID";
		public const string IMPORT_GASTOS_MONEDA_NOMBREColumnName = "IMPORT_GASTOS_MONEDA_NOMBRE";
		public const string IMPORT_GASTOS_COTIZACIONColumnName = "IMPORT_GASTOS_COTIZACION";
		public const string MONTOColumnName = "MONTO";
		public const string PORCENTAJEColumnName = "PORCENTAJE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CANTIDAD_DECIMALESColumnName = "MONEDA_CANTIDAD_DECIMALES";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string COTIZACIONColumnName = "COTIZACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public IMPORT_INGRE_COSTOS_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>IMPORT_INGRE_COSTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects.</returns>
		public virtual IMPORT_INGRE_COSTOS_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>IMPORT_INGRE_COSTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>IMPORT_INGRE_COSTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public IMPORT_INGRE_COSTOS_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			IMPORT_INGRE_COSTOS_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects.</returns>
		public IMPORT_INGRE_COSTOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects.</returns>
		public virtual IMPORT_INGRE_COSTOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.IMPORT_INGRE_COSTOS_INFO_COMPL";
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
		/// <returns>An array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects.</returns>
		protected IMPORT_INGRE_COSTOS_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects.</returns>
		protected IMPORT_INGRE_COSTOS_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> objects.</returns>
		protected virtual IMPORT_INGRE_COSTOS_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ingreso_stock_idColumnIndex = reader.GetOrdinal("INGRESO_STOCK_ID");
			int ingreso_caso_idColumnIndex = reader.GetOrdinal("INGRESO_CASO_ID");
			int ingreso_caso_fc_proveedor_idColumnIndex = reader.GetOrdinal("INGRESO_CASO_FC_PROVEEDOR_ID");
			int ingreso_sucursal_idColumnIndex = reader.GetOrdinal("INGRESO_SUCURSAL_ID");
			int ingreso_sucursal_nombreColumnIndex = reader.GetOrdinal("INGRESO_SUCURSAL_NOMBRE");
			int ingreso_sucursal_abreviaturaColumnIndex = reader.GetOrdinal("INGRESO_SUCURSAL_ABREVIATURA");
			int ingreso_deposito_idColumnIndex = reader.GetOrdinal("INGRESO_DEPOSITO_ID");
			int ingreso_deposito_nombreColumnIndex = reader.GetOrdinal("INGRESO_DEPOSITO_NOMBRE");
			int ingreso_deposito_abreviaturaColumnIndex = reader.GetOrdinal("INGRESO_DEPOSITO_ABREVIATURA");
			int monto_prorateoColumnIndex = reader.GetOrdinal("MONTO_PRORATEO");
			int ingreso_stock_detalle_idColumnIndex = reader.GetOrdinal("INGRESO_STOCK_DETALLE_ID");
			int ingreso_det_lote_idColumnIndex = reader.GetOrdinal("INGRESO_DET_LOTE_ID");
			int ingreso_det_articulo_idColumnIndex = reader.GetOrdinal("INGRESO_DET_ARTICULO_ID");
			int ingreso_det_articulo_codigoColumnIndex = reader.GetOrdinal("INGRESO_DET_ARTICULO_CODIGO");
			int ingreso_det_loteColumnIndex = reader.GetOrdinal("INGRESO_DET_LOTE");
			int ingreso_det_moneda_idColumnIndex = reader.GetOrdinal("INGRESO_DET_MONEDA_ID");
			int ingreso_det_moneda_simboloColumnIndex = reader.GetOrdinal("INGRESO_DET_MONEDA_SIMBOLO");
			int ingreso_det_cotizacionColumnIndex = reader.GetOrdinal("INGRESO_DET_COTIZACION");
			int importacion_idColumnIndex = reader.GetOrdinal("IMPORTACION_ID");
			int importacion_nombreColumnIndex = reader.GetOrdinal("IMPORTACION_NOMBRE");
			int importacion_total_gastosColumnIndex = reader.GetOrdinal("IMPORTACION_TOTAL_GASTOS");
			int importacion_facturasColumnIndex = reader.GetOrdinal("IMPORTACION_FACTURAS");
			int importacion_gastos_idColumnIndex = reader.GetOrdinal("IMPORTACION_GASTOS_ID");
			int importacion_gastos_montoColumnIndex = reader.GetOrdinal("IMPORTACION_GASTOS_MONTO");
			int import_gastos_moneda_idColumnIndex = reader.GetOrdinal("IMPORT_GASTOS_MONEDA_ID");
			int import_gastos_moneda_nombreColumnIndex = reader.GetOrdinal("IMPORT_GASTOS_MONEDA_NOMBRE");
			int import_gastos_cotizacionColumnIndex = reader.GetOrdinal("IMPORT_GASTOS_COTIZACION");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cantidad_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDAD_DECIMALES");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					IMPORT_INGRE_COSTOS_INFO_COMPLRow record = new IMPORT_INGRE_COSTOS_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_stock_idColumnIndex))
						record.INGRESO_STOCK_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_stock_idColumnIndex)), 9);
					record.INGRESO_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_caso_fc_proveedor_idColumnIndex))
						record.INGRESO_CASO_FC_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_caso_fc_proveedor_idColumnIndex)), 9);
					record.INGRESO_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_sucursal_idColumnIndex)), 9);
					record.INGRESO_SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(ingreso_sucursal_nombreColumnIndex));
					record.INGRESO_SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(ingreso_sucursal_abreviaturaColumnIndex));
					record.INGRESO_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_deposito_idColumnIndex)), 9);
					record.INGRESO_DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(ingreso_deposito_nombreColumnIndex));
					record.INGRESO_DEPOSITO_ABREVIATURA = Convert.ToString(reader.GetValue(ingreso_deposito_abreviaturaColumnIndex));
					if(!reader.IsDBNull(monto_prorateoColumnIndex))
						record.MONTO_PRORATEO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_prorateoColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_stock_detalle_idColumnIndex))
						record.INGRESO_STOCK_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_stock_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_det_lote_idColumnIndex))
						record.INGRESO_DET_LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_det_lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_det_articulo_idColumnIndex))
						record.INGRESO_DET_ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_det_articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingreso_det_articulo_codigoColumnIndex))
						record.INGRESO_DET_ARTICULO_CODIGO = Convert.ToString(reader.GetValue(ingreso_det_articulo_codigoColumnIndex));
					if(!reader.IsDBNull(ingreso_det_loteColumnIndex))
						record.INGRESO_DET_LOTE = Convert.ToString(reader.GetValue(ingreso_det_loteColumnIndex));
					record.INGRESO_DET_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_det_moneda_idColumnIndex)), 9);
					record.INGRESO_DET_MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(ingreso_det_moneda_simboloColumnIndex));
					record.INGRESO_DET_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_det_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_idColumnIndex))
						record.IMPORTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_nombreColumnIndex))
						record.IMPORTACION_NOMBRE = Convert.ToString(reader.GetValue(importacion_nombreColumnIndex));
					if(!reader.IsDBNull(importacion_total_gastosColumnIndex))
						record.IMPORTACION_TOTAL_GASTOS = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_total_gastosColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_facturasColumnIndex))
						record.IMPORTACION_FACTURAS = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_facturasColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_gastos_idColumnIndex))
						record.IMPORTACION_GASTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_gastos_idColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_gastos_montoColumnIndex))
						record.IMPORTACION_GASTOS_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_gastos_montoColumnIndex)), 9);
					if(!reader.IsDBNull(import_gastos_moneda_idColumnIndex))
						record.IMPORT_GASTOS_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(import_gastos_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(import_gastos_moneda_nombreColumnIndex))
						record.IMPORT_GASTOS_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(import_gastos_moneda_nombreColumnIndex));
					if(!reader.IsDBNull(import_gastos_cotizacionColumnIndex))
						record.IMPORT_GASTOS_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(import_gastos_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentajeColumnIndex))
						record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.MONEDA_CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidad_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (IMPORT_INGRE_COSTOS_INFO_COMPLRow[])(recordList.ToArray(typeof(IMPORT_INGRE_COSTOS_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="IMPORT_INGRE_COSTOS_INFO_COMPLRow"/> object.</returns>
		protected virtual IMPORT_INGRE_COSTOS_INFO_COMPLRow MapRow(DataRow row)
		{
			IMPORT_INGRE_COSTOS_INFO_COMPLRow mappedObject = new IMPORT_INGRE_COSTOS_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "INGRESO_STOCK_ID"
			dataColumn = dataTable.Columns["INGRESO_STOCK_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_STOCK_ID = (decimal)row[dataColumn];
			// Column "INGRESO_CASO_ID"
			dataColumn = dataTable.Columns["INGRESO_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_CASO_ID = (decimal)row[dataColumn];
			// Column "INGRESO_CASO_FC_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["INGRESO_CASO_FC_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_CASO_FC_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "INGRESO_SUCURSAL_ID"
			dataColumn = dataTable.Columns["INGRESO_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "INGRESO_SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["INGRESO_SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "INGRESO_SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["INGRESO_SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "INGRESO_DEPOSITO_ID"
			dataColumn = dataTable.Columns["INGRESO_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "INGRESO_DEPOSITO_NOMBRE"
			dataColumn = dataTable.Columns["INGRESO_DEPOSITO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DEPOSITO_NOMBRE = (string)row[dataColumn];
			// Column "INGRESO_DEPOSITO_ABREVIATURA"
			dataColumn = dataTable.Columns["INGRESO_DEPOSITO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DEPOSITO_ABREVIATURA = (string)row[dataColumn];
			// Column "MONTO_PRORATEO"
			dataColumn = dataTable.Columns["MONTO_PRORATEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRORATEO = (decimal)row[dataColumn];
			// Column "INGRESO_STOCK_DETALLE_ID"
			dataColumn = dataTable.Columns["INGRESO_STOCK_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_STOCK_DETALLE_ID = (decimal)row[dataColumn];
			// Column "INGRESO_DET_LOTE_ID"
			dataColumn = dataTable.Columns["INGRESO_DET_LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DET_LOTE_ID = (decimal)row[dataColumn];
			// Column "INGRESO_DET_ARTICULO_ID"
			dataColumn = dataTable.Columns["INGRESO_DET_ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DET_ARTICULO_ID = (decimal)row[dataColumn];
			// Column "INGRESO_DET_ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["INGRESO_DET_ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DET_ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "INGRESO_DET_LOTE"
			dataColumn = dataTable.Columns["INGRESO_DET_LOTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DET_LOTE = (string)row[dataColumn];
			// Column "INGRESO_DET_MONEDA_ID"
			dataColumn = dataTable.Columns["INGRESO_DET_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DET_MONEDA_ID = (decimal)row[dataColumn];
			// Column "INGRESO_DET_MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["INGRESO_DET_MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DET_MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "INGRESO_DET_COTIZACION"
			dataColumn = dataTable.Columns["INGRESO_DET_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_DET_COTIZACION = (decimal)row[dataColumn];
			// Column "IMPORTACION_ID"
			dataColumn = dataTable.Columns["IMPORTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_ID = (decimal)row[dataColumn];
			// Column "IMPORTACION_NOMBRE"
			dataColumn = dataTable.Columns["IMPORTACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_NOMBRE = (string)row[dataColumn];
			// Column "IMPORTACION_TOTAL_GASTOS"
			dataColumn = dataTable.Columns["IMPORTACION_TOTAL_GASTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_TOTAL_GASTOS = (decimal)row[dataColumn];
			// Column "IMPORTACION_FACTURAS"
			dataColumn = dataTable.Columns["IMPORTACION_FACTURAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_FACTURAS = (decimal)row[dataColumn];
			// Column "IMPORTACION_GASTOS_ID"
			dataColumn = dataTable.Columns["IMPORTACION_GASTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_GASTOS_ID = (decimal)row[dataColumn];
			// Column "IMPORTACION_GASTOS_MONTO"
			dataColumn = dataTable.Columns["IMPORTACION_GASTOS_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_GASTOS_MONTO = (decimal)row[dataColumn];
			// Column "IMPORT_GASTOS_MONEDA_ID"
			dataColumn = dataTable.Columns["IMPORT_GASTOS_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORT_GASTOS_MONEDA_ID = (decimal)row[dataColumn];
			// Column "IMPORT_GASTOS_MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["IMPORT_GASTOS_MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORT_GASTOS_MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "IMPORT_GASTOS_COTIZACION"
			dataColumn = dataTable.Columns["IMPORT_GASTOS_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORT_GASTOS_COTIZACION = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "MONEDA_CANTIDAD_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDAD_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDAD_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>IMPORT_INGRE_COSTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "IMPORT_INGRE_COSTOS_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_STOCK_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_CASO_FC_PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DEPOSITO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_PRORATEO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_STOCK_DETALLE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DET_LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DET_ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DET_ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DET_LOTE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DET_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DET_MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_DET_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_TOTAL_GASTOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_FACTURAS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_GASTOS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_GASTOS_MONTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORT_GASTOS_MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORT_GASTOS_MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORT_GASTOS_COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDAD_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
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

				case "INGRESO_STOCK_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_CASO_FC_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_DEPOSITO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_PRORATEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_STOCK_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_DET_LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_DET_ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_DET_ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_DET_LOTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_DET_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO_DET_MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_DET_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPORTACION_TOTAL_GASTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_FACTURAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_GASTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_GASTOS_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORT_GASTOS_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORT_GASTOS_MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPORT_GASTOS_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CANTIDAD_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of IMPORT_INGRE_COSTOS_INFO_COMPLCollection_Base class
}  // End of namespace
