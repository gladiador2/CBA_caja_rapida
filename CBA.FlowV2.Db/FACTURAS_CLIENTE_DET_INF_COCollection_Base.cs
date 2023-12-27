// <fileinfo name="FACTURAS_CLIENTE_DET_INF_COCollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_DET_INF_COCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_CLIENTE_DET_INF_COCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_DET_INF_COCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FACTURAS_CLIENTE_IDColumnName = "FACTURAS_CLIENTE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string ARTICULO_ES_TRAZABLEColumnName = "ARTICULO_ES_TRAZABLE";
		public const string FAMILIA_NOMBREColumnName = "FAMILIA_NOMBRE";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string GRUPO_NOMBREColumnName = "GRUPO_NOMBRE";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string SERVICIOColumnName = "SERVICIO";
		public const string SUBGRUPO_NOMBREColumnName = "SUBGRUPO_NOMBRE";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACION_ORIGENColumnName = "COTIZACION_ORIGEN";
		public const string COTIZACION_MONEDA_LINEA_CREDColumnName = "COTIZACION_MONEDA_LINEA_CRED";
		public const string UNIDAD_DESTINO_IDColumnName = "UNIDAD_DESTINO_ID";
		public const string CANTIDAD_EMBALADAColumnName = "CANTIDAD_EMBALADA";
		public const string CANTIDAD_UNIDAD_DESTINOColumnName = "CANTIDAD_UNIDAD_DESTINO";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string CANTIDAD_UNITARIA_TOTAL_DESTColumnName = "CANTIDAD_UNITARIA_TOTAL_DEST";
		public const string PRECIO_LISTA_DESTINOColumnName = "PRECIO_LISTA_DESTINO";
		public const string UNIDAD_ORIGEN_IDColumnName = "UNIDAD_ORIGEN_ID";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIG";
		public const string PRECIO_LISTA_ORIGENColumnName = "PRECIO_LISTA_ORIGEN";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string COSTO_IDColumnName = "COSTO_ID";
		public const string COSTO_MONTOColumnName = "COSTO_MONTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_NOMBREColumnName = "COSTO_MONEDA_NOMBRE";
		public const string COSTO_MONEDA_SIMBOLOColumnName = "COSTO_MONEDA_SIMBOLO";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string MONTO_DESCUENTOColumnName = "MONTO_DESCUENTO";
		public const string PORCENTAJE_DTOColumnName = "PORCENTAJE_DTO";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string IMPUESTO_DESCRIPCIONColumnName = "IMPUESTO_DESCRIPCION";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string PORCENTAJE_COMISION_VENColumnName = "PORCENTAJE_COMISION_VEN";
		public const string MONTO_COMISION_VENColumnName = "MONTO_COMISION_VEN";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_MONTO_BRUTOColumnName = "TOTAL_MONTO_BRUTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string TOTAL_NETO_LUEGO_DE_NCColumnName = "TOTAL_NETO_LUEGO_DE_NC";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_CODIGO_BARRASColumnName = "ARTICULO_CODIGO_BARRAS";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string LOTE_NOMBREColumnName = "LOTE_NOMBRE";
		public const string CANTIDAD_DEVUELTA_NOTA_CREDITOColumnName = "CANTIDAD_DEVUELTA_NOTA_CREDITO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string VENDEDOR_COMISIONISTA_IDColumnName = "VENDEDOR_COMISIONISTA_ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";
		public const string CTACTE_RECARGO_IDColumnName = "CTACTE_RECARGO_ID";
		public const string TOTAL_NETO_LUEGO_DE_NC_AUXColumnName = "TOTAL_NETO_LUEGO_DE_NC_AUX";
		public const string CANTIDAD_ANTERIOR_AUXColumnName = "CANTIDAD_ANTERIOR_AUX";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string CASO_ASO_FLUJO_IDColumnName = "CASO_ASO_FLUJO_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITO_ABREVIATURAColumnName = "DEPOSITO_ABREVIATURA";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DET_INF_COCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_CLIENTE_DET_INF_COCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURAS_CLIENTE_DET_INF_CO</c> view.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DET_INF_CORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_CLIENTE_DET_INF_CO</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_CLIENTE_DET_INF_CO</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_CLIENTE_DET_INF_CORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_CLIENTE_DET_INF_CORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects.</returns>
		public FACTURAS_CLIENTE_DET_INF_CORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DET_INF_CORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_CLIENTE_DET_INF_CO";
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects.</returns>
		protected FACTURAS_CLIENTE_DET_INF_CORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects.</returns>
		protected FACTURAS_CLIENTE_DET_INF_CORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> objects.</returns>
		protected virtual FACTURAS_CLIENTE_DET_INF_CORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int facturas_cliente_idColumnIndex = reader.GetOrdinal("FACTURAS_CLIENTE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int articulo_es_trazableColumnIndex = reader.GetOrdinal("ARTICULO_ES_TRAZABLE");
			int familia_nombreColumnIndex = reader.GetOrdinal("FAMILIA_NOMBRE");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int grupo_nombreColumnIndex = reader.GetOrdinal("GRUPO_NOMBRE");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int servicioColumnIndex = reader.GetOrdinal("SERVICIO");
			int subgrupo_nombreColumnIndex = reader.GetOrdinal("SUBGRUPO_NOMBRE");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacion_origenColumnIndex = reader.GetOrdinal("COTIZACION_ORIGEN");
			int cotizacion_moneda_linea_credColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_LINEA_CRED");
			int unidad_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_ID");
			int cantidad_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA");
			int cantidad_unidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_DESTINO");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int cantidad_unitaria_total_destColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_DEST");
			int precio_lista_destinoColumnIndex = reader.GetOrdinal("PRECIO_LISTA_DESTINO");
			int unidad_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_ID");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int cantidad_unitaria_total_origColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIG");
			int precio_lista_origenColumnIndex = reader.GetOrdinal("PRECIO_LISTA_ORIGEN");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int costo_idColumnIndex = reader.GetOrdinal("COSTO_ID");
			int costo_montoColumnIndex = reader.GetOrdinal("COSTO_MONTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_nombreColumnIndex = reader.GetOrdinal("COSTO_MONEDA_NOMBRE");
			int costo_moneda_simboloColumnIndex = reader.GetOrdinal("COSTO_MONEDA_SIMBOLO");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int monto_descuentoColumnIndex = reader.GetOrdinal("MONTO_DESCUENTO");
			int porcentaje_dtoColumnIndex = reader.GetOrdinal("PORCENTAJE_DTO");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int impuesto_descripcionColumnIndex = reader.GetOrdinal("IMPUESTO_DESCRIPCION");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int porcentaje_comision_venColumnIndex = reader.GetOrdinal("PORCENTAJE_COMISION_VEN");
			int monto_comision_venColumnIndex = reader.GetOrdinal("MONTO_COMISION_VEN");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_monto_brutoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int total_neto_luego_de_ncColumnIndex = reader.GetOrdinal("TOTAL_NETO_LUEGO_DE_NC");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_codigo_barrasColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO_BARRAS");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int lote_nombreColumnIndex = reader.GetOrdinal("LOTE_NOMBRE");
			int cantidad_devuelta_nota_creditoColumnIndex = reader.GetOrdinal("CANTIDAD_DEVUELTA_NOTA_CREDITO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int vendedor_comisionista_idColumnIndex = reader.GetOrdinal("VENDEDOR_COMISIONISTA_ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");
			int ctacte_recargo_idColumnIndex = reader.GetOrdinal("CTACTE_RECARGO_ID");
			int total_neto_luego_de_nc_auxColumnIndex = reader.GetOrdinal("TOTAL_NETO_LUEGO_DE_NC_AUX");
			int cantidad_anterior_auxColumnIndex = reader.GetOrdinal("CANTIDAD_ANTERIOR_AUX");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int caso_aso_flujo_idColumnIndex = reader.GetOrdinal("CASO_ASO_FLUJO_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int deposito_abreviaturaColumnIndex = reader.GetOrdinal("DEPOSITO_ABREVIATURA");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_CLIENTE_DET_INF_CORow record = new FACTURAS_CLIENTE_DET_INF_CORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FACTURAS_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(facturas_cliente_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					record.ARTICULO_ES_TRAZABLE = Convert.ToString(reader.GetValue(articulo_es_trazableColumnIndex));
					record.FAMILIA_NOMBRE = Convert.ToString(reader.GetValue(familia_nombreColumnIndex));
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					record.GRUPO_NOMBRE = Convert.ToString(reader.GetValue(grupo_nombreColumnIndex));
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					record.SERVICIO = Convert.ToString(reader.GetValue(servicioColumnIndex));
					record.SUBGRUPO_NOMBRE = Convert.ToString(reader.GetValue(subgrupo_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(cotizacion_origenColumnIndex))
						record.COTIZACION_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_moneda_linea_credColumnIndex))
						record.COTIZACION_MONEDA_LINEA_CRED = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_linea_credColumnIndex)), 9);
					record.UNIDAD_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_destino_idColumnIndex));
					record.CANTIDAD_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embaladaColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_destinoColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_destColumnIndex)), 9);
					record.PRECIO_LISTA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_lista_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_origen_idColumnIndex))
						record.UNIDAD_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_origen_idColumnIndex));
					if(!reader.IsDBNull(cantidad_unidad_origenColumnIndex))
						record.CANTIDAD_UNIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_por_caja_origenColumnIndex))
						record.CANTIDAD_POR_CAJA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_total_origColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL_ORIG = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_origColumnIndex)), 9);
					record.PRECIO_LISTA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(precio_lista_origenColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_idColumnIndex))
						record.COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_idColumnIndex)), 9);
					record.COSTO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_idColumnIndex))
						record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_nombreColumnIndex))
						record.COSTO_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(costo_moneda_nombreColumnIndex));
					if(!reader.IsDBNull(costo_moneda_simboloColumnIndex))
						record.COSTO_MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(costo_moneda_simboloColumnIndex));
					if(!reader.IsDBNull(costo_moneda_cotizacionColumnIndex))
						record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					record.MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_descuentoColumnIndex)), 9);
					record.PORCENTAJE_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_dtoColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_descripcionColumnIndex))
						record.IMPUESTO_DESCRIPCION = Convert.ToString(reader.GetValue(impuesto_descripcionColumnIndex));
					if(!reader.IsDBNull(porcentaje_impuestoColumnIndex))
						record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_comision_venColumnIndex))
						record.PORCENTAJE_COMISION_VEN = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_comision_venColumnIndex)), 9);
					if(!reader.IsDBNull(monto_comision_venColumnIndex))
						record.MONTO_COMISION_VEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_comision_venColumnIndex)), 9);
					record.TOTAL_MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuestoColumnIndex)), 9);
					record.TOTAL_MONTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_dtoColumnIndex)), 9);
					record.TOTAL_MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_brutoColumnIndex)), 9);
					record.TOTAL_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_netoColumnIndex)), 9);
					record.TOTAL_NETO_LUEGO_DE_NC = Math.Round(Convert.ToDecimal(reader.GetValue(total_neto_luego_de_ncColumnIndex)), 9);
					record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_codigo_barrasColumnIndex))
						record.ARTICULO_CODIGO_BARRAS = Convert.ToString(reader.GetValue(articulo_codigo_barrasColumnIndex));
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_nombreColumnIndex))
						record.LOTE_NOMBRE = Convert.ToString(reader.GetValue(lote_nombreColumnIndex));
					record.CANTIDAD_DEVUELTA_NOTA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_devuelta_nota_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(vendedor_comisionista_idColumnIndex))
						record.VENDEDOR_COMISIONISTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_comisionista_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));
					if(!reader.IsDBNull(ctacte_recargo_idColumnIndex))
						record.CTACTE_RECARGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recargo_idColumnIndex)), 9);
					record.TOTAL_NETO_LUEGO_DE_NC_AUX = Math.Round(Convert.ToDecimal(reader.GetValue(total_neto_luego_de_nc_auxColumnIndex)), 9);
					record.CANTIDAD_ANTERIOR_AUX = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_anterior_auxColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_aso_flujo_idColumnIndex))
						record.CASO_ASO_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_aso_flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_abreviaturaColumnIndex))
						record.DEPOSITO_ABREVIATURA = Convert.ToString(reader.GetValue(deposito_abreviaturaColumnIndex));
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_CLIENTE_DET_INF_CORow[])(recordList.ToArray(typeof(FACTURAS_CLIENTE_DET_INF_CORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_CLIENTE_DET_INF_CORow"/> object.</returns>
		protected virtual FACTURAS_CLIENTE_DET_INF_CORow MapRow(DataRow row)
		{
			FACTURAS_CLIENTE_DET_INF_CORow mappedObject = new FACTURAS_CLIENTE_DET_INF_CORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FACTURAS_CLIENTE_ID"
			dataColumn = dataTable.Columns["FACTURAS_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAS_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ES_TRAZABLE"
			dataColumn = dataTable.Columns["ARTICULO_ES_TRAZABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ES_TRAZABLE = (string)row[dataColumn];
			// Column "FAMILIA_NOMBRE"
			dataColumn = dataTable.Columns["FAMILIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_NOMBRE = (string)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "SERVICIO"
			dataColumn = dataTable.Columns["SERVICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SERVICIO = (string)row[dataColumn];
			// Column "SUBGRUPO_NOMBRE"
			dataColumn = dataTable.Columns["SUBGRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_ORIGEN = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_LINEA_CRED"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_LINEA_CRED"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_LINEA_CRED = (decimal)row[dataColumn];
			// Column "UNIDAD_DESTINO_ID"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO_ID = (string)row[dataColumn];
			// Column "CANTIDAD_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_DEST"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_DEST = (decimal)row[dataColumn];
			// Column "PRECIO_LISTA_DESTINO"
			dataColumn = dataTable.Columns["PRECIO_LISTA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_LISTA_DESTINO = (decimal)row[dataColumn];
			// Column "UNIDAD_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_ID = (string)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_ORIG"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_ORIG"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_ORIG = (decimal)row[dataColumn];
			// Column "PRECIO_LISTA_ORIGEN"
			dataColumn = dataTable.Columns["PRECIO_LISTA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_LISTA_ORIGEN = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "COSTO_ID"
			dataColumn = dataTable.Columns["COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONTO"
			dataColumn = dataTable.Columns["COSTO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONTO = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["COSTO_MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "COSTO_MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["COSTO_MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "COSTO_MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "MONTO_DESCUENTO"
			dataColumn = dataTable.Columns["MONTO_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESCUENTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DTO"
			dataColumn = dataTable.Columns["PORCENTAJE_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DTO = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_DESCRIPCION"
			dataColumn = dataTable.Columns["IMPUESTO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_DESCRIPCION = (string)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_COMISION_VEN"
			dataColumn = dataTable.Columns["PORCENTAJE_COMISION_VEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_COMISION_VEN = (decimal)row[dataColumn];
			// Column "MONTO_COMISION_VEN"
			dataColumn = dataTable.Columns["MONTO_COMISION_VEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COMISION_VEN = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_DTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_DTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO"
			dataColumn = dataTable.Columns["TOTAL_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO_LUEGO_DE_NC"
			dataColumn = dataTable.Columns["TOTAL_NETO_LUEGO_DE_NC"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO_LUEGO_DE_NC = (decimal)row[dataColumn];
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_CODIGO_BARRAS"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO_BARRAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO_BARRAS = (string)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE_NOMBRE"
			dataColumn = dataTable.Columns["LOTE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_NOMBRE = (string)row[dataColumn];
			// Column "CANTIDAD_DEVUELTA_NOTA_CREDITO"
			dataColumn = dataTable.Columns["CANTIDAD_DEVUELTA_NOTA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEVUELTA_NOTA_CREDITO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "VENDEDOR_COMISIONISTA_ID"
			dataColumn = dataTable.Columns["VENDEDOR_COMISIONISTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_COMISIONISTA_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			// Column "CTACTE_RECARGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECARGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECARGO_ID = (decimal)row[dataColumn];
			// Column "TOTAL_NETO_LUEGO_DE_NC_AUX"
			dataColumn = dataTable.Columns["TOTAL_NETO_LUEGO_DE_NC_AUX"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO_LUEGO_DE_NC_AUX = (decimal)row[dataColumn];
			// Column "CANTIDAD_ANTERIOR_AUX"
			dataColumn = dataTable.Columns["CANTIDAD_ANTERIOR_AUX"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ANTERIOR_AUX = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "CASO_ASO_FLUJO_ID"
			dataColumn = dataTable.Columns["CASO_ASO_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASO_FLUJO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ABREVIATURA"
			dataColumn = dataTable.Columns["DEPOSITO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ABREVIATURA = (string)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_CLIENTE_DET_INF_CO</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_CLIENTE_DET_INF_CO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURAS_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 951;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ES_TRAZABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SERVICIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_LINEA_CRED", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO_LISTA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_ORIG", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO_LISTA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_COMISION_VEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_COMISION_VEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO_LUEGO_DE_NC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO_BARRAS", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEVUELTA_NOTA_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_COMISIONISTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECARGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO_LUEGO_DE_NC_AUX", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ANTERIOR_AUX", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASO_FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
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

				case "FACTURAS_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ES_TRAZABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FAMILIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SERVICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SUBGRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_LINEA_CRED":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_LISTA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_UNIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_ORIG":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_LISTA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_COMISION_VEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COMISION_VEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO_LUEGO_DE_NC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_CODIGO_BARRAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_DEVUELTA_NOTA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENDEDOR_COMISIONISTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_RECARGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO_LUEGO_DE_NC_AUX":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ANTERIOR_AUX":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASO_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_CLIENTE_DET_INF_COCollection_Base class
}  // End of namespace
