// <fileinfo name="INGRESO_STOCK_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="INGRESO_STOCK_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INGRESO_STOCK_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_STOCK_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string INGRESO_STOCK_IDColumnName = "INGRESO_STOCK_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string ES_TRAZABLEColumnName = "ES_TRAZABLE";
		public const string LOTEColumnName = "LOTE";
		public const string UNIDAD_IDColumnName = "UNIDAD_ID";
		public const string CANTIDAD_TOTAL_DESTINOColumnName = "CANTIDAD_TOTAL_DESTINO";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string CANTIDAD_TOTAL_ORIGENColumnName = "CANTIDAD_TOTAL_ORIGEN";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONEDA_PAIS_COTIZACIONColumnName = "MONEDA_PAIS_COTIZACION";
		public const string COSTOColumnName = "COSTO";
		public const string COSTO_IMPUESTO_PORCColumnName = "COSTO_IMPUESTO_PORC";
		public const string PORCENTAJE_PRORRATEO_DETALLEColumnName = "PORCENTAJE_PRORRATEO_DETALLE";
		public const string MONTO_PRORRATEADOColumnName = "MONTO_PRORRATEADO";
		public const string MONTO_PRORRATEO_DETALLEColumnName = "MONTO_PRORRATEO_DETALLE";
		public const string COSTO_NETO_SIN_DTO_ORIGINALColumnName = "COSTO_NETO_SIN_DTO_ORIGINAL";
		public const string CANTIDAD_ORIGINALColumnName = "CANTIDAD_ORIGINAL";
		public const string MONEDA_ORIGINAL_IDColumnName = "MONEDA_ORIGINAL_ID";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";
		public const string COSTO_TOTALColumnName = "COSTO_TOTAL";
		public const string GASTO_UNITARIO_APLICADOColumnName = "GASTO_UNITARIO_APLICADO";
		public const string GASTO_TOTAL_APLICADOColumnName = "GASTO_TOTAL_APLICADO";
		public const string COSTO_PRORRATEADOColumnName = "COSTO_PRORRATEADO";
		public const string MONTO_TOTAL_PRORRATEADOColumnName = "MONTO_TOTAL_PRORRATEADO";
		public const string COSTO_TOTAL_PRORRATEADOColumnName = "COSTO_TOTAL_PRORRATEADO";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_STOCK_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INGRESO_STOCK_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INGRESO_STOCK_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INGRESO_STOCK_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INGRESO_STOCK_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INGRESO_STOCK_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INGRESO_STOCK_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects.</returns>
		public INGRESO_STOCK_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual INGRESO_STOCK_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INGRESO_STOCK_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects.</returns>
		protected INGRESO_STOCK_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects.</returns>
		protected INGRESO_STOCK_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual INGRESO_STOCK_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ingreso_stock_idColumnIndex = reader.GetOrdinal("INGRESO_STOCK_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int es_trazableColumnIndex = reader.GetOrdinal("ES_TRAZABLE");
			int loteColumnIndex = reader.GetOrdinal("LOTE");
			int unidad_idColumnIndex = reader.GetOrdinal("UNIDAD_ID");
			int cantidad_total_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_DESTINO");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int cantidad_total_origenColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_ORIGEN");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int moneda_pais_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_PAIS_COTIZACION");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int costo_impuesto_porcColumnIndex = reader.GetOrdinal("COSTO_IMPUESTO_PORC");
			int porcentaje_prorrateo_detalleColumnIndex = reader.GetOrdinal("PORCENTAJE_PRORRATEO_DETALLE");
			int monto_prorrateadoColumnIndex = reader.GetOrdinal("MONTO_PRORRATEADO");
			int monto_prorrateo_detalleColumnIndex = reader.GetOrdinal("MONTO_PRORRATEO_DETALLE");
			int costo_neto_sin_dto_originalColumnIndex = reader.GetOrdinal("COSTO_NETO_SIN_DTO_ORIGINAL");
			int cantidad_originalColumnIndex = reader.GetOrdinal("CANTIDAD_ORIGINAL");
			int moneda_original_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGINAL_ID");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");
			int costo_totalColumnIndex = reader.GetOrdinal("COSTO_TOTAL");
			int gasto_unitario_aplicadoColumnIndex = reader.GetOrdinal("GASTO_UNITARIO_APLICADO");
			int gasto_total_aplicadoColumnIndex = reader.GetOrdinal("GASTO_TOTAL_APLICADO");
			int costo_prorrateadoColumnIndex = reader.GetOrdinal("COSTO_PRORRATEADO");
			int monto_total_prorrateadoColumnIndex = reader.GetOrdinal("MONTO_TOTAL_PRORRATEADO");
			int costo_total_prorrateadoColumnIndex = reader.GetOrdinal("COSTO_TOTAL_PRORRATEADO");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INGRESO_STOCK_DET_INFO_COMPLRow record = new INGRESO_STOCK_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.INGRESO_STOCK_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_stock_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					record.ES_TRAZABLE = Convert.ToString(reader.GetValue(es_trazableColumnIndex));
					if(!reader.IsDBNull(loteColumnIndex))
						record.LOTE = Convert.ToString(reader.GetValue(loteColumnIndex));
					if(!reader.IsDBNull(unidad_idColumnIndex))
						record.UNIDAD_ID = Convert.ToString(reader.GetValue(unidad_idColumnIndex));
					if(!reader.IsDBNull(cantidad_total_destinoColumnIndex))
						record.CANTIDAD_TOTAL_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					record.CANTIDAD_TOTAL_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_origenColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.MONEDA_PAIS_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_pais_cotizacionColumnIndex)), 9);
					record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					record.COSTO_IMPUESTO_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(costo_impuesto_porcColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_prorrateo_detalleColumnIndex))
						record.PORCENTAJE_PRORRATEO_DETALLE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_prorrateo_detalleColumnIndex)), 9);
					if(!reader.IsDBNull(monto_prorrateadoColumnIndex))
						record.MONTO_PRORRATEADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_prorrateadoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_prorrateo_detalleColumnIndex))
						record.MONTO_PRORRATEO_DETALLE = Math.Round(Convert.ToDecimal(reader.GetValue(monto_prorrateo_detalleColumnIndex)), 9);
					if(!reader.IsDBNull(costo_neto_sin_dto_originalColumnIndex))
						record.COSTO_NETO_SIN_DTO_ORIGINAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_neto_sin_dto_originalColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_originalColumnIndex))
						record.CANTIDAD_ORIGINAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_originalColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_original_idColumnIndex))
						record.MONEDA_ORIGINAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_original_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));
					if(!reader.IsDBNull(costo_totalColumnIndex))
						record.COSTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_totalColumnIndex)), 9);
					if(!reader.IsDBNull(gasto_unitario_aplicadoColumnIndex))
						record.GASTO_UNITARIO_APLICADO = Math.Round(Convert.ToDecimal(reader.GetValue(gasto_unitario_aplicadoColumnIndex)), 9);
					if(!reader.IsDBNull(gasto_total_aplicadoColumnIndex))
						record.GASTO_TOTAL_APLICADO = Math.Round(Convert.ToDecimal(reader.GetValue(gasto_total_aplicadoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_prorrateadoColumnIndex))
						record.COSTO_PRORRATEADO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_prorrateadoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_total_prorrateadoColumnIndex))
						record.MONTO_TOTAL_PRORRATEADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_prorrateadoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_total_prorrateadoColumnIndex))
						record.COSTO_TOTAL_PRORRATEADO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_total_prorrateadoColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INGRESO_STOCK_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(INGRESO_STOCK_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INGRESO_STOCK_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual INGRESO_STOCK_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			INGRESO_STOCK_DET_INFO_COMPLRow mappedObject = new INGRESO_STOCK_DET_INFO_COMPLRow();
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
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "ES_TRAZABLE"
			dataColumn = dataTable.Columns["ES_TRAZABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TRAZABLE = (string)row[dataColumn];
			// Column "LOTE"
			dataColumn = dataTable.Columns["LOTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE = (string)row[dataColumn];
			// Column "UNIDAD_ID"
			dataColumn = dataTable.Columns["UNIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID = (string)row[dataColumn];
			// Column "CANTIDAD_TOTAL_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_DESTINO = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "CANTIDAD_TOTAL_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_ORIGEN = (decimal)row[dataColumn];
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
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "MONEDA_PAIS_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_PAIS_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_PAIS_COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "COSTO_IMPUESTO_PORC"
			dataColumn = dataTable.Columns["COSTO_IMPUESTO_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_IMPUESTO_PORC = (decimal)row[dataColumn];
			// Column "PORCENTAJE_PRORRATEO_DETALLE"
			dataColumn = dataTable.Columns["PORCENTAJE_PRORRATEO_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_PRORRATEO_DETALLE = (decimal)row[dataColumn];
			// Column "MONTO_PRORRATEADO"
			dataColumn = dataTable.Columns["MONTO_PRORRATEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRORRATEADO = (decimal)row[dataColumn];
			// Column "MONTO_PRORRATEO_DETALLE"
			dataColumn = dataTable.Columns["MONTO_PRORRATEO_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_PRORRATEO_DETALLE = (decimal)row[dataColumn];
			// Column "COSTO_NETO_SIN_DTO_ORIGINAL"
			dataColumn = dataTable.Columns["COSTO_NETO_SIN_DTO_ORIGINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_NETO_SIN_DTO_ORIGINAL = (decimal)row[dataColumn];
			// Column "CANTIDAD_ORIGINAL"
			dataColumn = dataTable.Columns["CANTIDAD_ORIGINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIGINAL = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGINAL_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGINAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGINAL_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			// Column "COSTO_TOTAL"
			dataColumn = dataTable.Columns["COSTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TOTAL = (decimal)row[dataColumn];
			// Column "GASTO_UNITARIO_APLICADO"
			dataColumn = dataTable.Columns["GASTO_UNITARIO_APLICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GASTO_UNITARIO_APLICADO = (decimal)row[dataColumn];
			// Column "GASTO_TOTAL_APLICADO"
			dataColumn = dataTable.Columns["GASTO_TOTAL_APLICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GASTO_TOTAL_APLICADO = (decimal)row[dataColumn];
			// Column "COSTO_PRORRATEADO"
			dataColumn = dataTable.Columns["COSTO_PRORRATEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_PRORRATEADO = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL_PRORRATEADO"
			dataColumn = dataTable.Columns["MONTO_TOTAL_PRORRATEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_PRORRATEADO = (decimal)row[dataColumn];
			// Column "COSTO_TOTAL_PRORRATEADO"
			dataColumn = dataTable.Columns["COSTO_TOTAL_PRORRATEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TOTAL_PRORRATEADO = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INGRESO_STOCK_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INGRESO_STOCK_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_STOCK_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_TRAZABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_PAIS_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_IMPUESTO_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_PRORRATEO_DETALLE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_PRORRATEADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_PRORRATEO_DETALLE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_NETO_SIN_DTO_ORIGINAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIGINAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGINAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 106;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GASTO_UNITARIO_APLICADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GASTO_TOTAL_APLICADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_PRORRATEADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_PRORRATEADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_TOTAL_PRORRATEADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
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

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_TRAZABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "LOTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_TOTAL_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_TOTAL_ORIGEN":
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

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_PAIS_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_IMPUESTO_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_PRORRATEO_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PRORRATEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_PRORRATEO_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_NETO_SIN_DTO_ORIGINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ORIGINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGINAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GASTO_UNITARIO_APLICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GASTO_TOTAL_APLICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_PRORRATEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL_PRORRATEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TOTAL_PRORRATEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INGRESO_STOCK_DET_INFO_COMPLCollection_Base class
}  // End of namespace
