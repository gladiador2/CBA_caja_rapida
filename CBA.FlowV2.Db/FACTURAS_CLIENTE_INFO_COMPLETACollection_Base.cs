// <fileinfo name="FACTURAS_CLIENTE_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_CLIENTE_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string CASO_ESTADOColumnName = "CASO_ESTADO";
		public const string CASO_ORIGEN_IDColumnName = "CASO_ORIGEN_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_VENTA_IDColumnName = "SUCURSAL_VENTA_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string SUCURSAL_VENTA_NOMBREColumnName = "SUCURSAL_VENTA_NOMBRE";
		public const string SUCURSAL_VENTA_ABREVIATURAColumnName = "SUCURSAL_VENTA_ABREVIATURA";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITO_NOMBREColumnName = "DEPOSITO_NOMBRE";
		public const string DEPOSITO_ABREVIATURAColumnName = "DEPOSITO_ABREVIATURA";
		public const string FECHAColumnName = "FECHA";
		public const string VENDEDOR_CODIGOColumnName = "VENDEDOR_CODIGO";
		public const string VENDEDOR_IDColumnName = "VENDEDOR_ID";
		public const string VENDEDOR_NOMBREColumnName = "VENDEDOR_NOMBRE";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONA_RUCColumnName = "PERSONA_RUC";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string PERSONA_PAIS_RESIDENCIA_NOMBREColumnName = "PERSONA_PAIS_RESIDENCIA_NOMBRE";
		public const string PERSONA_GARANTE_1_IDColumnName = "PERSONA_GARANTE_1_ID";
		public const string PERSONA_GARANTE_2_IDColumnName = "PERSONA_GARANTE_2_ID";
		public const string PERSONA_GARANTE_3_IDColumnName = "PERSONA_GARANTE_3_ID";
		public const string TIPO_FACTURA_IDColumnName = "TIPO_FACTURA_ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string AUTONUMERACION_TIMBRADOColumnName = "AUTONUMERACION_TIMBRADO";
		public const string AUTONUMERACIONES_CODIGOColumnName = "AUTONUMERACIONES_CODIGO";
		public const string VIGENCIADESDEColumnName = "VIGENCIADESDE";
		public const string VIGENCIAHASTAColumnName = "VIGENCIAHASTA";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string PORCENTAJE_DESC_SOBRE_TOTALColumnName = "PORCENTAJE_DESC_SOBRE_TOTAL";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CANTIDAD_DECIMALESColumnName = "MONEDA_CANTIDAD_DECIMALES";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string COTIZACION_DESTINOColumnName = "COTIZACION_DESTINO";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_MONTO_BRUTOColumnName = "TOTAL_MONTO_BRUTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string TOTAL_COSTO_BRUTOColumnName = "TOTAL_COSTO_BRUTO";
		public const string TOTAL_COSTO_NETOColumnName = "TOTAL_COSTO_NETO";
		public const string TOTAL_COMISION_VENDEDORColumnName = "TOTAL_COMISION_VENDEDOR";
		public const string TOTAL_ENTREGA_INICIALColumnName = "TOTAL_ENTREGA_INICIAL";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string USUARIO_ID_AUTORIZA_DESCUENTOColumnName = "USUARIO_ID_AUTORIZA_DESCUENTO";
		public const string USUARIO_AUTORIZA_DTO_NOMBREColumnName = "USUARIO_AUTORIZA_DTO_NOMBRE";
		public const string FECHA_AUTORIZACION_DESCUENTOColumnName = "FECHA_AUTORIZACION_DESCUENTO";
		public const string DESCUENTO_MAX_AUTORIZADOColumnName = "DESCUENTO_MAX_AUTORIZADO";
		public const string AFECTA_LINEA_CREDITOColumnName = "AFECTA_LINEA_CREDITO";
		public const string AFECTA_CTACTEColumnName = "AFECTA_CTACTE";
		public const string AFECTA_STOCKColumnName = "AFECTA_STOCK";
		public const string GENERAR_TRANSFERENCIAColumnName = "GENERAR_TRANSFERENCIA";
		public const string DEPOSITO_DESTINO_IDColumnName = "DEPOSITO_DESTINO_ID";
		public const string SUCURSAL_DESTINO_NOMBREColumnName = "SUCURSAL_DESTINO_NOMBRE";
		public const string DEPOSITO_DESTINO_NOMBREColumnName = "DEPOSITO_DESTINO_NOMBRE";
		public const string MONTO_AFECTA_LINEA_CREDITOColumnName = "MONTO_AFECTA_LINEA_CREDITO";
		public const string COMISION_POR_VENTAColumnName = "COMISION_POR_VENTA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CONTROLAR_CANT_MIN_DESC_MAXColumnName = "CONTROLAR_CANT_MIN_DESC_MAX";
		public const string CONDICION_DESCRIPCIONColumnName = "CONDICION_DESCRIPCION";
		public const string PERSONA_DEPARTAMENTO1_NOMBREColumnName = "PERSONA_DEPARTAMENTO1_NOMBRE";
		public const string PERSONA_CIUDAD1_NOMBREColumnName = "PERSONA_CIUDAD1_NOMBRE";
		public const string PERSONA_BARRIO1_NOMBREColumnName = "PERSONA_BARRIO1_NOMBRE";
		public const string PERSONA_CALLE1ColumnName = "PERSONA_CALLE1";
		public const string PERSONA_DEPARTAMENTO2_NOMBREColumnName = "PERSONA_DEPARTAMENTO2_NOMBRE";
		public const string PERSONA_CIUDAD2_NOMBREColumnName = "PERSONA_CIUDAD2_NOMBRE";
		public const string PERSONA_BARRIO2_NOMBREColumnName = "PERSONA_BARRIO2_NOMBRE";
		public const string PERSONA_CALLE2ColumnName = "PERSONA_CALLE2";
		public const string PERSONA_DEPTO_COBRANZA_NOMBREColumnName = "PERSONA_DEPTO_COBRANZA_NOMBRE";
		public const string PERSONA_CIUDAD_COBRANZA_NOMBREColumnName = "PERSONA_CIUDAD_COBRANZA_NOMBRE";
		public const string PERSONA_BARRIO_COBRANZA_NOMBREColumnName = "PERSONA_BARRIO_COBRANZA_NOMBRE";
		public const string PERSONA_CALLE_COBRANZAColumnName = "PERSONA_CALLE_COBRANZA";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string CONDICION_PAGO_NOMBREColumnName = "CONDICION_PAGO_NOMBRE";
		public const string A_CONSIGNACIONColumnName = "A_CONSIGNACION";
		public const string CASO_REPARTO_VINCULA_FCColumnName = "CASO_REPARTO_VINCULA_FC";
		public const string DIRECCIONColumnName = "DIRECCION";
		public const string LATITUDColumnName = "LATITUD";
		public const string LONGITUDColumnName = "LONGITUD";
		public const string OBSERVACION_ENTREGAColumnName = "OBSERVACION_ENTREGA";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string MORA_PORCENTAJEColumnName = "MORA_PORCENTAJE";
		public const string MORA_DIAS_GRACIAColumnName = "MORA_DIAS_GRACIA";
		public const string NRO_DOCUMENTO_EXTERNOColumnName = "NRO_DOCUMENTO_EXTERNO";
		public const string NRO_COMPROBANTE_SECUENCIAColumnName = "NRO_COMPROBANTE_SECUENCIA";
		public const string TIPO_CONDICION_PAGOColumnName = "TIPO_CONDICION_PAGO";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string TIPO_CLIENTE_IDColumnName = "TIPO_CLIENTE_ID";
		public const string TIPO_CLIENTES_NOMBREColumnName = "TIPO_CLIENTES_NOMBRE";
		public const string AUTONUMERACION_TRANSF_IDColumnName = "AUTONUMERACION_TRANSF_ID";
		public const string NRO_TIMBRADO_FACT_PROColumnName = "NRO_TIMBRADO_FACT_PRO";
		public const string FECHA_VENC_TIMBRADO_FACT_PROColumnName = "FECHA_VENC_TIMBRADO_FACT_PRO";
		public const string NRO_COMPROBANTE_FACT_PROColumnName = "NRO_COMPROBANTE_FACT_PRO";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string ES_RAPIDAColumnName = "ES_RAPIDA";
		public const string TOTAL_LETRASColumnName = "TOTAL_LETRAS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_CLIENTE_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURAS_CLIENTE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_CLIENTE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_CLIENTE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_CLIENTE_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_CLIENTE_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects.</returns>
		public FACTURAS_CLIENTE_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_CLIENTE_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects.</returns>
		protected FACTURAS_CLIENTE_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects.</returns>
		protected FACTURAS_CLIENTE_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> objects.</returns>
		protected virtual FACTURAS_CLIENTE_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int caso_estadoColumnIndex = reader.GetOrdinal("CASO_ESTADO");
			int caso_origen_idColumnIndex = reader.GetOrdinal("CASO_ORIGEN_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_venta_idColumnIndex = reader.GetOrdinal("SUCURSAL_VENTA_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int sucursal_venta_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_VENTA_NOMBRE");
			int sucursal_venta_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_VENTA_ABREVIATURA");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int deposito_nombreColumnIndex = reader.GetOrdinal("DEPOSITO_NOMBRE");
			int deposito_abreviaturaColumnIndex = reader.GetOrdinal("DEPOSITO_ABREVIATURA");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int vendedor_codigoColumnIndex = reader.GetOrdinal("VENDEDOR_CODIGO");
			int vendedor_idColumnIndex = reader.GetOrdinal("VENDEDOR_ID");
			int vendedor_nombreColumnIndex = reader.GetOrdinal("VENDEDOR_NOMBRE");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int persona_rucColumnIndex = reader.GetOrdinal("PERSONA_RUC");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int persona_pais_residencia_nombreColumnIndex = reader.GetOrdinal("PERSONA_PAIS_RESIDENCIA_NOMBRE");
			int persona_garante_1_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_1_ID");
			int persona_garante_2_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_2_ID");
			int persona_garante_3_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_3_ID");
			int tipo_factura_idColumnIndex = reader.GetOrdinal("TIPO_FACTURA_ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int autonumeracion_timbradoColumnIndex = reader.GetOrdinal("AUTONUMERACION_TIMBRADO");
			int autonumeraciones_codigoColumnIndex = reader.GetOrdinal("AUTONUMERACIONES_CODIGO");
			int vigenciadesdeColumnIndex = reader.GetOrdinal("VIGENCIADESDE");
			int vigenciahastaColumnIndex = reader.GetOrdinal("VIGENCIAHASTA");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int porcentaje_desc_sobre_totalColumnIndex = reader.GetOrdinal("PORCENTAJE_DESC_SOBRE_TOTAL");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cantidad_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDAD_DECIMALES");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int cotizacion_destinoColumnIndex = reader.GetOrdinal("COTIZACION_DESTINO");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_monto_brutoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int total_costo_brutoColumnIndex = reader.GetOrdinal("TOTAL_COSTO_BRUTO");
			int total_costo_netoColumnIndex = reader.GetOrdinal("TOTAL_COSTO_NETO");
			int total_comision_vendedorColumnIndex = reader.GetOrdinal("TOTAL_COMISION_VENDEDOR");
			int total_entrega_inicialColumnIndex = reader.GetOrdinal("TOTAL_ENTREGA_INICIAL");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int usuario_id_autoriza_descuentoColumnIndex = reader.GetOrdinal("USUARIO_ID_AUTORIZA_DESCUENTO");
			int usuario_autoriza_dto_nombreColumnIndex = reader.GetOrdinal("USUARIO_AUTORIZA_DTO_NOMBRE");
			int fecha_autorizacion_descuentoColumnIndex = reader.GetOrdinal("FECHA_AUTORIZACION_DESCUENTO");
			int descuento_max_autorizadoColumnIndex = reader.GetOrdinal("DESCUENTO_MAX_AUTORIZADO");
			int afecta_linea_creditoColumnIndex = reader.GetOrdinal("AFECTA_LINEA_CREDITO");
			int afecta_ctacteColumnIndex = reader.GetOrdinal("AFECTA_CTACTE");
			int afecta_stockColumnIndex = reader.GetOrdinal("AFECTA_STOCK");
			int generar_transferenciaColumnIndex = reader.GetOrdinal("GENERAR_TRANSFERENCIA");
			int deposito_destino_idColumnIndex = reader.GetOrdinal("DEPOSITO_DESTINO_ID");
			int sucursal_destino_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_NOMBRE");
			int deposito_destino_nombreColumnIndex = reader.GetOrdinal("DEPOSITO_DESTINO_NOMBRE");
			int monto_afecta_linea_creditoColumnIndex = reader.GetOrdinal("MONTO_AFECTA_LINEA_CREDITO");
			int comision_por_ventaColumnIndex = reader.GetOrdinal("COMISION_POR_VENTA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int controlar_cant_min_desc_maxColumnIndex = reader.GetOrdinal("CONTROLAR_CANT_MIN_DESC_MAX");
			int condicion_descripcionColumnIndex = reader.GetOrdinal("CONDICION_DESCRIPCION");
			int persona_departamento1_nombreColumnIndex = reader.GetOrdinal("PERSONA_DEPARTAMENTO1_NOMBRE");
			int persona_ciudad1_nombreColumnIndex = reader.GetOrdinal("PERSONA_CIUDAD1_NOMBRE");
			int persona_barrio1_nombreColumnIndex = reader.GetOrdinal("PERSONA_BARRIO1_NOMBRE");
			int persona_calle1ColumnIndex = reader.GetOrdinal("PERSONA_CALLE1");
			int persona_departamento2_nombreColumnIndex = reader.GetOrdinal("PERSONA_DEPARTAMENTO2_NOMBRE");
			int persona_ciudad2_nombreColumnIndex = reader.GetOrdinal("PERSONA_CIUDAD2_NOMBRE");
			int persona_barrio2_nombreColumnIndex = reader.GetOrdinal("PERSONA_BARRIO2_NOMBRE");
			int persona_calle2ColumnIndex = reader.GetOrdinal("PERSONA_CALLE2");
			int persona_depto_cobranza_nombreColumnIndex = reader.GetOrdinal("PERSONA_DEPTO_COBRANZA_NOMBRE");
			int persona_ciudad_cobranza_nombreColumnIndex = reader.GetOrdinal("PERSONA_CIUDAD_COBRANZA_NOMBRE");
			int persona_barrio_cobranza_nombreColumnIndex = reader.GetOrdinal("PERSONA_BARRIO_COBRANZA_NOMBRE");
			int persona_calle_cobranzaColumnIndex = reader.GetOrdinal("PERSONA_CALLE_COBRANZA");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int condicion_pago_nombreColumnIndex = reader.GetOrdinal("CONDICION_PAGO_NOMBRE");
			int a_consignacionColumnIndex = reader.GetOrdinal("A_CONSIGNACION");
			int caso_reparto_vincula_fcColumnIndex = reader.GetOrdinal("CASO_REPARTO_VINCULA_FC");
			int direccionColumnIndex = reader.GetOrdinal("DIRECCION");
			int latitudColumnIndex = reader.GetOrdinal("LATITUD");
			int longitudColumnIndex = reader.GetOrdinal("LONGITUD");
			int observacion_entregaColumnIndex = reader.GetOrdinal("OBSERVACION_ENTREGA");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int mora_porcentajeColumnIndex = reader.GetOrdinal("MORA_PORCENTAJE");
			int mora_dias_graciaColumnIndex = reader.GetOrdinal("MORA_DIAS_GRACIA");
			int nro_documento_externoColumnIndex = reader.GetOrdinal("NRO_DOCUMENTO_EXTERNO");
			int nro_comprobante_secuenciaColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_SECUENCIA");
			int tipo_condicion_pagoColumnIndex = reader.GetOrdinal("TIPO_CONDICION_PAGO");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tipo_cliente_idColumnIndex = reader.GetOrdinal("TIPO_CLIENTE_ID");
			int tipo_clientes_nombreColumnIndex = reader.GetOrdinal("TIPO_CLIENTES_NOMBRE");
			int autonumeracion_transf_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_TRANSF_ID");
			int nro_timbrado_fact_proColumnIndex = reader.GetOrdinal("NRO_TIMBRADO_FACT_PRO");
			int fecha_venc_timbrado_fact_proColumnIndex = reader.GetOrdinal("FECHA_VENC_TIMBRADO_FACT_PRO");
			int nro_comprobante_fact_proColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_FACT_PRO");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int es_rapidaColumnIndex = reader.GetOrdinal("ES_RAPIDA");
			int total_letrasColumnIndex = reader.GetOrdinal("TOTAL_LETRAS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_CLIENTE_INFO_COMPLETARow record = new FACTURAS_CLIENTE_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.CASO_ESTADO = Convert.ToString(reader.GetValue(caso_estadoColumnIndex));
					if(!reader.IsDBNull(caso_origen_idColumnIndex))
						record.CASO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_venta_idColumnIndex))
						record.SUCURSAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_venta_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_venta_nombreColumnIndex))
						record.SUCURSAL_VENTA_NOMBRE = Convert.ToString(reader.GetValue(sucursal_venta_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_venta_abreviaturaColumnIndex))
						record.SUCURSAL_VENTA_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_venta_abreviaturaColumnIndex));
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(deposito_nombreColumnIndex));
					record.DEPOSITO_ABREVIATURA = Convert.ToString(reader.GetValue(deposito_abreviaturaColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(vendedor_codigoColumnIndex))
						record.VENDEDOR_CODIGO = Convert.ToString(reader.GetValue(vendedor_codigoColumnIndex));
					if(!reader.IsDBNull(vendedor_idColumnIndex))
						record.VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_nombreColumnIndex))
						record.VENDEDOR_NOMBRE = Convert.ToString(reader.GetValue(vendedor_nombreColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(persona_rucColumnIndex))
						record.PERSONA_RUC = Convert.ToString(reader.GetValue(persona_rucColumnIndex));
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					if(!reader.IsDBNull(persona_pais_residencia_nombreColumnIndex))
						record.PERSONA_PAIS_RESIDENCIA_NOMBRE = Convert.ToString(reader.GetValue(persona_pais_residencia_nombreColumnIndex));
					if(!reader.IsDBNull(persona_garante_1_idColumnIndex))
						record.PERSONA_GARANTE_1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_1_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_2_idColumnIndex))
						record.PERSONA_GARANTE_2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_2_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_3_idColumnIndex))
						record.PERSONA_GARANTE_3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_3_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_factura_idColumnIndex))
						record.TIPO_FACTURA_ID = Convert.ToString(reader.GetValue(tipo_factura_idColumnIndex));
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_timbradoColumnIndex))
						record.AUTONUMERACION_TIMBRADO = Convert.ToString(reader.GetValue(autonumeracion_timbradoColumnIndex));
					if(!reader.IsDBNull(autonumeraciones_codigoColumnIndex))
						record.AUTONUMERACIONES_CODIGO = Convert.ToString(reader.GetValue(autonumeraciones_codigoColumnIndex));
					if(!reader.IsDBNull(vigenciadesdeColumnIndex))
						record.VIGENCIADESDE = Convert.ToDateTime(reader.GetValue(vigenciadesdeColumnIndex));
					if(!reader.IsDBNull(vigenciahastaColumnIndex))
						record.VIGENCIAHASTA = Convert.ToDateTime(reader.GetValue(vigenciahastaColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(porcentaje_desc_sobre_totalColumnIndex))
						record.PORCENTAJE_DESC_SOBRE_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_desc_sobre_totalColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_destino_idColumnIndex))
						record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.MONEDA_CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidad_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(cotizacion_destinoColumnIndex))
						record.COTIZACION_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_impuestoColumnIndex))
						record.TOTAL_MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_dtoColumnIndex))
						record.TOTAL_MONTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_dtoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_brutoColumnIndex))
						record.TOTAL_MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_netoColumnIndex))
						record.TOTAL_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costo_brutoColumnIndex))
						record.TOTAL_COSTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costo_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costo_netoColumnIndex))
						record.TOTAL_COSTO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costo_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_comision_vendedorColumnIndex))
						record.TOTAL_COMISION_VENDEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(total_comision_vendedorColumnIndex)), 9);
					record.TOTAL_ENTREGA_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(total_entrega_inicialColumnIndex)), 9);
					record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_id_autoriza_descuentoColumnIndex))
						record.USUARIO_ID_AUTORIZA_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_id_autoriza_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_autoriza_dto_nombreColumnIndex))
						record.USUARIO_AUTORIZA_DTO_NOMBRE = Convert.ToString(reader.GetValue(usuario_autoriza_dto_nombreColumnIndex));
					if(!reader.IsDBNull(fecha_autorizacion_descuentoColumnIndex))
						record.FECHA_AUTORIZACION_DESCUENTO = Convert.ToDateTime(reader.GetValue(fecha_autorizacion_descuentoColumnIndex));
					if(!reader.IsDBNull(descuento_max_autorizadoColumnIndex))
						record.DESCUENTO_MAX_AUTORIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_max_autorizadoColumnIndex)), 9);
					if(!reader.IsDBNull(afecta_linea_creditoColumnIndex))
						record.AFECTA_LINEA_CREDITO = Convert.ToString(reader.GetValue(afecta_linea_creditoColumnIndex));
					record.AFECTA_CTACTE = Convert.ToString(reader.GetValue(afecta_ctacteColumnIndex));
					record.AFECTA_STOCK = Convert.ToString(reader.GetValue(afecta_stockColumnIndex));
					record.GENERAR_TRANSFERENCIA = Convert.ToString(reader.GetValue(generar_transferenciaColumnIndex));
					if(!reader.IsDBNull(deposito_destino_idColumnIndex))
						record.DEPOSITO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_nombreColumnIndex))
						record.SUCURSAL_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(sucursal_destino_nombreColumnIndex));
					if(!reader.IsDBNull(deposito_destino_nombreColumnIndex))
						record.DEPOSITO_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(deposito_destino_nombreColumnIndex));
					if(!reader.IsDBNull(monto_afecta_linea_creditoColumnIndex))
						record.MONTO_AFECTA_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_afecta_linea_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(comision_por_ventaColumnIndex))
						record.COMISION_POR_VENTA = Convert.ToString(reader.GetValue(comision_por_ventaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.CONTROLAR_CANT_MIN_DESC_MAX = Convert.ToString(reader.GetValue(controlar_cant_min_desc_maxColumnIndex));
					if(!reader.IsDBNull(condicion_descripcionColumnIndex))
						record.CONDICION_DESCRIPCION = Convert.ToString(reader.GetValue(condicion_descripcionColumnIndex));
					if(!reader.IsDBNull(persona_departamento1_nombreColumnIndex))
						record.PERSONA_DEPARTAMENTO1_NOMBRE = Convert.ToString(reader.GetValue(persona_departamento1_nombreColumnIndex));
					if(!reader.IsDBNull(persona_ciudad1_nombreColumnIndex))
						record.PERSONA_CIUDAD1_NOMBRE = Convert.ToString(reader.GetValue(persona_ciudad1_nombreColumnIndex));
					if(!reader.IsDBNull(persona_barrio1_nombreColumnIndex))
						record.PERSONA_BARRIO1_NOMBRE = Convert.ToString(reader.GetValue(persona_barrio1_nombreColumnIndex));
					if(!reader.IsDBNull(persona_calle1ColumnIndex))
						record.PERSONA_CALLE1 = Convert.ToString(reader.GetValue(persona_calle1ColumnIndex));
					if(!reader.IsDBNull(persona_departamento2_nombreColumnIndex))
						record.PERSONA_DEPARTAMENTO2_NOMBRE = Convert.ToString(reader.GetValue(persona_departamento2_nombreColumnIndex));
					if(!reader.IsDBNull(persona_ciudad2_nombreColumnIndex))
						record.PERSONA_CIUDAD2_NOMBRE = Convert.ToString(reader.GetValue(persona_ciudad2_nombreColumnIndex));
					if(!reader.IsDBNull(persona_barrio2_nombreColumnIndex))
						record.PERSONA_BARRIO2_NOMBRE = Convert.ToString(reader.GetValue(persona_barrio2_nombreColumnIndex));
					if(!reader.IsDBNull(persona_calle2ColumnIndex))
						record.PERSONA_CALLE2 = Convert.ToString(reader.GetValue(persona_calle2ColumnIndex));
					if(!reader.IsDBNull(persona_depto_cobranza_nombreColumnIndex))
						record.PERSONA_DEPTO_COBRANZA_NOMBRE = Convert.ToString(reader.GetValue(persona_depto_cobranza_nombreColumnIndex));
					if(!reader.IsDBNull(persona_ciudad_cobranza_nombreColumnIndex))
						record.PERSONA_CIUDAD_COBRANZA_NOMBRE = Convert.ToString(reader.GetValue(persona_ciudad_cobranza_nombreColumnIndex));
					if(!reader.IsDBNull(persona_barrio_cobranza_nombreColumnIndex))
						record.PERSONA_BARRIO_COBRANZA_NOMBRE = Convert.ToString(reader.GetValue(persona_barrio_cobranza_nombreColumnIndex));
					if(!reader.IsDBNull(persona_calle_cobranzaColumnIndex))
						record.PERSONA_CALLE_COBRANZA = Convert.ToString(reader.GetValue(persona_calle_cobranzaColumnIndex));
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_pago_nombreColumnIndex))
						record.CONDICION_PAGO_NOMBRE = Convert.ToString(reader.GetValue(condicion_pago_nombreColumnIndex));
					record.A_CONSIGNACION = Convert.ToString(reader.GetValue(a_consignacionColumnIndex));
					if(!reader.IsDBNull(caso_reparto_vincula_fcColumnIndex))
						record.CASO_REPARTO_VINCULA_FC = Math.Round(Convert.ToDecimal(reader.GetValue(caso_reparto_vincula_fcColumnIndex)), 9);
					if(!reader.IsDBNull(direccionColumnIndex))
						record.DIRECCION = Convert.ToString(reader.GetValue(direccionColumnIndex));
					if(!reader.IsDBNull(latitudColumnIndex))
						record.LATITUD = Math.Round(Convert.ToDecimal(reader.GetValue(latitudColumnIndex)), 9);
					if(!reader.IsDBNull(longitudColumnIndex))
						record.LONGITUD = Math.Round(Convert.ToDecimal(reader.GetValue(longitudColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_entregaColumnIndex))
						record.OBSERVACION_ENTREGA = Convert.ToString(reader.GetValue(observacion_entregaColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					record.MORA_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(mora_porcentajeColumnIndex)), 9);
					record.MORA_DIAS_GRACIA = Math.Round(Convert.ToDecimal(reader.GetValue(mora_dias_graciaColumnIndex)), 9);
					if(!reader.IsDBNull(nro_documento_externoColumnIndex))
						record.NRO_DOCUMENTO_EXTERNO = Convert.ToString(reader.GetValue(nro_documento_externoColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_secuenciaColumnIndex))
						record.NRO_COMPROBANTE_SECUENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(nro_comprobante_secuenciaColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_condicion_pagoColumnIndex))
						record.TIPO_CONDICION_PAGO = Convert.ToString(reader.GetValue(tipo_condicion_pagoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(tipo_cliente_idColumnIndex))
						record.TIPO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_clientes_nombreColumnIndex))
						record.TIPO_CLIENTES_NOMBRE = Convert.ToString(reader.GetValue(tipo_clientes_nombreColumnIndex));
					if(!reader.IsDBNull(autonumeracion_transf_idColumnIndex))
						record.AUTONUMERACION_TRANSF_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_transf_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_timbrado_fact_proColumnIndex))
						record.NRO_TIMBRADO_FACT_PRO = Convert.ToString(reader.GetValue(nro_timbrado_fact_proColumnIndex));
					if(!reader.IsDBNull(fecha_venc_timbrado_fact_proColumnIndex))
						record.FECHA_VENC_TIMBRADO_FACT_PRO = Convert.ToDateTime(reader.GetValue(fecha_venc_timbrado_fact_proColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_fact_proColumnIndex))
						record.NRO_COMPROBANTE_FACT_PRO = Convert.ToString(reader.GetValue(nro_comprobante_fact_proColumnIndex));
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					if(!reader.IsDBNull(es_rapidaColumnIndex))
						record.ES_RAPIDA = Convert.ToString(reader.GetValue(es_rapidaColumnIndex));
					if(!reader.IsDBNull(total_letrasColumnIndex))
						record.TOTAL_LETRAS = Convert.ToString(reader.GetValue(total_letrasColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_CLIENTE_INFO_COMPLETARow[])(recordList.ToArray(typeof(FACTURAS_CLIENTE_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_CLIENTE_INFO_COMPLETARow"/> object.</returns>
		protected virtual FACTURAS_CLIENTE_INFO_COMPLETARow MapRow(DataRow row)
		{
			FACTURAS_CLIENTE_INFO_COMPLETARow mappedObject = new FACTURAS_CLIENTE_INFO_COMPLETARow();
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
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "CASO_ESTADO"
			dataColumn = dataTable.Columns["CASO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO = (string)row[dataColumn];
			// Column "CASO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CASO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_VENTA_ID"
			dataColumn = dataTable.Columns["SUCURSAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_VENTA_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_VENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_VENTA_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_VENTA_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_VENTA_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_VENTA_ABREVIATURA = (string)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_NOMBRE"
			dataColumn = dataTable.Columns["DEPOSITO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_NOMBRE = (string)row[dataColumn];
			// Column "DEPOSITO_ABREVIATURA"
			dataColumn = dataTable.Columns["DEPOSITO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ABREVIATURA = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "VENDEDOR_CODIGO"
			dataColumn = dataTable.Columns["VENDEDOR_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_CODIGO = (string)row[dataColumn];
			// Column "VENDEDOR_ID"
			dataColumn = dataTable.Columns["VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR_NOMBRE"
			dataColumn = dataTable.Columns["VENDEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PERSONA_RUC"
			dataColumn = dataTable.Columns["PERSONA_RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_RUC = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "PERSONA_PAIS_RESIDENCIA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_PAIS_RESIDENCIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_PAIS_RESIDENCIA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_GARANTE_1_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_1_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_2_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_2_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_3_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_3_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_3_ID = (decimal)row[dataColumn];
			// Column "TIPO_FACTURA_ID"
			dataColumn = dataTable.Columns["TIPO_FACTURA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FACTURA_ID = (string)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_TIMBRADO"
			dataColumn = dataTable.Columns["AUTONUMERACION_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_TIMBRADO = (string)row[dataColumn];
			// Column "AUTONUMERACIONES_CODIGO"
			dataColumn = dataTable.Columns["AUTONUMERACIONES_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACIONES_CODIGO = (string)row[dataColumn];
			// Column "VIGENCIADESDE"
			dataColumn = dataTable.Columns["VIGENCIADESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIGENCIADESDE = (System.DateTime)row[dataColumn];
			// Column "VIGENCIAHASTA"
			dataColumn = dataTable.Columns["VIGENCIAHASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIGENCIAHASTA = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "PORCENTAJE_DESC_SOBRE_TOTAL"
			dataColumn = dataTable.Columns["PORCENTAJE_DESC_SOBRE_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESC_SOBRE_TOTAL = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
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
			// Column "COTIZACION_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_DESTINO = (decimal)row[dataColumn];
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
			// Column "TOTAL_COSTO_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_COSTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COSTO_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_COSTO_NETO"
			dataColumn = dataTable.Columns["TOTAL_COSTO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COSTO_NETO = (decimal)row[dataColumn];
			// Column "TOTAL_COMISION_VENDEDOR"
			dataColumn = dataTable.Columns["TOTAL_COMISION_VENDEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COMISION_VENDEDOR = (decimal)row[dataColumn];
			// Column "TOTAL_ENTREGA_INICIAL"
			dataColumn = dataTable.Columns["TOTAL_ENTREGA_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_ENTREGA_INICIAL = (decimal)row[dataColumn];
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "USUARIO_ID_AUTORIZA_DESCUENTO"
			dataColumn = dataTable.Columns["USUARIO_ID_AUTORIZA_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID_AUTORIZA_DESCUENTO = (decimal)row[dataColumn];
			// Column "USUARIO_AUTORIZA_DTO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_AUTORIZA_DTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_AUTORIZA_DTO_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_AUTORIZACION_DESCUENTO"
			dataColumn = dataTable.Columns["FECHA_AUTORIZACION_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_AUTORIZACION_DESCUENTO = (System.DateTime)row[dataColumn];
			// Column "DESCUENTO_MAX_AUTORIZADO"
			dataColumn = dataTable.Columns["DESCUENTO_MAX_AUTORIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_MAX_AUTORIZADO = (decimal)row[dataColumn];
			// Column "AFECTA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["AFECTA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_LINEA_CREDITO = (string)row[dataColumn];
			// Column "AFECTA_CTACTE"
			dataColumn = dataTable.Columns["AFECTA_CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE = (string)row[dataColumn];
			// Column "AFECTA_STOCK"
			dataColumn = dataTable.Columns["AFECTA_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_STOCK = (string)row[dataColumn];
			// Column "GENERAR_TRANSFERENCIA"
			dataColumn = dataTable.Columns["GENERAR_TRANSFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_TRANSFERENCIA = (string)row[dataColumn];
			// Column "DEPOSITO_DESTINO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "DEPOSITO_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["DEPOSITO_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "MONTO_AFECTA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["MONTO_AFECTA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_AFECTA_LINEA_CREDITO = (decimal)row[dataColumn];
			// Column "COMISION_POR_VENTA"
			dataColumn = dataTable.Columns["COMISION_POR_VENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_POR_VENTA = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CONTROLAR_CANT_MIN_DESC_MAX"
			dataColumn = dataTable.Columns["CONTROLAR_CANT_MIN_DESC_MAX"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROLAR_CANT_MIN_DESC_MAX = (string)row[dataColumn];
			// Column "CONDICION_DESCRIPCION"
			dataColumn = dataTable.Columns["CONDICION_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_DESCRIPCION = (string)row[dataColumn];
			// Column "PERSONA_DEPARTAMENTO1_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_DEPARTAMENTO1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DEPARTAMENTO1_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CIUDAD1_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_CIUDAD1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CIUDAD1_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_BARRIO1_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_BARRIO1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_BARRIO1_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CALLE1"
			dataColumn = dataTable.Columns["PERSONA_CALLE1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CALLE1 = (string)row[dataColumn];
			// Column "PERSONA_DEPARTAMENTO2_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_DEPARTAMENTO2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DEPARTAMENTO2_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CIUDAD2_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_CIUDAD2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CIUDAD2_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_BARRIO2_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_BARRIO2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_BARRIO2_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CALLE2"
			dataColumn = dataTable.Columns["PERSONA_CALLE2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CALLE2 = (string)row[dataColumn];
			// Column "PERSONA_DEPTO_COBRANZA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_DEPTO_COBRANZA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DEPTO_COBRANZA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CIUDAD_COBRANZA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_CIUDAD_COBRANZA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CIUDAD_COBRANZA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_BARRIO_COBRANZA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_BARRIO_COBRANZA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_BARRIO_COBRANZA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CALLE_COBRANZA"
			dataColumn = dataTable.Columns["PERSONA_CALLE_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CALLE_COBRANZA = (string)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO_NOMBRE"
			dataColumn = dataTable.Columns["CONDICION_PAGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_NOMBRE = (string)row[dataColumn];
			// Column "A_CONSIGNACION"
			dataColumn = dataTable.Columns["A_CONSIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_CONSIGNACION = (string)row[dataColumn];
			// Column "CASO_REPARTO_VINCULA_FC"
			dataColumn = dataTable.Columns["CASO_REPARTO_VINCULA_FC"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_REPARTO_VINCULA_FC = (decimal)row[dataColumn];
			// Column "DIRECCION"
			dataColumn = dataTable.Columns["DIRECCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION = (string)row[dataColumn];
			// Column "LATITUD"
			dataColumn = dataTable.Columns["LATITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD = (decimal)row[dataColumn];
			// Column "LONGITUD"
			dataColumn = dataTable.Columns["LONGITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD = (decimal)row[dataColumn];
			// Column "OBSERVACION_ENTREGA"
			dataColumn = dataTable.Columns["OBSERVACION_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_ENTREGA = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "MORA_PORCENTAJE"
			dataColumn = dataTable.Columns["MORA_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_PORCENTAJE = (decimal)row[dataColumn];
			// Column "MORA_DIAS_GRACIA"
			dataColumn = dataTable.Columns["MORA_DIAS_GRACIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_DIAS_GRACIA = (decimal)row[dataColumn];
			// Column "NRO_DOCUMENTO_EXTERNO"
			dataColumn = dataTable.Columns["NRO_DOCUMENTO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_DOCUMENTO_EXTERNO = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE_SECUENCIA"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_SECUENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_SECUENCIA = (decimal)row[dataColumn];
			// Column "TIPO_CONDICION_PAGO"
			dataColumn = dataTable.Columns["TIPO_CONDICION_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONDICION_PAGO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TIPO_CLIENTE_ID"
			dataColumn = dataTable.Columns["TIPO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "TIPO_CLIENTES_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_CLIENTES_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTES_NOMBRE = (string)row[dataColumn];
			// Column "AUTONUMERACION_TRANSF_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_TRANSF_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_TRANSF_ID = (decimal)row[dataColumn];
			// Column "NRO_TIMBRADO_FACT_PRO"
			dataColumn = dataTable.Columns["NRO_TIMBRADO_FACT_PRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TIMBRADO_FACT_PRO = (string)row[dataColumn];
			// Column "FECHA_VENC_TIMBRADO_FACT_PRO"
			dataColumn = dataTable.Columns["FECHA_VENC_TIMBRADO_FACT_PRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENC_TIMBRADO_FACT_PRO = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE_FACT_PRO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_FACT_PRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_FACT_PRO = (string)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "ES_RAPIDA"
			dataColumn = dataTable.Columns["ES_RAPIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_RAPIDA = (string)row[dataColumn];
			// Column "TOTAL_LETRAS"
			dataColumn = dataTable.Columns["TOTAL_LETRAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_LETRAS = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_CLIENTE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_CLIENTE_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_VENTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_VENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_VENTA_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_RUC", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_PAIS_RESIDENCIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_3_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_FACTURA_ID", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACIONES_CODIGO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VIGENCIADESDE", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VIGENCIAHASTA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESC_SOBRE_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
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
			dataColumn = dataTable.Columns.Add("COTIZACION_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COMISION_VENDEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_ENTREGA_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID_AUTORIZA_DESCUENTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_AUTORIZA_DTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_AUTORIZACION_DESCUENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAX_AUTORIZADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_LINEA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERAR_TRANSFERENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_AFECTA_LINEA_CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMISION_POR_VENTA", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTROLAR_CANT_MIN_DESC_MAX", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DEPARTAMENTO1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CIUDAD1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_BARRIO1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CALLE1", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DEPARTAMENTO2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CIUDAD2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_BARRIO2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CALLE2", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DEPTO_COBRANZA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CIUDAD_COBRANZA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_BARRIO_COBRANZA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CALLE_COBRANZA", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("A_CONSIGNACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_REPARTO_VINCULA_FC", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIRECCION", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION_ENTREGA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MORA_PORCENTAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MORA_DIAS_GRACIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_DOCUMENTO_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_SECUENCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CONDICION_PAGO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTES_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_TRANSF_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_TIMBRADO_FACT_PRO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENC_TIMBRADO_FACT_PRO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_FACT_PRO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_RAPIDA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_LETRAS", typeof(string));
			dataColumn.MaxLength = 4000;
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

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_VENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_VENTA_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VENDEDOR_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_PAIS_RESIDENCIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_GARANTE_1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_3_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_FACTURA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACIONES_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VIGENCIADESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VIGENCIAHASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PORCENTAJE_DESC_SOBRE_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_ID":
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

				case "COTIZACION_DESTINO":
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

				case "TOTAL_COSTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COSTO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COMISION_VENDEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_ENTREGA_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID_AUTORIZA_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_AUTORIZA_DTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_AUTORIZACION_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESCUENTO_MAX_AUTORIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AFECTA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CTACTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GENERAR_TRANSFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DEPOSITO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_AFECTA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_POR_VENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTROLAR_CANT_MIN_DESC_MAX":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONDICION_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DEPARTAMENTO1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CIUDAD1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_BARRIO1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CALLE1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DEPARTAMENTO2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CIUDAD2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_BARRIO2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CALLE2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DEPTO_COBRANZA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CIUDAD_COBRANZA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_BARRIO_COBRANZA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CALLE_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "A_CONSIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_REPARTO_VINCULA_FC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIRECCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MORA_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MORA_DIAS_GRACIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_DOCUMENTO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE_SECUENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CONDICION_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CLIENTES_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_TRANSF_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_TIMBRADO_FACT_PRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VENC_TIMBRADO_FACT_PRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE_FACT_PRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_RAPIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TOTAL_LETRAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_CLIENTE_INFO_COMPLETACollection_Base class
}  // End of namespace
