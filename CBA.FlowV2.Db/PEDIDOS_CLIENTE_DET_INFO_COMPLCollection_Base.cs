// <fileinfo name="PEDIDOS_CLIENTE_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_CLIENTE_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PEDIDOS_CLIENTE_IDColumnName = "PEDIDOS_CLIENTE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULOColumnName = "ARTICULO";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string CODIGO_EMPRESAColumnName = "CODIGO_EMPRESA";
		public const string ARTICULO_FAMILIA_NOMBREColumnName = "ARTICULO_FAMILIA_NOMBRE";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_GRUPO_NOMBREColumnName = "ARTICULO_GRUPO_NOMBRE";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_SUBGRUPO_NOMBREColumnName = "ARTICULO_SUBGRUPO_NOMBRE";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_ORIGENColumnName = "MONEDA_ORIGEN";
		public const string CANTIDADES_DECIMALESColumnName = "CANTIDADES_DECIMALES";
		public const string SIMBOLOColumnName = "SIMBOLO";
		public const string CADENA_DECIMALESColumnName = "CADENA_DECIMALES";
		public const string COTIZACION_ORIGENColumnName = "COTIZACION_ORIGEN";
		public const string COTIZACION_MONEDA_LINEA_CREDColumnName = "COTIZACION_MONEDA_LINEA_CRED";
		public const string UNIDAD_DESTINO_IDColumnName = "UNIDAD_DESTINO_ID";
		public const string UNIDAD_DESTINOColumnName = "UNIDAD_DESTINO";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string PRECIO_LISTA_DESTINOColumnName = "PRECIO_LISTA_DESTINO";
		public const string UNIDAD_ORIGEN_IDColumnName = "UNIDAD_ORIGEN_ID";
		public const string UNIDAD_ORIGENColumnName = "UNIDAD_ORIGEN";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIG";
		public const string PRECIO_LISTA_ORIGENColumnName = "PRECIO_LISTA_ORIGEN";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string COSTO_IDColumnName = "COSTO_ID";
		public const string COSTO_MONTOColumnName = "COSTO_MONTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_NOMBREColumnName = "COSTO_MONEDA_NOMBRE";
		public const string CANTIDADES_DECIMALES_COSTOColumnName = "CANTIDADES_DECIMALES_COSTO";
		public const string CADENA_DECIMALES_COSTOColumnName = "CADENA_DECIMALES_COSTO";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string MONTO_DESCUENTOColumnName = "MONTO_DESCUENTO";
		public const string PORCENTAJE_DTOColumnName = "PORCENTAJE_DTO";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string IMPUESTOColumnName = "IMPUESTO";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string PORCENTAJE_COMISION_VENColumnName = "PORCENTAJE_COMISION_VEN";
		public const string MONTO_COMISION_VENColumnName = "MONTO_COMISION_VEN";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_MONTO_BRUTOColumnName = "TOTAL_MONTO_BRUTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string LOTEColumnName = "LOTE";
		public const string VENDEDOR_COMISIONISTA_IDColumnName = "VENDEDOR_COMISIONISTA_ID";
		public const string VENDEDOR_COMISIONISTAColumnName = "VENDEDOR_COMISIONISTA";
		public const string CANTIDAD_CAJAS_PEDIDAColumnName = "CANTIDAD_CAJAS_PEDIDA";
		public const string CANTIDAD_UNITARIA_PEDIDAColumnName = "CANTIDAD_UNITARIA_PEDIDA";
		public const string CANTIDAD_TOTAL_PEDIDAColumnName = "CANTIDAD_TOTAL_PEDIDA";
		public const string CANTIDAD_CAJAS_ENTREGADAColumnName = "CANTIDAD_CAJAS_ENTREGADA";
		public const string CANTIDAD_UNITARIA_ENTREGADAColumnName = "CANTIDAD_UNITARIA_ENTREGADA";
		public const string CANTIDAD_TOTAL_ENTREGADAColumnName = "CANTIDAD_TOTAL_ENTREGADA";
		public const string CANTIDAD_SUBITEMS_FINALColumnName = "CANTIDAD_SUBITEMS_FINAL";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string ORDEN_DE_PRESENTACIONColumnName = "ORDEN_DE_PRESENTACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string PRECIO_UNITARIO_APROBADOColumnName = "PRECIO_UNITARIO_APROBADO";
		public const string ARTICULO_MARCA_NOMBREColumnName = "ARTICULO_MARCA_NOMBRE";
		public const string CODIGO_BARRAS_EMPRESAColumnName = "CODIGO_BARRAS_EMPRESA";
		public const string CON_STOCKColumnName = "CON_STOCK";
		public const string PRODUCCION_INTERNAColumnName = "PRODUCCION_INTERNA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PEDIDOS_CLIENTE_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PEDIDOS_CLIENTE_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PEDIDOS_CLIENTE_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PEDIDOS_CLIENTE_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PEDIDOS_CLIENTE_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PEDIDOS_CLIENTE_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects.</returns>
		public PEDIDOS_CLIENTE_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PEDIDOS_CLIENTE_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects.</returns>
		protected PEDIDOS_CLIENTE_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects.</returns>
		protected PEDIDOS_CLIENTE_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual PEDIDOS_CLIENTE_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pedidos_cliente_idColumnIndex = reader.GetOrdinal("PEDIDOS_CLIENTE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articuloColumnIndex = reader.GetOrdinal("ARTICULO");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int codigo_empresaColumnIndex = reader.GetOrdinal("CODIGO_EMPRESA");
			int articulo_familia_nombreColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_NOMBRE");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_grupo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_NOMBRE");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_subgrupo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_NOMBRE");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_origenColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN");
			int cantidades_decimalesColumnIndex = reader.GetOrdinal("CANTIDADES_DECIMALES");
			int simboloColumnIndex = reader.GetOrdinal("SIMBOLO");
			int cadena_decimalesColumnIndex = reader.GetOrdinal("CADENA_DECIMALES");
			int cotizacion_origenColumnIndex = reader.GetOrdinal("COTIZACION_ORIGEN");
			int cotizacion_moneda_linea_credColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_LINEA_CRED");
			int unidad_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_ID");
			int unidad_destinoColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int precio_lista_destinoColumnIndex = reader.GetOrdinal("PRECIO_LISTA_DESTINO");
			int unidad_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_ID");
			int unidad_origenColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int cantidad_unitaria_total_origColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIG");
			int precio_lista_origenColumnIndex = reader.GetOrdinal("PRECIO_LISTA_ORIGEN");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int costo_idColumnIndex = reader.GetOrdinal("COSTO_ID");
			int costo_montoColumnIndex = reader.GetOrdinal("COSTO_MONTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_nombreColumnIndex = reader.GetOrdinal("COSTO_MONEDA_NOMBRE");
			int cantidades_decimales_costoColumnIndex = reader.GetOrdinal("CANTIDADES_DECIMALES_COSTO");
			int cadena_decimales_costoColumnIndex = reader.GetOrdinal("CADENA_DECIMALES_COSTO");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int monto_descuentoColumnIndex = reader.GetOrdinal("MONTO_DESCUENTO");
			int porcentaje_dtoColumnIndex = reader.GetOrdinal("PORCENTAJE_DTO");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int impuestoColumnIndex = reader.GetOrdinal("IMPUESTO");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int porcentaje_comision_venColumnIndex = reader.GetOrdinal("PORCENTAJE_COMISION_VEN");
			int monto_comision_venColumnIndex = reader.GetOrdinal("MONTO_COMISION_VEN");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_monto_brutoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int loteColumnIndex = reader.GetOrdinal("LOTE");
			int vendedor_comisionista_idColumnIndex = reader.GetOrdinal("VENDEDOR_COMISIONISTA_ID");
			int vendedor_comisionistaColumnIndex = reader.GetOrdinal("VENDEDOR_COMISIONISTA");
			int cantidad_cajas_pedidaColumnIndex = reader.GetOrdinal("CANTIDAD_CAJAS_PEDIDA");
			int cantidad_unitaria_pedidaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_PEDIDA");
			int cantidad_total_pedidaColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_PEDIDA");
			int cantidad_cajas_entregadaColumnIndex = reader.GetOrdinal("CANTIDAD_CAJAS_ENTREGADA");
			int cantidad_unitaria_entregadaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_ENTREGADA");
			int cantidad_total_entregadaColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_ENTREGADA");
			int cantidad_subitems_finalColumnIndex = reader.GetOrdinal("CANTIDAD_SUBITEMS_FINAL");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int orden_de_presentacionColumnIndex = reader.GetOrdinal("ORDEN_DE_PRESENTACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int precio_unitario_aprobadoColumnIndex = reader.GetOrdinal("PRECIO_UNITARIO_APROBADO");
			int articulo_marca_nombreColumnIndex = reader.GetOrdinal("ARTICULO_MARCA_NOMBRE");
			int codigo_barras_empresaColumnIndex = reader.GetOrdinal("CODIGO_BARRAS_EMPRESA");
			int con_stockColumnIndex = reader.GetOrdinal("CON_STOCK");
			int produccion_internaColumnIndex = reader.GetOrdinal("PRODUCCION_INTERNA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PEDIDOS_CLIENTE_DET_INFO_COMPLRow record = new PEDIDOS_CLIENTE_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PEDIDOS_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pedidos_cliente_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articuloColumnIndex))
						record.ARTICULO = Convert.ToString(reader.GetValue(articuloColumnIndex));
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_empresaColumnIndex))
						record.CODIGO_EMPRESA = Convert.ToString(reader.GetValue(codigo_empresaColumnIndex));
					if(!reader.IsDBNull(articulo_familia_nombreColumnIndex))
						record.ARTICULO_FAMILIA_NOMBRE = Convert.ToString(reader.GetValue(articulo_familia_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_nombreColumnIndex))
						record.ARTICULO_GRUPO_NOMBRE = Convert.ToString(reader.GetValue(articulo_grupo_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_nombreColumnIndex))
						record.ARTICULO_SUBGRUPO_NOMBRE = Convert.ToString(reader.GetValue(articulo_subgrupo_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONEDA_ORIGEN = Convert.ToString(reader.GetValue(moneda_origenColumnIndex));
					record.CANTIDADES_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidades_decimalesColumnIndex)), 9);
					record.SIMBOLO = Convert.ToString(reader.GetValue(simboloColumnIndex));
					if(!reader.IsDBNull(cadena_decimalesColumnIndex))
						record.CADENA_DECIMALES = Convert.ToString(reader.GetValue(cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(cotizacion_origenColumnIndex))
						record.COTIZACION_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_moneda_linea_credColumnIndex))
						record.COTIZACION_MONEDA_LINEA_CRED = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_linea_credColumnIndex)), 9);
					record.UNIDAD_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_destino_idColumnIndex));
					if(!reader.IsDBNull(unidad_destinoColumnIndex))
						record.UNIDAD_DESTINO = Convert.ToString(reader.GetValue(unidad_destinoColumnIndex));
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.PRECIO_LISTA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_lista_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_origen_idColumnIndex))
						record.UNIDAD_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_origen_idColumnIndex));
					if(!reader.IsDBNull(unidad_origenColumnIndex))
						record.UNIDAD_ORIGEN = Convert.ToString(reader.GetValue(unidad_origenColumnIndex));
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
					if(!reader.IsDBNull(cantidades_decimales_costoColumnIndex))
						record.CANTIDADES_DECIMALES_COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidades_decimales_costoColumnIndex)), 9);
					if(!reader.IsDBNull(cadena_decimales_costoColumnIndex))
						record.CADENA_DECIMALES_COSTO = Convert.ToString(reader.GetValue(cadena_decimales_costoColumnIndex));
					if(!reader.IsDBNull(costo_moneda_cotizacionColumnIndex))
						record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					record.MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_descuentoColumnIndex)), 9);
					record.PORCENTAJE_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_dtoColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					record.IMPUESTO = Convert.ToString(reader.GetValue(impuestoColumnIndex));
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
					record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(loteColumnIndex))
						record.LOTE = Convert.ToString(reader.GetValue(loteColumnIndex));
					if(!reader.IsDBNull(vendedor_comisionista_idColumnIndex))
						record.VENDEDOR_COMISIONISTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_comisionista_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_comisionistaColumnIndex))
						record.VENDEDOR_COMISIONISTA = Convert.ToString(reader.GetValue(vendedor_comisionistaColumnIndex));
					record.CANTIDAD_CAJAS_PEDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cajas_pedidaColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_PEDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_pedidaColumnIndex)), 9);
					record.CANTIDAD_TOTAL_PEDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_pedidaColumnIndex)), 9);
					record.CANTIDAD_CAJAS_ENTREGADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cajas_entregadaColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_ENTREGADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_entregadaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_total_entregadaColumnIndex))
						record.CANTIDAD_TOTAL_ENTREGADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_entregadaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_subitems_finalColumnIndex))
						record.CANTIDAD_SUBITEMS_FINAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_subitems_finalColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.ORDEN_DE_PRESENTACION = Math.Round(Convert.ToDecimal(reader.GetValue(orden_de_presentacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(precio_unitario_aprobadoColumnIndex))
						record.PRECIO_UNITARIO_APROBADO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_unitario_aprobadoColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_marca_nombreColumnIndex))
						record.ARTICULO_MARCA_NOMBRE = Convert.ToString(reader.GetValue(articulo_marca_nombreColumnIndex));
					if(!reader.IsDBNull(codigo_barras_empresaColumnIndex))
						record.CODIGO_BARRAS_EMPRESA = Convert.ToString(reader.GetValue(codigo_barras_empresaColumnIndex));
					if(!reader.IsDBNull(con_stockColumnIndex))
						record.CON_STOCK = Convert.ToString(reader.GetValue(con_stockColumnIndex));
					record.PRODUCCION_INTERNA = Convert.ToString(reader.GetValue(produccion_internaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PEDIDOS_CLIENTE_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(PEDIDOS_CLIENTE_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PEDIDOS_CLIENTE_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual PEDIDOS_CLIENTE_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			PEDIDOS_CLIENTE_DET_INFO_COMPLRow mappedObject = new PEDIDOS_CLIENTE_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PEDIDOS_CLIENTE_ID"
			dataColumn = dataTable.Columns["PEDIDOS_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PEDIDOS_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO"
			dataColumn = dataTable.Columns["ARTICULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO = (string)row[dataColumn];
			// Column "ARTICULO_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "CODIGO_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EMPRESA = (string)row[dataColumn];
			// Column "ARTICULO_FAMILIA_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN = (string)row[dataColumn];
			// Column "CANTIDADES_DECIMALES"
			dataColumn = dataTable.Columns["CANTIDADES_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDADES_DECIMALES = (decimal)row[dataColumn];
			// Column "SIMBOLO"
			dataColumn = dataTable.Columns["SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SIMBOLO = (string)row[dataColumn];
			// Column "CADENA_DECIMALES"
			dataColumn = dataTable.Columns["CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CADENA_DECIMALES = (string)row[dataColumn];
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
			// Column "UNIDAD_DESTINO"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO = (string)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_DESTINO = (decimal)row[dataColumn];
			// Column "PRECIO_LISTA_DESTINO"
			dataColumn = dataTable.Columns["PRECIO_LISTA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_LISTA_DESTINO = (decimal)row[dataColumn];
			// Column "UNIDAD_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_ID = (string)row[dataColumn];
			// Column "UNIDAD_ORIGEN"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN = (string)row[dataColumn];
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
			// Column "CANTIDADES_DECIMALES_COSTO"
			dataColumn = dataTable.Columns["CANTIDADES_DECIMALES_COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDADES_DECIMALES_COSTO = (decimal)row[dataColumn];
			// Column "CADENA_DECIMALES_COSTO"
			dataColumn = dataTable.Columns["CADENA_DECIMALES_COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CADENA_DECIMALES_COSTO = (string)row[dataColumn];
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
			// Column "IMPUESTO"
			dataColumn = dataTable.Columns["IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO = (string)row[dataColumn];
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
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE"
			dataColumn = dataTable.Columns["LOTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE = (string)row[dataColumn];
			// Column "VENDEDOR_COMISIONISTA_ID"
			dataColumn = dataTable.Columns["VENDEDOR_COMISIONISTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_COMISIONISTA_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR_COMISIONISTA"
			dataColumn = dataTable.Columns["VENDEDOR_COMISIONISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_COMISIONISTA = (string)row[dataColumn];
			// Column "CANTIDAD_CAJAS_PEDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_CAJAS_PEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CAJAS_PEDIDA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_PEDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_PEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_PEDIDA = (decimal)row[dataColumn];
			// Column "CANTIDAD_TOTAL_PEDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_PEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_PEDIDA = (decimal)row[dataColumn];
			// Column "CANTIDAD_CAJAS_ENTREGADA"
			dataColumn = dataTable.Columns["CANTIDAD_CAJAS_ENTREGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CAJAS_ENTREGADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_ENTREGADA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_ENTREGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_ENTREGADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_TOTAL_ENTREGADA"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_ENTREGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_ENTREGADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_SUBITEMS_FINAL"
			dataColumn = dataTable.Columns["CANTIDAD_SUBITEMS_FINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_SUBITEMS_FINAL = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_DE_PRESENTACION"
			dataColumn = dataTable.Columns["ORDEN_DE_PRESENTACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_DE_PRESENTACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "PRECIO_UNITARIO_APROBADO"
			dataColumn = dataTable.Columns["PRECIO_UNITARIO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_UNITARIO_APROBADO = (decimal)row[dataColumn];
			// Column "ARTICULO_MARCA_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_MARCA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MARCA_NOMBRE = (string)row[dataColumn];
			// Column "CODIGO_BARRAS_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_BARRAS_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BARRAS_EMPRESA = (string)row[dataColumn];
			// Column "CON_STOCK"
			dataColumn = dataTable.Columns["CON_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.CON_STOCK = (string)row[dataColumn];
			// Column "PRODUCCION_INTERNA"
			dataColumn = dataTable.Columns["PRODUCCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRODUCCION_INTERNA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PEDIDOS_CLIENTE_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PEDIDOS_CLIENTE_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PEDIDOS_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDADES_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_LINEA_CRED", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO_LISTA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN", typeof(string));
			dataColumn.MaxLength = 100;
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
			dataColumn = dataTable.Columns.Add("CANTIDADES_DECIMALES_COSTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CADENA_DECIMALES_COSTO", typeof(string));
			dataColumn.MaxLength = 15;
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
			dataColumn = dataTable.Columns.Add("IMPUESTO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
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
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_COMISIONISTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_COMISIONISTA", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CAJAS_PEDIDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_PEDIDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_PEDIDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CAJAS_ENTREGADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_ENTREGADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_ENTREGADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_SUBITEMS_FINAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 106;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_DE_PRESENTACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO_UNITARIO_APROBADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_MARCA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_BARRAS_EMPRESA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CON_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRODUCCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "PEDIDOS_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_FAMILIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_SUBGRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDADES_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CADENA_DECIMALES":
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

				case "UNIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_POR_CAJA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_LISTA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_ORIGEN":
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

				case "CANTIDADES_DECIMALES_COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CADENA_DECIMALES_COSTO":
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

				case "IMPUESTO":
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

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENDEDOR_COMISIONISTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_COMISIONISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CAJAS_PEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_PEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_TOTAL_PEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_CAJAS_ENTREGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_ENTREGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_TOTAL_ENTREGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_SUBITEMS_FINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_DE_PRESENTACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECIO_UNITARIO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_MARCA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_BARRAS_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CON_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRODUCCION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PEDIDOS_CLIENTE_DET_INFO_COMPLCollection_Base class
}  // End of namespace
