// <fileinfo name="FACTURAS_PROVEEDOR_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_PROVEEDOR_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_PROVEEDOR_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_PROVEEDOR_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string PAGAR_POR_FONDO_FIJOColumnName = "PAGAR_POR_FONDO_FIJO";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PROVEEDOR_NOMBREColumnName = "PROVEEDOR_NOMBRE";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string STOCK_DEPOSITO_IDColumnName = "STOCK_DEPOSITO_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string RUBRO_NOMBREColumnName = "RUBRO_NOMBRE";
		public const string STOCK_DEPOSITO_NOMBREColumnName = "STOCK_DEPOSITO_NOMBRE";
		public const string STOCK_DEPOSITO_ABREVIATURAColumnName = "STOCK_DEPOSITO_ABREVIATURA";
		public const string FECHAColumnName = "FECHA";
		public const string FECHA_FACTURAColumnName = "FECHA_FACTURA";
		public const string FECHA_RECEPCIONColumnName = "FECHA_RECEPCION";
		public const string FECHA_VENCIMIENTO_TIMBRADOColumnName = "FECHA_VENCIMIENTO_TIMBRADO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string NUMERO_CONTRATOColumnName = "NUMERO_CONTRATO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_COTIZACIONColumnName = "MONEDA_COTIZACION";
		public const string MONEDA_PAIS_COTIZACIONColumnName = "MONEDA_PAIS_COTIZACION";
		public const string CTACTE_CONDICION_PAGO_IDColumnName = "CTACTE_CONDICION_PAGO_ID";
		public const string CTACTE_CONDICION_PAGO_NOMBREColumnName = "CTACTE_CONDICION_PAGO_NOMBRE";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string ESTADO_DOCUMENTACION_NOMBREColumnName = "ESTADO_DOCUMENTACION_NOMBRE";
		public const string TIPO_CONTENEDOR_IDColumnName = "TIPO_CONTENEDOR_ID";
		public const string TIPO_CONTENEDOR_NOMBREColumnName = "TIPO_CONTENEDOR_NOMBRE";
		public const string CANTIDAD_CONTENEDORESColumnName = "CANTIDAD_CONTENEDORES";
		public const string TIPO_EMBARQUE_IDColumnName = "TIPO_EMBARQUE_ID";
		public const string TIPO_EMBARQUE_NOMBREColumnName = "TIPO_EMBARQUE_NOMBRE";
		public const string TOTAL_BRUTOColumnName = "TOTAL_BRUTO";
		public const string TOTAL_DESCUENTOColumnName = "TOTAL_DESCUENTO";
		public const string TOTAL_IMPUESTOColumnName = "TOTAL_IMPUESTO";
		public const string TOTAL_PAGOColumnName = "TOTAL_PAGO";
		public const string IMPORTACION_IDColumnName = "IMPORTACION_ID";
		public const string PASIBLE_RETENCIONColumnName = "PASIBLE_RETENCION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string NRO_TIMBRADOColumnName = "NRO_TIMBRADO";
		public const string TIPO_FACTURA_PROVEEDOR_IDColumnName = "TIPO_FACTURA_PROVEEDOR_ID";
		public const string TIPO_FACTURA_PROVEEDOR_NOMBREColumnName = "TIPO_FACTURA_PROVEEDOR_NOMBRE";
		public const string AFECTA_CTACTE_PROVEEDORColumnName = "AFECTA_CTACTE_PROVEEDOR";
		public const string AFECTA_CTACTE_PERSONAColumnName = "AFECTA_CTACTE_PERSONA";
		public const string AFECTA_CRED_FISCAL_EMPRESAColumnName = "AFECTA_CRED_FISCAL_EMPRESA";
		public const string AFECTA_CRED_FISCAL_PERSONAColumnName = "AFECTA_CRED_FISCAL_PERSONA";
		public const string PORC_PROR_IMPORTColumnName = "PORC_PROR_IMPORT";
		public const string NRO_DOCUMENTO_EXTERNOColumnName = "NRO_DOCUMENTO_EXTERNO";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string PORCENTAJE_DESC_SOBRE_TOTALColumnName = "PORCENTAJE_DESC_SOBRE_TOTAL";
		public const string ES_TICKETColumnName = "ES_TICKET";
		public const string PROVEEDOR_GASTO_IDColumnName = "PROVEEDOR_GASTO_ID";
		public const string PROVEEDOR_GASTO_NOMBREColumnName = "PROVEEDOR_GASTO_NOMBRE";
		public const string DIRECCION_LUGAR_TRANSACCIONColumnName = "DIRECCION_LUGAR_TRANSACCION";
		public const string EGRESO_VARIO_CAJA_AUTONUM_IDColumnName = "EGRESO_VARIO_CAJA_AUTONUM_ID";
		public const string EGRESO_VARIO_CAJA_NRO_COMPRColumnName = "EGRESO_VARIO_CAJA_NRO_COMPR";
		public const string CENTRO_COSTO_OBLIGATORIOColumnName = "CENTRO_COSTO_OBLIGATORIO";
		public const string EGRESO_VARIO_CAJA_FECHAColumnName = "EGRESO_VARIO_CAJA_FECHA";
		public const string ORDEN_PAGO_CTACTE_BANCARIA_IDColumnName = "ORDEN_PAGO_CTACTE_BANCARIA_ID";
		public const string APLICAR_PRORRATEO_SERVICIOSColumnName = "APLICAR_PRORRATEO_SERVICIOS";
		public const string PAGO_CONTRATISTA_DETALLE_IDColumnName = "PAGO_CONTRATISTA_DETALLE_ID";
		public const string ES_FACT_ELECTRONICAColumnName = "ES_FACT_ELECTRONICA";
		public const string TIPO_MOVIMIENTO_SETColumnName = "TIPO_MOVIMIENTO_SET";
		public const string CTB_TIPO_COMPROBANTE_SET_IDColumnName = "CTB_TIPO_COMPROBANTE_SET_ID";
		public const string IMPUTA_IVAColumnName = "IMPUTA_IVA";
		public const string IMPUTA_IREColumnName = "IMPUTA_IRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_PROVEEDOR_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_PROVEEDOR_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURAS_PROVEEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_PROVEEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_PROVEEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_PROVEEDOR_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_PROVEEDOR_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects.</returns>
		public FACTURAS_PROVEEDOR_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDOR_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_PROVEEDOR_INFO_COMP";
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects.</returns>
		protected FACTURAS_PROVEEDOR_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects.</returns>
		protected FACTURAS_PROVEEDOR_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> objects.</returns>
		protected virtual FACTURAS_PROVEEDOR_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int pagar_por_fondo_fijoColumnIndex = reader.GetOrdinal("PAGAR_POR_FONDO_FIJO");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int proveedor_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_NOMBRE");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int stock_deposito_idColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int rubro_nombreColumnIndex = reader.GetOrdinal("RUBRO_NOMBRE");
			int stock_deposito_nombreColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_NOMBRE");
			int stock_deposito_abreviaturaColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_ABREVIATURA");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int fecha_facturaColumnIndex = reader.GetOrdinal("FECHA_FACTURA");
			int fecha_recepcionColumnIndex = reader.GetOrdinal("FECHA_RECEPCION");
			int fecha_vencimiento_timbradoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_TIMBRADO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int numero_contratoColumnIndex = reader.GetOrdinal("NUMERO_CONTRATO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_COTIZACION");
			int moneda_pais_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_PAIS_COTIZACION");
			int ctacte_condicion_pago_idColumnIndex = reader.GetOrdinal("CTACTE_CONDICION_PAGO_ID");
			int ctacte_condicion_pago_nombreColumnIndex = reader.GetOrdinal("CTACTE_CONDICION_PAGO_NOMBRE");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int estado_documentacion_nombreColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_NOMBRE");
			int tipo_contenedor_idColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_ID");
			int tipo_contenedor_nombreColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_NOMBRE");
			int cantidad_contenedoresColumnIndex = reader.GetOrdinal("CANTIDAD_CONTENEDORES");
			int tipo_embarque_idColumnIndex = reader.GetOrdinal("TIPO_EMBARQUE_ID");
			int tipo_embarque_nombreColumnIndex = reader.GetOrdinal("TIPO_EMBARQUE_NOMBRE");
			int total_brutoColumnIndex = reader.GetOrdinal("TOTAL_BRUTO");
			int total_descuentoColumnIndex = reader.GetOrdinal("TOTAL_DESCUENTO");
			int total_impuestoColumnIndex = reader.GetOrdinal("TOTAL_IMPUESTO");
			int total_pagoColumnIndex = reader.GetOrdinal("TOTAL_PAGO");
			int importacion_idColumnIndex = reader.GetOrdinal("IMPORTACION_ID");
			int pasible_retencionColumnIndex = reader.GetOrdinal("PASIBLE_RETENCION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int nro_timbradoColumnIndex = reader.GetOrdinal("NRO_TIMBRADO");
			int tipo_factura_proveedor_idColumnIndex = reader.GetOrdinal("TIPO_FACTURA_PROVEEDOR_ID");
			int tipo_factura_proveedor_nombreColumnIndex = reader.GetOrdinal("TIPO_FACTURA_PROVEEDOR_NOMBRE");
			int afecta_ctacte_proveedorColumnIndex = reader.GetOrdinal("AFECTA_CTACTE_PROVEEDOR");
			int afecta_ctacte_personaColumnIndex = reader.GetOrdinal("AFECTA_CTACTE_PERSONA");
			int afecta_cred_fiscal_empresaColumnIndex = reader.GetOrdinal("AFECTA_CRED_FISCAL_EMPRESA");
			int afecta_cred_fiscal_personaColumnIndex = reader.GetOrdinal("AFECTA_CRED_FISCAL_PERSONA");
			int porc_pror_importColumnIndex = reader.GetOrdinal("PORC_PROR_IMPORT");
			int nro_documento_externoColumnIndex = reader.GetOrdinal("NRO_DOCUMENTO_EXTERNO");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int porcentaje_desc_sobre_totalColumnIndex = reader.GetOrdinal("PORCENTAJE_DESC_SOBRE_TOTAL");
			int es_ticketColumnIndex = reader.GetOrdinal("ES_TICKET");
			int proveedor_gasto_idColumnIndex = reader.GetOrdinal("PROVEEDOR_GASTO_ID");
			int proveedor_gasto_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_GASTO_NOMBRE");
			int direccion_lugar_transaccionColumnIndex = reader.GetOrdinal("DIRECCION_LUGAR_TRANSACCION");
			int egreso_vario_caja_autonum_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_AUTONUM_ID");
			int egreso_vario_caja_nro_comprColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_NRO_COMPR");
			int centro_costo_obligatorioColumnIndex = reader.GetOrdinal("CENTRO_COSTO_OBLIGATORIO");
			int egreso_vario_caja_fechaColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_FECHA");
			int orden_pago_ctacte_bancaria_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_CTACTE_BANCARIA_ID");
			int aplicar_prorrateo_serviciosColumnIndex = reader.GetOrdinal("APLICAR_PRORRATEO_SERVICIOS");
			int pago_contratista_detalle_idColumnIndex = reader.GetOrdinal("PAGO_CONTRATISTA_DETALLE_ID");
			int es_fact_electronicaColumnIndex = reader.GetOrdinal("ES_FACT_ELECTRONICA");
			int tipo_movimiento_setColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO_SET");
			int ctb_tipo_comprobante_set_idColumnIndex = reader.GetOrdinal("CTB_TIPO_COMPROBANTE_SET_ID");
			int imputa_ivaColumnIndex = reader.GetOrdinal("IMPUTA_IVA");
			int imputa_ireColumnIndex = reader.GetOrdinal("IMPUTA_IRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_PROVEEDOR_INFO_COMPRow record = new FACTURAS_PROVEEDOR_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.PAGAR_POR_FONDO_FIJO = Convert.ToString(reader.GetValue(pagar_por_fondo_fijoColumnIndex));
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_nombreColumnIndex))
						record.PROVEEDOR_NOMBRE = Convert.ToString(reader.GetValue(proveedor_nombreColumnIndex));
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					record.STOCK_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_nombreColumnIndex))
						record.RUBRO_NOMBRE = Convert.ToString(reader.GetValue(rubro_nombreColumnIndex));
					record.STOCK_DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(stock_deposito_nombreColumnIndex));
					record.STOCK_DEPOSITO_ABREVIATURA = Convert.ToString(reader.GetValue(stock_deposito_abreviaturaColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(fecha_facturaColumnIndex))
						record.FECHA_FACTURA = Convert.ToDateTime(reader.GetValue(fecha_facturaColumnIndex));
					if(!reader.IsDBNull(fecha_recepcionColumnIndex))
						record.FECHA_RECEPCION = Convert.ToDateTime(reader.GetValue(fecha_recepcionColumnIndex));
					record.FECHA_VENCIMIENTO_TIMBRADO = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_timbradoColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(numero_contratoColumnIndex))
						record.NUMERO_CONTRATO = Convert.ToString(reader.GetValue(numero_contratoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cotizacionColumnIndex)), 9);
					record.MONEDA_PAIS_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_pais_cotizacionColumnIndex)), 9);
					record.CTACTE_CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_condicion_pago_idColumnIndex)), 9);
					record.CTACTE_CONDICION_PAGO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_condicion_pago_nombreColumnIndex));
					if(!reader.IsDBNull(estado_documentacion_idColumnIndex))
						record.ESTADO_DOCUMENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_documentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_documentacion_nombreColumnIndex))
						record.ESTADO_DOCUMENTACION_NOMBRE = Convert.ToString(reader.GetValue(estado_documentacion_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_contenedor_idColumnIndex))
						record.TIPO_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_contenedor_nombreColumnIndex))
						record.TIPO_CONTENEDOR_NOMBRE = Convert.ToString(reader.GetValue(tipo_contenedor_nombreColumnIndex));
					if(!reader.IsDBNull(cantidad_contenedoresColumnIndex))
						record.CANTIDAD_CONTENEDORES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_contenedoresColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_embarque_idColumnIndex))
						record.TIPO_EMBARQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_embarque_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_embarque_nombreColumnIndex))
						record.TIPO_EMBARQUE_NOMBRE = Convert.ToString(reader.GetValue(tipo_embarque_nombreColumnIndex));
					if(!reader.IsDBNull(total_brutoColumnIndex))
						record.TOTAL_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_descuentoColumnIndex))
						record.TOTAL_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(total_impuestoColumnIndex))
						record.TOTAL_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(total_pagoColumnIndex))
						record.TOTAL_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(total_pagoColumnIndex)), 9);
					if(!reader.IsDBNull(importacion_idColumnIndex))
						record.IMPORTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_idColumnIndex)), 9);
					record.PASIBLE_RETENCION = Convert.ToString(reader.GetValue(pasible_retencionColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_timbradoColumnIndex))
						record.NRO_TIMBRADO = Convert.ToString(reader.GetValue(nro_timbradoColumnIndex));
					record.TIPO_FACTURA_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_factura_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_factura_proveedor_nombreColumnIndex))
						record.TIPO_FACTURA_PROVEEDOR_NOMBRE = Convert.ToString(reader.GetValue(tipo_factura_proveedor_nombreColumnIndex));
					record.AFECTA_CTACTE_PROVEEDOR = Convert.ToString(reader.GetValue(afecta_ctacte_proveedorColumnIndex));
					record.AFECTA_CTACTE_PERSONA = Convert.ToString(reader.GetValue(afecta_ctacte_personaColumnIndex));
					record.AFECTA_CRED_FISCAL_EMPRESA = Convert.ToString(reader.GetValue(afecta_cred_fiscal_empresaColumnIndex));
					record.AFECTA_CRED_FISCAL_PERSONA = Convert.ToString(reader.GetValue(afecta_cred_fiscal_personaColumnIndex));
					if(!reader.IsDBNull(porc_pror_importColumnIndex))
						record.PORC_PROR_IMPORT = Math.Round(Convert.ToDecimal(reader.GetValue(porc_pror_importColumnIndex)), 9);
					if(!reader.IsDBNull(nro_documento_externoColumnIndex))
						record.NRO_DOCUMENTO_EXTERNO = Convert.ToString(reader.GetValue(nro_documento_externoColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					record.PORCENTAJE_DESC_SOBRE_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_desc_sobre_totalColumnIndex)), 9);
					record.ES_TICKET = Convert.ToString(reader.GetValue(es_ticketColumnIndex));
					if(!reader.IsDBNull(proveedor_gasto_idColumnIndex))
						record.PROVEEDOR_GASTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_gasto_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_gasto_nombreColumnIndex))
						record.PROVEEDOR_GASTO_NOMBRE = Convert.ToString(reader.GetValue(proveedor_gasto_nombreColumnIndex));
					if(!reader.IsDBNull(direccion_lugar_transaccionColumnIndex))
						record.DIRECCION_LUGAR_TRANSACCION = Convert.ToString(reader.GetValue(direccion_lugar_transaccionColumnIndex));
					if(!reader.IsDBNull(egreso_vario_caja_autonum_idColumnIndex))
						record.EGRESO_VARIO_CAJA_AUTONUM_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_autonum_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_nro_comprColumnIndex))
						record.EGRESO_VARIO_CAJA_NRO_COMPR = Convert.ToString(reader.GetValue(egreso_vario_caja_nro_comprColumnIndex));
					record.CENTRO_COSTO_OBLIGATORIO = Convert.ToString(reader.GetValue(centro_costo_obligatorioColumnIndex));
					if(!reader.IsDBNull(egreso_vario_caja_fechaColumnIndex))
						record.EGRESO_VARIO_CAJA_FECHA = Convert.ToDateTime(reader.GetValue(egreso_vario_caja_fechaColumnIndex));
					if(!reader.IsDBNull(orden_pago_ctacte_bancaria_idColumnIndex))
						record.ORDEN_PAGO_CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_ctacte_bancaria_idColumnIndex)), 9);
					record.APLICAR_PRORRATEO_SERVICIOS = Convert.ToString(reader.GetValue(aplicar_prorrateo_serviciosColumnIndex));
					if(!reader.IsDBNull(pago_contratista_detalle_idColumnIndex))
						record.PAGO_CONTRATISTA_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pago_contratista_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(es_fact_electronicaColumnIndex))
						record.ES_FACT_ELECTRONICA = Convert.ToString(reader.GetValue(es_fact_electronicaColumnIndex));
					if(!reader.IsDBNull(tipo_movimiento_setColumnIndex))
						record.TIPO_MOVIMIENTO_SET = Convert.ToString(reader.GetValue(tipo_movimiento_setColumnIndex));
					if(!reader.IsDBNull(ctb_tipo_comprobante_set_idColumnIndex))
						record.CTB_TIPO_COMPROBANTE_SET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_tipo_comprobante_set_idColumnIndex)), 9);
					if(!reader.IsDBNull(imputa_ivaColumnIndex))
						record.IMPUTA_IVA = Convert.ToString(reader.GetValue(imputa_ivaColumnIndex));
					if(!reader.IsDBNull(imputa_ireColumnIndex))
						record.IMPUTA_IRE = Convert.ToString(reader.GetValue(imputa_ireColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_PROVEEDOR_INFO_COMPRow[])(recordList.ToArray(typeof(FACTURAS_PROVEEDOR_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_PROVEEDOR_INFO_COMPRow"/> object.</returns>
		protected virtual FACTURAS_PROVEEDOR_INFO_COMPRow MapRow(DataRow row)
		{
			FACTURAS_PROVEEDOR_INFO_COMPRow mappedObject = new FACTURAS_PROVEEDOR_INFO_COMPRow();
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
			// Column "PAGAR_POR_FONDO_FIJO"
			dataColumn = dataTable.Columns["PAGAR_POR_FONDO_FIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGAR_POR_FONDO_FIJO = (string)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "STOCK_DEPOSITO_ID"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_NOMBRE"
			dataColumn = dataTable.Columns["RUBRO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_NOMBRE = (string)row[dataColumn];
			// Column "STOCK_DEPOSITO_NOMBRE"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_NOMBRE = (string)row[dataColumn];
			// Column "STOCK_DEPOSITO_ABREVIATURA"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_ABREVIATURA = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FECHA_FACTURA"
			dataColumn = dataTable.Columns["FECHA_FACTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FACTURA = (System.DateTime)row[dataColumn];
			// Column "FECHA_RECEPCION"
			dataColumn = dataTable.Columns["FECHA_RECEPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECEPCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_TIMBRADO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_TIMBRADO = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NUMERO_CONTRATO"
			dataColumn = dataTable.Columns["NUMERO_CONTRATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CONTRATO = (string)row[dataColumn];
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
			// Column "MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "MONEDA_PAIS_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_PAIS_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_PAIS_COTIZACION = (decimal)row[dataColumn];
			// Column "CTACTE_CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CONDICION_PAGO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CONDICION_PAGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONDICION_PAGO_NOMBRE = (string)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_ID"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_ID = (decimal)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_NOMBRE"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "TIPO_CONTENEDOR_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_NOMBRE = (string)row[dataColumn];
			// Column "CANTIDAD_CONTENEDORES"
			dataColumn = dataTable.Columns["CANTIDAD_CONTENEDORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CONTENEDORES = (decimal)row[dataColumn];
			// Column "TIPO_EMBARQUE_ID"
			dataColumn = dataTable.Columns["TIPO_EMBARQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMBARQUE_ID = (decimal)row[dataColumn];
			// Column "TIPO_EMBARQUE_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_EMBARQUE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMBARQUE_NOMBRE = (string)row[dataColumn];
			// Column "TOTAL_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_DESCUENTO"
			dataColumn = dataTable.Columns["TOTAL_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DESCUENTO = (decimal)row[dataColumn];
			// Column "TOTAL_IMPUESTO"
			dataColumn = dataTable.Columns["TOTAL_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPUESTO = (decimal)row[dataColumn];
			// Column "TOTAL_PAGO"
			dataColumn = dataTable.Columns["TOTAL_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_PAGO = (decimal)row[dataColumn];
			// Column "IMPORTACION_ID"
			dataColumn = dataTable.Columns["IMPORTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_ID = (decimal)row[dataColumn];
			// Column "PASIBLE_RETENCION"
			dataColumn = dataTable.Columns["PASIBLE_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASIBLE_RETENCION = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "NRO_TIMBRADO"
			dataColumn = dataTable.Columns["NRO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TIMBRADO = (string)row[dataColumn];
			// Column "TIPO_FACTURA_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_FACTURA_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FACTURA_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "TIPO_FACTURA_PROVEEDOR_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_FACTURA_PROVEEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FACTURA_PROVEEDOR_NOMBRE = (string)row[dataColumn];
			// Column "AFECTA_CTACTE_PROVEEDOR"
			dataColumn = dataTable.Columns["AFECTA_CTACTE_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE_PROVEEDOR = (string)row[dataColumn];
			// Column "AFECTA_CTACTE_PERSONA"
			dataColumn = dataTable.Columns["AFECTA_CTACTE_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE_PERSONA = (string)row[dataColumn];
			// Column "AFECTA_CRED_FISCAL_EMPRESA"
			dataColumn = dataTable.Columns["AFECTA_CRED_FISCAL_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CRED_FISCAL_EMPRESA = (string)row[dataColumn];
			// Column "AFECTA_CRED_FISCAL_PERSONA"
			dataColumn = dataTable.Columns["AFECTA_CRED_FISCAL_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CRED_FISCAL_PERSONA = (string)row[dataColumn];
			// Column "PORC_PROR_IMPORT"
			dataColumn = dataTable.Columns["PORC_PROR_IMPORT"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORC_PROR_IMPORT = (decimal)row[dataColumn];
			// Column "NRO_DOCUMENTO_EXTERNO"
			dataColumn = dataTable.Columns["NRO_DOCUMENTO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_DOCUMENTO_EXTERNO = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DESC_SOBRE_TOTAL"
			dataColumn = dataTable.Columns["PORCENTAJE_DESC_SOBRE_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESC_SOBRE_TOTAL = (decimal)row[dataColumn];
			// Column "ES_TICKET"
			dataColumn = dataTable.Columns["ES_TICKET"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TICKET = (string)row[dataColumn];
			// Column "PROVEEDOR_GASTO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_GASTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_GASTO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_GASTO_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_GASTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_GASTO_NOMBRE = (string)row[dataColumn];
			// Column "DIRECCION_LUGAR_TRANSACCION"
			dataColumn = dataTable.Columns["DIRECCION_LUGAR_TRANSACCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_LUGAR_TRANSACCION = (string)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_AUTONUM_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_AUTONUM_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_AUTONUM_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_NRO_COMPR"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_NRO_COMPR"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_NRO_COMPR = (string)row[dataColumn];
			// Column "CENTRO_COSTO_OBLIGATORIO"
			dataColumn = dataTable.Columns["CENTRO_COSTO_OBLIGATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_OBLIGATORIO = (string)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_FECHA"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_FECHA = (System.DateTime)row[dataColumn];
			// Column "ORDEN_PAGO_CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "APLICAR_PRORRATEO_SERVICIOS"
			dataColumn = dataTable.Columns["APLICAR_PRORRATEO_SERVICIOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICAR_PRORRATEO_SERVICIOS = (string)row[dataColumn];
			// Column "PAGO_CONTRATISTA_DETALLE_ID"
			dataColumn = dataTable.Columns["PAGO_CONTRATISTA_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGO_CONTRATISTA_DETALLE_ID = (decimal)row[dataColumn];
			// Column "ES_FACT_ELECTRONICA"
			dataColumn = dataTable.Columns["ES_FACT_ELECTRONICA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_FACT_ELECTRONICA = (string)row[dataColumn];
			// Column "TIPO_MOVIMIENTO_SET"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO_SET"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO_SET = (string)row[dataColumn];
			// Column "CTB_TIPO_COMPROBANTE_SET_ID"
			dataColumn = dataTable.Columns["CTB_TIPO_COMPROBANTE_SET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_TIPO_COMPROBANTE_SET_ID = (decimal)row[dataColumn];
			// Column "IMPUTA_IVA"
			dataColumn = dataTable.Columns["IMPUTA_IVA"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUTA_IVA = (string)row[dataColumn];
			// Column "IMPUTA_IRE"
			dataColumn = dataTable.Columns["IMPUTA_IRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUTA_IRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_PROVEEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_PROVEEDOR_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAGAR_POR_FONDO_FIJO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FACTURA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_RECEPCION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_TIMBRADO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CONTRATO", typeof(string));
			dataColumn.MaxLength = 50;
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
			dataColumn = dataTable.Columns.Add("MONEDA_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_PAIS_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CONDICION_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CONDICION_PAGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CONTENEDORES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_EMBARQUE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_EMBARQUE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_DESCUENTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_PAGO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PASIBLE_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_FACTURA_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_FACTURA_PROVEEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_CRED_FISCAL_EMPRESA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_CRED_FISCAL_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORC_PROR_IMPORT", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_DOCUMENTO_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESC_SOBRE_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_TICKET", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_GASTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_GASTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIRECCION_LUGAR_TRANSACCION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_AUTONUM_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_NRO_COMPR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_OBLIGATORIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APLICAR_PRORRATEO_SERVICIOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAGO_CONTRATISTA_DETALLE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_FACT_ELECTRONICA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO_SET", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_TIPO_COMPROBANTE_SET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUTA_IVA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUTA_IRE", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "PAGAR_POR_FONDO_FIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "STOCK_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "STOCK_DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "STOCK_DEPOSITO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FACTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_RECEPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CONTRATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_PAIS_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONDICION_PAGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_DOCUMENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_DOCUMENTACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CONTENEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CONTENEDORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_EMBARQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_EMBARQUE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PASIBLE_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_FACTURA_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_FACTURA_PROVEEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AFECTA_CTACTE_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CTACTE_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CRED_FISCAL_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CRED_FISCAL_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PORC_PROR_IMPORT":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_DOCUMENTO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DESC_SOBRE_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_TICKET":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROVEEDOR_GASTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_GASTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_LUGAR_TRANSACCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EGRESO_VARIO_CAJA_AUTONUM_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_NRO_COMPR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CENTRO_COSTO_OBLIGATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EGRESO_VARIO_CAJA_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ORDEN_PAGO_CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICAR_PRORRATEO_SERVICIOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PAGO_CONTRATISTA_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_FACT_ELECTRONICA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_MOVIMIENTO_SET":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_TIPO_COMPROBANTE_SET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUTA_IVA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUTA_IRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_PROVEEDOR_INFO_COMPCollection_Base class
}  // End of namespace
